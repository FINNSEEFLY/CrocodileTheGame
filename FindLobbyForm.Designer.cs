namespace CrocodileTheGame
{
    partial class FindLobbyForm
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.ltLobby = new System.Windows.Forms.ListBox();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblServerLIst = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdate.Location = new System.Drawing.Point(0, 363);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(344, 36);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ltLobby
            // 
            this.ltLobby.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltLobby.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ltLobby.FormattingEnabled = true;
            this.ltLobby.ItemHeight = 22;
            this.ltLobby.Location = new System.Drawing.Point(0, 39);
            this.ltLobby.Name = "ltLobby";
            this.ltLobby.Size = new System.Drawing.Size(344, 360);
            this.ltLobby.TabIndex = 8;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.SystemColors.Window;
            this.pnlInfo.Controls.Add(this.lblServerLIst);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(344, 39);
            this.pnlInfo.TabIndex = 7;
            // 
            // lblServerLIst
            // 
            this.lblServerLIst.AutoSize = true;
            this.lblServerLIst.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblServerLIst.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblServerLIst.Location = new System.Drawing.Point(90, 5);
            this.lblServerLIst.Name = "lblServerLIst";
            this.lblServerLIst.Size = new System.Drawing.Size(154, 28);
            this.lblServerLIst.TabIndex = 0;
            this.lblServerLIst.Text = "Список лобби";
            // 
            // btnConnect
            // 
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnect.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConnect.Location = new System.Drawing.Point(0, 399);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(344, 36);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Присоединиться к игре";
            this.btnConnect.UseVisualStyleBackColor = true;
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
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FindLobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 471);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.ltLobby);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnExit);
            this.MaximumSize = new System.Drawing.Size(360, 510);
            this.MinimumSize = new System.Drawing.Size(360, 510);
            this.Name = "FindLobbyForm";
            this.Text = "Поиск лобби";
            this.Load += new System.EventHandler(this.FindLobbyForm_Load);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListBox ltLobby;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblServerLIst;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnExit;
    }
}