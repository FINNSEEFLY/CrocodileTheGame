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
            this.pnlRightSide = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblRound = new System.Windows.Forms.Label();
            this.pnlPlayersText = new System.Windows.Forms.Panel();
            this.lbPlayers = new System.Windows.Forms.Label();
            this.pnlPlayers = new System.Windows.Forms.Panel();
            this.ltPlayers = new System.Windows.Forms.ListBox();
            this.lblLeader = new System.Windows.Forms.Label();
            this.tbChat = new System.Windows.Forms.TextBox();
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
            this.tbLeader = new System.Windows.Forms.TextBox();
            this.tbRound = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.pnlRightSide.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlPlayersText.SuspendLayout();
            this.pnlPlayers.SuspendLayout();
            this.pnlTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRadius)).BeginInit();
            this.pnlCanvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCanvas.Location = new System.Drawing.Point(0, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(893, 591);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // pnlRightSide
            // 
            this.pnlRightSide.Controls.Add(this.pnlInfo);
            this.pnlRightSide.Controls.Add(this.tbChat);
            this.pnlRightSide.Controls.Add(this.txtInput);
            this.pnlRightSide.Controls.Add(this.btnSend);
            this.pnlRightSide.Controls.Add(this.btnExit);
            this.pnlRightSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightSide.Location = new System.Drawing.Point(893, 0);
            this.pnlRightSide.Name = "pnlRightSide";
            this.pnlRightSide.Size = new System.Drawing.Size(241, 661);
            this.pnlRightSide.TabIndex = 1;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.tbRound);
            this.pnlInfo.Controls.Add(this.tbLeader);
            this.pnlInfo.Controls.Add(this.lblRound);
            this.pnlInfo.Controls.Add(this.pnlPlayersText);
            this.pnlInfo.Controls.Add(this.pnlPlayers);
            this.pnlInfo.Controls.Add(this.lblLeader);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(241, 283);
            this.pnlInfo.TabIndex = 10;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRound.Location = new System.Drawing.Point(85, 68);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(72, 26);
            this.lblRound.TabIndex = 5;
            this.lblRound.Text = "Раунд:";
            // 
            // pnlPlayersText
            // 
            this.pnlPlayersText.Controls.Add(this.lbPlayers);
            this.pnlPlayersText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPlayersText.Location = new System.Drawing.Point(0, 141);
            this.pnlPlayersText.Name = "pnlPlayersText";
            this.pnlPlayersText.Size = new System.Drawing.Size(241, 34);
            this.pnlPlayersText.TabIndex = 3;
            // 
            // lbPlayers
            // 
            this.lbPlayers.AutoSize = true;
            this.lbPlayers.Font = new System.Drawing.Font("Open Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPlayers.Location = new System.Drawing.Point(86, 5);
            this.lbPlayers.Name = "lbPlayers";
            this.lbPlayers.Size = new System.Drawing.Size(70, 23);
            this.lbPlayers.TabIndex = 1;
            this.lbPlayers.Text = "Игроки";
            // 
            // pnlPlayers
            // 
            this.pnlPlayers.Controls.Add(this.ltPlayers);
            this.pnlPlayers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPlayers.Location = new System.Drawing.Point(0, 175);
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.Size = new System.Drawing.Size(241, 108);
            this.pnlPlayers.TabIndex = 4;
            // 
            // ltPlayers
            // 
            this.ltPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltPlayers.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ltPlayers.FormattingEnabled = true;
            this.ltPlayers.ItemHeight = 18;
            this.ltPlayers.Location = new System.Drawing.Point(0, 0);
            this.ltPlayers.Name = "ltPlayers";
            this.ltPlayers.Size = new System.Drawing.Size(241, 108);
            this.ltPlayers.TabIndex = 3;
            // 
            // lblLeader
            // 
            this.lblLeader.AutoSize = true;
            this.lblLeader.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLeader.Location = new System.Drawing.Point(73, 7);
            this.lblLeader.Name = "lblLeader";
            this.lblLeader.Size = new System.Drawing.Size(97, 26);
            this.lblLeader.TabIndex = 0;
            this.lblLeader.Text = "Ведущий";
            // 
            // tbChat
            // 
            this.tbChat.BackColor = System.Drawing.SystemColors.Window;
            this.tbChat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbChat.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbChat.Location = new System.Drawing.Point(0, 283);
            this.tbChat.Multiline = true;
            this.tbChat.Name = "tbChat";
            this.tbChat.ReadOnly = true;
            this.tbChat.Size = new System.Drawing.Size(241, 283);
            this.tbChat.TabIndex = 9;
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtInput.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInput.Location = new System.Drawing.Point(0, 566);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(241, 25);
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
            this.btnSend.Size = new System.Drawing.Size(241, 35);
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
            this.btnExit.Size = new System.Drawing.Size(241, 35);
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
            this.pnlTools.Size = new System.Drawing.Size(893, 70);
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
            this.pnlCanvas.Size = new System.Drawing.Size(893, 591);
            this.pnlCanvas.TabIndex = 3;
            // 
            // tbLeader
            // 
            this.tbLeader.BackColor = System.Drawing.SystemColors.Window;
            this.tbLeader.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLeader.Location = new System.Drawing.Point(25, 36);
            this.tbLeader.Name = "tbLeader";
            this.tbLeader.ReadOnly = true;
            this.tbLeader.Size = new System.Drawing.Size(193, 25);
            this.tbLeader.TabIndex = 6;
            this.tbLeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRound
            // 
            this.tbRound.BackColor = System.Drawing.SystemColors.Window;
            this.tbRound.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbRound.Location = new System.Drawing.Point(25, 97);
            this.tbRound.Name = "tbRound";
            this.tbRound.ReadOnly = true;
            this.tbRound.Size = new System.Drawing.Size(193, 25);
            this.tbRound.TabIndex = 7;
            this.tbRound.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1134, 661);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.pnlTools);
            this.Controls.Add(this.pnlRightSide);
            this.MaximumSize = new System.Drawing.Size(1150, 700);
            this.MinimumSize = new System.Drawing.Size(1150, 700);
            this.Name = "GameForm";
            this.Text = "Игра";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.pnlRightSide.ResumeLayout(false);
            this.pnlRightSide.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlPlayersText.ResumeLayout(false);
            this.pnlPlayersText.PerformLayout();
            this.pnlPlayers.ResumeLayout(false);
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRadius)).EndInit();
            this.pnlCanvas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Panel pnlRightSide;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox tbChat;
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
        private System.Windows.Forms.Label lblLeader;
        private System.Windows.Forms.TextBox tbLeader;
        private System.Windows.Forms.TextBox tbRound;
    }
}