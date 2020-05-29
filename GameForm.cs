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
        private List<string> PlayerList;
        private Bitmap MainCanvas;
        private Graphics Graphics;
        private int CurrentRound;
        private bool Drawer = false;
        private const int SECOND = 1000;
        private const int MAXTIME = 3 * 60;
        private int TimeCounter = MAXTIME;
        private bool IsDown;
        private Color Color = Color.FromArgb(0, 0, 0);

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
            btnSend.Enabled = false;

            MainCanvas = new Bitmap(picCanvas.Width, picCanvas.Height);
            picCanvas.Image = (Image)MainCanvas.Clone();
        }

        private void PrepareChatter()
        {
            TurnOffButtons();
            tbInput.Enabled = true;
            btnSend.Enabled = true;
            if (UserMode == UserTypes.TYPE_SERVER && Drawer)
            {
                this.picCanvas.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.HostpicCanvas_MouseDown);
                this.picCanvas.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.HostpicCanvas_MouseUp);
            }
            else if (UserMode == UserTypes.TYPE_USER && Drawer)
            {
                this.picCanvas.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.UserpicCanvas_MouseDown);
                this.picCanvas.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.UserpicCanvas_MouseUp);
            }
        }

        private void PrepareArtist()
        {
            TurnOnButtons();
            tbInput.Enabled = false;
            btnSend.Enabled = false;
            if (UserMode == UserTypes.TYPE_SERVER && !Drawer)
            {
                this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HostpicCanvas_MouseDown);
                this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HostpicCanvas_MouseUp);
            }
            else if (UserMode == UserTypes.TYPE_USER && Drawer)
            {
                this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserpicCanvas_MouseDown);
                this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserpicCanvas_MouseUp);
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
            ltPlayers.Items.Clear();
            foreach (var user in UserList)
            {
                ltPlayers.Items.Add(user.Username + " | " + user.Score);
            }

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

        private void UserSilentCloseConnection()
        {
            Server.Listen = false;
            Server.Dispose();
        }

        private void PaintDotAccepted(byte[] message)
        {
            // format -> r g b Radius X X X X Y Y Y Y
            Graphics = Graphics.FromImage(MainCanvas);
            int x, y;
            x = BitConverter.ToInt32(message, 4);
            y = BitConverter.ToInt32(message, 8);
            Graphics.FillEllipse(new SolidBrush(Color.FromArgb(message[0], message[1], message[2])),
                                 x - message[3], y - message[3], 2 * message[3], 2 * message[3]);
            picCanvas.Image.Dispose();
            picCanvas.Image = (Image)MainCanvas.Clone();
            Graphics.Dispose();
        }

        private void FillCanvasAccepted(byte[] message)
        {
            // format -> r g b
            Graphics = Graphics.FromImage(MainCanvas);
            Graphics.FillRectangle(new SolidBrush(Color.FromArgb(message[0], message[1], message[2])), 0, 0, picCanvas.Width, picCanvas.Height);
            picCanvas.Image.Dispose();
            picCanvas.Image = (Image)MainCanvas.Clone();
            Graphics.Dispose();
        }

        private void ClearCanvasAccepted()
        {
            MainCanvas.Dispose();
            MainCanvas = new Bitmap(picCanvas.Width, picCanvas.Height);
            picCanvas.Image.Dispose();
            picCanvas.Image = (Image)MainCanvas.Clone();
        }

        private void UserListenTCP()
        {
            while (Server.Listen)
            {
                try
                {
                    if (Server.stream.DataAvailable)
                    {
                        var typeAndLength = Server.ReciveTypeAndLength();
                        var messageType = typeAndLength[0];
                        int messageLength;
                        byte[] message;
                        switch (messageType)
                        {
                            case TcpFamily.TYPE_FAILED:
                            case TcpFamily.TYPE_DISCONNECT:
                                MessageBox.Show("Лобби было закрыто хостом.");
                                UserFormClose();
                                break;
                            case TcpFamily.TYPE_KICK:
                                MessageBox.Show("Вас исключили из лобби.");
                                UserFormClose();
                                break;
                            case TcpFamily.TYPE_CLEAR_CANVAS:
                                ClearCanvasAccepted();
                                break;
                            case TcpFamily.TYPE_YOU_CHATTER:
                                // Перевод в режим угадывающего
                                break;
                            case TcpFamily.TYPE_YOU_LEADER:
                                // Перевод в режим рисующего
                                break;
                            case TcpFamily.TYPE_USER_LIST:
                            case TcpFamily.TYPE_TIME:
                            case TcpFamily.TYPE_ROUNDS:
                            case TcpFamily.TYPE_RESULT:
                            case TcpFamily.TYPE_MESSAGE:
                            case TcpFamily.TYPE_DOT:
                            case TcpFamily.TYPE_FILL_CAVNAS:
                            case TcpFamily.TYPE_HEADER:
                                messageLength = BitConverter.ToInt32(typeAndLength, 1);
                                try
                                {
                                    message = Server.ReceiveMessage(messageLength);
                                }
                                catch
                                {
                                    MessageBox.Show("Ошибка, получен поврежденный пакет, соединение будет разорвано");
                                    UserFormClose();
                                    return;
                                }
                                switch (messageType)
                                {
                                    case TcpFamily.TYPE_USER_LIST:
                                        PlayerList.Clear();
                                        PlayerList = Server.ParseStringList(message, messageLength);
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            UpdatePlayerList();
                                        }));
                                        break;
                                    case TcpFamily.TYPE_TIME:
                                        tbTime.Text = Encoding.UTF8.GetString(message);
                                        break;
                                    case TcpFamily.TYPE_ROUNDS:
                                        tbRound.Text = Encoding.UTF8.GetString(message);
                                        break;
                                    case TcpFamily.TYPE_MESSAGE:
                                        tbChat.Text += Encoding.UTF8.GetString(message) + "\n";
                                        break;
                                    case TcpFamily.TYPE_DOT:
                                        PaintDotAccepted(message);
                                        break;
                                    case TcpFamily.TYPE_FILL_CAVNAS:
                                        FillCanvasAccepted(message);
                                        break;
                                    case TcpFamily.TYPE_HEADER:
                                        tbLeaderAndWord.Text = Encoding.UTF8.GetString(message);
                                        break;
                                    case TcpFamily.TYPE_RESULT:
                                        UserSilentCloseConnection();
                                        MessageBox.Show("Игра завершена!\nИтоговый рейтинг:\n" + Encoding.UTF8.GetString(message), "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.None);
                                        BackToMain();
                                        break;

                                }
                                break;
                            default:
                                throw new Exception("Неизвестный тип пакета!");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Потеряно соединение с сервером");
                    UserFormClose();
                };
            }
        }

        private void HostListenTCP(User user)
        {

        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            PrepareStart();
            if (UserMode == UserTypes.TYPE_USER)
            {
                Task.Factory.StartNew(UserListenTCP);
            }
            else if (UserMode == UserTypes.TYPE_SERVER)
            {
                foreach (var user in UserList)
                {
                    if (!user.IsHost)
                    {
                        Task.Factory.StartNew(() => HostListenTCP(UserList[UserList.IndexOf(user)]));
                    }
                }
                HostSendAllRounds();
                HostSendAllTime(MakeTime(MAXTIME));
                HostSendAllUserList();
                Timer.Tick += new System.EventHandler(this.TimerHost_Tick);
                Timer.Interval = SECOND;
                Timer.Enabled = true;
            }
            else
            {
                throw new Exception("Ошибка, которой не должно было возникать");
            }
        }

        private string MakeTime(int time)
        {
            string result = "";
            result += (time / 60 > 0) ? "0" + time / 60 + " : " : "00 : ";
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
                Timer.Enabled = false;
                CurrentRound++;
                if (CurrentRound > MaxRound)
                {
                    var result = MakeResults();
                    HostSendAllResults(result);
                    HostSilentCloseConnection();
                    MessageBox.Show("Игра завершена!\nИтоговый рейтинг:\n" + result, "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.None);
                    BackToMain();
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

        private void HostSendAllDot(int x, int y)
        {
            bool failed = false;
            foreach (var user in UserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendDot(Color,(byte)trbRadius.Value,x,y))
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
                HostSendAllDot(x,y);
            }
        }

        private void HostpicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HostpicCanvas_MouseMove);
        }

        private void HostpicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            this.picCanvas.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.HostpicCanvas_MouseMove);
        }

        private void HostpicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void UserpicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserpicCanvas_MouseMove);
        }

        private void UserpicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            this.picCanvas.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.UserpicCanvas_MouseMove);
        }

        private void UserpicCanvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            Color = Color.Blue;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            Color = Color.Green;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            Color = Color.Red;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color = colorDialog.Color;
        }
    }
}
