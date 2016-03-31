// Hanna Larsen & Salvatore Stone Mele
// u0741837        u0897718
// CS 3500  PS9 
// 03/31/16
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Boggle
{
    /// <summary>
    /// Data model for the game info stored in a Boggle game
    /// </summary>
    public class GameInfo
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public string GameState { get; set; }
        public int TimeLimit { get; set; }
        public int TimeLeft {get; set;}
        public BoggleBoard Board { get; set; }
        public long StartTimeInMilliseconds { get; set; }
    }

    /// <summary>
    /// Data model for creating a Boggle player
    /// </summary>
    [DataContract]
    public class Player
    {
        [DataMember(EmitDefaultValue = false)]
        public string Nickname { get; set; }

        public string UserToken { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int? Score { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<WordValue> WordsPlayed {get; set;}
    }

    /// <summary>
    /// Data model the components of a submitted word
    /// </summary>
    public class WordValue
    {
        public string Word { get; set; }
        public string Score { get; set; }
    }

    /// <summary>
    /// Data model that gets the user information: nickname & user token
    /// </summary>
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public string Nickname { get; set; }

        [DataMember]
        public string UserToken { get; set; }
    }

    /// <summary>
    /// Initial information recieved from a user upon joining a game
    /// </summary>
    public class gameStart
    {
        public string UserToken { get; set; }
        public int TimeLimit { get; set; }
    }

    /// <summary>
    /// Gets/sets the game ID
    /// </summary>
    public class gameIDClass
    {
        public string GameID
        {
            get; set;
        }
    }

    /// <summary>
    /// Gets/sets the user token
    /// </summary>
    public class UserTokenClass
    {
        public string UserToken { get; set; }
    }

    /// <summary>
    /// Data model that accesses the various game states
    /// </summary>
    [DataContract]
    public class GameStateClass
    {
        [DataMember(EmitDefaultValue = false)]
        public string GameState { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Board { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int TimeLimit { get; set;}

        [DataMember(EmitDefaultValue = false)]
        public int? TimeLeft { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Player Player1 { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Player Player2 { get; set; }
    }

    /// <summary>
    /// Information from a submitted word
    /// </summary>
    public class WordSubmit
    {
        public string UserToken { get; set; }
        public string Word { get; set; }
    }

    /// <summary>
    /// Information about the score when a word is submitted
    /// </summary>
    public class ScoreResponse
    {
        public string Score { get; set; }
    }


}