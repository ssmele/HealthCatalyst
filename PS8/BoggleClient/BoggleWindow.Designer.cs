namespace BoggleClient
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
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cheatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cheatSlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cheatWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cheatEthicallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpButton = new System.Windows.Forms.ToolStripMenuItem();
            this.howToStart = new System.Windows.Forms.ToolStripMenuItem();
            this.gameRules = new System.Windows.Forms.ToolStripMenuItem();
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
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Cell2 = new System.Windows.Forms.Label();
            this.Cell1 = new System.Windows.Forms.Label();
            this.Cell3 = new System.Windows.Forms.Label();
            this.Cell4 = new System.Windows.Forms.Label();
            this.Cell5 = new System.Windows.Forms.Label();
            this.Cell6 = new System.Windows.Forms.Label();
            this.Cell7 = new System.Windows.Forms.Label();
            this.Cell8 = new System.Windows.Forms.Label();
            this.Cell9 = new System.Windows.Forms.Label();
            this.Cell10 = new System.Windows.Forms.Label();
            this.Cell11 = new System.Windows.Forms.Label();
            this.Cell12 = new System.Windows.Forms.Label();
            this.Cell13 = new System.Windows.Forms.Label();
            this.Cell14 = new System.Windows.Forms.Label();
            this.Cell15 = new System.Windows.Forms.Label();
            this.Cell16 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(964, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileButton
            // 
            this.FileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseButton,
            this.newWindowToolStripMenuItem,
            this.cheatToolStripMenuItem,
            this.cheatSlowToolStripMenuItem,
            this.cheatWindowToolStripMenuItem,
            this.cheatEthicallyToolStripMenuItem});
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(37, 20);
            this.FileButton.Text = "File";
            // 
            // CloseButton
            // 
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(152, 22);
            this.CloseButton.Text = "Close";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newWindowToolStripMenuItem.Text = "New Window";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.newWindowToolStripMenuItem_Click);
            // 
            // cheatToolStripMenuItem
            // 
            this.cheatToolStripMenuItem.Name = "cheatToolStripMenuItem";
            this.cheatToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cheatToolStripMenuItem.Text = "Cheat Fast";
            this.cheatToolStripMenuItem.Click += new System.EventHandler(this.cheatToolStripMenuItem_Click);
            // 
            // cheatSlowToolStripMenuItem
            // 
            this.cheatSlowToolStripMenuItem.Name = "cheatSlowToolStripMenuItem";
            this.cheatSlowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cheatSlowToolStripMenuItem.Text = "Cheat Slow";
            this.cheatSlowToolStripMenuItem.Click += new System.EventHandler(this.cheatSlowToolStripMenuItem_Click);
            // 
            // cheatWindowToolStripMenuItem
            // 
            this.cheatWindowToolStripMenuItem.Name = "cheatWindowToolStripMenuItem";
            this.cheatWindowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cheatWindowToolStripMenuItem.Text = "Cheat Window";
            this.cheatWindowToolStripMenuItem.Click += new System.EventHandler(this.cheatWindowToolStripMenuItem_Click);
            // 
            // cheatEthicallyToolStripMenuItem
            // 
            this.cheatEthicallyToolStripMenuItem.Name = "cheatEthicallyToolStripMenuItem";
            this.cheatEthicallyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cheatEthicallyToolStripMenuItem.Text = "Cheat Ethically";
            this.cheatEthicallyToolStripMenuItem.Click += new System.EventHandler(this.cheatEthicallyToolStripMenuItem_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToStart,
            this.gameRules});
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(44, 20);
            this.HelpButton.Text = "Help";
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // howToStart
            // 
            this.howToStart.Name = "howToStart";
            this.howToStart.Size = new System.Drawing.Size(143, 22);
            this.howToStart.Text = "How To Start";
            this.howToStart.Click += new System.EventHandler(this.howToStart_Click);
            // 
            // gameRules
            // 
            this.gameRules.Name = "gameRules";
            this.gameRules.Size = new System.Drawing.Size(143, 22);
            this.gameRules.Text = "Game Rules";
            this.gameRules.Click += new System.EventHandler(this.gameRules_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(208, 106);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(170, 20);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(208, 132);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(170, 20);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // wordEntryBox
            // 
            this.wordEntryBox.Location = new System.Drawing.Point(22, 182);
            this.wordEntryBox.Name = "wordEntryBox";
            this.wordEntryBox.Size = new System.Drawing.Size(361, 20);
            this.wordEntryBox.TabIndex = 5;
            this.wordEntryBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wordEntryBox_KeyPress);
            // 
            // wordEntryBoxLabel
            // 
            this.wordEntryBoxLabel.AutoSize = true;
            this.wordEntryBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordEntryBoxLabel.Location = new System.Drawing.Point(18, 155);
            this.wordEntryBoxLabel.Name = "wordEntryBoxLabel";
            this.wordEntryBoxLabel.Size = new System.Drawing.Size(160, 24);
            this.wordEntryBoxLabel.TabIndex = 6;
            this.wordEntryBoxLabel.Text = "Enter words here:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(22, 47);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(125, 20);
            this.urlTextBox.TabIndex = 7;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlLabel.Location = new System.Drawing.Point(23, 24);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(46, 20);
            this.urlLabel.TabIndex = 8;
            this.urlLabel.Text = "URL:";
            // 
            // playerBox
            // 
            this.playerBox.Location = new System.Drawing.Point(22, 89);
            this.playerBox.Name = "playerBox";
            this.playerBox.Size = new System.Drawing.Size(128, 20);
            this.playerBox.TabIndex = 9;
            // 
            // playerNameBox
            // 
            this.playerNameBox.AutoSize = true;
            this.playerNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameBox.Location = new System.Drawing.Point(23, 66);
            this.playerNameBox.Name = "playerNameBox";
            this.playerNameBox.Size = new System.Drawing.Size(127, 20);
            this.playerNameBox.TabIndex = 10;
            this.playerNameBox.Text = "Enter username:";
            // 
            // timeLengthBox
            // 
            this.timeLengthBox.Location = new System.Drawing.Point(22, 132);
            this.timeLengthBox.Name = "timeLengthBox";
            this.timeLengthBox.Size = new System.Drawing.Size(128, 20);
            this.timeLengthBox.TabIndex = 11;
            // 
            // timeBoxLabel
            // 
            this.timeBoxLabel.AutoSize = true;
            this.timeBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeBoxLabel.Location = new System.Drawing.Point(23, 108);
            this.timeBoxLabel.Name = "timeBoxLabel";
            this.timeBoxLabel.Size = new System.Drawing.Size(130, 20);
            this.timeBoxLabel.TabIndex = 12;
            this.timeBoxLabel.Text = "Desired duration:";
            // 
            // Player1NameBox
            // 
            this.Player1NameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Player1NameBox.Location = new System.Drawing.Point(476, 42);
            this.Player1NameBox.Name = "Player1NameBox";
            this.Player1NameBox.ReadOnly = true;
            this.Player1NameBox.Size = new System.Drawing.Size(175, 20);
            this.Player1NameBox.TabIndex = 13;
            // 
            // Player2NameBox
            // 
            this.Player2NameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Player2NameBox.Location = new System.Drawing.Point(734, 43);
            this.Player2NameBox.Name = "Player2NameBox";
            this.Player2NameBox.ReadOnly = true;
            this.Player2NameBox.Size = new System.Drawing.Size(172, 20);
            this.Player2NameBox.TabIndex = 14;
            // 
            // Player1ScoreBox
            // 
            this.Player1ScoreBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Player1ScoreBox.Location = new System.Drawing.Point(476, 77);
            this.Player1ScoreBox.Name = "Player1ScoreBox";
            this.Player1ScoreBox.ReadOnly = true;
            this.Player1ScoreBox.Size = new System.Drawing.Size(175, 20);
            this.Player1ScoreBox.TabIndex = 15;
            // 
            // Player2ScoreBox
            // 
            this.Player2ScoreBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Player2ScoreBox.Location = new System.Drawing.Point(734, 77);
            this.Player2ScoreBox.Name = "Player2ScoreBox";
            this.Player2ScoreBox.ReadOnly = true;
            this.Player2ScoreBox.Size = new System.Drawing.Size(172, 20);
            this.Player2ScoreBox.TabIndex = 16;
            // 
            // Player1NameLabel
            // 
            this.Player1NameLabel.AutoSize = true;
            this.Player1NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1NameLabel.Location = new System.Drawing.Point(407, 42);
            this.Player1NameLabel.Name = "Player1NameLabel";
            this.Player1NameLabel.Size = new System.Drawing.Size(69, 20);
            this.Player1NameLabel.TabIndex = 17;
            this.Player1NameLabel.Text = "Player 1:";
            // 
            // Player1ScoreLabel
            // 
            this.Player1ScoreLabel.AutoSize = true;
            this.Player1ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1ScoreLabel.Location = new System.Drawing.Point(421, 75);
            this.Player1ScoreLabel.Name = "Player1ScoreLabel";
            this.Player1ScoreLabel.Size = new System.Drawing.Size(55, 20);
            this.Player1ScoreLabel.TabIndex = 18;
            this.Player1ScoreLabel.Text = "Score:";
            // 
            // Player2NameLabel
            // 
            this.Player2NameLabel.AutoSize = true;
            this.Player2NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2NameLabel.Location = new System.Drawing.Point(659, 42);
            this.Player2NameLabel.Name = "Player2NameLabel";
            this.Player2NameLabel.Size = new System.Drawing.Size(69, 20);
            this.Player2NameLabel.TabIndex = 19;
            this.Player2NameLabel.Text = "Player 2:";
            // 
            // Player2ScoreLabel
            // 
            this.Player2ScoreLabel.AutoSize = true;
            this.Player2ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2ScoreLabel.Location = new System.Drawing.Point(673, 77);
            this.Player2ScoreLabel.Name = "Player2ScoreLabel";
            this.Player2ScoreLabel.Size = new System.Drawing.Size(55, 20);
            this.Player2ScoreLabel.TabIndex = 20;
            this.Player2ScoreLabel.Text = "Score:";
            // 
            // Player1WordList
            // 
            this.Player1WordList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Player1WordList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1WordList.Location = new System.Drawing.Point(476, 112);
            this.Player1WordList.Name = "Player1WordList";
            this.Player1WordList.ReadOnly = true;
            this.Player1WordList.Size = new System.Drawing.Size(175, 462);
            this.Player1WordList.TabIndex = 21;
            this.Player1WordList.Text = "";
            // 
            // Player2WordsList
            // 
            this.Player2WordsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Player2WordsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2WordsList.Location = new System.Drawing.Point(734, 110);
            this.Player2WordsList.Name = "Player2WordsList";
            this.Player2WordsList.ReadOnly = true;
            this.Player2WordsList.Size = new System.Drawing.Size(172, 464);
            this.Player2WordsList.TabIndex = 22;
            this.Player2WordsList.Text = "";
            // 
            // Player1WordLabel
            // 
            this.Player1WordLabel.AutoSize = true;
            this.Player1WordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1WordLabel.Location = new System.Drawing.Point(417, 108);
            this.Player1WordLabel.Name = "Player1WordLabel";
            this.Player1WordLabel.Size = new System.Drawing.Size(59, 20);
            this.Player1WordLabel.TabIndex = 23;
            this.Player1WordLabel.Text = "Words:";
            // 
            // Player2WordLabel
            // 
            this.Player2WordLabel.AutoSize = true;
            this.Player2WordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2WordLabel.Location = new System.Drawing.Point(669, 108);
            this.Player2WordLabel.Name = "Player2WordLabel";
            this.Player2WordLabel.Size = new System.Drawing.Size(59, 20);
            this.Player2WordLabel.TabIndex = 24;
            this.Player2WordLabel.Text = "Words:";
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(204, 24);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(127, 20);
            this.timerLabel.TabIndex = 25;
            this.timerLabel.Text = "Time Remaining:";
            // 
            // timerDisplayBox
            // 
            this.timerDisplayBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.timerDisplayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerDisplayBox.Location = new System.Drawing.Point(208, 47);
            this.timerDisplayBox.Name = "timerDisplayBox";
            this.timerDisplayBox.ReadOnly = true;
            this.timerDisplayBox.Size = new System.Drawing.Size(170, 37);
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
            this.statusLabel.Location = new System.Drawing.Point(706, 3);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(61, 18);
            this.statusLabel.TabIndex = 27;
            this.statusLabel.Text = "Status:";
            // 
            // statusBox
            // 
            this.statusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBox.ForeColor = System.Drawing.Color.Red;
            this.statusBox.Location = new System.Drawing.Point(773, 2);
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.Size = new System.Drawing.Size(133, 22);
            this.statusBox.TabIndex = 28;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.Cell2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cell1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cell3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cell4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cell5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Cell6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Cell7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Cell8, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Cell9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Cell10, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Cell11, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Cell12, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Cell13, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Cell14, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Cell15, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.Cell16, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 218);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(356, 356);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // Cell2
            // 
            this.Cell2.AutoSize = true;
            this.Cell2.BackColor = System.Drawing.SystemColors.Control;
            this.Cell2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell2.Location = new System.Drawing.Point(92, 0);
            this.Cell2.Name = "Cell2";
            this.Cell2.Size = new System.Drawing.Size(83, 89);
            this.Cell2.TabIndex = 0;
            this.Cell2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell1
            // 
            this.Cell1.AutoSize = true;
            this.Cell1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell1.Location = new System.Drawing.Point(3, 0);
            this.Cell1.Name = "Cell1";
            this.Cell1.Size = new System.Drawing.Size(83, 89);
            this.Cell1.TabIndex = 1;
            this.Cell1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell3
            // 
            this.Cell3.AutoSize = true;
            this.Cell3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell3.Location = new System.Drawing.Point(181, 0);
            this.Cell3.Name = "Cell3";
            this.Cell3.Size = new System.Drawing.Size(83, 89);
            this.Cell3.TabIndex = 2;
            this.Cell3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell4
            // 
            this.Cell4.AutoSize = true;
            this.Cell4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell4.Location = new System.Drawing.Point(270, 0);
            this.Cell4.Name = "Cell4";
            this.Cell4.Size = new System.Drawing.Size(83, 89);
            this.Cell4.TabIndex = 3;
            this.Cell4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell5
            // 
            this.Cell5.AutoSize = true;
            this.Cell5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell5.Location = new System.Drawing.Point(3, 89);
            this.Cell5.Name = "Cell5";
            this.Cell5.Size = new System.Drawing.Size(83, 89);
            this.Cell5.TabIndex = 4;
            this.Cell5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell6
            // 
            this.Cell6.AutoSize = true;
            this.Cell6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell6.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell6.Location = new System.Drawing.Point(92, 89);
            this.Cell6.Name = "Cell6";
            this.Cell6.Size = new System.Drawing.Size(83, 89);
            this.Cell6.TabIndex = 5;
            this.Cell6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell7
            // 
            this.Cell7.AutoSize = true;
            this.Cell7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell7.Location = new System.Drawing.Point(181, 89);
            this.Cell7.Name = "Cell7";
            this.Cell7.Size = new System.Drawing.Size(83, 89);
            this.Cell7.TabIndex = 6;
            this.Cell7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell8
            // 
            this.Cell8.AutoSize = true;
            this.Cell8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell8.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell8.Location = new System.Drawing.Point(270, 89);
            this.Cell8.Name = "Cell8";
            this.Cell8.Size = new System.Drawing.Size(83, 89);
            this.Cell8.TabIndex = 7;
            this.Cell8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell9
            // 
            this.Cell9.AutoSize = true;
            this.Cell9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell9.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell9.Location = new System.Drawing.Point(3, 178);
            this.Cell9.Name = "Cell9";
            this.Cell9.Size = new System.Drawing.Size(83, 89);
            this.Cell9.TabIndex = 8;
            this.Cell9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell10
            // 
            this.Cell10.AutoSize = true;
            this.Cell10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell10.Location = new System.Drawing.Point(92, 178);
            this.Cell10.Name = "Cell10";
            this.Cell10.Size = new System.Drawing.Size(83, 89);
            this.Cell10.TabIndex = 9;
            this.Cell10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell11
            // 
            this.Cell11.AutoSize = true;
            this.Cell11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell11.Location = new System.Drawing.Point(181, 178);
            this.Cell11.Name = "Cell11";
            this.Cell11.Size = new System.Drawing.Size(83, 89);
            this.Cell11.TabIndex = 10;
            this.Cell11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell12
            // 
            this.Cell12.AutoSize = true;
            this.Cell12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell12.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell12.Location = new System.Drawing.Point(270, 178);
            this.Cell12.Name = "Cell12";
            this.Cell12.Size = new System.Drawing.Size(83, 89);
            this.Cell12.TabIndex = 11;
            this.Cell12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell13
            // 
            this.Cell13.AutoSize = true;
            this.Cell13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell13.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell13.Location = new System.Drawing.Point(3, 267);
            this.Cell13.Name = "Cell13";
            this.Cell13.Size = new System.Drawing.Size(83, 89);
            this.Cell13.TabIndex = 12;
            this.Cell13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell14
            // 
            this.Cell14.AutoSize = true;
            this.Cell14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell14.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell14.Location = new System.Drawing.Point(92, 267);
            this.Cell14.Name = "Cell14";
            this.Cell14.Size = new System.Drawing.Size(83, 89);
            this.Cell14.TabIndex = 13;
            this.Cell14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell15
            // 
            this.Cell15.AutoSize = true;
            this.Cell15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell15.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell15.Location = new System.Drawing.Point(181, 267);
            this.Cell15.Name = "Cell15";
            this.Cell15.Size = new System.Drawing.Size(83, 89);
            this.Cell15.TabIndex = 14;
            this.Cell15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cell16
            // 
            this.Cell16.AutoSize = true;
            this.Cell16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cell16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cell16.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cell16.Location = new System.Drawing.Point(270, 267);
            this.Cell16.Name = "Cell16";
            this.Cell16.Size = new System.Drawing.Size(83, 89);
            this.Cell16.TabIndex = 15;
            this.Cell16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BoggleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(964, 596);
            this.Controls.Add(this.tableLayoutPanel1);
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BoggleWindow";
            this.Text = "Boggle";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem FileButton;
        private System.Windows.Forms.ToolStripMenuItem CloseButton;
        private System.Windows.Forms.ToolStripMenuItem HelpButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
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
        private System.Windows.Forms.ToolStripMenuItem howToStart;
        private System.Windows.Forms.ToolStripMenuItem gameRules;
        private System.Windows.Forms.ToolStripMenuItem cheatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cheatSlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cheatWindowToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ToolStripMenuItem cheatEthicallyToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Cell2;
        private System.Windows.Forms.Label Cell1;
        private System.Windows.Forms.Label Cell3;
        private System.Windows.Forms.Label Cell4;
        private System.Windows.Forms.Label Cell5;
        private System.Windows.Forms.Label Cell6;
        private System.Windows.Forms.Label Cell7;
        private System.Windows.Forms.Label Cell8;
        private System.Windows.Forms.Label Cell9;
        private System.Windows.Forms.Label Cell10;
        private System.Windows.Forms.Label Cell11;
        private System.Windows.Forms.Label Cell12;
        private System.Windows.Forms.Label Cell13;
        private System.Windows.Forms.Label Cell14;
        private System.Windows.Forms.Label Cell15;
        private System.Windows.Forms.Label Cell16;
    }
}

