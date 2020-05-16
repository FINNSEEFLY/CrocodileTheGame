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
            this.lbPlayers = new System.Windows.Forms.ListBox();
            this.btnKick = new System.Windows.Forms.Button();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExit.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(0, 435);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(344, 36);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStartGame.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartGame.Location = new System.Drawing.Point(0, 399);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(344, 36);
            this.btnStartGame.TabIndex = 1;
            this.btnStartGame.Text = "Запустить игру";
            this.btnStartGame.UseVisualStyleBackColor = true;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblListOfPlayers);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(344, 39);
            this.pnlInfo.TabIndex = 2;
            // 
            // lblListOfPlayers
            // 
            this.lblListOfPlayers.AutoSize = true;
            this.lblListOfPlayers.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblListOfPlayers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblListOfPlayers.Location = new System.Drawing.Point(90, 5);
            this.lblListOfPlayers.Name = "lblListOfPlayers";
            this.lblListOfPlayers.Size = new System.Drawing.Size(174, 28);
            this.lblListOfPlayers.TabIndex = 0;
            this.lblListOfPlayers.Text = "Список игроков";
            // 
            // lbPlayers
            // 
            this.lbPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPlayers.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPlayers.FormattingEnabled = true;
            this.lbPlayers.ItemHeight = 22;
            this.lbPlayers.Location = new System.Drawing.Point(0, 39);
            this.lbPlayers.Name = "lbPlayers";
            this.lbPlayers.Size = new System.Drawing.Size(344, 360);
            this.lbPlayers.TabIndex = 3;
            // 
            // btnKick
            // 
            this.btnKick.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKick.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnKick.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKick.Location = new System.Drawing.Point(0, 363);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(344, 36);
            this.btnKick.TabIndex = 4;
            this.btnKick.Text = "Выгнать игрока";
            this.btnKick.UseVisualStyleBackColor = true;
            // 
            // HostLobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(344, 471);
            this.Controls.Add(this.btnKick);
            this.Controls.Add(this.lbPlayers);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.btnExit);
            this.MaximumSize = new System.Drawing.Size(360, 510);
            this.MinimumSize = new System.Drawing.Size(360, 510);
            this.Name = "HostLobbyForm";
            this.Text = "Лобби (Создатель)";
            this.Load += new System.EventHandler(this.HostLobbyForm_Load);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblListOfPlayers;
        private System.Windows.Forms.ListBox lbPlayers;
        private System.Windows.Forms.Button btnKick;
    }
}