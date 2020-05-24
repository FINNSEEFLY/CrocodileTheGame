using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace CrocodileTheGame
{
    public partial class MainForm : Form
    {
        private LobbyHostForm lobbyHostForm;
        private FindLobbyForm findLobbyForm;
        private PackEditorForm packEditorForm;
        private AboutForm aboutForm;
        private LobbyPlayerForm lobbyPlayer;
        private GameForm gameform;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCreateLobby_Click(object sender, EventArgs e)
        {
            lobbyHostForm = new LobbyHostForm();
            lobbyHostForm.TakeNickname += GiveNickname;
            lobbyHostForm.TakeLocalIP += GiveLocalIP;
            lobbyHostForm.Owner = this;
            lobbyHostForm.Show();
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConnectToLobby_Click(object sender, EventArgs e)
        {
            findLobbyForm = new FindLobbyForm();
            findLobbyForm.Owner = this;
            findLobbyForm.TakeLocalIP += GiveLocalIP;
            findLobbyForm.TakeNickname += GiveNickname;
            findLobbyForm.Show();
            Hide();
        }

        private void btnPackCreator_Click(object sender, EventArgs e)
        {
            packEditorForm = new PackEditorForm();
            packEditorForm.Owner = this;
            packEditorForm.Show();
            Hide();
        }

        private void btnAboutProgramm_Click(object sender, EventArgs e)
        {
            aboutForm = new AboutForm();
            aboutForm.Owner = this;
            aboutForm.ShowDialog();
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
       
    }
}
