using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Boggle
{
    public class GameInfo
    {
        public string GameID { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public string GameState { get; set; }
        public int TimeLimit { get; set; }
        public int TimeLeft {get; set;}
    }


    public class Player
    {
        public string Nickname { get; set; }
        public string UserToken { get; set; }
        public int Score { get; set; }
        public string[] WordsPlayed {get; set;}
    }

    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public string Nickname { get; set; }

        [DataMember]
        public string UserToken { get; set; }
    }


    public class gameStart
    {
        public string UserToken { get; set; }
        public int TimeLimit { get; set; }
    }

    public class gameIDClass
    {
        public string GameID
        {
            get; set;
        }
    }
}