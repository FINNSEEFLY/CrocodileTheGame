namespace CrocodileTheGame
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.lblRadius = new System.Windows.Forms.Label();
            this.tbRadius = new System.Windows.Forms.TrackBar();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnBlack = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblLeader = new System.Windows.Forms.Label();
            this.lblLeaderName = new System.Windows.Forms.Label();
            this.pnlPlayersText = new System.Windows.Forms.Panel();
            this.pnlPlayers = new System.Windows.Forms.Panel();
            this.ltPlayers = new System.Windows.Forms.ListBox();
            this.lbPlayers = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRadius)).BeginInit();
            this.pnlCanvas.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlPlayersText.SuspendLayout();
            this.pnlPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCanvas.Location = new System.Drawing.Point(0, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(896, 591);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlInfo);
            this.panel1.Controls.Add(this.txtChat);
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(896, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 661);
            this.panel1.TabIndex = 1;
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.SystemColors.Window;
            this.txtChat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtChat.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtChat.Location = new System.Drawing.Point(0, 264);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.Size = new System.Drawing.Size(238, 302);
            this.txtChat.TabIndex = 9;
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtInput.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInput.Location = new System.Drawing.Point(0, 566);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(238, 25);
            this.txtInput.TabIndex = 8;
            // 
            // btnSend
            // 
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSend.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSend.Location = new System.Drawing.Point(0, 591);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(238, 35);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExit.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(0, 626);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(238, 35);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // pnlTools
            // 
            this.pnlTools.Controls.Add(this.lblRadius);
            this.pnlTools.Controls.Add(this.tbRadius);
            this.pnlTools.Controls.Add(this.btnClear);
            this.pnlTools.Controls.Add(this.btnFill);
            this.pnlTools.Controls.Add(this.btnBlue);
            this.pnlTools.Controls.Add(this.btnGreen);
            this.pnlTools.Controls.Add(this.btnRed);
            this.pnlTools.Controls.Add(this.btnBlack);
            this.pnlTools.Controls.Add(this.btnColor);
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTools.Location = new System.Drawing.Point(0, 591);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(896, 70);
            this.pnlTools.TabIndex = 2;
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.BackColor = System.Drawing.Color.Transparent;
            this.lblRadius.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRadius.Location = new System.Drawing.Point(774, 40);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(88, 17);
            this.lblRadius.TabIndex = 8;
            this.lblRadius.Text = "Размер кисти";
            // 
            // tbRadius
            // 
            this.tbRadius.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbRadius.LargeChange = 1;
            this.tbRadius.Location = new System.Drawing.Point(760, 10);
            this.tbRadius.Minimum = 1;
            this.tbRadius.Name = "tbRadius";
            this.tbRadius.Size = new System.Drawing.Size(114, 45);
            this.tbRadius.TabIndex = 7;
            this.tbRadius.Value = 5;
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClear.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.Location = new System.Drawing.Point(590, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 50);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Очистить холст";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnFill
            // 
            this.btnFill.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFill.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFill.Location = new System.Drawing.Point(420, 10);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(140, 50);
            this.btnFill.TabIndex = 5;
            this.btnFill.Text = "Залить цветом";
            this.btnFill.UseVisualStyleBackColor = true;
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBlue.Location = new System.Drawing.Point(340, 10);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(50, 50);
            this.btnBlue.TabIndex = 4;
            this.btnBlue.UseVisualStyleBackColor = false;
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Lime;
            this.btnGreen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGreen.Location = new System.Drawing.Point(260, 10);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(50, 50);
            this.btnGreen.TabIndex = 3;
            this.btnGreen.UseVisualStyleBackColor = false;
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRed.Location = new System.Drawing.Point(180, 10);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(50, 50);
            this.btnRed.TabIndex = 2;
            this.btnRed.UseVisualStyleBackColor = false;
            // 
            // btnBlack
            // 
            this.btnBlack.BackColor = System.Drawing.Color.Black;
            this.btnBlack.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBlack.Location = new System.Drawing.Point(100, 10);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(50, 50);
            this.btnBlack.TabIndex = 1;
            this.btnBlack.UseVisualStyleBackColor = false;
            // 
            // btnColor
            // 
            this.btnColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnColor.BackgroundImage")));
            this.btnColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnColor.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnColor.Image = ((System.Drawing.Image)(resources.GetObject("btnColor.Image")));
            this.btnColor.Location = new System.Drawing.Point(20, 10);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(50, 50);
            this.btnColor.TabIndex = 0;
            this.btnColor.UseVisualStyleBackColor = true;
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.Controls.Add(this.picCanvas);
            this.pnlCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCanvas.Location = new System.Drawing.Point(0, 0);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(896, 591);
            this.pnlCanvas.TabIndex = 3;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblRound);
            this.pnlInfo.Controls.Add(this.pnlPlayersText);
            this.pnlInfo.Controls.Add(this.pnlPlayers);
            this.pnlInfo.Controls.Add(this.lblLeaderName);
            this.pnlInfo.Controls.Add(this.lblLeader);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(238, 264);
            this.pnlInfo.TabIndex = 10;
            // 
            // lblLeader
            // 
            this.lblLeader.AutoSize = true;
            this.lblLeader.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLeader.Location = new System.Drawing.Point(74, 8);
            this.lblLeader.Name = "lblLeader";
            this.lblLeader.Size = new System.Drawing.Size(97, 26);
            this.lblLeader.TabIndex = 0;
            this.lblLeader.Text = "Ведущий";
            // 
            // lblLeaderName
            // 
            this.lblLeaderName.AutoSize = true;
            this.lblLeaderName.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLeaderName.Location = new System.Drawing.Point(80, 43);
            this.lblLeaderName.Name = "lblLeaderName";
            this.lblLeaderName.Size = new System.Drawing.Size(84, 20);
            this.lblLeaderName.TabIndex = 1;
            this.lblLeaderName.Text = "Ведущий";
            // 
            // pnlPlayersText
            // 
            this.pnlPlayersText.Controls.Add(this.lbPlayers);
            this.pnlPlayersText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPlayersText.Location = new System.Drawing.Point(0, 121);
            this.pnlPlayersText.Name = "pnlPlayersText";
            this.pnlPlayersText.Size = new System.Drawing.Size(238, 35);
            this.pnlPlayersText.TabIndex = 3;
            // 
            // pnlPlayers
            // 
            this.pnlPlayers.Controls.Add(this.ltPlayers);
            this.pnlPlayers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPlayers.Location = new System.Drawing.Point(0, 156);
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.Size = new System.Drawing.Size(238, 108);
            this.pnlPlayers.TabIndex = 4;
            // 
            // ltPlayers
            // 
            this.ltPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltPlayers.FormattingEnabled = true;
            this.ltPlayers.Location = new System.Drawing.Point(0, 0);
            this.ltPlayers.Name = "ltPlayers";
            this.ltPlayers.Size = new System.Drawing.Size(238, 108);
            this.ltPlayers.TabIndex = 3;
            // 
            // lbPlayers
            // 
            this.lbPlayers.AutoSize = true;
            this.lbPlayers.Font = new System.Drawing.Font("Open Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPlayers.Location = new System.Drawing.Point(87, 5);
            this.lbPlayers.Name = "lbPlayers";
            this.lbPlayers.Size = new System.Drawing.Size(70, 23);
            this.lbPlayers.TabIndex = 1;
            this.lbPlayers.Text = "Игроки";
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRound.Location = new System.Drawing.Point(52, 77);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(72, 26);
            this.lblRound.TabIndex = 5;
            this.lblRound.Text = "Раунд:";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1134, 661);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.pnlTools);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1150, 700);
            this.MinimumSize = new System.Drawing.Size(1150, 700);
            this.Name = "GameForm";
            this.Text = "Игра";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRadius)).EndInit();
            this.pnlCanvas.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlPlayersText.ResumeLayout(false);
            this.pnlPlayersText.PerformLayout();
            this.pnlPlayers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel pnlTools;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.TrackBar tbRadius;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Panel pnlPlayersText;
        private System.Windows.Forms.Label lbPlayers;
        private System.Windows.Forms.Panel pnlPlayers;
        private System.Windows.Forms.ListBox ltPlayers;
        private System.Windows.Forms.Label lblLeaderName;
        private System.Windows.Forms.Label lblLeader;
    }
}