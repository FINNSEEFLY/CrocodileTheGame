namespace CrocodileTheGame
{
    partial class LobbyPlayerForm
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblListOfPlayers = new System.Windows.Forms.Label();
            this.ltPlayers = new System.Windows.Forms.ListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblListOfPlayers);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(344, 39);
            this.pnlInfo.TabIndex = 3;
            // 
            // lblListOfPlayers
            // 
            this.lblListOfPlayers.AutoSize = true;
            this.lblListOfPlayers.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblListOfPlayers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblListOfPlayers.Location = new System.Drawing.Point(90, 5);
            this.lblListOfPlayers.Name = "lblListOfPlayers";
            this.lblListOfPlayers.Size = new System.Drawing.Size(174, 28);
            this.lblListOfPlayers.TabIndex = 1;
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
            this.ltPlayers.Size = new System.Drawing.Size(344, 396);
            this.ltPlayers.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExit.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(0, 435);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(344, 36);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // LobbyPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(344, 471);
            this.Controls.Add(this.ltPlayers);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnlInfo);
            this.MaximumSize = new System.Drawing.Size(360, 510);
            this.MinimumSize = new System.Drawing.Size(360, 510);
            this.Name = "LobbyPlayerForm";
            this.Text = "Лобби";
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.ListBox ltPlayers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblListOfPlayers;
    }
}