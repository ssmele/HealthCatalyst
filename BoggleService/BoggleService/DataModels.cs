﻿using System;
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
        public BoggleBoard Board { get; set; }
    }

    [DataContract]
    public class Player
    {
        public string Nickname { get; set; }
        public string UserToken { get; set; }
        public int Score { get; set; }

        [DataMember(EmitDefaultValue = false)]
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

    public class UserTokenClass
    {
        public string UserToken { get; set; }
    }


    public class GameStateClass
    {
        public string GameState { get; set; }
    }

    public class GameStateBrief :GameStateClass
    {
        public int TimeLeft { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }

    public class GameStateActive : GameStateBrief
    {
        public string Board { get; set; }
        public int TimeLimit { get; set; }
    }

    public class WordSubmit
    {
        public string UserToken { get; set; }
        public string Word { get; set; }
    }

    public class ScoreResponse
    {
        public string Score { get; set; }
    }


}