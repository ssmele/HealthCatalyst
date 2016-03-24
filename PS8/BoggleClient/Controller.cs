using System;
using System.Text;
using System.Dynamic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace BoggleClient
{
    public class Controller
    {

        private IBoggleWindow window;

        private string player1Token;

        private string gameID;

        private CancellationTokenSource source;

        CancellationToken token;
 
        string boardString;

        private string Default_URL = @"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc";

        private bool Cancel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="window"></param>
        public Controller(IBoggleWindow window)
        {
            this.window = window;
            window.CloseWindowEvent += HandleCloseWindowEvent;
            window.HelpEvent1 += HandleHelp1Event;
            window.HelpEvent2 += HandleHelp2Event;
            window.ConnectEvent += HandleConnectEvent;
            window.WordSubmitEvent += HandleSubmitWordEvent;
            window.CancelEvent += HandleCancelEvent;
            window.NewEvent += HandleNew;
            source = new CancellationTokenSource();
            token = source.Token;
            window.statusBox = "Idle";
        }

        /// <summary>
        /// Opens a new window
        /// </summary>
        public void HandleNew()
        {
            window.NewWindow();
        }

        /// <summary>
        /// This event sets Cancel to true. 
        /// </summary>
        public void HandleCancelEvent()
        {
            Cancel = true;
            //CancellationTokenSource cancelSource = new CancellationTokenSource();
            source.Cancel();
        }

        /// <summary>
        /// Resets the GUI back to idle status
        /// </summary>
        public void RESET()
        {
            refreshBoard("");
            window.statusBox = "Idle";
            window.cancelButton = false;
            window.connectButton = true;
            Cancel = false;
            source.Dispose();
            source = new CancellationTokenSource();
            token = source.Token;
        }

        //TODO: WE have two async methods inside of a async method is that necessary or do we only need the one async method. 
        
        /// <summary>
        /// Things that happen when the connect button is clicked.  Game will either be pending or active
        /// </summary>
        public async void HandleConnectEvent()
        {
            refreshBoard("");
            window.player1WordList = "";
            window.player2WordList = "";
            window.player1NameBox = "";
            window.player2NameBox = "";
            //gameUrl = window.urlTextBox;
            window.urlTextBox = Default_URL;
            window.player1ScoreBox = "0";
            window.player2ScoreBox = "0";
            window.statusBox = "Trying to connect!";
            window.connectButton = false;
            window.cancelButton = true;
            if (window.timeLengthBox == "")
            {
                window.timeLengthBox = "60";
            }


            try {
                //Create user and get token.  (Asynchronas)
                player1Token = await createUser(window.playerBox);
                if (Cancel == true || player1Token == null)
                {
                    RESET();
                    return;
                }

                //TODO:Change Parse to try parse.
                // Attempting to join the game
                Pair gameInfo = await joinGame(player1Token, int.Parse(window.timeLengthBox));
                if (gameInfo == null || (Cancel == true && (string)gameInfo.Status == "Pending"))
                {
                    RESET();
                    return;
                }


                gameID = gameInfo.GameID.ToString();


                //string x = await gameStateBrief();

                if (Cancel == true && (string)gameInfo.Status == "Pending")
                {
                    RESET();
                    return;
                }


                if ((string)gameInfo.Status == "Created")
                {
                    startGame();
                }

                else if ((string)gameInfo.Status == "Accepted")
                {
                    bool ActiveGame = await pendingLoop();
                    if (ActiveGame == true)
                    {
                        startGame();
                    }
                }


                bool isGameOver = await activeLoop();
                if (isGameOver == true)
                {
                    endGame();
                }
            }
            catch(TaskCanceledException e)
            {
                RESET();
            }
        }

        /// <summary>
        /// Ends the game & resets the gui
        /// </summary>
        public void endGame()
        {
            //RESET ALL THE VARIABLES. 
            window.cancelButton = false;
            window.statusBox = "GAME OVER";

            if (int.Parse(window.player1ScoreBox) > int.Parse(window.player2ScoreBox))

            {
                window.errorMessage("Congratulations! " + window.player1NameBox + " is the winner!\nThe game has ended. If you would like to start another game simply press connect again. Feel free to keep the same url, nickname, and game duration as last game, or if you want to change them up that is fine too!");
            }
            else if (int.Parse(window.player2ScoreBox) > int.Parse(window.player1ScoreBox))
            {
                window.errorMessage("Congratulations! " + window.player2NameBox + " is the winner!\nThe game has ended. If you would like to start another game simply press connect again. Feel free to keep the same url, nickname, and game duration as last game, or if you want to change them up that is fine too!");
            }
            else
            {
                window.errorMessage("It's a tie!\nThe game has ended. If you would like to start another game simply press connect again. Feel free to keep the same url, nickname, and game duration as last game, or if you want to change them up that is fine too!");
            }
                window.connectButton = true;
        }

        /// <summary>
        /// Checks to see if the game is active or completed
        /// </summary>
        /// <returns></returns>
        public async Task<bool> activeLoop()
        {
            bool keepLooping = true;
            do
            {
                string isGameConnnected = await scoreUpdater();
                if (isGameConnnected == "completed")
                {
                    keepLooping = false;
                }

            } while (keepLooping);

            return true;
        }

        /// <summary>
        /// Checks to see if the game is pending or active or canceled
        /// </summary>
        /// <returns></returns>
        public async Task<bool> pendingLoop()
        {
            bool keepLooping = true;
            do
            {
                if (Cancel == true)
                {
                    cancelJoin();
                    RESET();
                    return false;
                }

                string isGameConnnected = await gameState();
                if (isGameConnnected == "active")
                {
                    keepLooping = false;
                }

            } while (keepLooping);

            return true;
        }

        public void HandleCloseWindowEvent()
        {
            window.closeWindow();
        }

        /// <summary>
        /// To view game setup instructions
        /// </summary>
        public void HandleHelp1Event()
        {
            window.helpHowToStartGame();
        }

        /// <summary>
        /// To view game rules
        /// </summary>
        public void HandleHelp2Event()
        {
            window.helpGameRules();
        }

        /// <summary>
        /// This method will refresh the boggle board to represent the string it is given. 
        /// </summary>
        /// <param name="boardString">This is the string that represents the boggle board. The first four letters go
        /// on the first row of the boggle board and so forth.</param>
        public void refreshBoard(string boardString)
        {
            if (boardString.Length == 16)
            {
                //Setting all the values in the cells. 
                window.Cell1 = boardString[0].ToString();
                window.Cell2 = boardString[1].ToString();
                window.Cell3 = boardString[2].ToString();
                window.Cell4 = boardString[3].ToString();
                window.Cell5 = boardString[4].ToString();
                window.Cell6 = boardString[5].ToString();
                window.Cell7 = boardString[6].ToString();
                window.Cell8 = boardString[7].ToString();
                window.Cell9 = boardString[8].ToString();
                window.Cell10 = boardString[9].ToString();
                window.Cell11 = boardString[10].ToString();
                window.Cell12 = boardString[11].ToString();
                window.Cell13 = boardString[12].ToString();
                window.Cell14 = boardString[13].ToString();
                window.Cell15 = boardString[14].ToString();
                window.Cell16 = boardString[15].ToString();
            }
            if(boardString.Length == 0)
            {
                refreshBoard("                ");
            }
        }

        //TODO:OPPONENT TOKEN OUR TOKEN
        //TODO:MAKE URL GIVABLE.
        /// <summary>
        /// This method takes in the word that the user wants to submit and makes a put request to the given boggle server id. If the word
        /// is valid it will go ahead and change the score of the GUI. If its to late then no score will be added and user will recieve a popup box error.
        /// Will also recieve other errors for the various other problems need to make sure this is the correct result. 
        /// </summary>
        /// <param name="givenWord"></param>
        public async void HandleSubmitWordEvent(string givenWord)
        {
            using (HttpClient client = CreateClient(Default_URL))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.Word = givenWord;
                data.UserToken = player1Token;

                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                //Setting up the put.
                Task<HttpResponseMessage> putWord = client.PutAsync(Default_URL + "/games/" + gameID, content,token);

                //Awaiting post result.
                HttpResponseMessage response = await putWord;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);
                    //Get the new score, and previous in integer form. 
                    string scoreTemp = (string)responseData.Score;
                }
                else if (response.StatusCode.ToString() == "Forbidden")
                {
                    window.errorMessage("FORBIDDEN");
                }
                else if (response.StatusCode.ToString() == "Conflict")
                {
                    window.errorMessage("Sorry time limit to submit words is over.");
                }
                else
                {
                    window.errorMessage("UNKNOWN ERROR!!");
                }

            }
        }




        //TODO: FIX RUNTIME BINDER
        /// <summary>
        /// This starts the game once the game status changes to connected
        /// </summary>
        public async void startGame()
        {
            using (HttpClient client = CreateClient(Default_URL))
            {
                //Setting up the put.
                Task<HttpResponseMessage> getScore = client.GetAsync(Default_URL + "/games/" + gameID,token);

                //Awaiting post result.
                HttpResponseMessage response = await getScore;

                if (response.IsSuccessStatusCode)
                {
                    //window.CancelButton = false;
                    window.statusBox = "Connected";

                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);

                    string boardString = responseData.Board;
                    refreshBoard(boardString);

                    //string dlkasjdfg = responseData.Player1.Nickname;

                    string tempTimeLeft = responseData.TimeLeft;
                    window.timerDisplayBox = tempTimeLeft;

                    string tempPlayer1Name = responseData.Player1.Nickname;
                    window.player1NameBox = tempPlayer1Name;

                    string tempPlayer2Name = responseData.Player2.Nickname;
                    window.player2NameBox = tempPlayer2Name;

                    boardString = responseData.Board;
                    string blah = await MESSAROUND(boardString);

                    window.startTimer();
                    window.statusBox = "Connected";
                }
                else if (response.StatusCode.ToString() == "Forbidden")
                {
                    window.errorMessage("FORBIDDEN");
                }
                else if (response.StatusCode.ToString() == "Conflict")
                {
                    window.errorMessage("Sorry time limit to submit words is over.");
                }
                else
                {
                    window.errorMessage("UNKNOWN ERROR!!");
                }

            }
        }

        /// <summary>
        /// This method will create a user with the nickName that is submitted from the client. 
        /// </summary>
        /// <param name="nickname">Given nickname that the user wants to use.</param>
        /// <returns>The UserToken.</returns>
        public async Task<string> createUser(string nickname)
        {
            if (nickname == null || nickname.Trim() == "")
            {
                window.errorMessage("Invalid username. Try again.");
                return null;
            }


            using (HttpClient client = CreateClient(Default_URL))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.Nickname = nickname;

                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                //Setting up post.
                Task<HttpResponseMessage> getUserToken = client.PostAsync(Default_URL + "/users", content, token);

                ////Awaiting post result.
                HttpResponseMessage response = await getUserToken;

                //If the response is good then get the user token and return it.
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);
                    return responseData.UserToken;
                }
                else if (response.StatusCode.ToString() == "Forbidden")
                {
                    window.errorMessage("Invalid username. Try again.");
                    return null;
                }
                else
                {
                    window.errorMessage("Unknown error.");
                    return null;
                }
            }
        }

        //TODO:INvestigate the problem with async changing the GUI he talked about it in discussion. 

        /// <summary>
        /// This method will attempt to join the game a game under the UserToken that is given when the user given nickName was created.
        /// </summary>
        /// <param name="playerToken">userToken of player1.</param>
        /// <param name="timeGiven">Time limmit user gives.</param>
        /// <returns>The gameId</returns>
        public async Task<Pair> joinGame(string playerToken, int timeGiven)
        {
            if(timeGiven < 5 || timeGiven > 120)
            {
                window.errorMessage("Invalid time limit entered please try again");
                return null;
            }

            using (HttpClient client = CreateClient(Default_URL))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.UserToken = playerToken;
                data.TimeLimit = timeGiven;

                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                //Setting up post.
                Task<HttpResponseMessage> getGameID = client.PostAsync(Default_URL + "/games", content, token);

                //Awaiting post result.
                HttpResponseMessage response = await getGameID;

                if (response.StatusCode.ToString() == "Created")
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);
                    Pair info = new Pair(responseData.GameID, response.StatusCode.ToString());
                    return info;
                }
                else if (response.StatusCode.ToString() == "Accepted")
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);
                    Pair info = new Pair(responseData.GameID, response.StatusCode.ToString());
                    return info;
                }

                return null;
            }
        }

        /// <summary>
        /// Updates the score
        /// </summary>
        /// <returns></returns>
        public async Task<string> scoreUpdater()
        {
            using (HttpClient client = CreateClient(Default_URL))
            {
                //Setting up post.
                Task<HttpResponseMessage> getGameID = client.GetAsync(Default_URL + "/games/" + gameID,token);

                //Awaiting post result.
                HttpResponseMessage response = await getGameID;

                if (response.StatusCode.ToString() == "OK")
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);

                    string tempGameState = responseData.GameState;
                    if (tempGameState == "active")
                    {
                        string tempPlayer1Score = responseData.Player1.Score;
                        window.player1ScoreBox = tempPlayer1Score;

                        string tempPlayer2Score = responseData.Player2.Score;
                        window.player2ScoreBox = tempPlayer2Score;
                    }

                    else if (tempGameState == "completed") 
                    {
                        object player1WordList = responseData.Player1.WordsPlayed;
                        string stringList1 = player1WordList.ToString();
                        window.player1WordList = stringList1;

                        object player2WordList = responseData.Player2.WordsPlayed;
                        string stringList2 = player2WordList.ToString();
                        window.player2WordList = stringList2;
                    }

                    return responseData.GameState;
                }
                else
                {
                    return "Forbidden";
                }
            }
        }

        /// <summary>
        /// Gets the status of the game from the server.  Pending, Connected, or Completed
        /// </summary>
        /// <returns></returns>
        public async Task<string> gameState()
        {
            using (HttpClient client = CreateClient(Default_URL))
            {
                //Setting up post.
                Task<HttpResponseMessage> getGameID = client.GetAsync(Default_URL + "/games/" + gameID + "?Brief=yes",token);

                //Awaiting post result.
                HttpResponseMessage response = await getGameID;

                if (response.StatusCode.ToString() == "OK")
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);
                    return responseData.GameState;
                }
                else
                {
                    return "Forbidden";
                }
            }
        }


        /// <summary>
        /// This method asynchronlsy cancels a join request for the player1Token. 
        /// </summary>
        public async void cancelJoin()
        {
            using (HttpClient client = CreateClient(Default_URL))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.UserToken = player1Token;


                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                //Setting up post.
                Task<HttpResponseMessage> cancelGame = client.PutAsync(Default_URL + "/games", content,token);

                //Awaiting post result.
                HttpResponseMessage response = await cancelGame;


                if (response.IsSuccessStatusCode)
                {
                    //GAME CANCELED
                }
                else
                {
                    //INVALID USERTOKEN oR NOT IN PENDING GAME
                }

            }
        }



        /// <summary>
        /// This method creates a client for the HTTP interation that will go on in this class. 
        /// </summary>
        HttpClient CreateClient(string url)
        {
            // Create a client whose base address is the GitHub server
            HttpClient client = new HttpClient();
            //TODO: Catch exceptions here. 
            client.BaseAddress = new Uri(url);

            // Tell the server that the client will accept this particular type of response data
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");


            // There is more client configuration to do, depending on the request.
           /// mainClient = client;
            return client;
        }

        /// <summary>
        /// Used to keep track of the game ID and game status
        /// </summary>
        public class Pair
        {
            public Pair(object ID, object status)
            {
                GameID = ID;
                Status = status;
            }
            public object GameID { get; set; }
            public object Status { get; set; }
        }






        public async Task<string> MESSAROUND(string boardId)
        {
            using (HttpClient client = CreateClient(@"http://fuzzylogicinc.net/boggle/Solver.svc"))
            {
                //Setting up post.
                Task<HttpResponseMessage> getGameID = client.GetAsync(@"http://fuzzylogicinc.net/boggle/Solver.svc/?BoardID=" + boardId + "&Length=3",token);
  
                //Awaiting post result.
                HttpResponseMessage response = await getGameID;

                if (response.StatusCode.ToString() == "OK")
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);

                    string tempGameState = responseData.GameState;
                    if (tempGameState == "active")
                    {
                        return "";
                    }
                    return "";
                }
                else
                {
                    return "Forbidden";
                }
            }
        }





    }
}
