using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CrocodileTheGame
{
    public partial class PackEditorForm : Form
    {
        List<string> ListWord = new List<string>();

        public PackEditorForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ListWord.Clear();
            Owner.Show();
            Dispose();
        }

        private void PackEditorForm_Load(object sender, EventArgs e)
        {
            tbWord.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            tbPackName.Enabled = false;
            btnSave.Enabled = false;
        }

        private void PrepareToWork()
        {
            tbPackName.Enabled = true;
            tbWord.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            btnSave.Enabled = true;
            tbPackName.Clear();
            ListWord.Clear();
            ltWords.Items.Clear();
        }

        private void PreapreToNotWork()
        {
            tbPackName.Enabled = false;
            tbWord.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            tbPackName.Clear();
            ListWord.Clear();
            ltWords.Items.Clear();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PrepareToWork();
        }

        private void TryToAdd()
        {
            if (tbWord.Text.Trim() != "")
            {
                if (ListWord.FirstOrDefault(str => str.Trim().ToUpper() == tbWord.Text.Trim().ToUpper()) != null)
                {
                    MessageBox.Show("Данное слово уже есть", "Уже есть", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ListWord.Add(tbWord.Text.Trim());
                    ltWords.Items.Add(tbWord.Text.Trim());
                    tbWord.Clear();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TryToAdd();
        }

        private void tbWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TryToAdd();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var value = (string)ltWords.SelectedItem;
            if (value != null)
            {
                ltWords.Items.Remove(value);
                ListWord.Remove(value);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            using (var streamReader = new StreamReader(openFileDialog.FileName))
            {
                var firstLine = streamReader.ReadLine();
                string packName;
                try
                {
                    packName = firstLine.Substring(firstLine.IndexOf("Name=") + 5).Trim();
                }
                catch
                {
                    MessageBox.Show("Файл не верного формата, чтение невозможно", "Чтение файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                PrepareToWork();
                tbPackName.Text = packName;
                try
                {
                    while (!streamReader.EndOfStream)
                    {
                        var tmpstr = streamReader.ReadLine().Trim();
                        if (tmpstr != null && tmpstr != "")
                        {
                            ListWord.Add(tmpstr);
                            ltWords.Items.Add(tmpstr);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Чтение не удалось", "Чтение файла", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbPackName.Text.Trim() == "")
            {
                MessageBox.Show("Заполните название пака", "Название", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                saveFileDialog.FileName = tbPackName.Text.Trim();
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                try
                {
                    using (var streamWriter = new StreamWriter(saveFileDialog.FileName))
                    {
                        streamWriter.WriteLine("Name=" + tbPackName.Text.Trim());
                        foreach (var word in ListWord)
                        {
                            streamWriter.WriteLine(word);
                        }
                    }
                    MessageBox.Show("Файл успешно сохранен!", "Сохранено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {
                    MessageBox.Show("Ошибка при сохранении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PreapreToNotWork();
                }
            }

        }
    }
}
