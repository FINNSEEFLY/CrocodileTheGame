namespace CrocodileTheGame
{
    partial class HostLobbyForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblListOfPlayers = new System.Windows.Forms.Label();
            this.ltPlayers = new System.Windows.Forms.ListBox();
            this.btnKick = new System.Windows.Forms.Button();
            this.btnLoadPack = new System.Windows.Forms.Button();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbPack = new System.Windows.Forms.TextBox();
            this.lblNumOfRounds = new System.Windows.Forms.Label();
            this.tbNumOfRounds = new System.Windows.Forms.TextBox();
            this.lblPackName = new System.Windows.Forms.Label();
            this.pnlPlayers = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnlInfo.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExit.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(0, 244);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(339, 36);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStartGame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStartGame.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartGame.Location = new System.Drawing.Point(0, 208);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(339, 36);
            this.btnStartGame.TabIndex = 1;
            this.btnStartGame.Text = "Запустить игру";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblListOfPlayers);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(339, 39);
            this.pnlInfo.TabIndex = 2;
            // 
            // lblListOfPlayers
            // 
            this.lblListOfPlayers.AutoSize = true;
            this.lblListOfPlayers.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblListOfPlayers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblListOfPlayers.Location = new System.Drawing.Point(87, 4);
            this.lblListOfPlayers.Name = "lblListOfPlayers";
            this.lblListOfPlayers.Size = new System.Drawing.Size(174, 28);
            this.lblListOfPlayers.TabIndex = 0;
            this.lblListOfPlayers.Text = "Список игроков";
            // 
            // ltPlayers
            // 
            this.ltPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltPlayers.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ltPlayers.FormattingEnabled = true;
            this.ltPlayers.ItemHeight = 22;
            this.ltPlayers.Location = new System.Drawing.Point(0, 39);
            this.ltPlayers.Name = "ltPlayers";
            this.ltPlayers.Size = new System.Drawing.Size(339, 335);
            this.ltPlayers.TabIndex = 3;
            // 
            // btnKick
            // 
            this.btnKick.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnKick.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKick.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnKick.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKick.Location = new System.Drawing.Point(0, 172);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(339, 36);
            this.btnKick.TabIndex = 4;
            this.btnKick.Text = "Выгнать игрока";
            this.btnKick.UseVisualStyleBackColor = true;
            this.btnKick.Click += new System.EventHandler(this.btnKick_Click);
            // 
            // btnLoadPack
            // 
            this.btnLoadPack.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLoadPack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLoadPack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLoadPack.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadPack.Location = new System.Drawing.Point(0, 136);
            this.btnLoadPack.Name = "btnLoadPack";
            this.btnLoadPack.Size = new System.Drawing.Size(339, 36);
            this.btnLoadPack.TabIndex = 5;
            this.btnLoadPack.Text = "Загрузить комплект слов";
            this.btnLoadPack.UseVisualStyleBackColor = true;
            this.btnLoadPack.Click += new System.EventHandler(this.btnLoadPack_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.panel1);
            this.pnlControl.Controls.Add(this.btnLoadPack);
            this.pnlControl.Controls.Add(this.btnKick);
            this.pnlControl.Controls.Add(this.btnStartGame);
            this.pnlControl.Controls.Add(this.btnExit);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 374);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(339, 280);
            this.pnlControl.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbPack);
            this.panel1.Controls.Add(this.lblNumOfRounds);
            this.panel1.Controls.Add(this.tbNumOfRounds);
            this.panel1.Controls.Add(this.lblPackName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 136);
            this.panel1.TabIndex = 12;
            // 
            // tbPack
            // 
            this.tbPack.BackColor = System.Drawing.SystemColors.Window;
            this.tbPack.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPack.Location = new System.Drawing.Point(32, 100);
            this.tbPack.Name = "tbPack";
            this.tbPack.ReadOnly = true;
            this.tbPack.Size = new System.Drawing.Size(281, 25);
            this.tbPack.TabIndex = 10;
            this.tbPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNumOfRounds
            // 
            this.lblNumOfRounds.AutoSize = true;
            this.lblNumOfRounds.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumOfRounds.Location = new System.Drawing.Point(88, 12);
            this.lblNumOfRounds.Name = "lblNumOfRounds";
            this.lblNumOfRounds.Size = new System.Drawing.Size(171, 22);
            this.lblNumOfRounds.TabIndex = 6;
            this.lblNumOfRounds.Text = "Количество раундов";
            // 
            // tbNumOfRounds
            // 
            this.tbNumOfRounds.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNumOfRounds.Location = new System.Drawing.Point(33, 37);
            this.tbNumOfRounds.MaxLength = 3;
            this.tbNumOfRounds.Name = "tbNumOfRounds";
            this.tbNumOfRounds.Size = new System.Drawing.Size(281, 25);
            this.tbNumOfRounds.TabIndex = 7;
            this.tbNumOfRounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPackName
            // 
            this.lblPackName.AutoSize = true;
            this.lblPackName.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPackName.Location = new System.Drawing.Point(66, 75);
            this.lblPackName.Name = "lblPackName";
            this.lblPackName.Size = new System.Drawing.Size(212, 22);
            this.lblPackName.TabIndex = 9;
            this.lblPackName.Text = "Название комплекта слов";
            // 
            // pnlPlayers
            // 
            this.pnlPlayers.Controls.Add(this.ltPlayers);
            this.pnlPlayers.Controls.Add(this.pnlInfo);
            this.pnlPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayers.Location = new System.Drawing.Point(0, 0);
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.Size = new System.Drawing.Size(339, 374);
            this.pnlPlayers.TabIndex = 7;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "wrdpack";
            // 
            // HostLobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(339, 654);
            this.Controls.Add(this.pnlPlayers);
            this.Controls.Add(this.pnlControl);
            this.MaximumSize = new System.Drawing.Size(355, 693);
            this.MinimumSize = new System.Drawing.Size(355, 693);
            this.Name = "HostLobbyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лобби (Создатель)";
            this.Load += new System.EventHandler(this.LobbyHostForm_Load);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlPlayers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblListOfPlayers;
        private System.Windows.Forms.ListBox ltPlayers;
        private System.Windows.Forms.Button btnKick;
        private System.Windows.Forms.Button btnLoadPack;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Label lblNumOfRounds;
        private System.Windows.Forms.Panel pnlPlayers;
        private System.Windows.Forms.TextBox tbPack;
        private System.Windows.Forms.Label lblPackName;
        private System.Windows.Forms.TextBox tbNumOfRounds;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}