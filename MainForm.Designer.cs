namespace CrocodileTheGame
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCreateLobby = new System.Windows.Forms.Button();
            this.btnConnectToLobby = new System.Windows.Forms.Button();
            this.btnPackCreator = new System.Windows.Forms.Button();
            this.btnAboutProgramm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblNickname = new System.Windows.Forms.Label();
            this.tbNickName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateLobby
            // 
            this.btnCreateLobby.BackColor = System.Drawing.SystemColors.Control;
            this.btnCreateLobby.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCreateLobby.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreateLobby.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateLobby.Location = new System.Drawing.Point(235, 105);
            this.btnCreateLobby.Name = "btnCreateLobby";
            this.btnCreateLobby.Size = new System.Drawing.Size(430, 50);
            this.btnCreateLobby.TabIndex = 0;
            this.btnCreateLobby.Text = "Создать лобби";
            this.btnCreateLobby.UseVisualStyleBackColor = false;
            this.btnCreateLobby.Click += new System.EventHandler(this.btnCreateLobby_Click);
            // 
            // btnConnectToLobby
            // 
            this.btnConnectToLobby.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnConnectToLobby.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnectToLobby.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConnectToLobby.Location = new System.Drawing.Point(235, 185);
            this.btnConnectToLobby.Name = "btnConnectToLobby";
            this.btnConnectToLobby.Size = new System.Drawing.Size(430, 50);
            this.btnConnectToLobby.TabIndex = 1;
            this.btnConnectToLobby.Text = "Подключиться к лобби";
            this.btnConnectToLobby.UseVisualStyleBackColor = true;
            this.btnConnectToLobby.Click += new System.EventHandler(this.btnConnectToLobby_Click);
            // 
            // btnPackCreator
            // 
            this.btnPackCreator.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPackCreator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPackCreator.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPackCreator.Location = new System.Drawing.Point(235, 265);
            this.btnPackCreator.Name = "btnPackCreator";
            this.btnPackCreator.Size = new System.Drawing.Size(430, 50);
            this.btnPackCreator.TabIndex = 2;
            this.btnPackCreator.Text = "Создатель паков";
            this.btnPackCreator.UseVisualStyleBackColor = true;
            this.btnPackCreator.Click += new System.EventHandler(this.btnPackCreator_Click);
            // 
            // btnAboutProgramm
            // 
            this.btnAboutProgramm.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAboutProgramm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAboutProgramm.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAboutProgramm.Location = new System.Drawing.Point(235, 345);
            this.btnAboutProgramm.Name = "btnAboutProgramm";
            this.btnAboutProgramm.Size = new System.Drawing.Size(430, 50);
            this.btnAboutProgramm.TabIndex = 3;
            this.btnAboutProgramm.Text = "О программе";
            this.btnAboutProgramm.UseVisualStyleBackColor = true;
            this.btnAboutProgramm.Click += new System.EventHandler(this.btnAboutProgramm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExit.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(235, 425);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(430, 50);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.BackColor = System.Drawing.Color.Transparent;
            this.lblNickname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNickname.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNickname.Location = new System.Drawing.Point(395, 20);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(111, 20);
            this.lblNickname.TabIndex = 5;
            this.lblNickname.Text = "Ваш никнейм";
            // 
            // tbNickName
            // 
            this.tbNickName.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNickName.Location = new System.Drawing.Point(235, 55);
            this.tbNickName.MaxLength = 255;
            this.tbNickName.Name = "tbNickName";
            this.tbNickName.Size = new System.Drawing.Size(430, 28);
            this.tbNickName.TabIndex = 6;
            this.tbNickName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(899, 506);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(899, 506);
            this.Controls.Add(this.tbNickName);
            this.Controls.Add(this.lblNickname);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAboutProgramm);
            this.Controls.Add(this.btnPackCreator);
            this.Controls.Add(this.btnConnectToLobby);
            this.Controls.Add(this.btnCreateLobby);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(915, 545);
            this.MinimumSize = new System.Drawing.Size(915, 545);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crocodile The Game";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateLobby;
        private System.Windows.Forms.Button btnConnectToLobby;
        private System.Windows.Forms.Button btnPackCreator;
        private System.Windows.Forms.Button btnAboutProgramm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.TextBox tbNickName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

