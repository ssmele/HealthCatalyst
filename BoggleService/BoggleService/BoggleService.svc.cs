using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.ServiceModel.Web;
using static System.Net.HttpStatusCode;

namespace Boggle
{
    public class BoggleService : IBoggleService
    {
        //Represents the gameID.
        private static int gameNum = 0;
        /// <summary>
        /// This queue should only hold one value at a time and that should be a UserToken.
        /// </summary>
        private static Queue<string> needed = new Queue<string>();

        //REPResents Usertoken to Nickname.
        private readonly static Dictionary<String, string> users = new Dictionary<String, string>();

        //Represents Usertoken to gameID.
        private readonly static Dictionary<String, gameIDClass> currentPlayersinGame = new Dictionary<String, gameIDClass>();

        //Represents GameId to GameInfo.
        private readonly static Dictionary<string, GameInfo> games = new Dictionary<string, GameInfo>();

        //Sync object.
        private static readonly object sync = new object();

        /// <summary>
        /// If the userToken that is given from the parameter matches that of the player in the pending
        /// queue then that player will be removed from the pending queue and any other data
        /// structor that holds a game state.
        /// </summary>
        /// <param name="UI">UserToken of player that wants to be taken from the Queue.</param>
        public void CancelJoin(UserInfo UI)
        {
            lock (sync)
            {
                if (needed.Count == 1 && needed.Peek() == UI.UserToken)
                {
                    //TODO: Should we minus from the gameID, should we take the user out from users????
                    //If the UserToken is the same as the player in the queue remove them from the queue.
                    needed.Dequeue();
                    string tempGameId = currentPlayersinGame[UI.UserToken].GameID;
                    currentPlayersinGame.Remove(UI.UserToken);
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
            GameInfo currentGame = games[currentPlayersinGame[wordInfo.UserToken].GameID];
            //If word is empty or null, or usertoken is not in a real game then set status to forbidden.
            if (wordInfo.Word == null || wordInfo.Word.Trim().Length == 0 || !currentPlayersinGame.ContainsKey(wordInfo.UserToken))
            {
                SetStatus(Forbidden);
                return null;
            }
            //If game is not active. 
            else if(currentGame.GameState != "active")
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
                if (currentGame.Board.CanBeFormed(word))
                {
                    if (File.ReadAllText(".../.../dictionary.txt").Contains(wordInfo.Word))
                    {
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
                        returnInfo.Score = "0";
                    }
                }
                if(currentGame.Player1.UserToken == wordInfo.UserToken)
                {
                    //TEMPORARY
                    currentGame.Player1.WordsPlayed[0] = returnInfo.Score;
                }
                else
                {
                    //TEMPORARY
                    currentGame.Player2.WordsPlayed[0] = returnInfo.Score;
                }
                //RETURN WORD SCORE. 
                return returnInfo;
            }
        }

        //TODO: Need to check to see if the current time changing method words. 
        //TODO: NEED TO FIGURE OUT THIS RETURN VALUE STUFF for gameState!!!!
        //TODO: NEED TO FIX THE WORDSPLAYED DATA STRUCTURE?? OBJECT ARRAY????
        //TODO: IF we cancel a pending game do we want the gameID that was used for the previous game to be reused or should we just move to the next game?????
        //TODO: PUT A LOCK AROUND ALL THE METHODS bodies. 

        /// <summary>
        /// This method will get the elapsed time in seconds from a given long time. 
        /// </summary>
        /// <param name="startTime"></param>
        /// <returns></returns>
        private int getElapsedTime(long startTime)
        {
            //This subtracts the currentTime from the start time. WE then divide it by 1000 to get a value in
            //seconds. Round the  value to get a more accurate result.
            double seconds = -1*(startTime - (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond)) / 1000;
            return (int)Math.Round(seconds);
        }

        public GameStateClass getGameStatus(string GivenGameID, string answer)
        {
            if (games.ContainsKey(GivenGameID))
            {
                SetStatus(OK);
                GameInfo currentGame = games[GivenGameID];
                //dynamic returnInfo = new ExpandoObject();
                //IF THE GAME IS PENDING DO THIS.
                if (currentGame.GameState == "pending")
                {
                    GameStateClass ReturnInfo = new GameStateClass();
                    ReturnInfo.GameState = "pending";
                    //returnInfo.GameState = "pending";
                    return ReturnInfo;
                }
                //IF ITS ACTIVE OR COMPLETED DO THIS>
                else if (currentGame.GameState == "active")
                {
                    //If brief is yes do this.
                    if (answer == "yes")
                    {
                        GameStateClass ReturnInfo = new GameStateClass();
                        ReturnInfo.Player1 = new Player();
                        ReturnInfo.Player2 = new Player();

                        ReturnInfo.GameState = "active";
                        //If the time is already expired just set TimeLeft to 0. 
                        int minusTime = getElapsedTime(currentGame.StartTimeInMilliseconds);
                        if(minusTime >= currentGame.TimeLimit)
                        {
                            ReturnInfo.TimeLeft = 0;
                        }
                        else
                        {
                            ReturnInfo.TimeLeft = currentGame.TimeLimit - minusTime;
                        }
                        ReturnInfo.Player1.Score = currentGame.Player1.Score;
                        ReturnInfo.Player2.Score = currentGame.Player2.Score;
                        //returnInfo.GameState = "active";
                        //returnInfo.TimeLeft = currentGame.TimeLeft;
                        //returnInfo.Player1.Score = currentGame.Player1.Score;
                        //returnInfo.Player2.Score = currentGame.Player2.Score;
                        return ReturnInfo;
                    }
                    //If not brief do this.
                    else
                    {
                        GameStateClass ReturnInfo = new GameStateClass();
                        ReturnInfo.Player1 = new Player();
                        ReturnInfo.Player2 = new Player();

                        ReturnInfo.GameState = "active";
                        ReturnInfo.Board = currentGame.Board.ToString();
                        int minusTime = getElapsedTime(currentGame.StartTimeInMilliseconds);
                        if (minusTime >= currentGame.TimeLimit)
                        {
                            ReturnInfo.TimeLeft = 0;
                        }
                        else
                        {
                            ReturnInfo.TimeLeft = currentGame.TimeLimit - minusTime;
                        }
                        ReturnInfo.TimeLimit = currentGame.TimeLeft;
                        ReturnInfo.Player1.Nickname = currentGame.Player1.Nickname;
                        ReturnInfo.Player1.Score = currentGame.Player1.Score;
                        ReturnInfo.Player2.Nickname = currentGame.Player2.Nickname;
                        ReturnInfo.Player2.Score = currentGame.Player2.Score;

                        //returnInfo.GameState = "active";
                        //returnInfo.Board = "BOARDGAMEDLDL";
                        //returnInfo.TimeLimit = currentGame.TimeLimit;
                        //returnInfo.TimeLeft = currentGame.TimeLeft;
                        //returnInfo.Player1.Nickname = currentGame.Player1.Nickname;
                        //returnInfo.Player1.Score = currentGame.Player1.Score;
                        //returnInfo.Player2.Nickname = currentGame.Player2.Nickname;
                        //returnInfo.Player2.Score = currentGame.Player2.Score;
                        return ReturnInfo;
                    }
                }
                else
                {
                    if (answer == "yes")
                    {

                        GameStateClass ReturnInfo = new GameStateClass();
                        ReturnInfo.Player1 = new Player();
                        ReturnInfo.Player2 = new Player();

                        ReturnInfo.GameState = "completed";
                        int minusTime = getElapsedTime(currentGame.StartTimeInMilliseconds);
                        if (minusTime >= currentGame.TimeLimit)
                        {
                            ReturnInfo.TimeLeft = 0;
                        }
                        else
                        {
                            ReturnInfo.TimeLeft = currentGame.TimeLimit - minusTime;
                        }
                        ReturnInfo.Player1.Score = currentGame.Player1.Score;
                        ReturnInfo.Player2.Score = currentGame.Player2.Score;

                        //returnInfo.GameState = "completed";
                        //returnInfo.TimeLeft = currentGame.TimeLeft;
                        //returnInfo.Player1.Score = currentGame.Player1.Score;
                        //returnInfo.Player2.Score = currentGame.Player2.Score;
                        return ReturnInfo;
                    }
                    //If not brief do this.
                    else
                    {

                        GameStateClass ReturnInfo = new GameStateClass();
                        ReturnInfo.Player1 = new Player();
                        ReturnInfo.Player2 = new Player();

                        ReturnInfo.GameState = "active";
                        ReturnInfo.Board = currentGame.Board.ToString();
                        int minusTime = getElapsedTime(currentGame.StartTimeInMilliseconds);
                        if (minusTime >= currentGame.TimeLimit)
                        {
                            ReturnInfo.TimeLeft = 0;
                        }
                        else
                        {
                            ReturnInfo.TimeLeft = currentGame.TimeLimit - minusTime;
                        }
                        ReturnInfo.TimeLimit = currentGame.TimeLeft;
                        ReturnInfo.Player1.Nickname = currentGame.Player1.Nickname;
                        ReturnInfo.Player1.Score = currentGame.Player1.Score;
                        ReturnInfo.Player2.WordsPlayed = currentGame.Player2.WordsPlayed;
                        ReturnInfo.Player2.Nickname = currentGame.Player2.Nickname;
                        ReturnInfo.Player2.Score = currentGame.Player2.Score;
                        ReturnInfo.Player2.WordsPlayed = currentGame.Player2.WordsPlayed;

                        //returnInfo.GameState = "completed";
                        //returnInfo.Board = "BOARDGAMEDLDL";
                        //returnInfo.TimeLimit = currentGame.TimeLimit;
                        //returnInfo.TimeLeft = currentGame.TimeLeft;
                        //returnInfo.Player1.Nickname = currentGame.Player1.Nickname;
                        //returnInfo.Player1.Score = currentGame.Player1.Score;
                        //returnInfo.Player1.WordsPlayed = currentGame.Player1.WordsPlayed;
                        //returnInfo.Player2.Nickname = currentGame.Player2.Nickname;
                        //returnInfo.Player2.Score = currentGame.Player2.Score;
                        //returnInfo.Player2.WordsPlayed = currentGame.Player2.WordsPlayed;
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


        public gameIDClass JoinGame(gameStart starter)
        {
            lock (sync)
            {
                if (starter.TimeLimit > 120 || starter.TimeLimit < 5 || starter.UserToken.Length != 36 || !users.ContainsKey(starter.UserToken))
                {
                    SetStatus(Forbidden);
                    return null;
                }
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

                        //Queue the userToken. *** MIGHT NOT NEED THIS MAY ONLY NEED BOOL NOW.
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

                        //Setting the score. 
                        game.Player1.Score = 0;
                        game.Player1.Score = 0;

                        //Initializing the string arrays.
                        game.Player1.WordsPlayed = new string[2];
                        game.Player1.WordsPlayed = new string[2];

                        //set game to active and set status to created. 
                        game.GameState = "active";

                        SetStatus(Created);

                        game.StartTimeInMilliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    }
                    return id;
                }
            }


            
        }

        UserTokenClass IBoggleService.CreateUser(UserInfo Nickname)
        {
            lock (sync)
            {
                //If nickname is invalid then set status to forbidden and returns null.
                if (Nickname.Nickname == null || Nickname.Nickname.Trim().Length == 0)
                {
                    SetStatus(Forbidden);
                    return null;
                }
                //IF nickname is valud set status to created, and generate the GUID and returns it.
                else
                {
                    UserTokenClass ut = new UserTokenClass();
                    SetStatus(Created);
                    ut.UserToken = Guid.NewGuid().ToString();
                    users.Add(ut.UserToken, Nickname.Nickname);
                    return ut;
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

        /// <summary>
        /// Demo.  You can delete this.
        /// </summary>
        public int GetFirst(IList<int> list)
        {
            SetStatus(OK);
            return list[0];
        }

        /// <summary>
        /// Demo.  You can delete this.
        /// </summary>
        /// <returns></returns>
        public IList<int> Numbers(string n)
        {
            int index;
            if (!Int32.TryParse(n, out index) || index < 0)
            {
                SetStatus(Forbidden);
                return null;
            }
            else
            {
                List<int> list = new List<int>();
                for (int i = 0; i < index; i++)
                {
                    list.Add(i);
                }
                SetStatus(OK);
                return list;
            }
        }
    }
}
