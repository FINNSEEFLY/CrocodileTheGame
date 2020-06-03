using System;
using System.Windows.Forms;

namespace CrocodileTheGame
{
    public partial class MainForm : Form
    {
        private HostLobbyForm HostLobbyForm;
        private FindLobbyForm FindLobbyForm;
        private PackEditorForm PackEditorForm;
        private AboutForm AboutForm;
        public MainForm()
        {
            InitializeComponent();
            lblNickname.Parent = pictureBox1;
        }

        private void btnCreateLobby_Click(object sender, EventArgs e)
        {
            HostLobbyForm = new HostLobbyForm();
            HostLobbyForm.FinalFree += ClosingWithHostLobbyForm;
            HostLobbyForm.Nickname = GiveNickname();
            HostLobbyForm.Owner = this;
            HostLobbyForm.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnConnectToLobby_Click(object sender, EventArgs e)
        {
            FindLobbyForm = new FindLobbyForm();
            FindLobbyForm.Owner = this;
            FindLobbyForm.FinalFree += ClosingWithFindLobbyForm;
            FindLobbyForm.Nickname = GiveNickname();
            FindLobbyForm.Show();
            Hide();
        }
        private void btnPackCreator_Click(object sender, EventArgs e)
        {
            PackEditorForm = new PackEditorForm();
            PackEditorForm.Owner = this;
            PackEditorForm.FinalFree += ClosingWithPackEditorForm;
            PackEditorForm.Show();
            Hide();
        }
        private void btnAboutProgramm_Click(object sender, EventArgs e)
        {
            AboutForm = new AboutForm();
            AboutForm.Owner = this;
            AboutForm.ShowDialog();
        }


        public string GiveNickname()
        {
            string nickname = tbNickName.Text.Trim();
            if (nickname == "")
            {
                var random = new Random();
                nickname = "Player#" + random.Next(1,9999);
            }
            return nickname;
        }
        public void ClosingWithFindLobbyForm()
        {
            FindLobbyForm.Dispose();
            Dispose();
        }
        public void ClosingWithHostLobbyForm()
        {
            HostLobbyForm.Dispose();
            Dispose();
        }
        public void ClosingWithPackEditorForm()
        {
            PackEditorForm.Dispose();
            Dispose();
        }
    }
}
