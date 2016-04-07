// Hanna Larsen & Salvatore Stone Mele
// u0741837        u0897718
// CS 3500  PS10 
// 04/07/16
using System;
using System.Collections.Generic;
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
        /// HashSet that contains all the words in the dictionary.txt.
        /// </summary>
        private static HashSet<string> dictonaryWords = new HashSet<string>();

        /// <summary>
        /// The connection string to the DB
        /// </summary>
        private static string BoggleDB;

        /// <summary>
        /// Creates a boggle service
        /// </summary>
        static BoggleService()
        {
            // Saves the connection string for the database.  A connection string contains the
            // information necessary to connect with the database server.  ;
            string currentLine;
            StreamReader dictionaryReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/dictionary.txt");
            while ((currentLine = dictionaryReader.ReadLine()) != null)
            {
                dictonaryWords.Add(currentLine);
            }
        }

        /// <summary>
        /// If the userToken that is given from the parameter matches that of the player in the pending
        /// queue then that player will be removed from the pending queue and any other data
        /// structure that holds a game state.
        /// </summary>
        /// <param name="UI">UserToken of player that wants to be taken from the Queue.</param>
        public void CancelJoin(UserInfo UI)
        {
            // If user token is invalid
            if (UI.UserToken == null || UI.UserToken.Length != 36)
            {
                SetStatus(Forbidden);
                return;
            }

            using (SqlConnection conn = new SqlConnection(BoggleDB))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {

                    //THIS IS AN INTENSE QUERY!!!!!!!!! YEAH!!!!!!! DOES ALL THE WORK FOR US YEAH!!!!!
                    using (SqlCommand topCommand = new SqlCommand("Delete from Games where (Select Max(GameID) from Games) = GameID and Player2 IS NULL and Player1 = @UserToken and (select top 1 Player1 from Games order by GameID desc) = @UserToken", conn, trans))
                    {
                        topCommand.Parameters.AddWithValue("@UserToken", UI.UserToken);

                        //IF no columns were removed then SetStatus to forbidden.
                        if (topCommand.ExecuteNonQuery() == 0)
                        {
                            SetStatus(Forbidden);
                        }
                        else
                        {
                            trans.Commit();
                            SetStatus(OK);
                        }
                    }
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
            // If the user token is invalid or the word is invalid
            if (wordInfo.UserToken == null || wordInfo.UserToken.Length != 36 || wordInfo.Word == null || wordInfo.Word.Trim().Length == 0)
            {
                SetStatus(Forbidden);
                return null;
            }

            using (SqlConnection conn = new SqlConnection(BoggleDB))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    //This query checks to make sure the userToken given is actually in given gameId. It also gets the StartTime, and TimeLimit to determine
                    //if the game is active or completed.
                    string board = null;
                    using (SqlCommand Command = new SqlCommand("select StartTime,TimeLimit,Board,Player2 from Games where GameID = @GameID and Player1 = @UserToken or Player2 = @UserToken", conn, trans))
                    {
                        Command.Parameters.AddWithValue("@UserToken", wordInfo.UserToken);
                        Command.Parameters.AddWithValue("@GameID", GivenGameID);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                SetStatus(Forbidden);
                                return null;
                            }
                            else
                            {
                                reader.Read();

                                //Checking to see if player2 is null meaning the game is pending and words cant be submitted. 
                                object player2 = reader["Player2"];
                                if (player2 is DBNull)
                                {
                                    SetStatus(Conflict);
                                    return null;
                                }

                                // Creates a board & gets game info
                                board = (string)reader["Board"];
                                DateTime gameTime = (DateTime)reader["StartTime"];
                                long gameTimeInMilli = gameTime.Ticks / TimeSpan.TicksPerMillisecond;
                                long minusTime = getElapsedTime(gameTimeInMilli);
                                //Check to see if game is already completed if it is then setStatus to conflict and return null. 
                                int TimeLimit = (int)reader["TimeLimit"];
                                if (minusTime >= TimeLimit)
                                {
                                    SetStatus(Conflict);
                                    return null;
                                }
                            }
                            reader.Close();
                        }
                    }

                    //Determining word score. 
                    ScoreResponse returnInfo = new ScoreResponse();
                    string word = wordInfo.Word.Trim();

                    BoggleBoard currentBoard = new BoggleBoard(board);
                    // If the word is less than 3 long, automatically 0 points
                    if (word.Length < 3)
                    {
                        returnInfo.Score = "0";
                    }
                    // If the word can be formed on the board
                    else if (currentBoard.CanBeFormed(word))
                    {
                        // If the word is in the dictionary
                        if (dictonaryWords.Contains(wordInfo.Word.ToUpper()))
                        {
                            // Determines the score based on word length
                            int word_length = word.Length;
                            if (word_length >= 3 && word_length < 5)
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

                    //Seeing if the user already played the word. 
                    using (SqlCommand Command = new SqlCommand("select * from Words where Player = @UserToken and Word = @Word", conn, trans))
                    {
                        Command.Parameters.AddWithValue("@UserToken", wordInfo.UserToken);
                        Command.Parameters.AddWithValue("@Word", wordInfo.Word);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                returnInfo.Score = "0";
                            }
                            reader.Close();
                        }
                    }

                    //If it gets out of that command its active and a valid request.
                    using (SqlCommand Command = new SqlCommand("insert into Words(Word, Score, Player,GameID) values(@Word,@Score,@Player,@GameID)", conn, trans))
                    {
                        Command.Parameters.AddWithValue("@Word", wordInfo.Word);
                        Command.Parameters.AddWithValue("@Score", returnInfo.Score);
                        Command.Parameters.AddWithValue("@Player", wordInfo.UserToken);
                        Command.Parameters.AddWithValue("@GameID", GivenGameID);

                        Command.ExecuteNonQuery();
                        trans.Commit();
                        SetStatus(OK);
                        return returnInfo;
                    }
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
            double seconds = ((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime) / 1000;
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
            using (SqlConnection conn = new SqlConnection(BoggleDB))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    // Initializes game info variables
                    GameStateClass returnInfo = new GameStateClass();
                    string Board = "";
                    int TimeLimit = 0;
                    int? GameID = null;
                    string Player1UserToken = "", Player2UserToken = "";

                    //Determine which state the game is in. 
                    using (SqlCommand command = new SqlCommand("Select * from Games where GameID = @GameID", conn, trans))
                    {
                        command.Parameters.AddWithValue("@GameID", GivenGameID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //If there was no GameID by the given GameID
                            if (!reader.HasRows)
                            {
                                SetStatus(Forbidden);
                                return null;
                            }

                            while (reader.Read())
                            {
                                object Player2 = reader["Player2"];
                                if (Player2 is DBNull)
                                {
                                    returnInfo.GameState = "pending";
                                    SetStatus(OK);
                                    return returnInfo;
                                }

                                Player2UserToken = (string)Player2;
                                Player1UserToken = (string)reader["Player1"];
                                GameID = (int)reader["GameID"];

                                //Getting all the current info from the board as it is now either active or completed. 
                                Board = (string)reader["Board"];
                                TimeLimit = (int)reader["TimeLimit"];
                                DateTime startTime = (DateTime)reader["StartTime"];
                                long startTimeInMilli = startTime.Ticks / TimeSpan.TicksPerMillisecond;

                                //Getting currentTime that has passed since game and setting gameState accordingly. 
                                int minusTime = getElapsedTime(startTimeInMilli);
                                if (minusTime >= TimeLimit)
                                {
                                    returnInfo.GameState = "completed";
                                    returnInfo.TimeLeft = 0;
                                }
                                else
                                {
                                    returnInfo.GameState = "active";
                                    returnInfo.TimeLeft = TimeLimit - minusTime;
                                }
                            }
                            reader.Close();
                        }
                    }

                    returnInfo.Player1 = new Player();
                    returnInfo.Player2 = new Player();
                    returnInfo.Player1.Score = playerScoreGetter(Player1UserToken, GameID);
                    returnInfo.Player2.Score = playerScoreGetter(Player2UserToken, GameID);

                    //If the request was breif then just return current return info as it has all the necessary values already. 
                    if (answer == "yes")
                    {
                        SetStatus(OK);
                        return returnInfo;
                    }
                    else
                    {
                        //If game is active set all values that need to be returned. 
                        if (returnInfo.GameState == "active")
                        {
                            returnInfo.Board = Board;
                            returnInfo.TimeLimit = TimeLimit;
                            returnInfo.Player1.Nickname = playerNicknameGetter(Player1UserToken);
                            returnInfo.Player2.Nickname = playerNicknameGetter(Player2UserToken);
                            SetStatus(OK);
                            return returnInfo;
                        }
                        //If game is completed set all values that need to be returned. 
                        else if (returnInfo.GameState == "completed")
                        {
                            returnInfo.Board = Board;
                            returnInfo.TimeLimit = TimeLimit;
                            returnInfo.Player1.Nickname = playerNicknameGetter(Player1UserToken);
                            returnInfo.Player2.Nickname = playerNicknameGetter(Player2UserToken);
                            returnInfo.Player1.WordsPlayed = playerWordsPlayedGetter(Player1UserToken);
                            returnInfo.Player2.WordsPlayed = playerWordsPlayedGetter(Player2UserToken);
                            SetStatus(OK);
                            return returnInfo;
                        }
                        //If its not active or complete then something went wrong and return null and set status to forbideen. 
                        else
                        {
                            SetStatus(Forbidden);
                            return null;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method gets all the words played and there respective scores for the given userToken. 
        /// </summary>
        /// <param name="playerToken"></param>
        /// <returns></returns>
        private List<WordValue> playerWordsPlayedGetter(string playerToken)
        {
            using (SqlConnection conn = new SqlConnection(BoggleDB))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    // Gets the word & score from the database
                    using (SqlCommand command = new SqlCommand("Select Word,Score from Words where Player = @PlayerUserToken", conn, trans))
                    {
                        List<WordValue> wordsPlayedList = new List<WordValue>();
                        command.Parameters.AddWithValue("@PlayerUserToken", playerToken);
                        using (SqlDataReader reader2 = command.ExecuteReader())
                        {
                            //While the user has words in the game add them to there list. 
                            while (reader2.Read())
                            {
                                string word = (string)reader2["Word"];
                                //TODO: WE might need to change our data models to an INT!!! REFRENCE THE API.
                                string Score = reader2["Score"].ToString();
                                WordValue entry = new WordValue();
                                entry.Word = word;
                                entry.Score = Score;
                                wordsPlayedList.Add(entry);
                            }
                            return wordsPlayedList;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method gets the nickname for the given userToken. 
        /// </summary>
        /// <param name="playerToken"></param>
        /// <returns></returns>
        private string playerNicknameGetter(string playerToken)
        {
            using (SqlConnection conn = new SqlConnection(BoggleDB))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    // Gets the nickname
                    using (SqlCommand command = new SqlCommand("Select Nickname from Users where UserToken = @Player1UserToken", conn, trans))
                    {
                        command.Parameters.AddWithValue("@Player1UserToken", playerToken);
                        using (SqlDataReader reader2 = command.ExecuteReader())
                        {
                            reader2.Read();
                            object playerNickname = reader2["Nickname"];
                            if (playerNickname is DBNull)
                            {
                                return null;
                            }
                            else
                            {
                                return (string)playerNickname;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method gets the score for the given userToken.
        /// </summary>
        /// <param name="playerToken"></param>
        /// <param name="GameID"></param>
        /// <returns></returns>
        private int playerScoreGetter(string playerToken, int? GameID)
        {
            using (SqlConnection conn = new SqlConnection(BoggleDB))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    // Gets total score from the words in that database
                    using (SqlCommand command = new SqlCommand("Select Sum(Score) as Score from Words where GameID = @GameID and Player = @Player1UserToken ", conn, trans))
                    {
                        command.Parameters.AddWithValue("@Player1UserToken", playerToken);
                        command.Parameters.AddWithValue("@GameID", GameID);

                        using (SqlDataReader reader2 = command.ExecuteReader())
                        {
                            reader2.Read();
                            object playerScore = reader2["Score"];
                            if (playerScore is DBNull)
                            {
                                return 0;
                            }
                            else
                            {
                                return (int)playerScore;
                            }
                        }
                    }
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
            // Checks for invalid time & invalid user token
            if (starter.TimeLimit > 120 || starter.TimeLimit < 5 || starter.UserToken.Length != 36)
            {
                SetStatus(Forbidden);
                return null;
            }
            using (SqlConnection conn = new SqlConnection(BoggleDB))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    //Query to check if usertoken is in actual DB.
                    using (SqlCommand command = new SqlCommand("select UserToken from Users where UserToken = @UserToken ", conn, trans))
                    {
                        command.Parameters.AddWithValue("@UserToken", starter.UserToken);

                        // This executes a query (i.e. a select statement).  The result is an
                        // SqlDataReader that you can use to iterate through the rows in the response.
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows == false)
                            {
                                SetStatus(Forbidden);
                                return null;
                            }
                            reader.Close();
                        }
                    }

                    bool isAccepted = false;
                    bool isCreated = false;
                    string currentGameID = null;

                    //Gets game ID and decides if we are accepting or creating a game. 
                    using (SqlCommand command = new SqlCommand("select top 1 * from Games order by GameId desc", conn, trans))
                    {
                        using (SqlDataReader reader2 = command.ExecuteReader())
                        {
                            //If there is not games then set isAccepted = true.
                            if (!reader2.HasRows)
                            {
                                isAccepted = true;
                            }

                            while (reader2.Read())
                            {
                                //If the player is already in a pending game then SetStatus to conflict and return. 
                                string player1 = (string)reader2["Player1"];
                                if (player1 == starter.UserToken)
                                {
                                    SetStatus(Conflict);
                                    return null;
                                }

                                object player2 = reader2["Player2"];
                                //Accept Game
                                if (!(player2 is DBNull))
                                {
                                    isAccepted = true;
                                }

                                //Create Game
                                else
                                {
                                    isCreated = true;
                                }

                                currentGameID = reader2["GameID"].ToString();
                            }
                            reader2.Close();
                        }
                    }

                    gameIDClass returnInfo = new gameIDClass();
                    returnInfo.GameID = currentGameID;
                    //If we need to make a created game.
                    if (isCreated == true)
                    {
                        using (SqlCommand command = new SqlCommand("update Games set Player2 = @UserToken,TimeLimit = (TimeLimit + @TimeLimit)/2, StartTime = @StartTime,Board = @Board where GameID = @GameID", conn, trans))
                        {
                            command.Parameters.AddWithValue("@UserToken", starter.UserToken);
                            command.Parameters.AddWithValue("@TimeLimit", starter.TimeLimit);
                            command.Parameters.AddWithValue("@StartTime", DateTime.Now);
                            command.Parameters.AddWithValue("@Board", (new BoggleBoard()).ToString());
                            command.Parameters.AddWithValue("@GameID", currentGameID);
                            if (command.ExecuteNonQuery() == 0)
                            {
                                SetStatus(Forbidden);
                                return null;
                            }
                            trans.Commit();
                            SetStatus(Created);
                        }
                    }

                    //If we need to accept a game. 
                    else if (isAccepted == true)
                    {
                        using (SqlCommand command = new SqlCommand("insert into Games(Player1,TimeLimit) output inserted.GameID values(@UserToken,@TimeLimit)", conn, trans))
                        {
                            command.Parameters.AddWithValue("@UserToken", starter.UserToken);
                            command.Parameters.AddWithValue("@TimeLimit", starter.TimeLimit);

                            //If we dont have a current ID Then get the gameID from the command. 

                            using (SqlDataReader reader3 = command.ExecuteReader())
                            {

                                if (reader3.HasRows == false)
                                {
                                    SetStatus(Forbidden);
                                    return null;
                                }

                                while (reader3.Read())
                                {
                                    currentGameID = reader3["GameID"].ToString();
                                    returnInfo.GameID = currentGameID;
                                }
                            }

                            trans.Commit();
                            SetStatus(Accepted);
                        }
                    }
                    else
                    {
                        SetStatus(Forbidden);
                        return null;
                    }

                    return returnInfo;
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
            //If nickname is invalid then set status to forbidden and returns null.
            if (Nickname.Nickname == null || Nickname.Nickname.Trim().Length == 0)
            {
                SetStatus(Forbidden);
                return null;
            }

            using (SqlConnection conn = new SqlConnection(BoggleDB))
            {
                // Connections must be opened
                conn.Open();

                using (SqlTransaction trans = conn.BeginTransaction())
                {
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
                        command.ExecuteNonQuery();
                        SetStatus(Created);
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
