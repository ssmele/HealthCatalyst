using System;
using System.Text;
using System.Dynamic;
using System.Net.Http;
using Newtonsoft.Json;

namespace BoggleClient
{
    public class Controller
    {

        private IBoggleWindow window;

        //Represents the client we will accessing. 
        private HttpClient client;

        public Controller(IBoggleWindow window)
        {
            this.window = window;
            //Calls method to create new client. 
            client = CreateClient();
            window.CloseWindowEvent += HandleCloseWindowEvent;
            window.HelpEvent += HandleHelpEvent;
        }

        public void HandleCloseWindowEvent()
        {
            window.closeWindow();
        }

        public void HandleHelpEvent()
        {
            string x = createUser("stone");
            refreshBoard("abcdefgejdlhdofi");
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
            using (client)
            {
                dynamic data = new ExpandoObject();
                data.Nickname = nickname;

                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8,"application/json");
                HttpResponseMessage response = client.PostAsync("/users", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    dynamic newRepo = JsonConvert.DeserializeObject(result);
                    Console.WriteLine("User Token:");
                    Console.WriteLine(newRepo);
                }
                else
                {
                    Console.WriteLine("Error creating repo: " + response.StatusCode);
                    Console.WriteLine(response.ReasonPhrase);
                }
            }

            return "idk";
            
        }
        


        /// <summary>
        /// Creates an HttpClient for communicating with GitHub.  The GitHub API requires specific information
        /// to appear in each request header.
        /// </summary>
        HttpClient CreateClient()
        {
            // Create a client whose base address is the GitHub server
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://bogglecs3500s16.azurewebsites.net/BoggleService.svc");

            // Tell the server that the client will accept this particular type of response data
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");

            // There is more client configuration to do, depending on the request.
            return client;
        }
    }
}
