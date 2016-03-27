using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel.Web;
using static System.Net.HttpStatusCode;

namespace Boggle
{
    public class BoggleService : IBoggleService
    {
        private int gameNum = 0;
        private Queue<string> needed = new Queue<string>();
        //REPResents nickname to usertoken
        private readonly static Dictionary<String, string> users = new Dictionary<String, string>();
        //represents usertoken to gameid.
        private readonly static Dictionary<String, gameIDClass> currentPlayersinGame = new Dictionary<String, gameIDClass>();
        //represents gameId to GameInfo
        private readonly static Dictionary<string, GameInfo> games = new Dictionary<string, GameInfo>();
        private static readonly object sync = new object();



        public gameIDClass JoinGame(gameStart starter)
        {
            lock (sync)
            {
                if (starter.TimeLimit > 120 || starter.TimeLimit < 5 || starter.UserToken.Length != 36)
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
                        string tempGameid = "G" + (gameNum + 1).ToString();

                        //Sets the gamestate to pending.
                        game.GameState = "pending";

                        //Adds the game to the game dictionary.
                        games.Add(tempGameid, game);

                        //Returns the gameId.
                        id.GameID = tempGameid;
                    }
                    else
                    {
                        //gets the new users gameID and resets return value to equal that. 
                        string tempGameid = currentPlayersinGame[needed.Dequeue()].GameID;
                        id.GameID = tempGameid;

                        //Get the game info that the user will be added to from dequeue and using the other dictionaries.
                        game = games[tempGameid];

                        //Sets the newPlayer to player two as they are the second to enter this game.
                        game.Player2 = newPlayer;

                        //Takes the mean of the two players times and sets the timeLimit and timeLeft to it. 
                        game.TimeLimit = ((game.TimeLeft + starter.TimeLimit) / 2);
                        game.TimeLeft = game.TimeLimit;

                        //set game to active and set status to created. 
                        game.GameState = "active";

                        SetStatus(Created);

                    }
                    return id;
                }
            }


            
        }

        UserInfo IBoggleService.CreateUser(UserInfo Nickname)
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
                    SetStatus(Created);
                    Nickname.UserToken = Guid.NewGuid().ToString();
                    users.Add(Nickname.UserToken, Nickname.Nickname);
                    return Nickname;
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
