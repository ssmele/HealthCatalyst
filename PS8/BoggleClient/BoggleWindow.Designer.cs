﻿namespace BoggleClient
{
    partial class BoggleWindow
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpButton = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cell1 = new System.Windows.Forms.RichTextBox();
            this.Cell2 = new System.Windows.Forms.RichTextBox();
            this.Cell3 = new System.Windows.Forms.RichTextBox();
            this.Cell4 = new System.Windows.Forms.RichTextBox();
            this.Cell5 = new System.Windows.Forms.RichTextBox();
            this.Cell6 = new System.Windows.Forms.RichTextBox();
            this.Cell7 = new System.Windows.Forms.RichTextBox();
            this.Cell8 = new System.Windows.Forms.RichTextBox();
            this.Cell9 = new System.Windows.Forms.RichTextBox();
            this.Cell10 = new System.Windows.Forms.RichTextBox();
            this.Cell11 = new System.Windows.Forms.RichTextBox();
            this.Cell12 = new System.Windows.Forms.RichTextBox();
            this.Cell13 = new System.Windows.Forms.RichTextBox();
            this.Cell14 = new System.Windows.Forms.RichTextBox();
            this.Cell15 = new System.Windows.Forms.RichTextBox();
            this.Cell16 = new System.Windows.Forms.RichTextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.wordEntryBox = new System.Windows.Forms.TextBox();
            this.wordEntryBoxLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.playerBox = new System.Windows.Forms.TextBox();
            this.playerNameBox = new System.Windows.Forms.Label();
            this.timeLengthBox = new System.Windows.Forms.TextBox();
            this.timeBoxLabel = new System.Windows.Forms.Label();
            this.Player1NameBox = new System.Windows.Forms.TextBox();
            this.Player2NameBox = new System.Windows.Forms.TextBox();
            this.Player1ScoreBox = new System.Windows.Forms.TextBox();
            this.Player2ScoreBox = new System.Windows.Forms.TextBox();
            this.Player1NameLabel = new System.Windows.Forms.Label();
            this.Player1ScoreLabel = new System.Windows.Forms.Label();
            this.Player2NameLabel = new System.Windows.Forms.Label();
            this.Player2ScoreLabel = new System.Windows.Forms.Label();
            this.Player1WordList = new System.Windows.Forms.RichTextBox();
            this.Player2WordsList = new System.Windows.Forms.RichTextBox();
            this.Player1WordLabel = new System.Windows.Forms.Label();
            this.Player2WordLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timerDisplayBox = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileButton,
            this.HelpButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1285, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileButton
            // 
            this.FileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseButton,
            this.newWindowToolStripMenuItem});
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(44, 24);
            this.FileButton.Text = "File";
            // 
            // CloseButton
            // 
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(120, 26);
            this.CloseButton.Text = "Close";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(53, 24);
            this.HelpButton.Text = "Help";
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Cell1);
            this.panel1.Controls.Add(this.Cell2);
            this.panel1.Controls.Add(this.Cell3);
            this.panel1.Controls.Add(this.Cell4);
            this.panel1.Controls.Add(this.Cell5);
            this.panel1.Controls.Add(this.Cell6);
            this.panel1.Controls.Add(this.Cell7);
            this.panel1.Controls.Add(this.Cell8);
            this.panel1.Controls.Add(this.Cell9);
            this.panel1.Controls.Add(this.Cell10);
            this.panel1.Controls.Add(this.Cell11);
            this.panel1.Controls.Add(this.Cell12);
            this.panel1.Controls.Add(this.Cell13);
            this.panel1.Controls.Add(this.Cell14);
            this.panel1.Controls.Add(this.Cell15);
            this.panel1.Controls.Add(this.Cell16);
            this.panel1.Location = new System.Drawing.Point(29, 256);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 450);
            this.panel1.TabIndex = 2;
            // 
            // Cell1
            // 
            this.Cell1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell1.Location = new System.Drawing.Point(7, 16);
            this.Cell1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell1.Name = "Cell1";
            this.Cell1.ReadOnly = true;
            this.Cell1.Size = new System.Drawing.Size(100, 100);
            this.Cell1.TabIndex = 16;
            this.Cell1.Text = "";
            this.Cell1.UseWaitCursor = true;
            // 
            // Cell2
            // 
            this.Cell2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell2.Location = new System.Drawing.Point(113, 16);
            this.Cell2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell2.Name = "Cell2";
            this.Cell2.ReadOnly = true;
            this.Cell2.Size = new System.Drawing.Size(100, 100);
            this.Cell2.TabIndex = 17;
            this.Cell2.Text = "";
            this.Cell2.UseWaitCursor = true;
            // 
            // Cell3
            // 
            this.Cell3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell3.Location = new System.Drawing.Point(220, 16);
            this.Cell3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell3.Name = "Cell3";
            this.Cell3.ReadOnly = true;
            this.Cell3.Size = new System.Drawing.Size(100, 100);
            this.Cell3.TabIndex = 18;
            this.Cell3.Text = "";
            this.Cell3.UseWaitCursor = true;
            // 
            // Cell4
            // 
            this.Cell4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell4.Location = new System.Drawing.Point(327, 16);
            this.Cell4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell4.Name = "Cell4";
            this.Cell4.ReadOnly = true;
            this.Cell4.Size = new System.Drawing.Size(100, 100);
            this.Cell4.TabIndex = 19;
            this.Cell4.Text = "";
            this.Cell4.UseWaitCursor = true;
            // 
            // Cell5
            // 
            this.Cell5.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell5.Location = new System.Drawing.Point(7, 122);
            this.Cell5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell5.Name = "Cell5";
            this.Cell5.ReadOnly = true;
            this.Cell5.Size = new System.Drawing.Size(100, 100);
            this.Cell5.TabIndex = 20;
            this.Cell5.Text = "";
            this.Cell5.UseWaitCursor = true;
            // 
            // Cell6
            // 
            this.Cell6.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell6.Location = new System.Drawing.Point(113, 122);
            this.Cell6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell6.Name = "Cell6";
            this.Cell6.ReadOnly = true;
            this.Cell6.Size = new System.Drawing.Size(100, 100);
            this.Cell6.TabIndex = 21;
            this.Cell6.Text = "";
            this.Cell6.UseWaitCursor = true;
            // 
            // Cell7
            // 
            this.Cell7.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell7.Location = new System.Drawing.Point(220, 122);
            this.Cell7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell7.Name = "Cell7";
            this.Cell7.ReadOnly = true;
            this.Cell7.Size = new System.Drawing.Size(100, 100);
            this.Cell7.TabIndex = 22;
            this.Cell7.Text = "";
            this.Cell7.UseWaitCursor = true;
            // 
            // Cell8
            // 
            this.Cell8.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell8.Location = new System.Drawing.Point(327, 122);
            this.Cell8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell8.Name = "Cell8";
            this.Cell8.ReadOnly = true;
            this.Cell8.Size = new System.Drawing.Size(100, 100);
            this.Cell8.TabIndex = 23;
            this.Cell8.Text = "";
            this.Cell8.UseWaitCursor = true;
            // 
            // Cell9
            // 
            this.Cell9.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell9.Location = new System.Drawing.Point(7, 228);
            this.Cell9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell9.Name = "Cell9";
            this.Cell9.ReadOnly = true;
            this.Cell9.Size = new System.Drawing.Size(100, 100);
            this.Cell9.TabIndex = 24;
            this.Cell9.Text = "";
            this.Cell9.UseWaitCursor = true;
            // 
            // Cell10
            // 
            this.Cell10.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell10.Location = new System.Drawing.Point(113, 228);
            this.Cell10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell10.Name = "Cell10";
            this.Cell10.ReadOnly = true;
            this.Cell10.Size = new System.Drawing.Size(100, 100);
            this.Cell10.TabIndex = 25;
            this.Cell10.Text = "";
            this.Cell10.UseWaitCursor = true;
            // 
            // Cell11
            // 
            this.Cell11.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell11.Location = new System.Drawing.Point(220, 228);
            this.Cell11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell11.Name = "Cell11";
            this.Cell11.ReadOnly = true;
            this.Cell11.Size = new System.Drawing.Size(100, 100);
            this.Cell11.TabIndex = 26;
            this.Cell11.Text = "";
            this.Cell11.UseWaitCursor = true;
            // 
            // Cell12
            // 
            this.Cell12.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell12.Location = new System.Drawing.Point(327, 228);
            this.Cell12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell12.Name = "Cell12";
            this.Cell12.ReadOnly = true;
            this.Cell12.Size = new System.Drawing.Size(100, 100);
            this.Cell12.TabIndex = 27;
            this.Cell12.Text = "";
            this.Cell12.UseWaitCursor = true;
            // 
            // Cell13
            // 
            this.Cell13.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell13.Location = new System.Drawing.Point(7, 334);
            this.Cell13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell13.Name = "Cell13";
            this.Cell13.ReadOnly = true;
            this.Cell13.Size = new System.Drawing.Size(100, 100);
            this.Cell13.TabIndex = 28;
            this.Cell13.Text = "";
            this.Cell13.UseWaitCursor = true;
            // 
            // Cell14
            // 
            this.Cell14.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell14.Location = new System.Drawing.Point(113, 334);
            this.Cell14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell14.Name = "Cell14";
            this.Cell14.ReadOnly = true;
            this.Cell14.Size = new System.Drawing.Size(100, 100);
            this.Cell14.TabIndex = 29;
            this.Cell14.Text = "";
            this.Cell14.UseWaitCursor = true;
            // 
            // Cell15
            // 
            this.Cell15.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell15.Location = new System.Drawing.Point(220, 334);
            this.Cell15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell15.Name = "Cell15";
            this.Cell15.ReadOnly = true;
            this.Cell15.Size = new System.Drawing.Size(100, 100);
            this.Cell15.TabIndex = 30;
            this.Cell15.Text = "";
            this.Cell15.UseWaitCursor = true;
            // 
            // Cell16
            // 
            this.Cell16.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell16.Location = new System.Drawing.Point(327, 334);
            this.Cell16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cell16.Name = "Cell16";
            this.Cell16.ReadOnly = true;
            this.Cell16.Size = new System.Drawing.Size(100, 100);
            this.Cell16.TabIndex = 31;
            this.Cell16.Text = "";
            this.Cell16.UseWaitCursor = true;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(243, 129);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(140, 25);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(243, 161);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(140, 25);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // wordEntryBox
            // 
            this.wordEntryBox.Location = new System.Drawing.Point(29, 224);
            this.wordEntryBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wordEntryBox.Name = "wordEntryBox";
            this.wordEntryBox.Size = new System.Drawing.Size(440, 22);
            this.wordEntryBox.TabIndex = 5;
            this.wordEntryBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wordEntryBox_KeyPress);
            // 
            // wordEntryBoxLabel
            // 
            this.wordEntryBoxLabel.AutoSize = true;
            this.wordEntryBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordEntryBoxLabel.Location = new System.Drawing.Point(31, 191);
            this.wordEntryBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.wordEntryBoxLabel.Name = "wordEntryBoxLabel";
            this.wordEntryBoxLabel.Size = new System.Drawing.Size(203, 29);
            this.wordEntryBoxLabel.TabIndex = 6;
            this.wordEntryBoxLabel.Text = "Enter words here:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(29, 58);
            this.urlTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(165, 22);
            this.urlTextBox.TabIndex = 7;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlLabel.Location = new System.Drawing.Point(31, 30);
            this.urlLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(56, 25);
            this.urlLabel.TabIndex = 8;
            this.urlLabel.Text = "URL:";
            // 
            // playerBox
            // 
            this.playerBox.Location = new System.Drawing.Point(29, 110);
            this.playerBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playerBox.Name = "playerBox";
            this.playerBox.Size = new System.Drawing.Size(169, 22);
            this.playerBox.TabIndex = 9;
            // 
            // playerNameBox
            // 
            this.playerNameBox.AutoSize = true;
            this.playerNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameBox.Location = new System.Drawing.Point(31, 81);
            this.playerNameBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerNameBox.Name = "playerNameBox";
            this.playerNameBox.Size = new System.Drawing.Size(156, 25);
            this.playerNameBox.TabIndex = 10;
            this.playerNameBox.Text = "Enter username:";
            // 
            // timeLengthBox
            // 
            this.timeLengthBox.Location = new System.Drawing.Point(29, 162);
            this.timeLengthBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeLengthBox.Name = "timeLengthBox";
            this.timeLengthBox.Size = new System.Drawing.Size(169, 22);
            this.timeLengthBox.TabIndex = 11;
            // 
            // timeBoxLabel
            // 
            this.timeBoxLabel.AutoSize = true;
            this.timeBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeBoxLabel.Location = new System.Drawing.Point(31, 133);
            this.timeBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeBoxLabel.Name = "timeBoxLabel";
            this.timeBoxLabel.Size = new System.Drawing.Size(160, 25);
            this.timeBoxLabel.TabIndex = 12;
            this.timeBoxLabel.Text = "Desired duration:";
            // 
            // Player1NameBox
            // 
            this.Player1NameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Player1NameBox.Location = new System.Drawing.Point(635, 52);
            this.Player1NameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Player1NameBox.Name = "Player1NameBox";
            this.Player1NameBox.ReadOnly = true;
            this.Player1NameBox.Size = new System.Drawing.Size(232, 22);
            this.Player1NameBox.TabIndex = 13;
            // 
            // Player2NameBox
            // 
            this.Player2NameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Player2NameBox.Location = new System.Drawing.Point(979, 53);
            this.Player2NameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Player2NameBox.Name = "Player2NameBox";
            this.Player2NameBox.ReadOnly = true;
            this.Player2NameBox.Size = new System.Drawing.Size(228, 22);
            this.Player2NameBox.TabIndex = 14;
            // 
            // Player1ScoreBox
            // 
            this.Player1ScoreBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Player1ScoreBox.Location = new System.Drawing.Point(635, 95);
            this.Player1ScoreBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Player1ScoreBox.Name = "Player1ScoreBox";
            this.Player1ScoreBox.ReadOnly = true;
            this.Player1ScoreBox.Size = new System.Drawing.Size(232, 22);
            this.Player1ScoreBox.TabIndex = 15;
            // 
            // Player2ScoreBox
            // 
            this.Player2ScoreBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Player2ScoreBox.Location = new System.Drawing.Point(979, 95);
            this.Player2ScoreBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Player2ScoreBox.Name = "Player2ScoreBox";
            this.Player2ScoreBox.ReadOnly = true;
            this.Player2ScoreBox.Size = new System.Drawing.Size(228, 22);
            this.Player2ScoreBox.TabIndex = 16;
            // 
            // Player1NameLabel
            // 
            this.Player1NameLabel.AutoSize = true;
            this.Player1NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1NameLabel.Location = new System.Drawing.Point(543, 52);
            this.Player1NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player1NameLabel.Name = "Player1NameLabel";
            this.Player1NameLabel.Size = new System.Drawing.Size(89, 25);
            this.Player1NameLabel.TabIndex = 17;
            this.Player1NameLabel.Text = "Player 1:";
            // 
            // Player1ScoreLabel
            // 
            this.Player1ScoreLabel.AutoSize = true;
            this.Player1ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1ScoreLabel.Location = new System.Drawing.Point(561, 92);
            this.Player1ScoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player1ScoreLabel.Name = "Player1ScoreLabel";
            this.Player1ScoreLabel.Size = new System.Drawing.Size(70, 25);
            this.Player1ScoreLabel.TabIndex = 18;
            this.Player1ScoreLabel.Text = "Score:";
            // 
            // Player2NameLabel
            // 
            this.Player2NameLabel.AutoSize = true;
            this.Player2NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2NameLabel.Location = new System.Drawing.Point(879, 52);
            this.Player2NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player2NameLabel.Name = "Player2NameLabel";
            this.Player2NameLabel.Size = new System.Drawing.Size(89, 25);
            this.Player2NameLabel.TabIndex = 19;
            this.Player2NameLabel.Text = "Player 2:";
            // 
            // Player2ScoreLabel
            // 
            this.Player2ScoreLabel.AutoSize = true;
            this.Player2ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2ScoreLabel.Location = new System.Drawing.Point(897, 95);
            this.Player2ScoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player2ScoreLabel.Name = "Player2ScoreLabel";
            this.Player2ScoreLabel.Size = new System.Drawing.Size(70, 25);
            this.Player2ScoreLabel.TabIndex = 20;
            this.Player2ScoreLabel.Text = "Score:";
            // 
            // Player1WordList
            // 
            this.Player1WordList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Player1WordList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1WordList.Location = new System.Drawing.Point(635, 138);
            this.Player1WordList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Player1WordList.Name = "Player1WordList";
            this.Player1WordList.ReadOnly = true;
            this.Player1WordList.Size = new System.Drawing.Size(232, 568);
            this.Player1WordList.TabIndex = 21;
            this.Player1WordList.Text = "";
            // 
            // Player2WordsList
            // 
            this.Player2WordsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Player2WordsList.Location = new System.Drawing.Point(979, 135);
            this.Player2WordsList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Player2WordsList.Name = "Player2WordsList";
            this.Player2WordsList.ReadOnly = true;
            this.Player2WordsList.Size = new System.Drawing.Size(228, 570);
            this.Player2WordsList.TabIndex = 22;
            this.Player2WordsList.Text = "";
            // 
            // Player1WordLabel
            // 
            this.Player1WordLabel.AutoSize = true;
            this.Player1WordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1WordLabel.Location = new System.Drawing.Point(556, 133);
            this.Player1WordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player1WordLabel.Name = "Player1WordLabel";
            this.Player1WordLabel.Size = new System.Drawing.Size(76, 25);
            this.Player1WordLabel.TabIndex = 23;
            this.Player1WordLabel.Text = "Words:";
            // 
            // Player2WordLabel
            // 
            this.Player2WordLabel.AutoSize = true;
            this.Player2WordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2WordLabel.Location = new System.Drawing.Point(892, 133);
            this.Player2WordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player2WordLabel.Name = "Player2WordLabel";
            this.Player2WordLabel.Size = new System.Drawing.Size(76, 25);
            this.Player2WordLabel.TabIndex = 24;
            this.Player2WordLabel.Text = "Words:";
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(237, 30);
            this.timerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(159, 25);
            this.timerLabel.TabIndex = 25;
            this.timerLabel.Text = "Time Remaining:";
            // 
            // timerDisplayBox
            // 
            this.timerDisplayBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.timerDisplayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerDisplayBox.Location = new System.Drawing.Point(243, 59);
            this.timerDisplayBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timerDisplayBox.Name = "timerDisplayBox";
            this.timerDisplayBox.ReadOnly = true;
            this.timerDisplayBox.Size = new System.Drawing.Size(203, 45);
            this.timerDisplayBox.TabIndex = 26;
            this.timerDisplayBox.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Location = new System.Drawing.Point(941, 4);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(72, 24);
            this.statusLabel.TabIndex = 27;
            this.statusLabel.Text = "Status:";
            // 
            // statusBox
            // 
            this.statusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBox.ForeColor = System.Drawing.Color.Red;
            this.statusBox.Location = new System.Drawing.Point(1031, 2);
            this.statusBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.Size = new System.Drawing.Size(176, 26);
            this.statusBox.TabIndex = 28;
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newWindowToolStripMenuItem.Text = "New Window";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.newWindowToolStripMenuItem_Click);
            // 
            // BoggleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1285, 734);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.timerDisplayBox);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.Player2WordLabel);
            this.Controls.Add(this.Player1WordLabel);
            this.Controls.Add(this.Player2WordsList);
            this.Controls.Add(this.Player1WordList);
            this.Controls.Add(this.Player2ScoreLabel);
            this.Controls.Add(this.Player2NameLabel);
            this.Controls.Add(this.Player1ScoreLabel);
            this.Controls.Add(this.Player1NameLabel);
            this.Controls.Add(this.Player2ScoreBox);
            this.Controls.Add(this.Player1ScoreBox);
            this.Controls.Add(this.Player2NameBox);
            this.Controls.Add(this.Player1NameBox);
            this.Controls.Add(this.timeBoxLabel);
            this.Controls.Add(this.timeLengthBox);
            this.Controls.Add(this.playerNameBox);
            this.Controls.Add(this.playerBox);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.wordEntryBoxLabel);
            this.Controls.Add(this.wordEntryBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BoggleWindow";
            this.Text = "Boggle";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem FileButton;
        private System.Windows.Forms.ToolStripMenuItem CloseButton;
        private System.Windows.Forms.ToolStripMenuItem HelpButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox Cell1;
        private System.Windows.Forms.RichTextBox Cell2;
        private System.Windows.Forms.RichTextBox Cell3;
        private System.Windows.Forms.RichTextBox Cell4;
        private System.Windows.Forms.RichTextBox Cell5;
        private System.Windows.Forms.RichTextBox Cell6;
        private System.Windows.Forms.RichTextBox Cell7;
        private System.Windows.Forms.RichTextBox Cell8;
        private System.Windows.Forms.RichTextBox Cell9;
        private System.Windows.Forms.RichTextBox Cell10;
        private System.Windows.Forms.RichTextBox Cell11;
        private System.Windows.Forms.RichTextBox Cell12;
        private System.Windows.Forms.RichTextBox Cell13;
        private System.Windows.Forms.RichTextBox Cell14;
        private System.Windows.Forms.RichTextBox Cell15;
        private System.Windows.Forms.RichTextBox Cell16;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox wordEntryBox;
        private System.Windows.Forms.Label wordEntryBoxLabel;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox playerBox;
        private System.Windows.Forms.Label playerNameBox;
        private System.Windows.Forms.TextBox timeLengthBox;
        private System.Windows.Forms.Label timeBoxLabel;
        private System.Windows.Forms.TextBox Player1NameBox;
        private System.Windows.Forms.TextBox Player2NameBox;
        private System.Windows.Forms.TextBox Player1ScoreBox;
        private System.Windows.Forms.TextBox Player2ScoreBox;
        private System.Windows.Forms.Label Player1NameLabel;
        private System.Windows.Forms.Label Player1ScoreLabel;
        private System.Windows.Forms.Label Player2NameLabel;
        private System.Windows.Forms.Label Player2ScoreLabel;
        private System.Windows.Forms.RichTextBox Player1WordList;
        private System.Windows.Forms.RichTextBox Player2WordsList;
        private System.Windows.Forms.Label Player1WordLabel;
        private System.Windows.Forms.Label Player2WordLabel;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.RichTextBox timerDisplayBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
    }
}

