// Written by: Hanna Larsen & Salvatore Stone Mele
//              u0741837       u0897718
//Date: 3/24/16

using System;


namespace BoggleClient
{
    //Interface for boggle client. 
    public interface IBoggleWindow
    {
        //Events
        event Action UpdateScoreEvent;
        event Action GameStateEvent;
        event Action CloseWindowEvent;
        event Action HelpEvent1;
        event Action HelpEvent2;
        event Action ConnectEvent;
        event Action CancelEvent;
        event Action<string> WordSubmitEvent;
        event Action NewEvent;
        event Action CheatEventFast;
        event Action CheatEventSlow;
        event Action CheatEventWindow;
        event Action CheatEventEthically;
        event Action HelpCheat;

        
        void refreshBoard(string boardSTRING);
        void endScoreUpdater();
        void endPending();
        string CancelButtonText { get; set; }
        string ConnectButtonText { get; set; }
        void NewWindow();
        void startTimer();
        void startTimerPending();
        void startTimerScoreUpdate();
        string wordEntryBox { get; }
        string urlTextBox { get; set; }
        void closeWindow();
        void helpHowToStartGame();
        void helpGameRules();
        void errorMessage(string message);
        string statusBox { set; get; }
        bool connectButton { set; get; }
        bool cancelButton { set; get; }
        string player1WordList { set; }
        string player2WordList { set; }
        string timeLengthBox { set; get; }
        string timerDisplayBox { set; get; }
        string player1ScoreBox { set; get; }
        string player2ScoreBox { get; set; }
        string player1NameBox { get; set; }
        string player2NameBox { get; set; }
        string playerBox { set; get; }
        void helpCheat();
    }
}
