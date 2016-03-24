// Written by: Hanna Larsen & Salvatore Stone Mele
//              u0741837       u0897718
//Date: 3/24/16

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BoggleClient
{

    /// <summary>
    /// Viewer for Boggle Client. 
    /// </summary>
    public partial class BoggleWindow : Form, IBoggleWindow
    {


        // Events
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
        public event Action HelpCheat;


        // Getters & setters for GUI components
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

        /// <summary>
        /// Associated with the lock on the player 1 scorebox
        /// </summary>
        private readonly object sync = new object();

        public string player1ScoreBox
        {
            set
            {
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
                Player1WordList.Text = value;
            }
        }

        public string player2WordList
        {
            set
            {
                Player2WordsList.Text = value;
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

        /// <summary>
        /// Creates the GUI window
        /// </summary>
        public BoggleWindow()
        {
            InitializeComponent();
            Text = "Boggle";
            CancelButton.Enabled = false;
            timer1.Tick += Timer1_Tick;
        }


        /// <summary>
        /// Timer that controls the time left in the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
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

        /// <summary>
        /// Starts Timer1
        /// </summary>
        public void startTimer()
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        /// <summary>
        /// Starts the timer for the status updater
        /// </summary>
        public void startTimerPending()
        {
            timer2.Interval = 1000;
            timer2.Start();
        }

        /// <summary>
        /// Timer for the status updates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (GameStateEvent != null)
            {
                GameStateEvent();
            }
        }

        /// <summary>
        /// Starts the timer to update the scores
        /// </summary>
        public void startTimerScoreUpdate()
        {
            timer3.Interval = 1000;
            timer3.Start();
        }

        /// <summary>
        /// Timer that updates the scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (UpdateScoreEvent != null)
            {
                UpdateScoreEvent();
            }
        }

        /// <summary>
        /// When Close button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (CloseWindowEvent != null)
            {
                CloseWindowEvent();
            }
        }

        /// <summary>
        /// When How to Start is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void howToStart_Click(object sender, EventArgs e)
        {
            if (HelpEvent1 != null)
            {
                HelpEvent1();
            }
        }

        /// <summary>
        /// When Game Rules menu is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameRules_Click(object sender, EventArgs e)
        {
            if (HelpEvent2 != null)
            {
                HelpEvent2();
            }
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        public void closeWindow()
        {
            Close();
        }

        /// <summary>
        /// When connect button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (ConnectEvent != null)
            {
                ConnectEvent();
            }
        }

        /// <summary>
        /// Displays text explaining how to start the game
        /// </summary>
        public void helpHowToStartGame()
        {
            MessageBox.Show("How to start the game:\nEnter a URL to connect to another player, enter a username for yourself, and enter a time duration for each round.\nIf no time duration is set, the default is 60 seconds\n Once this information is entered, click Connect.\n Once another player connects, the game will start", "Help", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Displays the game rules
        /// </summary>
        public void helpGameRules()
        {
            MessageBox.Show("If a string has fewer than three characters, it scores zero points\n\nOtherwise, if a string has a duplicate that occurs earlier in the list, it scores zero points\n\nOtherwise, if a string is legal (it appears in the dictionary and occurs on the board), it receives a score that depends on its length.  Three- and four-letter words are worth one point, five-letter words are worth two points, six-letter words are worth three points, seven-letter words are worth five points, and longer words are worth 11 points\n\nOtherwise, the string scores negative one point");
        }

        /// <summary>
        /// General error message method
        /// </summary>
        /// <param name="message"></param>
        public void errorMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// When a word is submitted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When the cancel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (CancelEvent != null)
            {
                CancelEvent();
            }
        }

        /// <summary>
        /// When new game is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewEvent != null)
            {
                NewEvent();
            }
        }

        /// <summary>
        /// Opens a new window w/ a new game
        /// </summary>
        public void NewWindow()
        {
            BoggleContext.GetContext().RunNew();
        }


        /// <summary>
        /// Ends the pending timer
        /// </summary>
        public void endPending()
        {
            timer2.Stop();
        }

        /// <summary>
        /// Ends updating the score
        /// </summary>
        public void endScoreUpdater()
        {
            timer3.Stop();
        }

        /// <summary>
        /// Refreshes the letters on the board
        /// </summary>
        /// <param name="boardSTRING"></param>
        public void refreshBoard(string boardSTRING)
        {
            List<Label> cellList = new List<Label>();
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
            int count = 0;
            foreach (Label cell in cellList)
            {
                if (boardSTRING[count] == 'Q')
                {
                    cell.Text = "Qu";
                }
                else
                {
                    cell.Text = boardSTRING[count].ToString();
                }
                count++;
            }
        }
        // NOT IMPORTANT CODE ------------------------------------------------------------*********************************************************************************
        private void cheatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheatEventFast != null)
            {
                CheatEventFast();
            }
        }


        private void cheatWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheatEventWindow != null)
            {
                CheatEventWindow();
            }
        }

        private void cheatSlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheatEventSlow != null)
            {
                CheatEventSlow();
            }
        }

        private void cheatEthicallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheatEventEthically != null)
            {
                CheatEventEthically();
            }
        }

        private void howToCheatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HelpCheat != null)
            {
                helpCheat();
            }
        }


        /// <summary>
        /// Displays the game rules
        /// </summary>
        public void helpCheat()
        {
            MessageBox.Show("Cheating: \n Fast Cheat: This will insert all possible words on current boggle board. \n SlowCheat: Does same thing as fast cheat but slowly so its more sneaky(Also less stressful on the server) \n Cheat Window: Will display a window will all possible words of current boggle board. Sort button located at the bottom of the window to sort based on score. \n Cheat ethically: This will enter one of the largest words on the board every few seconds. Very low stress on the server, and very sneaky.");
        }
    }
}
