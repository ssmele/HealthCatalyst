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

        event Action HelpEvent;

        event Action ConnectEvent;

        void closeWindow();
        

        string timeLengthBox { set; get; }
        string timerDisplayBox { set; get; }
        string player1ScoreBox { set; }
        string player2ScoreBox { set; }
        string player1NameBox { set; }
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
