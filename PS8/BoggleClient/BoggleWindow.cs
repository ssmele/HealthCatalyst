using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoggleClient;

namespace BoggleClient
{
    public partial class BoggleWindow : Form, IBoggleWindow
    {

        //Getters and setters for the cells.
        string IBoggleWindow.Cell1
        {
            get
            {
                return Cell1.Text;
            }

            set
            {
                Cell1.Text = value;
            }
        }

        string IBoggleWindow.Cell2
        {
            get
            {
                return Cell2.Text;
            }

            set
            {
                Cell2.Text = value;
            }
        }

        string IBoggleWindow.Cell3
        {
            get
            {
                return Cell3.Text;
            }

            set
            {
                Cell3.Text = value;
            }
        }

        string IBoggleWindow.Cell4
        {
            get
            {
                return Cell4.Text;
            }

            set
            {
                Cell4.Text = value;
            }
        }

        string IBoggleWindow.Cell5
        {
            get
            {
                return Cell5.Text;
            }

            set
            {
                Cell5.Text = value;
            }
        }

        string IBoggleWindow.Cell6
        {
            get
            {
                return Cell6.Text;
            }

            set
            {
                Cell6.Text = value;
            }
        }

        string IBoggleWindow.Cell7
        {
            get
            {
                return Cell7.Text;
            }

            set
            {
                Cell7.Text = value;
            }
        }

        string IBoggleWindow.Cell8
        {
            get
            {
                return Cell8.Text;
            }

            set
            {
                Cell8.Text = value;
            }
        }

        string IBoggleWindow.Cell9
        {
            get
            {
                return Cell9.Text;
            }

            set
            {
                Cell9.Text = value;
            }
        }

        string IBoggleWindow.Cell10
        {
            get
            {
                return Cell10.Text;
            }

            set
            {
                Cell10.Text = value;
            }
        }

        string IBoggleWindow.Cell11
        {
            get
            {
                return Cell11.Text;
            }

            set
            {
                Cell11.Text = value;
            }
        }

        string IBoggleWindow.Cell12
        {
            get
            {
                return Cell12.Text;
            }

            set
            {
                Cell12.Text = value;
            }
        }

        string IBoggleWindow.Cell13
        {
            get
            {
                return Cell13.Text;
            }

            set
            {
                Cell13.Text = value;
            }
        }

        string IBoggleWindow.Cell14
        {
            get
            {
                return Cell14.Text;
            }

            set
            {
                Cell14.Text = value;
            }
        }

        string IBoggleWindow.Cell15
        {
            get
            {
                return Cell15.Text;
            }

            set
            {
                Cell15.Text = value;
            }
        }

        string IBoggleWindow.Cell16
        {
            get
            {
                return Cell16.Text;
            }

            set
            {
                Cell16.Text = value;
            }
        }

        string IBoggleWindow.playerBox
        {
            get
            {
                return playerBox.Text;
            }
            set
            {
                playerBox.Text = value;
            }
        }

        public string player1NameBox
        {
            set
            {
                Player1NameBox.Text = value;
            }
            get
            {
                return Player1NameBox.Text;
            }
        }


        //TODO:Need to go through all the http responses and decided what needs to be done for each error. 

        //TODO:FIGURE OUT WHERE SYNC GOES.
        /// <summary>
        /// I DONT KNOW WHERE THIS GOES!!!
        /// </summary>
        private readonly object sync = new object();

        public string player1ScoreBox
        {
            set
            {
                //I THINK I DID THIS RIGHT IS IT NECESSARY IDK!!!!
                lock (sync)
                {
                    Player1ScoreBox.Text = value;
                }
            }
            get
            {
                return Player1ScoreBox.Text;
            }
        }

        public string player2ScoreBox
        {
            set
            {
                Player2ScoreBox.Text = value;
            }
            get
            {
                return Player2ScoreBox.Text;
            }
        }

        string IBoggleWindow.timeLengthBox
        {
            get
            {
                return timeLengthBox.Text;
            }

            set
            {
                timeLengthBox.Text = value;
            }
        }

        string IBoggleWindow.timerDisplayBox
        {
            get
            {
                return timerDisplayBox.Text;
            }

            set
            {
                timerDisplayBox.Text = value;
            }
        }

        string IBoggleWindow.statusBox
        {
            get
            {
                return statusBox.Text;
            }

            set
            {
                statusBox.Text = value;
            }
        }

        public bool connectButton
        {
            get
            {
                return ConnectButton.Enabled;
            }

            set
            {
                ConnectButton.Enabled = value;
            }
        }

        public bool cancelButton
        {
            get
            {
                return CancelButton.Enabled;
            }

            set
            {
                CancelButton.Enabled = value;
            }
        }

        public string player2NameBox
        {
            set
            {
                Player2NameBox.Text = value;
            }
            get
            {
                return Player2NameBox.Text;
            }
        }

        string IBoggleWindow.wordEntryBox
        {
            get
            {
                return wordEntryBox.Text;
            }
        }

        string IBoggleWindow.urlTextBox
        {
            get
            {
                return urlTextBox.Text;
            }
            set
            {
                urlTextBox.Text = value;
            }
        }

        public string player1WordList
        {
            set
            {
                Player1WordList.Text =  value;
            }
        }

        public string player2WordList
        {
            set
            {
                Player2WordsList.Text = value;
            }
        }

        public BoggleWindow()
        {
            InitializeComponent();
            Text = "Boggle";
            CancelButton.Enabled = false;
            //Sets all cells to align in the center. 
            Cell1.SelectionAlignment = HorizontalAlignment.Center;
            Cell2.SelectionAlignment = HorizontalAlignment.Center;
            Cell3.SelectionAlignment = HorizontalAlignment.Center;
            Cell4.SelectionAlignment = HorizontalAlignment.Center;
            Cell5.SelectionAlignment = HorizontalAlignment.Center;
            Cell6.SelectionAlignment = HorizontalAlignment.Center;
            Cell7.SelectionAlignment = HorizontalAlignment.Center;
            Cell8.SelectionAlignment = HorizontalAlignment.Center;
            Cell9.SelectionAlignment = HorizontalAlignment.Center;
            Cell10.SelectionAlignment = HorizontalAlignment.Center;
            Cell11.SelectionAlignment = HorizontalAlignment.Center;
            Cell12.SelectionAlignment = HorizontalAlignment.Center;
            Cell13.SelectionAlignment = HorizontalAlignment.Center;
            Cell14.SelectionAlignment = HorizontalAlignment.Center;
            Cell15.SelectionAlignment = HorizontalAlignment.Center;
            Cell16.SelectionAlignment = HorizontalAlignment.Center;
            List<RichTextBox> cellList = new List<RichTextBox>();
            cellList.Add(Cell1);
            cellList.Add(Cell2);
            cellList.Add(Cell3);
            cellList.Add(Cell4);
            cellList.Add(Cell5);
            cellList.Add(Cell6);
            cellList.Add(Cell7);
            cellList.Add(Cell8);
            cellList.Add(Cell9);
            cellList.Add(Cell10);
            cellList.Add(Cell11);
            cellList.Add(Cell12);
            cellList.Add(Cell13);
            cellList.Add(Cell14);
            cellList.Add(Cell15);
            cellList.Add(Cell16);
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //TODO:when nothing is in timebox. or 5 or 120
            //Gets current time.
            int currentTime = int.Parse(timerDisplayBox.Text);
            if (currentTime <= 0)
            {
                timer1.Stop();
                return;
            }
            //Sets new time. 
            int newTime = --currentTime;
            timerDisplayBox.Text = newTime.ToString();
        }

        public void startTimer()
        {
            timer1.Interval = 1000;
            timer1.Start();
        }


        public void startTimerPending()
        {
            timer2.Interval = 1000;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(GameStateEvent != null)
            {
                GameStateEvent();
            }
        }

        public void startTimerScoreUpdate()
        {
            timer3.Interval = 1000;
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(UpdateScoreEvent != null)
            {
                UpdateScoreEvent();
            }
        }

        public event Action GameStateEvent;
        public event Action UpdateScoreEvent;
        public event Action CloseWindowEvent;
        public event Action HelpEvent1;
        public event Action HelpEvent2;
        public event Action ConnectEvent;
        public event Action<string> WordSubmitEvent;
        public event Action CancelEvent;
        public event Action NewEvent;
        public event Action CheatEventFast;
        public event Action CheatEventSlow;
        public event Action CheatEventWindow;
        public event Action CheatEventEthically;

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (CloseWindowEvent != null)
            {
                CloseWindowEvent();
            }
        }

        private void howToStart_Click(object sender, EventArgs e)
        {
            if (HelpEvent1 != null)
            {
                HelpEvent1();
            }
        }

        private void gameRules_Click(object sender, EventArgs e)
        {
            if (HelpEvent2 != null)
            {
                HelpEvent2();
            }
        }
        private void HelpButton_Click(object sender, EventArgs e)
        {
           
        }


        public void closeWindow()
        {
            Close();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (ConnectEvent != null)
            {
                ConnectEvent();
            }

        }


        public void helpHowToStartGame()
        {
            MessageBox.Show("How to start the game:\nEnter a URL to connect to another player, enter a username for yourself, and enter a time duration for each round.\nIf no time duration is set, the default is 60 seconds\n Once this information is entered, click Connect.\n Once another player connects, the game will start", "Help", MessageBoxButtons.OK);
        }

        public void helpGameRules()
        {
            MessageBox.Show("If a string has fewer than three characters, it scores zero points\n\nOtherwise, if a string has a duplicate that occurs earlier in the list, it scores zero points\n\nOtherwise, if a string is legal (it appears in the dictionary and occurs on the board), it receives a score that depends on its length.  Three- and four-letter words are worth one point, five-letter words are worth two points, six-letter words are worth three points, seven-letter words are worth five points, and longer words are worth 11 points\n\nOtherwise, the string scores negative one point");
        }
        public void errorMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void wordEntryBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Checks to see if the key pressed is the enter key if it is then continue on with the event. 
            if (statusBox.Text == "Connected" && e.KeyChar == '\r')
            {
                e.Handled = true;
                if (WordSubmitEvent != null)
                {
                    WordSubmitEvent(wordEntryBox.Text);
                    wordEntryBox.Text = "";
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if(CancelEvent != null)
            {
                CancelEvent();
            }
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(NewEvent != null)
            {
                NewEvent();
            }
        }

        public void NewWindow()
        {
            BoggleContext.GetContext().RunNew();
        }

        private void cheatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CheatEventFast != null)
            {
                CheatEventFast();
            }
        }

        public string ConnectButtonText
        {
            get
            {
                return ConnectButton.Text;
            }
            set
            {
                ConnectButton.Text = value;
            }

        }

        public string CancelButtonText
        {
            get
            {
                return CancelButton.Text;
            }

            set
            {
                CancelButton.Text = value;
            }
        }

        public RichTextBox Cell1Access
        {
            get
            {
                return Cell1;
            }
        }

        private void cheatSlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheatEventSlow != null)
            {
                CheatEventSlow();
            }
        }

        private void cheatWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CheatEventWindow != null)
            {
                CheatEventWindow();
            }
        }

        public void endPending()
        {
            timer2.Stop();
        }

        public void endScoreUpdater()
        {
            timer3.Stop();
        }

        private void cheatEthicallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CheatEventEthically != null)
            {
                CheatEventEthically();
            }
        }
    }
}
