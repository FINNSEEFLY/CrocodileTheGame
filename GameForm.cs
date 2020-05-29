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
        public int MaxRound { get; set; }
        private int CurrentRound;
        private const int SECOND = 1000;
        private const int MAXTIME = 3 * 60;
        private int TimeCounter = MAXTIME;

        public event BackToMainForm BackToMain;
        public delegate void BackToMainForm();

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
            foreach (var user in UserList)
            {
                if (!user.IsHost)
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
                    if (!user.SendRounds(CurrentRound, MaxRound))
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
                HostSendAllUserList();
                HostSendAllRounds();
            }
        }

        private void HostSendAllTime(string time)
        {
            bool failed = false;
            foreach (var user in UserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendTime(time))
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
                HostSendAllUserList();
                HostSendAllTime(time);
            }
        }

        private void UpdatePlayerList()
        {
            ltPlayers.DataSource = null;
            ltPlayers.DataSource = UserList;
            ltPlayers.DisplayMember = "Username";
            ltPlayers.ValueMember = "IsHost";
        }

        private void HostSendAllUserList()
        {
            bool failed = false;
            foreach (var user in UserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendUserListInGame(UserList))
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
                HostSendAllUserList();
            }
            else
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    UpdatePlayerList();
                }));
            }
        }

        private void HostSendAllResults(string result)
        {

            foreach (var user in UserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendUserResults(result))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                    }
                }
            }
        }

        private string MakeResults()
        {
            string result = "";
            var orderedUserList = from user in UserList
                                  orderby user.Score descending
                                  select user;
            int i = 1;
            foreach (var user in orderedUserList)
            {
                result += i + " Место " + user.Username + " | " + user.Score + "\n";
            }
            return result;

        }

        private void HostSilentCloseConnection()
        {
            foreach (var user in UserList)
            {
                if (!user.IsHost)
                {
                    user.Listen = false;
                    user.Dispose();
                }
            }
            UserList.Clear();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            PrepareStart();
            if (UserMode == UserTypes.TYPE_USER)
            {

            }
            else if (UserMode == UserTypes.TYPE_SERVER)
            {
                HostSendAllRounds();
                HostSendAllTime(MakeTime(MAXTIME));
                HostSendAllUserList();
                Timer.Interval = SECOND;
                Timer.Tick += new System.EventHandler(this.TimerHost_Tick);
            }
            else
            {
                throw new Exception("Ошибка, которой не должно было возникать");
            }
        }

        private string MakeTime(int time)
        {
            string result = "";
            result += (time / 60 > 0) ? time / 60 + " : " : "";
            result += (time % 60 >= 10) ? (time % 60).ToString() : "0" + (time % 60);
            return result;
        }

        private void TimerHost_Tick(object sender, EventArgs e)
        {
            TimeCounter--;
            var timestr = MakeTime(TimeCounter);
            tbTime.Text = timestr;
            HostSendAllTime(timestr);
            if (TimeCounter == 0)
            {
                CurrentRound++;
                if (CurrentRound > MaxRound)
                {
                    var result = MakeResults();
                    HostSendAllResults(result);
                    HostSilentCloseConnection();
                    MessageBox.Show("Игра завершена!\nИтоговый рейтинг:\n" + result, "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                // Проверить не конец ли игры
                // Если конец - объявить результаты
                // Если не конец
                // отрубить таймер себе и игрокам
                // Выбрать некст ведущего
                // Запустить игру
                // Восстановить таймеры
            }
        }

        private void UserFormClose()
        {
            Server.SendDisconnect();
            Server.Listen = false;
            Server.Dispose();
            BackToMain();
        }

        private void HostFormClose()
        {
            Disconnect();
            BackToMain();
        }

        private void Disconnect()
        {
            foreach (var user in UserList)
            {
                if (!user.IsHost)
                {
                    user.Listen = false;
                    user.SendDisconnect();
                    user.Dispose();
                }
            }
            UserList.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (UserMode == UserTypes.TYPE_USER)
            {
                UserFormClose();
            }
            else if (UserMode == UserTypes.TYPE_SERVER)
            {
                HostFormClose();
            }
            else
            {
                throw new Exception("Ошибка которой не должно было возникать");
            }
        }
    }
}
