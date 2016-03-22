using System;
using System.Text;
using System.Dynamic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BoggleClient
{
    public class Controller
    {

        private IBoggleWindow window;

        private string player1Token;

        private string gameID;

        private string gameUrl;

        public Controller(IBoggleWindow window)
        {
            this.window = window;
            
            //Calls method to create new client. 
            //client = CreateClient(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc");
            window.CloseWindowEvent += HandleCloseWindowEvent;
            window.HelpEvent += HandleHelpEvent;
            window.ConnectEvent += HandleConnectEvent;
            window.WordSubmitEvent += HandleSubmitWordEvent;
            
        }

        //TODO: WE have two async methods inside of a async method is that necessary or do we only need the one async method. 

        public async void HandleConnectEvent()
        {
            window.player1NameBox = window.playerBox;
            gameUrl = window.urlTextBox;
            window.player1ScoreBox = "0";
            window.player2ScoreBox = "0";
            window.statusBox = "Pending";
            window.connectButton = false;
            window.cancelButton = true;
            if (window.timeLengthBox == "")
            {
                window.timeLengthBox = "60";
            }
            window.timerDisplayBox = window.timeLengthBox;
            

            //Create user and get token.  (Asynchronas)
            player1Token = await createUser(window.playerBox);
            //string player2Token = await createUser("asdfasdf");
            //Attempgint to JoinGame
            gameID = await joinGame(player1Token, int.Parse(window.timeLengthBox));

            //HandleSubmitWordEvent("yo");

            //string response2 = await joinGame(player2Token, int.Parse(window.timeLengthBox));

            //if 202 call pending.
            // can cancel
            // activeGame bool is false

            //if 201 call created.
            // activeGame = true
            // Cancel button inactive
            // Connect button inactive
            // start timer
        }

        public void HandleCloseWindowEvent()
        {
            window.closeWindow();
        }

        public void HandleHelpEvent()
        {
            //string x = getTest();
            //string x = createUser("");
            //window.playerBox = x;
            //refreshBoard("abcdefgejdlhdofi");
            window.helpWindow();

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
        }

        //TODO:MAKE URL GIVABLE.
        /// <summary>
        /// This method takes in the word that the user wants to submit and makes a put request to the given boggle server id. If the word
        /// is valid it will go ahead and change the score of the GUI. If its to late then no score will be added and user will recieve a popup box error.
        /// Will also recieve other errors for the various other problems need to make sure this is the correct result. 
        /// </summary>
        /// <param name="givenWord"></param>
        public async void HandleSubmitWordEvent(string givenWord)
        {
            using (HttpClient client = CreateClient(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc"))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.Word = givenWord;
                data.UserToken = player1Token;
                
                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                //Setting up the put.
                Task<HttpResponseMessage> getScore = client.PutAsync(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc/games/" + gameID, content);

                //Awaiting post result.
                HttpResponseMessage response = await getScore;


                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);
                    //Get the new score, and previous in integer form. 
                    int score = int.Parse(responseData.Score);
                    int previousScore = int.Parse(window.player1ScoreBox);
                    //Set player box to new score. 
                    window.player1ScoreBox = (score + previousScore).ToString();
                }
                else if(response.StatusCode.ToString() == "Forbidden")
                {
                    window.errorMessage("FORBIDDEN");
                }
                else if(response.StatusCode.ToString() == "Conflict")
                {
                    window.errorMessage("Sorry time limit to submit words is over.");
                }
                else
                {
                    window.errorMessage("UNKNOW ERROR!!");
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
            using (HttpClient client = CreateClient(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc"))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.Nickname = nickname;

                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8,"application/json");
                
                //Setting up post.
                Task<HttpResponseMessage> getUserToken = client.PostAsync(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc/users", content);

                //Awaiting post result.
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
                    return "";
                }
                else
                {
                    window.errorMessage("Unknow error.");
                    return "";
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
        public async Task<string> joinGame(string playerToken, int timeGiven)
        {
            using (HttpClient client = CreateClient(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc"))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.UserToken = playerToken;
                data.TimeLimit = timeGiven;

                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                //Setting up post.
                Task<HttpResponseMessage> getGameID = client.PostAsync(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc/games", content);
                
                //Awaiting post result.
                HttpResponseMessage response = await getGameID;

                if(response.StatusCode.ToString() == "Created")
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);
                    return responseData.GameID;
                }
                else if (response.StatusCode.ToString() == "Accepted")
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic responseData = JsonConvert.DeserializeObject(result);
                    return responseData.GameID;
                }
                
                return "";
            }
        }


        /// <summary>
        /// This method asynchronlsy cancels a join request for the player1Token. 
        /// </summary>
        public async void cancelJoin()
        {
            using (HttpClient client = CreateClient(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc"))
            {
                //Setting up nickname to give to server.
                dynamic data = new ExpandoObject();
                data.UserToken = player1Token;


                //Setting header and payload. 
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                //Setting up post.
                Task<HttpResponseMessage> cancelGame = client.PutAsync(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc/games", content);

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
        /// My attempt to make a post. 
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public string getTest()
        {
            using (HttpClient client = CreateClient(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc"))
            {
                
                HttpResponseMessage response = client.GetAsync(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc/users").Result;



                if (response.IsSuccessStatusCode)
                {
                    return response.StatusCode.ToString(); 
                }
                else
                {
                    return response.StatusCode.ToString();
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
            return client;
        }
    }
}
