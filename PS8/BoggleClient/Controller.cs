// Written by: Hanna Larsen & Salvatore Stone Mele
//              u0741837       u0897718
//Date: 3/24/16

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
    /// <summary>
    /// Controller class for our boggle client. 
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Creates the window
        /// </summary>
        private IBoggleWindow window;

        /// <summary>
        /// Current user info
        /// </summary>
        private string currentUserToken;

        /// <summary>
        /// ID of the game
        /// </summary>
        private string gameID;

        /// <summary>
        /// Used in canceling requests
        /// </summary>
        private CancellationTokenSource source;

        /// <summary>
        /// Used in canceling requests
        /// </summary>
        private CancellationToken token;

        /// <summary>
        /// String that determines the letters on the board
        /// </summary>
        string boardString;

        /// <summary>
        /// URL of the server 
        /// </summary>
        private string URL = "";

        /// <summary>
        /// Determines whether the request was cancelled
        /// </summary>
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
            window.HelpCheat += HandleHelpCheatEvent;
            window.ConnectEvent += HandleConnectEvent;
            window.WordSubmitEvent += HandleSubmitWordEvent;
            window.CancelEvent += HandleCancelEvent;
            window.NewEvent += HandleNew;
            window.UpdateScoreEvent += scoreUpdater;
            window.GameStateEvent += gameState;
            window.CheatEventFast += HandleCheatFast;
            window.CheatEventSlow += HandleCheatSlow;
            window.CheatEventWindow += HandleCheatWindow;
            window.CheatEventEthically += HandleCheatGoodandSlow;
            source = new CancellationTokenSource();
            token = source.Token;
            window.urlTextBox = @"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc";
            window.statusBox = "Idle";
            window.timerDisplayBox = "0";
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
            source.Cancel();
        }

        /// <summary>
        /// Resets the GUI back to idle status
        /// </summary>
        public async void resetClient()
        {
            //If we are still pending then cancel the latest join request. 
            if (window.statusBox == "Trying to connect!")
            {
                await cancelJoin();
            }
            refreshBoard("");
            window.statusBox = "Idle";
            window.cancelButton = false;
            window.connectButton = true;
            Cancel = false;
            source.Dispose();
            source = new CancellationTokenSource();
            token = source.Token;
            // Initializations
            window.player1WordList = "";
            window.player2WordList = "";
            window.player1NameBox = "";
            window.player2NameBox = "";
            window.player1ScoreBox = "0";
            window.player2ScoreBox = "0";
            window.timerDisplayBox = "0";
            window.ConnectButtonText = "Connect";
            window.CancelButtonText = "Cancel";
            window.endScoreUpdater();
            window.endPending();
        }

        /// <summary>
        /// Things that happen when the connect button is clicked.  Game will either be pending or active
        /// </summary>
        public async void HandleConnectEvent()
        {
            //Setting up the board to be connected. 
            refreshBoard("");
            window.player1WordList = "";
            window.player2WordList = "";
            window.player1NameBox = "";
            window.player2NameBox = "";
            URL = window.urlTextBox;
            window.player1ScoreBox = "0";
            window.player2ScoreBox = "0";
            window.timerDisplayBox = "0";
            window.ConnectButtonText = "Connect";
            window.statusBox = "Trying to connect!";
            window.connectButton = false;
            window.cancelButton = true;
            if (window.timeLengthBox == "")
            {
                window.timeLengthBox = "60";
            }

           


            //TRY CATCH OVER ALL THE AWAIT METHODS AS THEY CAN ALL THROW CANCELLATION EXCEPTIONS. 
            try
            {
                //Create user and get token.
                currentUserToken = await createUser(window.playerBox);
                //If we get a null then we know that the name was invalid or some other type of error. Or if the cancel is true.
                if (Cancel == true || currentUserToken == null)
                {
                    resetClient();
                    return;
                }

                //Try and parse the time to ensure that it is a valid entry if its not then throw error and restart the client. 
                int tempTime;
                if (int.TryParse(window.timeLengthBox, out tempTime) == false)
                {
                    window.errorMessage("Please enter a valid integer for the desired game duration, and try again. ");
                    resetClient();
                    return;
                }

                // Attempt to join the game
                Pair gameInfo = await joinGame(currentUserToken, tempTime);
                if (gameInfo == null) 
                {
                    resetClient();
                    return;
                }
                //Sets gameID equal to what we recieved from the join game HTTP request. 
                gameID = gameInfo.GameID.ToString();

                //Decides stat to put client in. 
                await stateDecision();

            }
            catch (TaskCanceledException)
            {
                //If any of the methods get canceled simply just reset the client. 
                resetClient();
                return;
            }
            catch (HttpRequestException)
            {
                window.errorMessage("Invalid URL make sure you spelled it correctly, and try again!");
                resetClient();
                return;
            }
            catch (UriFormatException)
            {
                window.errorMessage("Invalid URL make sure you spelled it correctly, and try again!");
                resetClient();
                return;
            }
        }

        /// <summary>
        /// Ends the game & resets the gui
        /// </summary>
        public void endGame()
        {
            // Set end game variables 
            window.CancelButtonText = "Cancel";
            window.ConnectButtonText = "New Game";
            window.cancelButton = false;
            window.connectButton = true;
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
        }

        /// <summary>
        /// Closes the game window
        /// </summary>
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
            // Sets the values of the board
            if (boardString.Length == 0)
            {
                window.refreshBoard("                ");
            }
            if (boardString.Length == 16)
            {
                window.refreshBoard(boardString);
            }
        }

        /// <summary>
        /// This method takes in the word that the user wants to submit and makes a put request to the given boggle server id. If the word
        /// is valid it will go ahead and change the score of the GUI. If its to late then no score will be added and user will recieve a popup box error.
        /// Will also recieve other errors for the various other problems need to make sure this is the correct result. 
        /// </summary>
        /// <param name="givenWord"></param>
        public async void HandleSubmitWordEvent(string givenWord)
        {
            using (HttpClient client = CreateClient(URL))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.Word = givenWord;
                data.UserToken = currentUserToken;

                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                //Setting up the put.
                Task<HttpResponseMessage> putWord = client.PutAsync(URL + "/games/" + gameID, content, token);

                try
                {
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
                    window.errorMessage("Please enter a valid word, and try again.");
                }
                else if (response.StatusCode.ToString() == "Conflict")
                {
                    window.errorMessage("Sorry time limit to submit words is over. Start a new game to submit words.");
                }
                else
                {
                    window.errorMessage("UNKNOWN ERROR!!");
                }
                }
                // Resets the client if cancel button is clicked
                catch (TaskCanceledException)
                {
                    resetClient();
                    return;
                }

            }
        }



        /// <summary>
        /// This method sends a get state request to the http server. It is not brief as it needs to retrieve board information. 
        /// </summary>
        public async Task stateDecision()
        {
            using (HttpClient client = CreateClient(URL))
            {
                //Setting up the put.
                Task<HttpResponseMessage> getStartInfo = client.GetAsync(URL + "/games/" + gameID, token);

                try
                {
                    //Awaiting post result.
                    HttpResponseMessage response = await getStartInfo;

                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        dynamic responseData = JsonConvert.DeserializeObject(result);

                        if (responseData.GameState == "active")
                        {
                            await startGame();
                        }
                        else if (responseData.GameState == "pending")
                        {
                            window.startTimerPending();
                        }
                    }
                    else if (response.StatusCode.ToString() == "Forbidden")
                    {
                        //TODO: IF THE GAME ID GETS CORRUPTED NEEDS TO RESET FIGURE THAT OUT.
                        window.errorMessage("Your gameID seems to be corrupted please try again.");
                        return;
                    }
                    else
                    {
                        window.errorMessage("Your game session got corrupted please try again.");
                        return;
                    }
                }
                catch (TaskCanceledException)
                {
                    resetClient();
                    return;
                }

            }
        }



        /// <summary>
        /// This method sends a get state request to the http server. It is not brief as it needs to retrieve board information. 
        /// </summary>
        public async Task startGame()
        {
            using (HttpClient client = CreateClient(URL))
            {
                //Setting up the put.
                Task<HttpResponseMessage> getStartInfo = client.GetAsync(URL + "/games/" + gameID, token);

                //Awaiting post result.
                try
                {
                    HttpResponseMessage response = await getStartInfo;

                    if (response.IsSuccessStatusCode)
                    {
                        //Lets the users no the game has connected.
                        window.statusBox = "Connected";

                        //Changes the Cancel Button to say EXIT GAME so user knows that they can exit the game at anytime. 
                        window.CancelButtonText = "Exit Game";

                        //Get the data out of the response. 
                        string result = response.Content.ReadAsStringAsync().Result;
                        dynamic responseData = JsonConvert.DeserializeObject(result);

                        //Sets the boardString private instance variable.
                        boardString = responseData.Board;

                        //Refreshes the board to represent the current game. 
                        refreshBoard(boardString);

                        //string tempTimeLeft = responseData.TimeLeft;
                        //Sets time to current game clock.
                        window.timerDisplayBox = (string)responseData.TimeLeft;

                        //Sets player1 to player1s nickname.
                        string tempPlayer1Name = responseData.Player1.Nickname;
                        window.player1NameBox = (string)responseData.Player1.Nickname;

                        //Sets player2 to player2s nickname.
                        string tempPlayer2Name = responseData.Player2.Nickname;
                        window.player2NameBox = (string)responseData.Player2.Nickname;

                        //starts the clockTimer.
                        window.startTimer();
                        window.startTimerScoreUpdate();
                    }
                    else if (response.StatusCode.ToString() == "Forbidden")
                    {
                        
                        window.errorMessage("Your gameID seems to be corrupted please try to start a new game.");
                        resetClient();
                        return;
                    }
                }
                catch (TaskCanceledException)
                {
                    resetClient();
                    return;
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

            //Checks to see if name is Valid if its not prompt error and RESET board. 
            if (nickname == null || nickname.Trim() == "")
            {
                window.errorMessage("Invalid username. Please enter a new one and try again.");
                return null;
            }


            using (HttpClient client = CreateClient(URL))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.Nickname = nickname;

                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                //Setting up post.
                Task<HttpResponseMessage> getUserToken = client.PostAsync(URL + "/users", content, token);

                ////Awaiting post result.
                HttpResponseMessage response = await getUserToken;

                //If the response is good then get the user token and return it.
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);
                    return responseData.UserToken;
                }
                //This should be checked before but if it somehow makes it through then return null.
                else if (response.StatusCode.ToString() == "Forbidden")
                {
                    window.errorMessage("Invalid username. Try again.");
                    return null;
                }
                //Incase something really bad happens just return unknown error. 
                else
                {
                    window.errorMessage("Unknown error, please try creating a new game!");
                    return null;
                }
            }
        }
 

        /// <summary>
        /// This method will attempt to join the game a game under the UserToken that is given when the user given nickName was created.
        /// </summary>
        /// <param name="playerToken">userToken of player1.</param>
        /// <param name="timeGiven">Time limmit user gives.</param>
        /// <returns>The gameId</returns>
        public async Task<Pair> joinGame(string playerToken, int timeGiven)
        {
            using (HttpClient client = CreateClient(URL))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.UserToken = playerToken;
                data.TimeLimit = timeGiven;

                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                //Setting up get
                Task<HttpResponseMessage> getGameINFO = client.PostAsync(URL + "/games", content, token);

                //Awaiting get result.
                HttpResponseMessage response = await getGameINFO;

                //If we succesfully join or create a game then get the game ID, and the statusCode and return it.
                if (response.IsSuccessStatusCode == true)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);
                    Pair info = new Pair(responseData.GameID, response.StatusCode.ToString());
                    return info;
                }
                //If the userTOken is already in this game respond with error and return null. 
                else if (response.StatusCode.ToString() == "Conflict")
                {
                    window.errorMessage("It seems as if your already in another game please finish that one first and then try again.");
                    return null;
                }
                else if(response.StatusCode.ToString() == "Forbidden")
                {
                    window.errorMessage("Please enter a valid integer for the desired game duration, and try again. ");
                    return null;
                }
                //If anything else happens return unknown error message. 
                else
                {
                    window.errorMessage("Unknown error, please try creating a new game!");
                    return null;
                }
            }
        }

        /// <summary>
        /// This method will take in a wordList dyanmic object and return it into a formatted string that is presentable for the 
        /// wordList textboxes. 
        /// </summary>
        /// <param name="wordList"></param>
        /// <returns></returns>
        private string wordListFormatter(dynamic wordList)
        {
            string finalList = "";
            int count = 0;
            foreach (dynamic wordObj in wordList)
            {
                if (count == 0) { }
                else { finalList = finalList + "\n"; }
                finalList = finalList + wordObj.Word + ":" + wordObj.Score;
                count++;
            }
            return finalList;
        }

        /// <summary>
        /// Will go and get the gameStatus. It will then update the scores if the game is still active. If it becomes complete then it will
        /// put all the words form the words list into the text box.
        /// </summary>
        /// <returns>Returns the game status.</returns>
        public async void scoreUpdater()
        {
            using (HttpClient client = CreateClient(URL))
            {
                //Setting up get
                Task<HttpResponseMessage> getGameID = client.GetAsync(URL + "/games/" + gameID, token);

                try
                {
                    //Awaiting get result.
                    HttpResponseMessage response = await getGameID;

                    //If the game status is ok then decide what to do with info. 
                    if (response.StatusCode.ToString() == "OK")
                    {
                        //Get data from response.
                        string result = response.Content.ReadAsStringAsync().Result;
                        dynamic responseData = JsonConvert.DeserializeObject(result);

                        //Get the gameState
                        string tempGameState = responseData.GameState;

                        //If the game was active then update the scores. 
                        if (tempGameState == "active")
                        {
                            //Update the two players scores. 
                            window.player1ScoreBox = (string)responseData.Player1.Score;
                            window.player2ScoreBox = (string)responseData.Player2.Score;
                        }
                        //If its complete then update the wordLists.
                        else if (tempGameState == "completed")
                        {
                            //Updates the wordlist.
                            window.player1WordList = wordListFormatter(responseData.Player1.WordsPlayed);
                            window.player2WordList = wordListFormatter(responseData.Player2.WordsPlayed);
                            // Stops updating the score
                            window.endScoreUpdater();
                            endGame();
                        }

                    }

                    //If the game was corrupted prompt error. 
                    else
                    {
                        window.errorMessage("Game was corrupted while active.");
                        resetClient();
                        return;
                    }
                }
                catch (TaskCanceledException)
                {
                    resetClient();
                    return;
                }
            }
        }

        // <summary>
        // Gets the status of the game from the server.This is different that the other get method as it is brief.
        // </summary>
        // <returns></returns>
        public async void gameState()
        {
            using (HttpClient client = CreateClient(URL))
            {
                //Setting up get.
                Task<HttpResponseMessage> getGameID = client.GetAsync(URL + "/games/" + gameID + "?Brief=yes", token);

                //Awaiting get result.
                try
                {
                    HttpResponseMessage response = await getGameID;
                    //Getting the response code
                    if (response.StatusCode.ToString() == "OK")
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        dynamic responseData = JsonConvert.DeserializeObject(result);
                        if (responseData.GameState == "active")
                        {
                            window.endPending();
                            await startGame();
                        }
                    }
                    else
                    {
                        // If there is any error, displays message & resets
                        window.errorMessage("Game was corrupted while active.");
                        resetClient();
                        return;
                    }
                }
                catch (TaskCanceledException)
                {
                    resetClient();
                    return;
                }
            }
        }


        /// <summary>
        /// This method cancels a join request for the current user token. 
        /// </summary>
        public async Task cancelJoin()
        {
            using (HttpClient client = CreateClient(URL))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.UserToken = currentUserToken;


                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                //Setting up put.

                Task<HttpResponseMessage> cancelGame = client.PutAsync(URL + "/games", content);
                try {
                    //Awaiting put result.
                    HttpResponseMessage response = await cancelGame;
                }
                catch(TaskCanceledException)
                {
                    window.errorMessage("Unknown Error. Error code 500");
                    resetClient();
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



        ///*********************Not important code***************************************************************************

        /// <summary>
        /// This method access's a seperate API that will give you back all the solutions to the current BoggleBoard.
        /// </summary>
        /// <param name="boardId"></param>
        /// <returns></returns>
        public async Task<dynamic> boggleSolver(string boardId)
        {
            using (HttpClient client = CreateClient(@"http://fuzzylogicinc.net/boggle/Solver.svc"))
            {
                //Setting up post.
                Task<HttpResponseMessage> getGameID = client.GetAsync(@"http://fuzzylogicinc.net/boggle/Solver.svc/?BoardID=" + boardId + "&Length=3", token);

                //Awaiting post result.
                HttpResponseMessage response = await getGameID;

                if (response.StatusCode.ToString() == "OK")
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);


                    return responseData;
                }
                else
                {
                    return "Forbidden";
                }
            }
        }



        /// <summary>
        /// This method will automatically insert all the words of a boggle board. 
        /// </summary>
        public async void HandleCheatFast()
        {
            if (int.Parse(window.timerDisplayBox) < 1)
            {
                window.errorMessage("Sorry not enough time for the fast cheat, looks like your on your own!");
                return;
            }

            if (window.statusBox == "Connected" && window.timerDisplayBox != "0")
            {
                double sleepTime = int.Parse(window.timerDisplayBox);
                dynamic answer = await boggleSolver(boardString);
                foreach (dynamic word in answer.Solutions)
                {
                    string x = word.Word.ToString();
                    HandleSubmitWordEvent(x);
                }

            }
        }

        public async void HandleCheatGoodandSlow()
        {
            dynamic answer = await boggleSolver(boardString);

            List<Pair> wordSORT = new List<Pair>();

            foreach (dynamic wordObj in answer.Solutions)
            {
                wordSORT.Add(new Pair(wordObj.Word, wordObj.Score));
            }

            wordSORT.Sort(pairCompare);

            //sleepTime = (sleepTime / 5) * 1000;
            int sleepTime = 5000;
            foreach (Pair words in wordSORT)
            {
                if (window.timerDisplayBox != 0.ToString())
                {
                    string x = words.GameID.ToString();
                    HandleSubmitWordEvent(x);
                    await Task.Delay(sleepTime);
                }

            }
        }

        /// <summary>
        /// This method will make it look less suspicious of cheating. 
        /// </summary>
        public async void HandleCheatSlow()
        {
            if (int.Parse(window.timerDisplayBox) < 25)
            {
                window.errorMessage("Sorry not enough time for the slow cheat please try fast cheat.");
                return;
            }


            double sleepTime = int.Parse(window.timerDisplayBox);
            //sleepTime = (sleepTime / 5) * 1000;
            sleepTime = 5000;
            dynamic answer = await boggleSolver(boardString);
            foreach (dynamic word in answer.Solutions)
            {
                if (window.timerDisplayBox != 0.ToString())
                {
                    string x = word.Word.ToString();
                    HandleSubmitWordEvent(x);
                    await Task.Delay((int)sleepTime);
                }
            }
        }

        public async void HandleCheatWindow()
        {
            dynamic answer = await boggleSolver(boardString);

            //Get the answers in a presentable form. 
            string finalList = "";
            int count = 0;

            string longestWord = "";
            int largestScore = 0;

            List<Pair> wordSORT = new List<Pair>();

            foreach (dynamic wordObj in answer.Solutions)
            {
                wordSORT.Add(new Pair(wordObj.Word, wordObj.Score));
                int tempScore = wordObj.Score;
                if (tempScore > largestScore)
                {
                    largestScore = tempScore;
                    longestWord = wordObj.Word;
                }

                if (count == 0) { }
                else { finalList = finalList + "\n"; }
                finalList = finalList + wordObj.Word + " : " + wordObj.Score;
                count++;
            }

            wordSORT.Sort(pairCompare);
            string sortedFinalList = "";
            foreach (Pair sorted in wordSORT)
            {
                if (count == 0) { }
                else { sortedFinalList = sortedFinalList + "\n"; }
                sortedFinalList = sortedFinalList + sorted.GameID + " : " + sorted.Status;
                count++;
            }
            //Display them in a new window. 
            CheatForm cheatWindow = new CheatForm();
            cheatWindow.Show();
            cheatWindow.displayWords(finalList, sortedFinalList.TrimStart('\n'));
            cheatWindow.displayLargest(longestWord, largestScore);


        }

        private int pairCompare(Pair x, Pair y)
        {
            int a = int.Parse(x.Status.ToString());
            int b = int.Parse(y.Status.ToString());
            if (a < b)
            {
                return 1;
            }
            else if (b < a)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }

        private void HandleHelpCheatEvent()
        {
            window.helpCheat();
        }

    }
}
