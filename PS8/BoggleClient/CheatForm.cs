using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoggleClient
{
    public partial class CheatForm : Form
    {
        public CheatForm()
        {
            InitializeComponent();
            this.Text = "Answers";
        }

        public void displayWords(string answers)
        {
            answerBox.Text = answers;
        }
        

    }
}
