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

        //Represents the client we will accessing. 
        //private HttpClient client;

        public Controller(IBoggleWindow window)
        {
            this.window = window;
            
            //Calls method to create new client. 
            //client = CreateClient(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc");
            window.CloseWindowEvent += HandleCloseWindowEvent;
            window.HelpEvent += HandleHelpEvent;
            window.ConnectEvent += HandleConnectEvent;
            
        }

        public void HandleConnectEvent()
        {
            window.player1NameBox = window.playerBox;
            window.player1ScoreBox = "0";
            window.player2ScoreBox = "0";
            window.statusBox = "Pending";
            window.connectButton = false;
            window.cancelButton = true;
            if (window.timeLengthBox == "")
            {
                window.timeLengthBox = "60";
            }
            else
            {
                window.timerDisplayBox = window.timeLengthBox;
            }


            //Create user and get token.  (Asynchronas)
            string player1Token = createUser(window.playerBox);

            //JoinGame
            //string response = joinGame(player1Token, window.timeLengthBox);

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

        public void refreshBoard(string boardString)
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

        /// <summary>
        /// My attempt to make a post. 
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public string createUser(string nickname)
        {
            using (HttpClient client = CreateClient(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc"))
            {
                dynamic data = new ExpandoObject();
                data.Nickname = nickname;

                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8,"application/json");
                HttpResponseMessage response = client.PostAsync(@"http://bogglecs3500s16.azurewebsites.net/BoggleService.svc/users", content).Result;

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
                    return response.ReasonPhrase;
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
        /// Creates an HttpClient for communicating with GitHub.  The GitHub API requires specific information
        /// to appear in each request header.
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
