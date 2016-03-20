﻿using System;
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
        }

        public string player1ScoreBox
        {
            set
            {
                Player1ScoreBox.Text = value;
            }
        }

        public string player2ScoreBox
        {
            set
            {
                Player2ScoreBox.Text = value;
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
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //TODO:when nothing is in timebox. or 5 or 120
            //Gets current time.
            int currentTime = int.Parse(timerDisplayBox.Text);
            if(currentTime <= 0)
            {
                timer1.Stop();
                return;
            }
            //Sets new time. 
            int newTime = --currentTime;
            timerDisplayBox.Text = newTime.ToString();
        }

        private void startTimer()
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        



        public event Action CloseWindowEvent;
        public event Action HelpEvent;
        public event Action ConnectEvent;

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if(CloseWindowEvent != null)
            {
                CloseWindowEvent();
            }
        }


        private void HelpButton_Click(object sender, EventArgs e)
        {
            if (HelpEvent != null)
            {
                HelpEvent();
            }
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
            //startTimer();
            
        }

        public void helpWindow()
        {
            MessageBox.Show("How to start the game:\nEnter a URL to connect to another player, enter a username for yourself, and enter a time duration for each round.\nIf no time duration is set, the default is 60 seconds\n Once this information is entered, click Connect.\n Once another player connects, the game will start");
        }

        public void errorMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
