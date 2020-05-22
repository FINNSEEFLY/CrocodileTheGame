using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            lobbyHostForm.OpenMainWindow += OpenMainWindow;
            DisplayForm(lobbyHostForm);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConnectToLobby_Click(object sender, EventArgs e)
        {
            findLobbyForm = new FindLobbyForm();
            findLobbyForm.OpenMainWindow += OpenMainWindow;
            DisplayForm(findLobbyForm);
        }

        private void btnPackCreator_Click(object sender, EventArgs e)
        {
            packEditorForm = new PackEditorForm();
            packEditorForm.OpenMainWindow += OpenMainWindow;
            DisplayForm(packEditorForm);
        }

        private void btnAboutProgramm_Click(object sender, EventArgs e)
        {
            aboutForm = new AboutForm();
            aboutForm.OpenMainWindow += OpenMainWindow;
            DisplayForm(aboutForm);
        }

        public void DisplayForm(Form form)
        {
            form.Show();
            this.Hide();
        }

        public void OpenMainWindow()
        {
            this.Show();
        }
    }
}
