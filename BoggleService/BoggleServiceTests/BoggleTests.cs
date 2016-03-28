using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Dynamic;
using static System.Net.HttpStatusCode;
using System.Diagnostics;

namespace Boggle
{
    /// <summary>
    /// Provides a way to start and stop the IIS web server from within the test
    /// cases.  If something prevents the test cases from stopping the web server,
    /// subsequent tests may not work properly until the stray process is killed
    /// manually.
    /// </summary>
    public static class IISAgent
    {
        // Reference to the running process
        private static Process process = null;

        /// <summary>
        /// Starts IIS
        /// </summary>
        public static void Start(string arguments)
        {
            if (process == null)
            {
                ProcessStartInfo info = new ProcessStartInfo(Properties.Resources.IIS_EXECUTABLE, arguments);
                info.WindowStyle = ProcessWindowStyle.Minimized;
                info.UseShellExecute = false;
                process = Process.Start(info);
            }
        }

        /// <summary>
        ///  Stops IIS
        /// </summary>
        public static void Stop()
        {
            if (process != null)
            {
                process.Kill();
            }
        }
    }
    [TestClass]
    public class BoggleTests
    {
        /// <summary>
        /// This is automatically run prior to all the tests to start the server
        /// </summary>
        [ClassInitialize()]
        public static void StartIIS(TestContext testContext)
        {
            IISAgent.Start(@"/site:""BoggleService"" /apppool:""Clr4IntegratedAppPool"" /config:""..\..\..\.vs\config\applicationhost.config""");
        }

        /// <summary>
        /// This is automatically run when all tests have completed to stop the server
        /// </summary>
        [ClassCleanup()]
        public static void StopIIS()
        {
            IISAgent.Stop();
        }

        private RestTestClient client = new RestTestClient("http://localhost:50000/");

        [TestMethod]
        public void TestMethod1()
        {
            Response r = client.DoGetAsync("/numbers?length={0}", "5").Result;
            Assert.AreEqual(OK, r.Status);
            Assert.AreEqual(5, r.Data.Count);
            r = client.DoGetAsync("/numbers?length={0}", "-5").Result;
            Assert.AreEqual(Forbidden, r.Status);
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<int> list = new List<int>();
            list.Add(15);
            Response r = client.DoPostAsync("/first", list).Result;
            Assert.AreEqual(OK, r.Status);
            Assert.AreEqual(15, r.Data);
        }

        //Testing createUser

        [TestMethod]
        public void TestCreateUserDefault()
        {
            dynamic user = new ExpandoObject();
            user.Nickname = "Joe";
            Response r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Created, r.Status);
            string token = r.Data.UserToken;
            Assert.AreEqual(36, token.Length);
        }


        [TestMethod]
        public void TestCreateUserBad()
        {
            dynamic user = new ExpandoObject();
            user.Nickname = null;
            Response r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Forbidden, r.Status);
            Assert.IsNull(r.Data);
        }

        [TestMethod]
        public void TestCreateUserEmpty()
        {
            dynamic user = new ExpandoObject();
            user.Nickname = "";
            Response r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Forbidden, r.Status);
            Assert.IsNull(r.Data);
        }

        [TestMethod]
        public void TestCreateUserEmptyLine()
        {
            dynamic user = new ExpandoObject();
            user.Nickname = "\n";
            Response r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Forbidden, r.Status);
            Assert.IsNull(r.Data);
        }

        /// <summary>
        /// This test ensures that a userToken that doesnt exist in the system will return a FOrbidden response.
        /// </summary>
        [TestMethod]
        public void TestJoinGameBadToken()
        {
            string token = "123456789112345678911234567891123456";

            dynamic newGame = new ExpandoObject();
            newGame.UserToken = token;
            newGame.TimeLimit = 60;
            Response x = client.DoPostAsync("games", newGame).Result;
            Assert.AreEqual(x.Status, Forbidden);
            Assert.IsNull(x.Data);
        }

        /// <summary>
        /// This test ensures that a userToken that doesnt match the format will return a forbidden response.
        /// </summary>
        [TestMethod]
        public void TestJoinGameBadderToken()
        {
            string token = "DKKDKDKDK";

            dynamic newGame = new ExpandoObject();
            newGame.UserToken = token;
            newGame.TimeLimit = 60;
            Response x = client.DoPostAsync("games", newGame).Result;
            Assert.AreEqual(x.Status, Forbidden);
            Assert.IsNull(x.Data);
        }

        /// <summary>
        /// This test ensures that all bad timelimits will return a forbidden response.
        /// </summary>
        [TestMethod]
        public void TestJoinGameBadTime()
        {
            //Creating first user. 
            dynamic user = new ExpandoObject();
            user.Nickname = "badTimeUser";
            Response r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Created, r.Status);
            string token = r.Data.UserToken;

            dynamic newGame = new ExpandoObject();
            newGame.UserToken = token;
            newGame.TimeLimit = 1;
            Response x = client.DoPostAsync("games", newGame).Result;
            Assert.AreEqual(x.Status, Forbidden);
            Assert.IsNull(x.Data);

            newGame.UserToken = token;
            newGame.TimeLimit = 121;
            x = client.DoPostAsync("games", newGame).Result;
            Assert.AreEqual(x.Status, Forbidden);
            Assert.IsNull(x.Data);

        }

        /// <summary>
        /// This test ensures that a game can be accepted. 
        /// </summary>
        [TestMethod]
        public void TestJoinGame1Player()
        {
            //Creating first user. 
            dynamic user = new ExpandoObject();
            user.Nickname = "swag";
            Response r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Created, r.Status);
            string token = r.Data.UserToken;

            dynamic newGame = new ExpandoObject();
            newGame.UserToken = token;
            newGame.TimeLimit = 60;
            Response x = client.DoPostAsync("games", newGame).Result;
            Assert.AreEqual((string)x.Data.GameID, "G0");
            Assert.AreEqual(x.Status, Accepted);
        }

        /// <summary>
        /// This test ensures that a game can be created.
        /// </summary>
        [TestMethod]
        public void TestJoinGame2Players()
        {
            //Creating first user. 
            dynamic user = new ExpandoObject();
            user.Nickname = "swag";
            Response r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Created, r.Status);
            string token = r.Data.UserToken;

            //Joining game.
            dynamic newGame = new ExpandoObject();
            newGame.UserToken = token;
            newGame.TimeLimit = 60;
            Response x = client.DoPostAsync("games", newGame).Result;
            Assert.AreEqual((string)x.Data.GameID, "G0");
            Assert.AreEqual(x.Status, Created);

            //Creating second user. 
            user.Nickname = "123";
            r = client.DoPostAsync("users", user).Result;
            token = r.Data.UserToken;

            dynamic newGame2 = new ExpandoObject();
            newGame2.UserToken = token;
            newGame2.TimeLimit = 60;
            Response firstGame = client.DoPostAsync("games", newGame2).Result;
            Assert.AreEqual((string)firstGame.Data.GameID, "G1");
            Assert.AreEqual(firstGame.Status, Accepted);



            user.Nickname = "124443";
            r = client.DoPostAsync("users", user).Result;
            token = r.Data.UserToken;

            newGame2 = new ExpandoObject();
            newGame2.UserToken = token;
            newGame2.TimeLimit = 60;
            firstGame = client.DoPostAsync("games", newGame2).Result;
            Assert.AreEqual((string)firstGame.Data.GameID, "G1");
            Assert.AreEqual(firstGame.Status, Created);
        }

        //This test ensures that a game can be canceled. 
        [TestMethod]
        public void TestCancel()
        {
            //Creating first user. 
            dynamic user = new ExpandoObject();
            user.Nickname = "swag";
            Response r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Created, r.Status);
            string token = (string)r.Data.UserToken;

            //Joining Game
            dynamic newGame = new ExpandoObject();
            newGame.UserToken = token;
            newGame.TimeLimit = 60;
            Response x = client.DoPostAsync("games", newGame).Result;
            Assert.AreEqual((string)x.Data.GameID, "G2");
            Assert.AreEqual(x.Status, Accepted);

            //CANCELING PENDING
            dynamic Cancel = new ExpandoObject();
            Cancel.UserToken = token;
            Response y = client.DoPutAsync(Cancel, "games").Result;
            Assert.AreEqual(y.Status, OK);

            //Make sure we can still join back.
            x = client.DoPostAsync("games", newGame).Result;
            Assert.AreEqual((string)x.Data.GameID, "G3");
            Assert.AreEqual(x.Status, Accepted);


            //New user
            user = new ExpandoObject();
            user.Nickname = "second";
            r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Created, r.Status);
            token = (string)r.Data.UserToken;

            //joining game
            newGame.UserToken = token;
            newGame.TimeLimit = 85;
            x = client.DoPostAsync("games", newGame).Result;
            Assert.AreEqual((string)x.Data.GameID, "G3");
            Assert.AreEqual(x.Status, Created);
        }

        /// <summary>
        /// This test ensures that forbidden is returned when trying to cancel game with bad tokens. 
        /// </summary>
        [TestMethod]
        public void TestCancelBadUserToken()
        {
            //Creating first user. 
            dynamic user = new ExpandoObject();
            user.Nickname = "CancelBadTokenTest";
            Response r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Created, r.Status);
            string token = (string)r.Data.UserToken;

            //Joining Game
            dynamic newGame = new ExpandoObject();
            newGame.UserToken = token;
            newGame.TimeLimit = 60;
            Response x = client.DoPostAsync("games", newGame).Result;
            Assert.AreEqual((string)x.Data.GameID, "G4");
            Assert.AreEqual(x.Status, Accepted);


            //making test token.
            user.Nickname = "TestToken";
            r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Created, r.Status);
            token = (string)r.Data.UserToken;


            //CANCELING PENDIng with bad usertoken.
            dynamic Cancel = new ExpandoObject();
            Cancel.UserToken = "BadToken";
            Response y = client.DoPutAsync(Cancel, "games").Result;
            Assert.AreEqual(y.Status, Forbidden);

            //Canceling pending with good token but not the right one. 
            Cancel.UserToken = token;
            y = client.DoPutAsync(Cancel, "games").Result;
            Assert.AreEqual(y.Status, Forbidden);
        }

        /// <summary>
        /// This test ensures forbidden is returned when trying to cancel a game that doesnt exist.
        /// </summary>
        [TestMethod]
        public void TestCancelNoPendingGame()
        {

            //Creating first user. 
            dynamic user = new ExpandoObject();
            user.Nickname = "CancelBadTokenTest";
            Response r = client.DoPostAsync("users", user).Result;
            Assert.AreEqual(Created, r.Status);
            string token = (string)r.Data.UserToken;

            //CANCELING PENDIng with bad usertoken.
            dynamic Cancel = new ExpandoObject();
            Cancel.UserToken = "BadToken";
            Response y = client.DoPutAsync(Cancel, "games").Result;
            Assert.AreEqual(y.Status, Forbidden);

            //Caneling with good token but no game to cancel. 
            Cancel.UserToken = token;
            y = client.DoPutAsync(Cancel, "games").Result;
            Assert.AreEqual(y.Status, Forbidden);
        }



    }
}
