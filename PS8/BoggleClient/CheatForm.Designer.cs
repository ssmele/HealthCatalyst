namespace BoggleClient
{
    partial class CheatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.answerLabel = new System.Windows.Forms.Label();
            this.answerBox = new System.Windows.Forms.RichTextBox();
            this.largestWordBox = new System.Windows.Forms.TextBox();
            this.longestWord = new System.Windows.Forms.Label();
            this.largestScore = new System.Windows.Forms.Label();
            this.largestScoreBox = new System.Windows.Forms.TextBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Font = new System.Drawing.Font("Adobe Heiti Std R", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerLabel.Location = new System.Drawing.Point(27, 9);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(558, 35);
            this.answerLabel.TabIndex = 0;
            this.answerLabel.Text = "Possible words on current boggle board.";
            // 
            // answerBox
            // 
            this.answerBox.Location = new System.Drawing.Point(33, 91);
            this.answerBox.Name = "answerBox";
            this.answerBox.Size = new System.Drawing.Size(552, 373);
            this.answerBox.TabIndex = 1;
            this.answerBox.Text = "";
            // 
            // largestWordBox
            // 
            this.largestWordBox.Location = new System.Drawing.Point(195, 61);
            this.largestWordBox.Name = "largestWordBox";
            this.largestWordBox.ReadOnly = true;
            this.largestWordBox.Size = new System.Drawing.Size(249, 22);
            this.largestWordBox.TabIndex = 2;
            // 
            // longestWord
            // 
            this.longestWord.AutoSize = true;
            this.longestWord.Location = new System.Drawing.Point(30, 64);
            this.longestWord.Name = "longestWord";
            this.longestWord.Size = new System.Drawing.Size(163, 17);
            this.longestWord.TabIndex = 3;
            this.longestWord.Text = "Longest Word on Board:";
            // 
            // largestScore
            // 
            this.largestScore.AutoSize = true;
            this.largestScore.Location = new System.Drawing.Point(458, 64);
            this.largestScore.Name = "largestScore";
            this.largestScore.Size = new System.Drawing.Size(49, 17);
            this.largestScore.TabIndex = 4;
            this.largestScore.Text = "Score:";
            // 
            // largestScoreBox
            // 
            this.largestScoreBox.Location = new System.Drawing.Point(511, 61);
            this.largestScoreBox.Name = "largestScoreBox";
            this.largestScoreBox.ReadOnly = true;
            this.largestScoreBox.Size = new System.Drawing.Size(74, 22);
            this.largestScoreBox.TabIndex = 5;
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(33, 470);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(552, 28);
            this.sortButton.TabIndex = 6;
            this.sortButton.Text = "Sort Words By Score";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // CheatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 513);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.largestScoreBox);
            this.Controls.Add(this.largestScore);
            this.Controls.Add(this.longestWord);
            this.Controls.Add(this.largestWordBox);
            this.Controls.Add(this.answerBox);
            this.Controls.Add(this.answerLabel);
            this.Name = "CheatForm";
            this.Text = "CheatForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.RichTextBox answerBox;
        private System.Windows.Forms.TextBox largestWordBox;
        private System.Windows.Forms.Label longestWord;
        private System.Windows.Forms.Label largestScore;
        private System.Windows.Forms.TextBox largestScoreBox;
        private System.Windows.Forms.Button sortButton;
    }
}