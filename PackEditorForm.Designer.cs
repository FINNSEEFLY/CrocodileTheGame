namespace CrocodileTheGame
{
    partial class PackEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackEditorForm));
            this.pnlRightSide = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblPackName = new System.Windows.Forms.Label();
            this.tbPackName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblWord = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbWord = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlLeftSide = new System.Windows.Forms.Panel();
            this.ltWords = new System.Windows.Forms.ListBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnlRightSide.SuspendLayout();
            this.pnlLeftSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRightSide
            // 
            this.pnlRightSide.Controls.Add(this.btnDelete);
            this.pnlRightSide.Controls.Add(this.lblPackName);
            this.pnlRightSide.Controls.Add(this.tbPackName);
            this.pnlRightSide.Controls.Add(this.btnCreate);
            this.pnlRightSide.Controls.Add(this.lblWord);
            this.pnlRightSide.Controls.Add(this.btnAdd);
            this.pnlRightSide.Controls.Add(this.tbWord);
            this.pnlRightSide.Controls.Add(this.btnSave);
            this.pnlRightSide.Controls.Add(this.btnLoad);
            this.pnlRightSide.Controls.Add(this.btnExit);
            this.pnlRightSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightSide.Location = new System.Drawing.Point(470, 0);
            this.pnlRightSide.Name = "pnlRightSide";
            this.pnlRightSide.Size = new System.Drawing.Size(194, 451);
            this.pnlRightSide.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.Location = new System.Drawing.Point(21, 126);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblPackName
            // 
            this.lblPackName.AutoSize = true;
            this.lblPackName.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPackName.Location = new System.Drawing.Point(58, 207);
            this.lblPackName.Name = "lblPackName";
            this.lblPackName.Size = new System.Drawing.Size(79, 17);
            this.lblPackName.TabIndex = 13;
            this.lblPackName.Text = "Имя набора";
            // 
            // tbPackName
            // 
            this.tbPackName.Location = new System.Drawing.Point(21, 238);
            this.tbPackName.MaxLength = 255;
            this.tbPackName.Name = "tbPackName";
            this.tbPackName.Size = new System.Drawing.Size(152, 20);
            this.tbPackName.TabIndex = 12;
            this.tbPackName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCreate
            // 
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreate.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreate.Location = new System.Drawing.Point(0, 307);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(194, 36);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWord.Location = new System.Drawing.Point(39, 20);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(119, 17);
            this.lblWord.TabIndex = 9;
            this.lblWord.Text = "Работа со словами";
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(21, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(152, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbWord
            // 
            this.tbWord.Location = new System.Drawing.Point(21, 52);
            this.tbWord.MaxLength = 255;
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(152, 20);
            this.tbWord.TabIndex = 7;
            this.tbWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWord_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(0, 343);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(194, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLoad.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoad.Location = new System.Drawing.Point(0, 379);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(194, 36);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExit.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(0, 415);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(194, 36);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlLeftSide
            // 
            this.pnlLeftSide.Controls.Add(this.ltWords);
            this.pnlLeftSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftSide.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftSide.Name = "pnlLeftSide";
            this.pnlLeftSide.Size = new System.Drawing.Size(470, 451);
            this.pnlLeftSide.TabIndex = 1;
            // 
            // ltWords
            // 
            this.ltWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltWords.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ltWords.FormattingEnabled = true;
            this.ltWords.ItemHeight = 22;
            this.ltWords.Location = new System.Drawing.Point(0, 0);
            this.ltWords.Name = "ltWords";
            this.ltWords.Size = new System.Drawing.Size(470, 451);
            this.ltWords.TabIndex = 2;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "wrdpack";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "wrdpack";
            // 
            // PackEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(664, 451);
            this.Controls.Add(this.pnlLeftSide);
            this.Controls.Add(this.pnlRightSide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(680, 490);
            this.MinimumSize = new System.Drawing.Size(680, 490);
            this.Name = "PackEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор паков";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PackEditorForm_FormClosed);
            this.Load += new System.EventHandler(this.PackEditorForm_Load);
            this.pnlRightSide.ResumeLayout(false);
            this.pnlRightSide.PerformLayout();
            this.pnlLeftSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRightSide;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel pnlLeftSide;
        private System.Windows.Forms.ListBox ltWords;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblPackName;
        private System.Windows.Forms.TextBox tbPackName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}