// Hanna Larsen & Salvatore Stone Mele
// u0741837        u0897718
// CS 3500  PS10 
// 04/05/16
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.ServiceModel.Web;
using static System.Net.HttpStatusCode;

namespace Boggle
{
    /// <summary>
    /// This class creates a service that returns game information when interacting with the client
    /// </summary>
    public class BoggleService : IBoggleService
    {
        /// <summary>
        /// Represents the gameID
        /// </summary>
        private static int gameNum = 0;

        /// <summary>
        /// This queue should only hold one value at a time and that should be a UserToken.
        /// </summary>
        private static Queue<string> needed = new Queue<string>();

        /// <summary>
        /// Maps the user token to the nickname
        /// </summary>
        private readonly static Dictionary<string, string> users = new Dictionary<string, string>();

        /// <summary>
        /// Maps the user token to the gameID
        /// </summary>
        private readonly static Dictionary<string, gameIDClass> currentPlayersinGame = new Dictionary<string, gameIDClass>();

        /// <summary>
        /// Maps the gameID to game info
        /// </summary>
        private readonly static Dictionary<string, GameInfo> games = new Dictionary<string, GameInfo>();

        /// <summary>
        /// HashSet that contains all the words in the dictionary.txt.
        /// </summary>
        private static HashSet<string> dictonaryWords = new HashSet<string>();

        /// <summary>
        /// object used for syncing
        /// </summary>
        private static readonly object sync = new object();


        /// <summary>
        /// The connection string to the DB
        /// </summary>
        private static string BoggleDB;

        static BoggleService()
        {
            // Saves the connection string for the database.  A connection string contains the
            // information necessary to connect with the database server.  When you create a
            // DB, there is generally a way to obtain the connection string.  From the Server
            // Explorer pane, obtain the properties of DB to see the connection string.

            // The connection string of my ToDoDB.mdf shows as
            //
            //    Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\zachary\Source\CS 3500 S16\examples\ToDoList\ToDoListDB\App_Data\ToDoDB.mdf";Integrated Security=True
            //
            // Unfortunately, this is absolute pathname on my computer, which means that it
            // won't work if the solution is moved.  Fortunately, it can be shorted to
            //
            //    Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="|DataDirectory|\ToDoDB.mdf";Integrated Security=True
            //
            // You should shorten yours this way as well.
            //
            // Rather than build the connection string into the program, I store it in the Web.config
            // file where it can be easily found and changed.  You should do that too.
            BoggleDB = ConfigurationManager.ConnectionStrings["BoggleDB"].ConnectionString;
        }

        /// <summary>
        /// If the userToken that is given from the parameter matches that of the player in the pending
        /// queue then that player will be removed from the pending queue and any other data
        /// structure that holds a game state.
        /// </summary>
        /// <param name="UI">UserToken of player that wants to be taken from the Queue.</param>
        public void CancelJoin(UserInfo UI)
        {
            lock (sync)
            {
                // Check if pending player
                if (needed.Count == 1 && needed.Peek() == UI.UserToken)
                { 
                    //If the UserToken is the same as the player in the queue remove them from the queue.
                    needed.Dequeue();
                    string tempGameId = currentPlayersinGame[UI.UserToken].GameID;
                    currentPlayersinGame.Remove(UI.UserToken);
                    users.Remove(UI.UserToken);
                    games.Remove(tempGameId);
                    //Set status to OK.
                    SetStatus(OK);
                }
                else
                {
                    //If there not in the queue then there is no where to take that user out from. 
                    SetStatus(Forbidden);
                }
            }
        }


        /// <summary>
        /// This method accepts a userToken and a game ID. 
        /// </summary>
        /// <param name="wordInfo"></param>
        /// <param name="GivenGameID"></param>
        /// <returns></returns>
        public ScoreResponse SubmitWord(WordSubmit wordInfo, string GivenGameID)
        {
            lock (sync)
            {
                GameInfo currentGame = games[currentPlayersinGame[wordInfo.UserToken].GameID];
                //If word is empty or null, or usertoken is not in a real game then set status to forbidden.
                if (wordInfo.Word == null || wordInfo.Word.Trim().Length == 0 || !currentPlayersinGame.ContainsKey(wordInfo.UserToken))
                {
                    SetStatus(Forbidden);
                    return null;
                }
                //If game is not active. 
                else if (currentGame.GameState != "active")
                {
                    SetStatus(Conflict);
                    return null;
                }
                //If game is active then score word and add it to the players words_played list. 
                else
                {
                    SetStatus(OK);
                    ScoreResponse returnInfo = new ScoreResponse();
                    string word = wordInfo.Word.Trim();
                    // If the word can be formed on the board
                    if (currentGame.Board.CanBeFormed(word))
                    {
                        // If the word is in the dictionary
                        if (dictonaryWords.Contains(wordInfo.Word.ToUpper()))
                        {
                            // Determines the score based on word length
                            int word_length = word.Length;

                            if (word_length < 3)
                            {
                                returnInfo.Score = "0";
                            }
                            else if (word_length >= 3 && word_length < 5)
                            {
                                returnInfo.Score = "1";
                            }
                            else if (word_length == 5)
                            {
                                returnInfo.Score = "2";
                            }
                            else if (word_length == 6)
                            {
                                returnInfo.Score = "3";
                            }
                            else if (word_length == 7)
                            {
                                returnInfo.Score = "5";
                            }
                            else
                            {
                                returnInfo.Score = "11";
                            }
                        }
                        else
                        {
                            returnInfo.Score = "-1";
                        }
                    }
                    else
                    {
                        returnInfo.Score = "-1";
                    }
                    // Checks to see if a word has already been played
                    // If yes, returns a score of 0
                    if (currentGame.Player1.UserToken == wordInfo.UserToken)
                    {
                        WordValue info = new WordValue();
                        foreach (WordValue x in currentGame.Player1.WordsPlayed)
                        {
                            if (x.Word == wordInfo.Word)
                            {
                                returnInfo.Score = "0";
                                break;
                            }
                        }
                        info.Word = wordInfo.Word;
                        info.Score = returnInfo.Score;
                        currentGame.Player1.WordsPlayed.Add(info);

                        //Updating the score. 
                        int scoreValue = int.Parse(returnInfo.Score);
                        currentGame.Player1.Score = currentGame.Player1.Score + scoreValue;
                    }
                    // Same for Player 2
                    else
                    {
                        WordValue info = new WordValue();
                        foreach (WordValue x in currentGame.Player2.WordsPlayed)
                        {
                            if (x.Word == wordInfo.Word)
                            {
                                returnInfo.Score = "0";
                                break;
                            }
                        }
                        info.Word = wordInfo.Word;
                        info.Score = returnInfo.Score;
                        currentGame.Player2.WordsPlayed.Add(info);

                        //Updating the score.
                        int scoreValue = int.Parse(returnInfo.Score);
                        currentGame.Player2.Score = currentGame.Player2.Score + scoreValue;
                    }
                    //RETURN WORD SCORE. 
                    return returnInfo;
                }
            }
        }

        /// <summary>
        /// This method will get the elapsed time in seconds from a given long time. 
        /// </summary>
        /// <param name="startTime"></param>
        /// <returns></returns>
        private int getElapsedTime(long startTime)
        {
            //This subtracts the currentTime from the start time. WE then divide it by 1000 to get a value in
            //seconds. Round the  value to get a more accurate result.
            double seconds = ((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) -startTime) / 1000;
            return (int)Math.Round(seconds);
        }

        /// <summary>
        /// Gets the current status of game with Given GameID. If a bad GameID is given or one that does not exist in the 
        /// current service then respond with a Forbidden Status. 
        /// </summary>
        /// <param name="GivenGameID">TGameID that user wants to get gameStatus from. </param>
        /// <param name="answer">The answer that is given in the brief address.</param>
        /// <returns>An object with serialized information on the gameStatus.</returns>
        public GameStateClass getGameStatus(string GivenGameID, string answer)
        {
            lock (sync)
            {
                if (games.ContainsKey(GivenGameID))
                {
                    SetStatus(OK);
                    GameInfo currentGame = games[GivenGameID];
                    GameStateClass ReturnInfo = new GameStateClass();
                    //IF THE GAME IS PENDING DO THIS.
                    if (currentGame.GameState == "pending")
                    {
                        ReturnInfo.GameState = "pending";
                        return ReturnInfo;
                    }
                    //IF ITS ACTIVE DO THIS
                    else if (currentGame.GameState == "active")
                    {
                        //If brief is yes do this.
                        if (answer == "yes")
                        {
                            ReturnInfo.Player1 = new Player();
                            ReturnInfo.Player2 = new Player();

                            //If the time is already expired just set TimeLeft to 0. 
                            int minusTime = getElapsedTime(currentGame.StartTimeInMilliseconds);
                            if (minusTime >= currentGame.TimeLimit)
                            {
                                //If the game was previously active but the time got set to zero then add all the values we need for 
                                //complete game.
                                ReturnInfo.TimeLeft = 0;
                                currentGame.GameState = "completed";
                            }
                            else
                            {
                                ReturnInfo.TimeLeft = currentGame.TimeLimit - minusTime;
                            }

                            //Setting state
                            ReturnInfo.GameState = currentGame.GameState;

                            //Setting Score
                            ReturnInfo.Player1.Score = currentGame.Player1.Score;
                            ReturnInfo.Player2.Score = currentGame.Player2.Score;
                            return ReturnInfo;
                        }
                        //If not brief do this.
                        else
                        {
                            ReturnInfo.Player1 = new Player();
                            ReturnInfo.Player2 = new Player();

                            ReturnInfo.Board = currentGame.Board.ToString();
                            int minusTime = getElapsedTime(currentGame.StartTimeInMilliseconds);
                            if (minusTime >= currentGame.TimeLimit)
                            {
                                //If the game was previously active but the time got set to zero then add all the values we need for 
                                //complete game.
                                ReturnInfo.TimeLeft = 0;
                                currentGame.GameState = "completed";
                                ReturnInfo.Player1.WordsPlayed = currentGame.Player1.WordsPlayed;
                                ReturnInfo.Player2.WordsPlayed = currentGame.Player2.WordsPlayed;
                            }
                            else
                            {
                                ReturnInfo.TimeLeft = currentGame.TimeLimit - minusTime;
                            }

                            //Setting GameState
                            ReturnInfo.GameState = currentGame.GameState;

                            //Setting timelimit & player info
                            ReturnInfo.TimeLimit = currentGame.TimeLimit;
                            ReturnInfo.Player1.Nickname = currentGame.Player1.Nickname;
                            ReturnInfo.Player1.Score = currentGame.Player1.Score;
                            ReturnInfo.Player2.Nickname = currentGame.Player2.Nickname;
                            ReturnInfo.Player2.Score = currentGame.Player2.Score;
                            return ReturnInfo;
                        }
                    }
                    // If the status is completed
                    else
                    {
                        if (answer == "yes")
                        {
                            ReturnInfo.Player1 = new Player();
                            ReturnInfo.Player2 = new Player();
                            ReturnInfo.GameState = "completed";
                            ReturnInfo.TimeLeft = 0;
                            ReturnInfo.Player1.Score = currentGame.Player1.Score;
                            ReturnInfo.Player2.Score = currentGame.Player2.Score;
                            return ReturnInfo;
                        }
                        //If not brief do this.
                        else
                        {
                            ReturnInfo.Player1 = new Player();
                            ReturnInfo.Player2 = new Player();
                            ReturnInfo.GameState = "completed";
                            ReturnInfo.Board = currentGame.Board.ToString();
                            ReturnInfo.TimeLeft = 0;
                            ReturnInfo.TimeLimit = currentGame.TimeLimit;
                            // Player 1
                            ReturnInfo.Player1.Nickname = currentGame.Player1.Nickname;
                            ReturnInfo.Player1.Score = currentGame.Player1.Score;
                            ReturnInfo.Player1.WordsPlayed = currentGame.Player1.WordsPlayed;
                            // Player 2
                            ReturnInfo.Player2.Nickname = currentGame.Player2.Nickname;
                            ReturnInfo.Player2.Score = currentGame.Player2.Score;
                            ReturnInfo.Player2.WordsPlayed = currentGame.Player2.WordsPlayed;
                            return ReturnInfo;
                        }
                    }
                }
                else
                {
                    SetStatus(Forbidden);
                    return null;
                }
            }
        }

        /// <summary>
        /// Creates a new game if there is a pending player.
        /// Otherwise creates a pending player.
        /// </summary>
        /// <param name="starter">Represents time limit & user token</param>
        /// <returns>gameID of game created</returns>
        public gameIDClass JoinGame(gameStart starter)
        {
            lock (sync)
            {

                // Adds the words from the dictionary to a hashset if this is the first game. 
                if (games.Count == 0 && dictonaryWords.Count == 0)
                {
                    string currentLine;
                    StreamReader dictionaryReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/dictionary.txt");
                    while ((currentLine = dictionaryReader.ReadLine()) != null)
                    {
                        dictonaryWords.Add(currentLine);
                    }
                }


                // Checks for invalid time & invalid user token
                if (starter.TimeLimit > 120 || starter.TimeLimit < 5 || starter.UserToken.Length != 36 || !users.ContainsKey(starter.UserToken))
                {
                    SetStatus(Forbidden);
                    return null;
                }
                // If the user token is already a player in a pending game
                else if (currentPlayersinGame.ContainsKey(starter.UserToken))
                {
                    SetStatus(Conflict);
                    return null;
                }
                else
                {
                    gameIDClass id = new gameIDClass();
                    GameInfo game = new GameInfo();
                    Player newPlayer = new Player();

                    //Sets up the new players values. 
                    newPlayer.UserToken = starter.UserToken;
                    newPlayer.Nickname = users[starter.UserToken];
                    //If the currently pending games is 0 then we need to add to it. 
                    if(needed.Count == 0)
                    {
                        //Set the games player one to the new player as it will be the first. 
                        game.Player1 = newPlayer;

                        //Queue the userToken.
                        needed.Enqueue(starter.UserToken);

                        //Set status to accepted.
                        SetStatus(Accepted);

                        //Set the timeLeft temporarly so we can compute the average in the next step.
                        game.TimeLeft = starter.TimeLimit;

                        //Compute the gameID.
                        string tempGameid = "G" + (gameNum++).ToString();

                        //Sets the gamestate to pending.
                        game.GameState = "pending";

                        //Adds the game to the game dictionary.
                        games.Add(tempGameid, game);

                        //Returns the gameId.
                        id.GameID = tempGameid;

                        //adding to currentplayersingame
                        currentPlayersinGame.Add(starter.UserToken, id);
                    }
                    else
                    {
                        //gets the new users gameID and resets return value to equal that. 
                        string tempGameid = currentPlayersinGame[needed.Dequeue()].GameID;
                        currentPlayersinGame.Add(starter.UserToken, id);
                        id.GameID = tempGameid;

                        //Get the game info that the user will be added to from dequeue and using the other dictionaries.
                        game = games[tempGameid];

                        //Making the boggleBoard.
                        game.Board = new BoggleBoard();

                        //Sets the newPlayer to player two as they are the second to enter this game.
                        game.Player2 = newPlayer;

                        //Takes the mean of the two players times and sets the timeLimit and timeLeft to it. 
                        game.TimeLimit = ((game.TimeLeft + starter.TimeLimit) / 2);
                        game.TimeLeft = game.TimeLimit;

                        //Setting the score of both player.s
                        game.Player1.Score = 0;
                        game.Player2.Score = 0;

                        //Initializing the arrays of each player. 
                        game.Player1.WordsPlayed = new List<WordValue>();
                        game.Player2.WordsPlayed = new List<WordValue>();

                        //set game to active and set status to created. 
                        game.GameState = "active";

                        SetStatus(Created);

                        game.StartTimeInMilliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    }
                    return id;
                }
            }
        }

        /// <summary>
        /// Creates a user w/ a given nickname
        /// </summary>
        /// <param name="Nickname">nickname given by user</param>
        /// <returns>user token</returns>
        UserTokenClass IBoggleService.CreateUser(UserInfo Nickname)
        { 
            //DB VERSION
            //If nickname is invalid then set status to forbidden and returns null.
            if (Nickname.Nickname == null || Nickname.Nickname.Trim().Length == 0)
            {
                SetStatus(Forbidden);
                return null;
            }

            // The first step to using the DB is opening a connection to it.  Creating it in a
            // using block guarantees that the connection will be closed when control leaves
            // the block.  As you'll see below, I also follow this pattern for SQLTransactions,
            // SqlCommands, and SqlDataReaders.
            using (SqlConnection conn = new SqlConnection(BoggleDB))
            {
                // Connections must be opened
                conn.Open();

                // Database commands should be executed within a transaction.  When commands 
                // are executed within a transaction, either all of the commands will succeed
                // or all will be canceled.  You don't have to worry about some of the commands
                // changing the DB and others failing.
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    // An SqlCommand executes a SQL statement on the database.  In this case it is an
                    // insert statement.  The first parameter is the statement, the second is the
                    // connection, and the third is the transaction.  
                    //
                    // Note that I use symbols like @UserID as placeholders for values that need to appear
                    // in the statement.  You will see below how the placeholders are replaced.  You may be
                    // tempted to simply paste the values into the string, but this is a BAD IDEA that violates
                    // a cardinal rule of DB Security 101.  By using the placeholder approach, you don't have
                    // to worry about escaping special characters and you don't have to worry about one form
                    // of the SQL insertion attack.
                    using (SqlCommand command =
                        new SqlCommand("insert into Users (UserToken, Nickname) values(@UserToken, @Nickname)",
                                        conn,
                                        trans))
                    {
                        // We generate the userID to use.
                        string newUserToken = Guid.NewGuid().ToString();

                        // This is where the placeholders are replaced.
                        command.Parameters.AddWithValue("@UserToken", newUserToken);
                        command.Parameters.AddWithValue("@Nickname", Nickname.Nickname.Trim());

                        // This executes the command within the transaction over the connection.  The number of rows
                        // that were modified is returned.  Perhaps I should check and make sure that 1 is returned
                        // as expected.
                        command.ExecuteNonQuery();
                        SetStatus(Created);

                        // Immediately before each return that appears within the scope of a transaction, it is
                        // important to commit the transaction.  Otherwise, the transaction will be aborted and
                        // rolled back as soon as control leaves the scope of the transaction. 
                        trans.Commit();

                        UserTokenClass returnToken = new UserTokenClass();
                        returnToken.UserToken = newUserToken;
                        return returnToken;
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////METHOD GIVEN BY JOE///////////////////////////////////////////////////

        /// <summary>
        /// The most recent call to SetStatus determines the response code used when
        /// an http response is sent.
        /// </summary>
        /// <param name="status"></param>
        private static void SetStatus(HttpStatusCode status)
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = status;
        }

        /// <summary>
        /// Returns a Stream version of index.html.
        /// </summary>
        /// <returns></returns>
        public Stream API()
        {
            SetStatus(OK);
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "index.html");
        }

    }
}
