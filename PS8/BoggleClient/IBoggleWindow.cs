using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoggleClient
{
    public interface IBoggleWindow
    {

        event Action CloseWindowEvent;

        event Action HelpEvent1;
        event Action HelpEvent2;

        event Action ConnectEvent;

        event Action CancelEvent;

        event Action<string> WordSubmitEvent;

        event Action NewEvent;

        void NewWindow();
        void startTimer();
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
        string player2ScoreBox { set; }
        string player1NameBox { set; }
        string player2NameBox { set; }
        string playerBox { set; get; }
        string Cell1 { set; get; }
        string Cell2 { set; get; }
        string Cell3 { set; get; }
        string Cell4 { set; get; }
        string Cell5 { set; get; }
        string Cell6 { set; get; }
        string Cell7 { set; get; }
        string Cell8 { set; get; }
        string Cell9 { set; get; }
        string Cell10 { set; get; }
        string Cell11 { set; get; }
        string Cell12 { set; get; }
        string Cell13 { set; get; }
        string Cell14 { set; get; }
        string Cell15 { set; get; }
        string Cell16 { set; get; }
    }
}
