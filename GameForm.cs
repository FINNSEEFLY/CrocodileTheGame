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
    public partial class GameForm : Form
    {
        public int UserMode { get; set; }
        public Server Server { get; set; }
        public List<User> UserList { get; set; }
        public List<string> WordList { get; set; }
        public string Nickname { get; set; }
        public int RoundMaxNumber { get; set; }
        private int CurrentRound;

        public GameForm(int usermode)
        {
            InitializeComponent();
            UserMode = usermode;
        }

        private void TurnOffButtons()
        {
            btnColor.Enabled = false;
            btnBlack.Enabled = false;
            btnBlue.Enabled = false;
            btnRed.Enabled = false;
            btnGreen.Enabled = false;
            btnFill.Enabled = false;
            btnClear.Enabled = false;
            trbRadius.Enabled = false;
        }

        private void TurnOnButtons()
        {
            btnColor.Enabled = true;
            btnBlack.Enabled = true;
            btnBlue.Enabled = true;
            btnRed.Enabled = true;
            btnGreen.Enabled = true;
            btnFill.Enabled = true;
            btnClear.Enabled = true;
            trbRadius.Enabled = true;
        }

        private void PrepareStart()
        {
            TurnOffButtons();
            tbInput.Enabled = false;
        }

        private void PrepareChatter()
        {
            TurnOffButtons();
            tbInput.Enabled = true;
            // Отключение обработчиков нажатия на канвас
        }

        private void PrepareArtist()
        {
            TurnOnButtons();
            tbInput.Enabled = false;
            // Подключение обработчика нажатия
        }

        private void HostSendAllDisconnect()
        {
            foreach(var user in UserList)
            {
                if(!user.IsHost)
                {
                    user.SendDisconnect();
                }
            }
        }

        private void HostSendAllRounds()
        {
            bool failed = false;
            foreach (var user in UserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendRounds(CurrentRound,RoundMaxNumber))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        failed = true;
                        break;
                    }
                }
            }
            if (failed)
            {
                ServerSendAllUserList();
                HostSendAllRounds();
            }
        }

        private void UpdatePlayerList()
        {
            ltPlayers.DataSource = null;
            ltPlayers.DataSource = UserList;
            ltPlayers.DisplayMember = "Username";
            ltPlayers.ValueMember = "IsHost";
        }

        private void ServerSendAllUserList()
        {
            bool failed = false;
            foreach (var user in UserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendUserList(UserList))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        failed = true;
                        break;
                    }
                }
            }
            if (failed)
            {
                ServerSendAllUserList();
            }
            else
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    UpdatePlayerList();
                }));
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            PrepareStart();
            if (UserMode == PlayerTypes.TYPE_USER)
            {

            }
            else if (UserMode == PlayerTypes.TYPE_SERVER)
            {
                UserList.Add(new User() { Username = Nickname, IsHost = true });
                Timer.Tick += new System.EventHandler(this.Timer_Tick);

            } else
            {
                throw new Exception("Ошибка, которой не должно было возникать");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

        }
    }
}
