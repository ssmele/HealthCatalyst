// Hanna Larsen & Salvatore Stone Mele
// u0741837        u0897718
// CS 3500  PS10 
// 04/07/16
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using static System.Net.HttpStatusCode;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using System.Net;


namespace Boggle
{

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
    /// <summary>
    /// Tests all methods for the Boggle server.
    /// NOTE: ALL TESTS MUST BE RAN AT THE SAME TIME, OTHERWISE SOME ASSERTIONS WILL FAIL'
    /// BASED ON HOW MANY GAMES ARE CREATED
    /// </summary>
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

        //private static string gameIDforTest = "";

        /// <summary>
        /// This is automatically run when all tests have completed to stop the server
        /// </summary>
        [ClassCleanup()]
        public static void StopIIS()
        {
            IISAgent.Stop();
        }

        /// <summary>
        /// Creates the client to be used
        /// </summary>
        //private RestTestClient client = new RestTestClient("http://localhost:60000/");


        //Testing createUser

        ///// <summary>
        ///// This tests creating a standard user
        ///// </summary>
        //[TestMethod]
        //public void TestCreateUserDefault()
        //{
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "Joe";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = r.Data.UserToken;
        //    Assert.AreEqual(36, token.Length);
        //}


        ///// <summary>
        ///// This tests creating a bad user (null)
        ///// </summary>
        //[TestMethod]
        //public void TestCreateUserBad()
        //{
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = null;
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Forbidden, r.Status);
        //    Assert.IsNull(r.Data);
        //}

        ///// <summary>
        ///// This tests creating a bad user (empty nickname)
        ///// </summary>
        //[TestMethod]
        //public void TestCreateUserEmpty()
        //{
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Forbidden, r.Status);
        //    Assert.IsNull(r.Data);
        //}

        ///// <summary>
        ///// This tests to make sure nicknames are trimmed correctly
        ///// </summary>
        //[TestMethod]
        //public void TestCreateUserEmptySpace()
        //{
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "      ";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Forbidden, r.Status);
        //    Assert.IsNull(r.Data);
        //}

        ///// <summary>
        ///// Testing trimming for nicknames
        ///// </summary>
        //[TestMethod]
        //public void TestCreateUserEmptyLine()
        //{
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "\n";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Forbidden, r.Status);
        //    Assert.IsNull(r.Data);
        //}

        ////Testing JoinGame

        ///// <summary>
        ///// This test ensures that a userToken that doesnt exist in the system will return a FOrbidden response.
        ///// </summary>
        //[TestMethod]
        //public void TestJoinGameBadToken()
        //{
        //    string token = "123456789112345678911234567891123456";

        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 60;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Forbidden);
        //    Assert.IsNull(x.Data);
        //}

        ///// <summary>
        ///// This test ensures that a userToken that doesnt match the format will return a forbidden response.
        ///// </summary>
        //[TestMethod]
        //public void TestJoinGameBadderToken()
        //{
        //    string token = "DKKDKDKDK";

        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 60;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Forbidden);
        //    Assert.IsNull(x.Data);
        //}

        ///// <summary>
        ///// This test ensures that all bad timelimits will return a forbidden response.
        ///// </summary>
        //[TestMethod]
        //public void TestJoinGameBadTime()
        //{
        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "badTimeUser";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = r.Data.UserToken;

        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = -78;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Forbidden);
        //    Assert.IsNull(x.Data);

        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 121;
        //    x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Forbidden);
        //    Assert.IsNull(x.Data);

        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 4;
        //    x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Forbidden);
        //    Assert.IsNull(x.Data);
        //}

        ///// <summary>
        ///// This test ensures that a game can be accepted. 
        ///// </summary>
        //[TestMethod]
        //public void TestJoinGame1Player()
        //{


        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "swag";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = r.Data.UserToken;

        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 60;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Accepted);


        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 60;
        //    x = client.DoPostAsync("games", newGame).Result;
        //    Assert.IsNull(x.Data);
        //    Assert.AreEqual(x.Status, Conflict);
        //}

        ///// <summary>
        ///// This test ensures that a game can be created.
        ///// </summary>
        //[TestMethod]
        //public void TestJoinGame2Players()
        //{
        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "swag";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = r.Data.UserToken;

        //    //Joining game.
        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 60;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Created);

        //    ///TODO: FIX THIS CASE!!!!
        //    //newGame.UserToken = token;
        //    //newGame.TimeLimit = 60;
        //    //x = client.DoPostAsync("games", newGame).Result;
        //    //Assert.IsNull(x.Data);
        //    //Assert.AreEqual(x.Status, Conflict);

        //    //Creating second user. 
        //    user.Nickname = "123";
        //    r = client.DoPostAsync("users", user).Result;
        //    token = r.Data.UserToken;

        //    dynamic newGame2 = new ExpandoObject();
        //    newGame2.UserToken = token;
        //    newGame2.TimeLimit = 60;
        //    Response firstGame = client.DoPostAsync("games", newGame2).Result;
        //    Assert.AreEqual(firstGame.Status, Accepted);



        //    user.Nickname = "124443";
        //    r = client.DoPostAsync("users", user).Result;
        //    token = r.Data.UserToken;

        //    newGame2 = new ExpandoObject();
        //    newGame2.UserToken = token;
        //    newGame2.TimeLimit = 60;
        //    firstGame = client.DoPostAsync("games", newGame2).Result;
        //    Assert.AreEqual(firstGame.Status, Created);
        //}

        ////TESTING CANCELJOIN.

        ///// <summary>
        ///// This test ensures that a game can be canceled.
        ///// </summary> 
        //[TestMethod]
        //public void TestCancel()
        //{
        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "swag";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = (string)r.Data.UserToken;

        //    //Joining Game
        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 60;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Accepted);

        //    //CANCELING PENDING
        //    dynamic Cancel = new ExpandoObject();
        //    Cancel.UserToken = token;
        //    Response y = client.DoPutAsync(Cancel, "games").Result;
        //    Assert.AreEqual(y.Status, OK);


        //    //MAKE NEW USER TO JOIN WITH.
        //    user.Nickname = "newswag";
        //    r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    token = (string)r.Data.UserToken;
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 60;
        //    //Make sure we can still join back.
        //    x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Accepted);


        //    //New user
        //    user = new ExpandoObject();
        //    user.Nickname = "second";
        //    r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    token = (string)r.Data.UserToken;

        //    //joining game
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 85;
        //    x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Created);
        //}

        ///// <summary>
        ///// This test ensures that forbidden is returned when trying to cancel game with bad tokens. 
        ///// </summary>
        //[TestMethod]
        //public void TestCancelBadUserToken()
        //{
        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "CancelBadTokenTest";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = (string)r.Data.UserToken;

        //    //Joining Game
        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 60;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Accepted);
        //    gameIDforTest = x.Data.GameID;


        //    //making test token.
        //    user.Nickname = "TestToken";
        //    r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    token = (string)r.Data.UserToken;


        //    //CANCELING PENDIng with bad usertoken.
        //    dynamic Cancel = new ExpandoObject();
        //    Cancel.UserToken = "BadToken";
        //    Response y = client.DoPutAsync(Cancel, "games").Result;
        //    Assert.AreEqual(y.Status, Forbidden);

        //    //Canceling pending with good token but not the right one. 
        //    Cancel.UserToken = token;
        //    y = client.DoPutAsync(Cancel, "games").Result;
        //    Assert.AreEqual(y.Status, Forbidden);
        //}

        ///// <summary>
        ///// This test ensures forbidden is returned when trying to cancel a game that doesnt exist.
        ///// </summary>
        //[TestMethod]
        //public void TestCancelNoPendingGame()
        //{

        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "CancelBadTokenTest";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = (string)r.Data.UserToken;

        //    //CANCELING PENDIng with bad usertoken.
        //    dynamic Cancel = new ExpandoObject();
        //    Cancel.UserToken = "BadToken";
        //    Response y = client.DoPutAsync(Cancel, "games").Result;
        //    Assert.AreEqual(y.Status, Forbidden);

        //    //Canceling with good token but no game to cancel. 
        //    Cancel.UserToken = token;
        //    y = client.DoPutAsync(Cancel, "games").Result;
        //    Assert.AreEqual(y.Status, Forbidden);
        //}

        ////TESTING GAMESTATUS.


        ///// <summary>
        ///// This tests for attempting to get the game status when gameID is bad
        ///// </summary>
        //[TestMethod]
        //public void TestJoinGameStatusBadGameID(string gameID)
        //{
        //    Response getResponse = client.DoGetAsync("games/{0}?Brief={1}", "G10000000", "yes").Result;
        //    Assert.IsNull(getResponse.Data);
        //    Assert.AreEqual(getResponse.Status, Forbidden);

        //    getResponse = client.DoGetAsync("games/{0}?Brief={1}", "G12231234", "no").Result;
        //    Assert.IsNull(getResponse.Data);
        //    Assert.AreEqual(getResponse.Status, Forbidden);

        //    getResponse = client.DoGetAsync("games/{0}", "G12222224").Result;
        //    Assert.IsNull(getResponse.Data);
        //    Assert.AreEqual(getResponse.Status, Forbidden);
        //}

        ////TODO:FIX THIS METHOD!!!!
        ///// <summary>
        ///// This tests getting the game status when it should be pending
        ///// </summary>
        //[TestMethod]
        //public void TestJoinGameStatusPENDING()
        //{
        //    Response getResponse = client.DoGetAsync("games/{0}?Brief={1}", gameIDforTest, "yes").Result;
        //    Assert.AreEqual((string)getResponse.Data.GameState, "pending");
        //    Assert.AreEqual(getResponse.Status, OK);


        //    getResponse = client.DoGetAsync("games/{0}?Brief={1}", gameIDforTest, "no").Result;
        //    Assert.AreEqual((string)getResponse.Data.GameState, "pending");
        //    Assert.AreEqual(getResponse.Status, OK);

        //    getResponse = client.DoGetAsync("games/{0}", gameIDforTest).Result;
        //    Assert.AreEqual((string)getResponse.Data.GameState, "pending");
        //    Assert.AreEqual(getResponse.Status, OK);
        //}

        ///// <summary>
        ///// This tests getting the game status when it should be active
        ///// </summary>
        //[TestMethod]
        //public void TestGetGameStatusActive()
        //{
        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "Tester";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = (string)r.Data.UserToken;

        //    //Joining Game
        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 60;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Created);

        //    Response getResponse = client.DoGetAsync("games/{0}?Brief={1}", (string)x.Data.GameID, "yes").Result;
        //    Assert.AreEqual((string)getResponse.Data.GameState, "active");
        //    Assert.IsTrue((int)getResponse.Data.TimeLeft <= 60 && !((int)getResponse.Data.TimeLeft > 60));
        //    Assert.AreEqual((int)getResponse.Data.Player1.Score, 0);
        //    Assert.AreEqual((int)getResponse.Data.Player2.Score, 0);
        //    Assert.AreEqual(getResponse.Status, OK);


        //    getResponse = client.DoGetAsync("games/{0}?Brief={1}", (string)x.Data.GameID, "no").Result;
        //    Assert.AreEqual((string)getResponse.Data.GameState, "active");
        //    Assert.IsTrue((int)getResponse.Data.TimeLeft <= 60 && !((int)getResponse.Data.TimeLeft > 60));
        //    string board = getResponse.Data.Board;
        //    Assert.IsTrue(board.Length == 16);
        //    Assert.AreEqual((int)getResponse.Data.TimeLimit, 60);
        //    Assert.AreEqual((int)getResponse.Data.Player1.Score, 0);
        //    Assert.AreEqual((string)getResponse.Data.Player1.Nickname, "CancelBadTokenTest");
        //    Assert.AreEqual((int)getResponse.Data.Player2.Score, 0);
        //    Assert.AreEqual((string)getResponse.Data.Player2.Nickname, "Tester");
        //    Assert.AreEqual(getResponse.Status, OK);

        //    getResponse = client.DoGetAsync("games/{0}", (string)x.Data.GameID).Result;
        //    Assert.AreEqual((string)getResponse.Data.GameState, "active");
        //    Assert.IsTrue((int)getResponse.Data.TimeLeft <= 60 && !((int)getResponse.Data.TimeLeft > 60));
        //    board = getResponse.Data.Board;
        //    Assert.IsTrue(board.Length == 16);
        //    Assert.AreEqual((int)getResponse.Data.Player1.Score, 0);
        //    Assert.AreEqual((int)getResponse.Data.TimeLimit, 60);
        //    Assert.AreEqual((string)getResponse.Data.Player1.Nickname, "CancelBadTokenTest");
        //    Assert.AreEqual((int)getResponse.Data.Player2.Score, 0);
        //    Assert.AreEqual((string)getResponse.Data.Player2.Nickname, "Tester");
        //    Assert.AreEqual(getResponse.Status, OK);
        //}

        ///// <summary>
        ///// This tests for getting the game status when it is complete
        ///// </summary>
        //[TestMethod]
        //public void TestGetGameStatusComplete()
        //{

        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "swag";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = r.Data.UserToken;

        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 5;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Accepted);


        //    //Creating second user. 
        //    user = new ExpandoObject();
        //    user.Nickname = "swag2";
        //    r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    token = r.Data.UserToken;

        //    newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 5;
        //    x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Created);


        //    Thread.Sleep(5500);

        //    Response getResponse = client.DoGetAsync("games/{0}?Brief={1}", (string)x.Data.GameID, "yes").Result;
        //    Assert.AreEqual((string)getResponse.Data.GameState, "completed");
        //    Assert.IsTrue((int)getResponse.Data.TimeLeft == 0);
        //    Assert.AreEqual((int)getResponse.Data.Player1.Score, 0);
        //    Assert.AreEqual((int)getResponse.Data.Player2.Score, 0);
        //    Assert.AreEqual(getResponse.Status, OK);

        //    getResponse = client.DoGetAsync("games/{0}?Brief={1}", (string)x.Data.GameID, "yes").Result;
        //    Assert.AreEqual((string)getResponse.Data.GameState, "completed");
        //    Assert.IsTrue((int)getResponse.Data.TimeLeft == 0);
        //    Assert.AreEqual((int)getResponse.Data.Player1.Score, 0);
        //    Assert.AreEqual((int)getResponse.Data.Player2.Score, 0);
        //    Assert.AreEqual(getResponse.Status, OK);


        //    getResponse = client.DoGetAsync("games/{0}?Brief={1}", (string)x.Data.GameID, "no").Result;
        //    Assert.AreEqual((string)getResponse.Data.GameState, "completed");
        //    Assert.IsTrue((int)getResponse.Data.TimeLeft == 0);
        //    string board = getResponse.Data.Board;
        //    Assert.IsTrue(board.Length == 16);
        //    Assert.AreEqual((int)getResponse.Data.TimeLimit, 5);
        //    Assert.AreEqual((int)getResponse.Data.Player1.Score, 0);
        //    Assert.AreEqual((string)getResponse.Data.Player1.Nickname, "swag");

        //    //TESTING WORDSPLAYED
        //    dynamic testList = getResponse.Data.Player1.WordsPlayed;
        //    int count = 0;
        //    foreach (dynamic WORDVALUE in testList)
        //    {
        //        count++;
        //    }
        //    Assert.IsTrue(count == 0);

        //    Assert.AreEqual((int)getResponse.Data.Player2.Score, 0);
        //    Assert.AreEqual((string)getResponse.Data.Player2.Nickname, "swag2");

        //    //TESTING WORDS PLAYED.
        //    testList = getResponse.Data.Player1.WordsPlayed;
        //    count = 0;
        //    foreach (dynamic WORDVALUE in testList)
        //    {
        //        count++;
        //    }
        //    Assert.IsTrue(count == 0);
        //    Assert.AreEqual(getResponse.Status, OK);

        //    getResponse = client.DoGetAsync("games/{0}", (string)x.Data.GameID).Result;
        //    Assert.AreEqual((string)getResponse.Data.GameState, "completed");
        //    Assert.IsTrue((int)getResponse.Data.TimeLeft == 0);
        //    board = getResponse.Data.Board;
        //    Assert.IsTrue(board.Length == 16);
        //    Assert.AreEqual((int)getResponse.Data.TimeLimit, 5);
        //    Assert.AreEqual((int)getResponse.Data.Player1.Score, 0);
        //    Assert.AreEqual((string)getResponse.Data.Player1.Nickname, "swag");

        //    testList = getResponse.Data.Player1.WordsPlayed;
        //    count = 0;
        //    foreach (dynamic WORDVALUE in testList)
        //    {
        //        count++;
        //    }
        //    Assert.IsTrue(count == 0);
        //    Assert.AreEqual((int)getResponse.Data.Player2.Score, 0);
        //    Assert.AreEqual((string)getResponse.Data.Player2.Nickname, "swag2");


        //    testList = getResponse.Data.Player1.WordsPlayed;
        //    count = 0;
        //    foreach (dynamic WORDVALUE in testList)
        //    {
        //        count++;
        //    }
        //    Assert.IsTrue(count == 0);
        //    Assert.AreEqual(getResponse.Status, OK);
        //}

        //// Testing SUBMIT WORD

        ///// <summary>
        ///// Tests for submitting all words that are valid
        ///// </summary>
        //[TestMethod]
        //public void TestSubmitWord1()
        //{
        //    //Creating the game

        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "hanna";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = r.Data.UserToken;
        //    string HannahsToken = token;

        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 7;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Accepted);


        //    //Creating second user. 
        //    user = new ExpandoObject();
        //    user.Nickname = "stone";
        //    r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    token = r.Data.UserToken;

        //    newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 7;
        //    x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Created);
        //    Response getResponse = client.DoGetAsync("games/{0}?Brief={1}", (string)x.Data.GameID, "no").Result;

        //    string board = getResponse.Data.Board;

        //    BoggleBoard testBoard = new BoggleBoard(board);


        //    List<string> wordSubmitted = new List<string>();
        //    // dynamic wordToBeSubmitted = new ExpandoObject();
        //    dynamic HannasDyanmic = new ExpandoObject();
        //    HannasDyanmic.UserToken = HannahsToken;
        //    StreamReader dictionaryL = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/dictionary.txt");
        //    string currentLine;
        //    user.UserToken = token;
        //    dynamic wordSubmitter = new ExpandoObject();
        //    wordSubmitter.UserToken = token;

        //    int count = 0;

        //    while ((currentLine = dictionaryL.ReadLine()) != null)
        //    {
        //        if (testBoard.CanBeFormed(currentLine))
        //        {
        //            wordSubmitted.Add(currentLine);

        //            wordSubmitter.Word = currentLine;
        //            Response putReponse = client.DoPutAsync(wordSubmitter, "games/" + (string)x.Data.GameID).Result;
        //            Assert.AreEqual(OK, putReponse.Status);

        //            HannasDyanmic.Word = currentLine;
        //            putReponse = client.DoPutAsync(HannasDyanmic, "games/" + (string)x.Data.GameID).Result;
        //            Assert.AreEqual(OK, putReponse.Status);

        //            //Add two of the same words twice. 
        //            if(count == 0)
        //            {

        //                 putReponse = client.DoPutAsync(wordSubmitter, "games/" + (string)x.Data.GameID).Result;
        //                Assert.AreEqual(OK, putReponse.Status);
        //                putReponse = client.DoPutAsync(HannasDyanmic, "games/" + (string)x.Data.GameID).Result;
        //                Assert.AreEqual(OK, putReponse.Status);
        //                //Testing in the board not in the dictionary. 
        //                string boardWORD = "";
        //                boardWORD = boardWORD + board[0] + board[1] + board[2] + board[3] + board[7] + board[6] + board[5] + board[4];
        //                wordSubmitted.Add(boardWORD);
        //                HannasDyanmic.Word = boardWORD;
        //                putReponse = client.DoPutAsync(HannasDyanmic, "games/" + (string)x.Data.GameID).Result;
        //                Assert.AreEqual(OK, putReponse.Status);
        //                wordSubmitter.Word = boardWORD;
        //                putReponse = client.DoPutAsync(wordSubmitter, "games/" + (string)x.Data.GameID).Result;
        //                Assert.AreEqual(OK, putReponse.Status);

        //            }
        //            count++;
        //        }
        //    }

        //    Thread.Sleep(7000);

        //    getResponse = client.DoGetAsync("games/{0}?Brief={1}", (string)x.Data.GameID, "no").Result;
        //    dynamic WORDSPLAYED = getResponse.Data.Player2.WordsPlayed;
        //    HannasDyanmic = getResponse.Data.Player1.WordsPlayed;
        //    HashSet<string> setOfWords = new HashSet<string>(wordSubmitted);
        //    List<string> wordsPlayedLIST = new List<string>();

        //    foreach (dynamic checkWord in WORDSPLAYED)
        //    {
        //        Assert.IsTrue(wordSubmitted.Contains((string)checkWord.Word));
        //        wordsPlayedLIST.Add((string)checkWord.Word);
        //    }

        //    Assert.IsTrue(setOfWords.SetEquals(wordsPlayedLIST));
        //    wordsPlayedLIST.Clear();

        //    foreach (dynamic checkWord in HannasDyanmic)
        //    {
        //        Assert.IsTrue(wordSubmitted.Contains((string)checkWord.Word));
        //        wordsPlayedLIST.Add((string)checkWord.Word);
        //    }

        //    Assert.IsTrue(setOfWords.SetEquals(wordsPlayedLIST));
        //}

        ///// <summary>
        ///// Tests submitting a word when the string is null
        ///// </summary>
        //[TestMethod]
        //public void TestSubmitNull()
        //{
        //    //Creating the game

        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "hanna";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = r.Data.UserToken;
        //    string HannahsToken = token;

        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 7;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Accepted);


        //    //Creating second user. 
        //    user = new ExpandoObject();
        //    user.Nickname = "stone";
        //    r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    token = r.Data.UserToken;

        //    newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 7;
        //    x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Created);
        //    Response getResponse = client.DoGetAsync("games/{0}?Brief={1}", (string)x.Data.GameID, "no").Result;

        //    dynamic HannasDyanmic = new ExpandoObject();
        //    HannasDyanmic.UserToken = HannahsToken;
        //    user.UserToken = token;
        //    user.Word = null;
        //    Response putReponse = client.DoPutAsync(user, "games/" + (string)x.Data.GameID).Result;
        //    Assert.AreEqual(Forbidden, putReponse.Status);

        //    HannasDyanmic.Word = null;
        //    putReponse = client.DoPutAsync(HannasDyanmic, "games/" + (string)x.Data.GameID).Result;
        //    Assert.AreEqual(Forbidden, putReponse.Status);
        //}

        ///// <summary>
        ///// Tests submitting a word when the string is empty
        ///// </summary>
        //[TestMethod]
        //public void TestSubmitEmpty()
        //{
        //    //Creating the game

        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "hanna";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = r.Data.UserToken;
        //    string HannahsToken = token;

        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 7;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Accepted);


        //    //Creating second user. 
        //    user = new ExpandoObject();
        //    user.Nickname = "stone";
        //    r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    token = r.Data.UserToken;

        //    newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 7;
        //    x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Created);
        //    Response getResponse = client.DoGetAsync("games/{0}?Brief={1}", (string)x.Data.GameID, "no").Result;

        //    dynamic HannasDyanmic = new ExpandoObject();
        //    HannasDyanmic.UserToken = HannahsToken;
        //    user.UserToken = token;
        //    user.Word = "";
        //    Response putReponse = client.DoPutAsync(user, "games/" + (string)x.Data.GameID).Result;
        //    Assert.AreEqual(Forbidden, putReponse.Status);

        //    HannasDyanmic.Word = "";
        //    putReponse = client.DoPutAsync(HannasDyanmic, "games/" + (string)x.Data.GameID).Result;
        //    Assert.AreEqual(Forbidden, putReponse.Status);
        //}



        ///// <summary>
        ///// Tests submitting a word when game is not active
        ///// </summary>
        //[TestMethod]
        //public void TestSubmitNotActive()
        //{
        //    //Creating the game

        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "hanna";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = r.Data.UserToken;
        //    string HannahsToken = token;

        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 7;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Accepted);


        //    //Creating second user. 
        //    user = new ExpandoObject();
        //    user.Nickname = "stone";
        //    r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    token = r.Data.UserToken;

        //    newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 7;
        //    x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Created);
        //    Thread.Sleep(7000);
        //    Response getResponse = client.DoGetAsync("games/{0}?Brief={1}", (string)x.Data.GameID, "no").Result;

        //    dynamic HannasDyanmic = new ExpandoObject();
        //    HannasDyanmic.UserToken = HannahsToken;
        //    user.UserToken = token;
        //    user.Word = "test";
        //    Response putReponse = client.DoPutAsync(user, "games/" + (string)x.Data.GameID).Result;
        //    Assert.AreEqual(Conflict, putReponse.Status);

        //    HannasDyanmic.Word = "test";
        //    putReponse = client.DoPutAsync(HannasDyanmic, "games/" + (string)x.Data.GameID).Result;
        //    Assert.AreEqual(Conflict, putReponse.Status);
        //}

        ///// <summary>
        ///// Tests submitting a word when the string is invalid
        ///// </summary>
        //[TestMethod]
        //public void TestSubmitInvalid()
        //{
        //    //Creating the game

        //    //Creating first user. 
        //    dynamic user = new ExpandoObject();
        //    user.Nickname = "hanna";
        //    Response r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    string token = r.Data.UserToken;
        //    string HannahsToken = token;

        //    dynamic newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 7;
        //    Response x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Accepted);


        //    //Creating second user. 
        //    user = new ExpandoObject();
        //    user.Nickname = "stone";
        //    r = client.DoPostAsync("users", user).Result;
        //    Assert.AreEqual(Created, r.Status);
        //    token = r.Data.UserToken;

        //    newGame = new ExpandoObject();
        //    newGame.UserToken = token;
        //    newGame.TimeLimit = 7;
        //    x = client.DoPostAsync("games", newGame).Result;
        //    Assert.AreEqual(x.Status, Created);
        //    Response getResponse = client.DoGetAsync("games/{0}?Brief={1}", (string)x.Data.GameID, "no").Result;

        //    dynamic HannasDyanmic = new ExpandoObject();
        //    HannasDyanmic.UserToken = HannahsToken;
        //    user.UserToken = token;
        //    user.Word = "123";
        //    Response putReponse = client.DoPutAsync(user, "games/" + (string)x.Data.GameID).Result;
        //    Assert.AreEqual(OK, putReponse.Status);

        //    HannasDyanmic.Word = "123";
        //    putReponse = client.DoPutAsync(HannasDyanmic, "games/" + (string)x.Data.GameID).Result;
        //    Assert.AreEqual(OK, putReponse.Status);
        //}

        //[TestClass]
        //public class Tests
        //{
            /// <summary>
            /// Creates an HttpClient for communicating with the boggle server.
            /// </summary>
            private static HttpClient CreateClient()
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:60000");
                //client.BaseAddress = new Uri("http://bogglecs3500s16db.azurewebsites.net");
                return client;
            }

            /// <summary>
            /// Helper for serializaing JSON.
            /// </summary>
            private static StringContent Serialize(dynamic json)
            {
                return new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
            }

            /// <summary>
            /// Given a board configuration, returns all the valid words.
            /// </summary>
            private static IList<string> AllValidWords(string board)
            {
                ISet<string> dictionary = new HashSet<string>();
                using (StreamReader words = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/dictionary.txt"))
                {
                    string word;
                    while ((word = words.ReadLine()) != null)
                    {
                        dictionary.Add(word.ToUpper());
                    }
                }
                BoggleBoard bb = new BoggleBoard(board);
                List<string> validWords = new List<string>();
                foreach (string word in dictionary)
                {
                    if (bb.CanBeFormed(word))
                    {
                        validWords.Add(word);
                    }
                }
                return validWords;
            }

            /// <summary>
            /// Returns the score for a word.
            /// </summary>
            private static int GetScore(string word)
            {
                switch (word.Length)
                {
                    case 1:
                    case 2:
                        return 0;
                    case 3:
                    case 4:
                        return 1;
                    case 5:
                        return 2;
                    case 6:
                        return 3;
                    case 7:
                        return 5;
                    default:
                        return 11;
                }
            }

            /// <summary>
            /// Makes a user and asserts that the resulting status code is equal to the
            /// status parameter.  Returns a Task that will produce the new userID.
            /// </summary>
            private async Task<string> MakeUser(String nickname, HttpStatusCode status)
            {
                dynamic name = new ExpandoObject();
                name.Nickname = nickname;

                using (HttpClient client = CreateClient())
                {
                    HttpResponseMessage response = await client.PostAsync("/BoggleService.svc/users", Serialize(name));
                    Assert.AreEqual(status, response.StatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        String result = await response.Content.ReadAsStringAsync();
                        dynamic user = JsonConvert.DeserializeObject(result);
                        Assert.IsNotNull(user.UserToken);
                        return user.UserToken;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            /// <summary>
            /// Joins the game and asserts that the resulting status code is equal to the parameter status.
            /// Returns a Task that will produce the new GameID.
            /// </summary>
            private async Task<string> JoinGame(String player, int timeLimit, HttpStatusCode status)
            {
                dynamic user = new ExpandoObject();
                user.UserToken = player;
                user.TimeLimit = timeLimit;

                using (HttpClient client = CreateClient())
                {
                    HttpResponseMessage response = await client.PostAsync("/BoggleService.svc/games", Serialize(user));
                    Assert.AreEqual(status, response.StatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        String result = await response.Content.ReadAsStringAsync();
                        dynamic game = JsonConvert.DeserializeObject(result);
                        Assert.IsNotNull(game.GameID);
                        return game.GameID;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            /// <summary>
            /// Cancels the pending game and asserts that the resulting status code is
            /// equal to the parameter status.
            /// </summary>
            private async Task CancelGame(String player, HttpStatusCode status)
            {
                dynamic user = new ExpandoObject();
                user.UserToken = player;

                using (HttpClient client = CreateClient())
                {
                    HttpResponseMessage response = await client.PutAsync("/BoggleService.svc/games", Serialize(user));
                    Assert.AreEqual(status, response.StatusCode);
                }
            }

            /// <summary>
            /// Gets the status for the specified game and value of brief.  Asserts that the resulting
            /// status code is equal to the parameter status.  Returns a task that produces the object
            /// returned by the service.
            /// </summary>
            private async Task<dynamic> GetStatus(String game, string brief, HttpStatusCode status)
            {
                using (HttpClient client = CreateClient())
                {
                    HttpResponseMessage response = await client.GetAsync("/BoggleService.svc/games/" + game + "?brief=" + brief);
                    Assert.AreEqual(status, response.StatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        String result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject(result);
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            /// <summary>
            /// Plays a word and asserts that the resulting status code is equal to the parameter
            /// status.  Returns a task that will produce the score of the word.
            /// </summary>
            private async Task<int> PlayWord(String player, String game, String word, HttpStatusCode status)
            {
                dynamic play = new ExpandoObject();
                play.UserToken = player;
                play.Word = word;

                using (HttpClient client = CreateClient())
                {
                    HttpResponseMessage response = await client.PutAsync("/BoggleService.svc/games/" + game, Serialize(play));
                    Assert.AreEqual(status, response.StatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        String result = await response.Content.ReadAsStringAsync();
                        dynamic score = JsonConvert.DeserializeObject(result);
                        return score.Score;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }

            /// <summary>
            /// Try to make a user.
            /// </summary>
            [TestMethod]
            public void TestMakeUser()
            {
                MakeUser(null, Forbidden).Wait();
                MakeUser("  ", Forbidden).Wait();
                MakeUser("Player", Created).Wait();
            }

            /// <summary>
            /// Try to make a game.
            /// </summary>
            [TestMethod]
            public void TestJoinGame()
            {
                JoinGame("hello", 10, Forbidden).Wait();
                JoinGame("hello", 1, Forbidden).Wait();
                String player1 = MakeUser("Player 1", Created).Result;
                String player2 = MakeUser("Player 2", Created).Result;
                JoinGame(player1, 4, Forbidden).Wait();
                JoinGame(player1, 121, Forbidden).Wait();

                String game1 = JoinGame(player1, 10, Accepted).Result;
                JoinGame(player1, 10, Conflict).Wait();
                String game2 = JoinGame(player2, 10, Created).Result;
                Assert.AreEqual(game1, game2);

                String player3 = MakeUser("Player 3", Created).Result;
                String player4 = MakeUser("Player 4", Created).Result;
                String game3 = JoinGame(player3, 10, Accepted).Result;
                JoinGame(player3, 10, Conflict).Wait();
                String game4 = JoinGame(player4, 10, Created).Result;
                Assert.AreEqual(game3, game4);

                Assert.AreNotEqual(game1, game3);
            }

            /// <summary>
            /// Test canceling a game.
            /// </summary>
            [TestMethod]
            public void TestCancelGame()
            {
                String player1 = MakeUser("Player 1", Created).Result;
                String player2 = MakeUser("Player 2", Created).Result;
                String game1 = JoinGame(player1, 10, Accepted).Result;
                CancelGame(null, Forbidden).Wait();
                CancelGame("  ", Forbidden).Wait();
                CancelGame(player2, Forbidden).Wait();
                CancelGame(player1, OK).Wait();
                CancelGame(player1, Forbidden).Wait();
                String game2 = JoinGame(player1, 10, Accepted).Result;
                String game3 = JoinGame(player2, 10, Created).Result;
                Assert.AreEqual(game2, game3);
            }

            /// <summary>
            /// Test getting status
            /// </summary>
            [TestMethod]
            public void TestStatus1()
            {
                String player1 = MakeUser("Player 1", Created).Result;
                String player2 = MakeUser("Player 2", Created).Result;
                String game1 = JoinGame(player1, 10, Accepted).Result;
                GetStatus(game1, "no", OK).Wait();
                String game2 = JoinGame(player2, 20, Created).Result;
                GetStatus(game1, "no", OK).Wait();

                GetStatus("blank", "no", Forbidden).Wait();
                dynamic status = GetStatus(game1, "no", OK).Result;
                Assert.AreEqual("active", (string)status.GameState);
                Assert.AreEqual(16, ((string)status.Board).Length);
                Assert.AreEqual(15, (int)status.TimeLimit);
                Assert.IsTrue((int)status.TimeLeft <= 120 && (int)status.TimeLeft > 0);
                Assert.AreEqual("Player 1", (string)status.Player1.Nickname);
                Assert.AreEqual(0, (int)status.Player1.Score);
                Assert.AreEqual("Player 2", (string)status.Player2.Nickname);
                Assert.AreEqual(0, (int)status.Player2.Score);
            }

            /// <summary>
            /// Try to playing a word.
            /// </summary>
            [TestMethod]
            public void TestPlayWord1()
            {
                String player1 = MakeUser("Player 1", Created).Result;
                String player2 = MakeUser("Player 2", Created).Result;
                String player3 = MakeUser("Player 3", Created).Result;
                String game1 = JoinGame(player1, 10, Accepted).Result;
                PlayWord(player1, game1, "a", Conflict).Wait();
                String game2 = JoinGame(player2, 30, Created).Result;
                Assert.AreEqual(game1, game2);

                PlayWord(player1, game1, null, Forbidden).Wait();
                PlayWord(player1, game1, "  ", Forbidden).Wait();
                PlayWord(null, game1, "a", Forbidden).Wait();
                PlayWord("blank", game1, "a", Forbidden).Wait();
                PlayWord(player3, game1, "a", Forbidden).Wait();
                PlayWord(player1, "blank", "a", Forbidden).Wait();

                Assert.AreEqual(-1, PlayWord(player1, game1, "xxxxxx", OK).Result);
                Assert.AreEqual(-1, PlayWord(player2, game1, "xxxxxx", OK).Result);

                Assert.AreEqual(0, PlayWord(player1, game1, "xxxxxx", OK).Result);
                Assert.AreEqual(0, PlayWord(player2, game1, "xxxxxx", OK).Result);

                Assert.AreEqual(0, PlayWord(player1, game1, "q", OK).Result);
                Assert.AreEqual(0, PlayWord(player2, game1, "q", OK).Result);
            }

            /// <summary>
            /// Try to play a lot of words.
            /// </summary>
            [TestMethod]
            public void TestPlayWord2()
            {
                // Time limit of game in seconds
                int LIMIT = 30;

                String player1 = MakeUser("Player 1", Created).Result;
                String player2 = MakeUser("Player 2", Created).Result;
                String player3 = MakeUser("Player 3", Created).Result;
                String game1 = JoinGame(player1, LIMIT, Accepted).Result;
                String game2 = JoinGame(player2, LIMIT, Created).Result;
                Assert.AreEqual(game1, game2);

                string board = GetStatus(game1, "no", OK).Result.Board;

                // Play up to LIMIT words
                int limit = LIMIT;
                foreach (string word in AllValidWords(board))
                {
                    if (limit-- == 0) break;
                    if (word.Length >= 3)
                    {
                        Console.WriteLine(word);
                        Assert.AreEqual(GetScore(word), PlayWord(player1, game1, word, OK).Result);
                        Assert.AreEqual(GetScore(word), PlayWord(player2, game1, word, OK).Result);
                    }
                }
            }

            /// <summary>
            /// Gets the status and asserts that it is as described in the parameters.
            /// </summary>
            private void CheckStatus(string game, string state, string brief, string p1, string p2, string n1, string n2, string b,
                                     List<string> w1, List<string> w2, List<int> s1, List<int> s2, int timeLimit)
            {
                dynamic status = GetStatus(game, brief, OK).Result;
                Assert.AreEqual(state, (string)status.GameState);

                if (state == "pending")
                {
                    Assert.IsNull(status.TimeLimit);
                    Assert.IsNull(status.TimeLeft);
                    Assert.IsNull(status.Board);
                    Assert.IsNull(status.Player1);
                    Assert.IsNull(status.Player2);
                }
                else if (brief == "yes")
                {
                    Assert.IsNull(status.TimeLimit);
                    Assert.IsNull(status.Board);
                    Assert.IsNull(status.Player1.WordsPlayed);
                    Assert.IsNull(status.Player1.Nickname);
                    Assert.IsNull(status.Player2.WordsPlayed);
                    Assert.IsNull(status.Player2.Nickname);
                }
                else if (state == "active")
                {
                    Assert.IsNull(status.Player1.WordsPlayed);
                    Assert.IsNull(status.Player2.WordsPlayed);
                }

                if (state == "active" || state == "completed")
                {
                    Assert.IsTrue((int)status.TimeLeft <= timeLimit);
                    if (state == "active")
                    {
                        Assert.IsTrue((int)status.TimeLeft > 0);
                    }
                    else
                    {
                        Assert.IsTrue((int)status.TimeLeft >= 0);
                    }

                    int total1 = 0;
                    for (int i = 0; i < s1.Count; i++)
                    {
                        total1 += s1[i];
                    }
                    Assert.AreEqual(total1, (int)status.Player1.Score);

                    int total2 = 0;
                    for (int i = 0; i < s2.Count; i++)
                    {
                        total2 += s2[i];
                    }
                    Assert.AreEqual(total2, (int)status.Player2.Score);

                    if (brief != "yes")
                    {
                        Assert.AreEqual(b, (string)status.Board);
                        Assert.AreEqual(timeLimit, (int)status.TimeLimit);
                        Assert.AreEqual(n1, (string)status.Player1.Nickname);
                        Assert.AreEqual(n2, (string)status.Player2.Nickname);

                        if (state == "completed")
                        {
                            List<dynamic> words1 = new List<dynamic>(status.Player1.WordsPlayed);
                            List<dynamic> words2 = new List<dynamic>(status.Player2.WordsPlayed);
                            Assert.AreEqual(w1.Count, words1.Count);
                            Assert.AreEqual(w2.Count, words2.Count);

                            for (int i = 0; i < w1.Count; i++)
                            {
                                Assert.AreEqual(w1[i], (string)words1[i].Word);
                                Assert.AreEqual(s1[i], (int)words1[i].Score);
                            }

                            for (int i = 0; i < w2.Count; i++)
                            {
                                Assert.AreEqual(w2[i], (string)words2[i].Word);
                                Assert.AreEqual(s2[i], (int)words2[i].Score);
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Try to play a lot of words while checking status.
            /// </summary>
            [TestMethod]
            public void TestPlayWord3()
            {
                // Play for LIMIT seconds
                int LIMIT = 30;
                var words1 = new List<string>();
                var words2 = new List<string>();
                var scores1 = new List<int>();
                var scores2 = new List<int>();

                String player1 = MakeUser("Player 1", Created).Result;
                String player2 = MakeUser("Player 2", Created).Result;
                String game1 = JoinGame(player1, LIMIT, Accepted).Result;
                CheckStatus(game1, "pending", "no", player1, "", "", "", "", words1, words2, scores1, scores2, 0);
                String game2 = JoinGame(player2, LIMIT, Created).Result;
                Assert.AreEqual(game1, game2);

                DateTime startTime = DateTime.Now;

                string board = GetStatus(game1, "no", OK).Result.Board;

                CheckStatus(game1, "active", "no", player1, player2, "Player 1", "Player 2", board, words1, words2, scores1, scores2, 30);

                int limit = LIMIT;
                PlayWord(player1, game1, "xyzzy", OK).Wait();
                words1.Add("xyzzy");
                scores1.Add(-1);
                foreach (string word in AllValidWords(board))
                {
                    if (limit-- == 0) break;
                    Assert.AreEqual(GetScore(word), PlayWord(player1, game1, word, OK).Result);
                    words1.Add(word);
                    scores1.Add(GetScore(word));
                    Assert.AreEqual(GetScore(word), PlayWord(player2, game1, word, OK).Result);
                    words2.Add(word);
                    scores2.Add(GetScore(word));
                    CheckStatus(game1, "active", "no", player1, player2, "Player 1", "Player 2", board, words1, words2, scores1, scores2, 30);
                    CheckStatus(game1, "active", "yes", player1, player2, "Player 1", "Player 2", board, words1, words2, scores1, scores2, 30);
                }

                // Wait until the game is over before checking the final status.
                int timeRemaining = LIMIT - (int)Math.Ceiling(DateTime.Now.Subtract(startTime).TotalSeconds);
                Thread.Sleep((timeRemaining + 2) * 1000);

                CheckStatus(game1, "completed", "no", player1, player2, "Player 1", "Player 2", board, words1, words2, scores1, scores2, 30);
                CheckStatus(game1, "completed", "yes", player1, player2, "Player 1", "Player 2", board, words1, words2, scores1, scores2, 30);
                PlayWord(player1, game1, "a", Conflict).Wait();
                PlayWord(player1, game1, "b", Conflict).Wait();
            }

            /// <summary>
            /// Test game timing
            /// </summary>
            [TestMethod]
            public void TestTiming()
            {
                String player1 = MakeUser("Player 1", Created).Result;
                String player2 = MakeUser("Player 2", Created).Result;
                String game1 = JoinGame(player1, 10, Accepted).Result;
                String game2 = JoinGame(player2, 10, Created).Result;
                string board = GetStatus(game1, "no", OK).Result.Board;

                Task t = new Task(() => TimerTester(game1, 10));
                t.Start();
                t.Wait();

                CheckStatus(game1, "completed", "yes", player1, player2, "Player 1", "Player 2", null, null, null, new List<int>(), new List<int>(), 10);
                CheckStatus(game1, "completed", "no", player1, player2, "Player 1", "Player 2", board, new List<string>(), new List<string>(), new List<int>(), new List<int>(), 10);

            }

            /// <summary>
            /// Helper for checking that times are reported semi-accurately.
            /// </summary>
            private void TimerTester(string game1, int limit)
            {
                while (limit >= 0)
                {
                    int timeRemaining = GetStatus(game1, "yes", OK).Result.TimeLeft;
                    Assert.IsTrue(timeRemaining <= limit + 1 && timeRemaining >= limit - 1);
                    limit--;
                    Thread.Sleep(1000);
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Stores the components of a word: Score & string
        /// </summary>
        //public class WordValue
        //{
        //    public string Word { get; set; }
        //    public string Score { get; set; }
        //}
    }
//}

