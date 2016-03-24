// Written by: Boggle Masters
//Date: 3/24/16

using System;
using System.Windows.Forms;

namespace BoggleClient
{
    //View for cheater.
    public partial class CheatForm : Form
    {
        public CheatForm()
        {
            InitializeComponent();
            this.Text = "Answers";
        }

        public void displayWords(string answers,string sortedAnswers)
        {
            answerBox.Text = answers;
            sorted = sortedAnswers;
        }

        public void displayLargest(string largestWord, int largestScore)
        {
            largestWordBox.Text = largestWord;
            largestScoreBox.Text = largestScore.ToString();
        }

        private string sorted;
        private void sortButton_Click(object sender, EventArgs e)
        {
            answerBox.Text = sorted;
        }
    }
}
