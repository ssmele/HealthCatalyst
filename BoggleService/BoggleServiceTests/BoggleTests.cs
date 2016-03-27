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
            Assert.AreEqual(x.Status, Accepted);
        }

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
            Assert.AreEqual(x.Data.GameID, "G1");
            Assert.AreEqual(x.Status, Accepted);

            //Creating second user. 
            user.Nickname = "swag";
            r = client.DoPostAsync("users", user).Result;
            token = r.Data.UserToken;


            newGame.UserToken = token;
            newGame.TimeLimit = 60;
            x = client.DoPostAsync("games", newGame).Result;
            Assert.AreEqual(x.Data.GameID, "G1");
            Assert.AreEqual(x.Status, Created);
        }


    }
}
