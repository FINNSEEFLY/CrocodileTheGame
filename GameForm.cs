using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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
        private int CurrentRound = 0;
        private const int SECOND = 1000;
        private const int MAXTIME = 3 * 60;
        private int TimeCounter = MAXTIME;
        private Color Color = Color.FromArgb(0, 0, 0);
        private string SelectedWord;

        public event BackToMainForm BackToMain;
        public delegate void BackToMainForm();
        public event Free FinalFree;
        public delegate void Free();

        public GameForm(int usermode)
        {
            InitializeComponent();
            UserMode = usermode;
        }

        // Buttons
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


        // Start
        private void PrepareStart()
        {
            TurnOffButtons();
            tbInput.Enabled = false;
            btnSend.Enabled = false;

            MainCanvas = new Bitmap(picCanvas.Width, picCanvas.Height);
            picCanvas.Image = (Image)MainCanvas.Clone();
        }


        // Mode Switch
        private void PrepareChatter()
        {
            TurnOffButtons();
            tbInput.Enabled = true;
            btnSend.Enabled = true;
            if (UserMode == UserTypes.TYPE_SERVER)
            {
                try
                {
                    this.picCanvas.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.HostpicCanvas_MouseDown);
                }
                catch { };
                try
                {
                    this.picCanvas.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.HostpicCanvas_MouseMove);
                }
                catch { };
                try
                {
                    this.picCanvas.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.HostpicCanvas_MouseUp);
                }
                catch { };
            }
            else if (UserMode == UserTypes.TYPE_USER)
            {
                try
                {
                    this.picCanvas.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.UserpicCanvas_MouseDown);
                }
                catch { };
                try
                {
                    this.picCanvas.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.UserpicCanvas_MouseMove);
                }
                catch { };
                try
                {
                    this.picCanvas.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.UserpicCanvas_MouseUp);
                }
                catch { };
            }
        }
        private void PrepareLeader()
        {
            TurnOnButtons();
            tbInput.Enabled = false;
            btnSend.Enabled = false;
            if (UserMode == UserTypes.TYPE_SERVER)
            {
                try
                {
                    this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HostpicCanvas_MouseDown);
                }
                catch { }
                try
                {
                    this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HostpicCanvas_MouseUp);
                }
                catch { }
            }
            else if (UserMode == UserTypes.TYPE_USER)
            {
                try
                {
                    this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserpicCanvas_MouseDown);
                }
                catch { }
                try
                {
                    this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserpicCanvas_MouseUp);
                }
                catch { }
            }

        }


        // Common
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
        private void ClearCanvas()
        {
            MainCanvas.Dispose();
            MainCanvas = new Bitmap(picCanvas.Width, picCanvas.Height);
            picCanvas.Image.Dispose();
            picCanvas.Image = (Image)MainCanvas.Clone();
        }
        private void GameForm_Load(object sender, EventArgs e)
        {
            PrepareStart();
            PlayerList = new List<string>();
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
                PrepareNextRound();
                tbRound.Text = CurrentRound + " / " + MaxRound;
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
        public void FreeResources()
        {
            if (UserMode == UserTypes.TYPE_USER)
            {
                Server.SendDisconnect();
                Server.Listen = false;
                Server.Dispose();
            }
            else if (UserMode == UserTypes.TYPE_SERVER)
            {
                HostSendAllDisconnect();
            }
            else
            {
                throw new Exception("Ошибка которой не должно было возникать");
            }
            MainCanvas.Dispose();
        }
        private void CloseForm()
        {
            BackToMain();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            FreeResources();
            CloseForm();
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
        private void btnBlack_Click(object sender, EventArgs e)
        {
            Color = Color.Black;
        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color = colorDialog.Color;
        }
        private void PaintDot(Color color, int radius, int x, int y)
        {
            Graphics = Graphics.FromImage(MainCanvas);
            Graphics.FillEllipse(new SolidBrush(Color), x - radius, y - radius, 2 * radius, 2 * radius);
            picCanvas.Image.Dispose();
            picCanvas.Image = (Image)MainCanvas.Clone();
            Graphics.Dispose();
        }
        private void FillCanvas(Color color)
        {
            Graphics = Graphics.FromImage(MainCanvas);
            Graphics.FillRectangle(new SolidBrush(Color), 0, 0, picCanvas.Width, picCanvas.Height);
            picCanvas.Image.Dispose();
            picCanvas.Image = (Image)MainCanvas.Clone();
            Graphics.Dispose();
        }
        private void btnFill_Click(object sender, EventArgs e)
        {
            FillCanvas(Color);
            if (UserMode == UserTypes.TYPE_USER)
            {
                if (!Server.SendFillCanvas(Color))
                {
                    MessageBox.Show("Потеряно соединение с сервером");
                    UserFormClose();
                }
            }
            else if (UserMode == UserTypes.TYPE_SERVER)
            {
                HostSendAllFillCanvas(Color);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            if (UserMode == UserTypes.TYPE_USER)
            {
                if (!Server.SendClearCanvas())
                {
                    MessageBox.Show("Потеряно соединение с сервером");
                    UserFormClose();
                }
            }
            else if (UserMode == UserTypes.TYPE_SERVER)
            {
                HostSendAllClearCanvas();
            }
        }
        private void SendMessage()
        {
            if (tbInput.Text.Trim() != "")
            {
                if (UserMode == UserTypes.TYPE_USER)
                {
                    if (!Server.SendMessage(TcpFamily.TYPE_MESSAGE, tbInput.Text.Trim()))
                    {
                        UserFormClose();
                    }
                    else
                    {
                        tbInput.Clear();
                    }
                }
                else if (UserMode == UserTypes.TYPE_SERVER)
                {
                    HostSendAllMessage(Nickname + ": " + tbInput.Text.Trim());
                    tbChat.Text += Nickname + ": " + tbInput.Text.Trim() + Environment.NewLine;
                    if (SelectedWord != null)
                    {
                        if (tbInput.Text.Trim().ToUpper().Equals(SelectedWord.Trim().ToUpper()))
                        {
                            Task.Factory.StartNew(() => FinishRound(UserList[0], TimeCounter));
                        }
                    }
                    tbInput.Clear();
                }
            }
        }
        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
        private void tbChat_TextChanged(object sender, EventArgs e)
        {
            tbChat.SelectionStart = tbChat.Text.Length;
            tbChat.ScrollToCaret();
        }
        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FreeResources();
            FinalFree();
        }

        // Host
        private void HostSendAllRounds()
        {
            bool failed = false;
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendRounds(CurrentRound, MaxRound))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        failed = true;
                    }
                }
            }
            if (failed)
            {
                HostSendAllUserList();
            }
        }
        private void HostSendAllTime(string time)
        {
            bool failed = false;
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendTime(time))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        failed = true;
                    }
                }
            }
            if (failed)
            {
                HostSendAllUserList();
            }
        }
        private void HostSendAllUserList()
        {
            bool failed = false;
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
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
                    UpdateUserList();
                }));
            }
        }

        private void HostSendAllResults(string result)
        {
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
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
                i++;
            }
            return result;

        }
        private void HostSilentCloseConnection()
        {
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
            {
                if (!user.IsHost)
                {
                    user.Listen = false;
                    user.Dispose();
                }
            }
            UserList.Clear();
        }
        private void HostSendAllClearCanvas()
        {
            bool failed = false;
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendClearCanvas())
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        failed = true;
                    }
                }
            }
            if (failed)
            {
                HostSendAllUserList();
            }
        }
        private void HostSendAllMessage(string message)
        {
            bool failed = false;
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendMessage(TcpFamily.TYPE_MESSAGE, message))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        failed = true;
                    }
                }
            }
            if (failed)
            {
                HostSendAllUserList();
            }
        }
        private void HostSendAllDot(byte[] message)
        {
            bool failed = false;
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendDot(message))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        failed = true;
                    }
                }
            }
            if (failed)
            {
                HostSendAllUserList();
            }
        }
        private void HostSendAllFillCanvas(byte[] message)
        {
            bool failed = false;
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendFillCanvas(message))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        failed = true;
                    }
                }
            }
            if (failed)
            {
                HostSendAllUserList();
            }
        }
        private void HostSendAllFillCanvas(Color color)
        {
            bool failed = false;
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendFillCanvas(color))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        failed = true;
                    }
                }
            }
            if (failed)
            {
                HostSendAllUserList();
            }
        }
        private void HostSendAllHeader(string str)
        {
            bool failed = false;
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendHeader(str))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        failed = true;
                    }
                }
            }
            if (failed)
            {
                HostSendAllUserList();
            }
        }
        private void HostListenTCP(User user)
        {
            while (user.Listen)
            {
                try
                {
                    if (user.stream.DataAvailable)
                    {
                        var typeAndLength = user.ReciveTypeAndLength();
                        var messageType = typeAndLength[0];
                        int messageLength;
                        byte[] message;
                        switch (messageType)
                        {
                            case TcpFamily.TYPE_FAILED:
                            case TcpFamily.TYPE_DISCONNECT:
                                user.Listen = false;
                                UserList.Remove(user);
                                user.Dispose();
                                HostSendAllUserList();
                                break;
                            case TcpFamily.TYPE_CLEAR_CANVAS:
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    ClearCanvas();
                                }));
                                HostSendAllClearCanvas();
                                break;
                            case TcpFamily.TYPE_MESSAGE:
                            case TcpFamily.TYPE_DOT:
                            case TcpFamily.TYPE_FILL_CANVAS:
                                messageLength = BitConverter.ToInt32(typeAndLength, 1);
                                try
                                {
                                    message = user.ReceiveMessage(messageLength);
                                }
                                catch (Exception e)
                                {
                                    this.Invoke(new MethodInvoker(() =>
                                    {
                                        MessageBox.Show(e.Message + "\n" + e.StackTrace);
                                    }));
                                    user.Listen = false;
                                    UserList.Remove(user);
                                    user.Dispose();
                                    HostSendAllUserList();
                                    break;
                                }
                                switch (messageType)
                                {
                                    case TcpFamily.TYPE_MESSAGE:
                                        var word = Encoding.UTF8.GetString(message);
                                        var result = user.Username + ": " + word;
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            tbChat.Text += result + Environment.NewLine;
                                        }));
                                        HostSendAllMessage(result);
                                        if (SelectedWord != null)
                                        {
                                            if (word.Trim().ToUpper().Equals(SelectedWord.Trim().ToUpper()))
                                            {
                                                FinishRound(user, TimeCounter);
                                            }
                                        }
                                        break;
                                    case TcpFamily.TYPE_DOT:
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            PaintDotAccepted(message);
                                        }));
                                        HostSendAllDot(message);
                                        break;
                                    case TcpFamily.TYPE_FILL_CANVAS:
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            FillCanvasAccepted(message);
                                        }));
                                        HostSendAllFillCanvas(message);
                                        break;

                                }
                                break;
                            default:
                                throw new Exception("Неизвестный тип пакета!");
                        }
                    }
                }
                catch (Exception e)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        MessageBox.Show(e.Message + "\n" + e.StackTrace);
                    }));
                };
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
                PrepareNextRound();
            }
        }
        private void HostSendAllDisconnect()
        {
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
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
        private void HostSendAllDot(int x, int y)
        {
            bool failed = false;
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendDot(Color, (byte)trbRadius.Value, x, y))
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
                HostSendAllDot(x, y);
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
            PaintDot(Color, trbRadius.Value, e.X, e.Y);
            HostSendAllDot(e.X, e.Y);
        }
        private void FinishRound(User winner, int time)
        {
            WordList.Remove(SelectedWord);
            var tmpWord = SelectedWord;
            SelectedWord = null;
            Timer.Enabled = false;
            HostSendAllHeader(winner.Username + " отгадывает [ " + tmpWord + " ] | +" + time * 10 + " баллов");
            this.Invoke(new MethodInvoker(() =>
            {
                tbLeaderAndWord.Text = winner.Username + " отгадывает [ " + tmpWord + " ] | +" + time * 10 + " баллов";
            }));
            UserList[UserList.IndexOf(winner)].Score += time * 10;
            Thread.Sleep(3500);
            PrepareNextRound();
        }
        private void HostSendAllPrepareInfo(User lead)
        {
            bool failed = false;
            var tmpUserList = new List<User>(UserList);
            foreach (var user in tmpUserList)
            {
                if (!user.IsHost)
                {
                    if (!user.IPv4Address.Equals(lead.IPv4Address))
                    {
                        if (!(user.SendPrepareChatter() && user.SendHeader("Ведущий " + lead.Username + " | Количество букв: " + SelectedWord.Length)))
                        {

                            user.Listen = false;
                            UserList.Remove(user);
                            user.Dispose();
                            failed = true;
                        }
                    }
                    else if (!(user.SendPrepareLeader() && user.SendHeader("Вы ведущий! | Нарисуйте: " + SelectedWord)))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        failed = true;
                    }
                }
            }
            if (failed)
            {
                HostSendAllUserList();
            }
        }
        private void PrepareNextRound()
        {
            CurrentRound++;
            if (CurrentRound > MaxRound)
            {
                var result = MakeResults();
                HostSendAllResults(result);
                HostSilentCloseConnection();
                this.Invoke(new MethodInvoker(() =>
                {
                    MessageBox.Show("Игра завершена!\nИтоговый рейтинг:\n" + result, "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.None);
                    BackToMain();
                }));
            }
            else
            {
                HostSendAllUserList();
                this.Invoke(new MethodInvoker(() =>
                {
                    UpdateUserList();
                }));
                TimeCounter = MAXTIME;
                RandomWord();
                var leader = SelectUser();
                var user = UserList[UserList.IndexOf(leader)];
                user.NumOfLeads += 1;
                HostSendAllPrepareInfo(leader);
                HostSendAllRounds();
                this.Invoke(new MethodInvoker(() =>
                {
                    tbRound.Text = CurrentRound + " / " + MaxRound;
                }));
                HostSendAllTime(MakeTime(MAXTIME));
                HostSendAllClearCanvas();
                this.Invoke(new MethodInvoker(() =>
                {
                    tbRound.Text = CurrentRound + " / " + MaxRound;
                    ClearCanvas();
                }));
                if (leader.IsHost)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        PrepareLeader();
                        tbLeaderAndWord.Text = "Вы ведущий! | Нарисуйте: " + SelectedWord;
                    }));
                }
                else
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        PrepareChatter();
                        tbLeaderAndWord.Text = "Ведущий " + leader.Username + " | Количество букв: " + SelectedWord.Length;
                    }));
                }
                this.Invoke(new MethodInvoker(() =>
                {
                    Timer.Enabled = true;
                }));
            }
            // Проверить не конец ли игры
            // Если конец - объявить результаты
            // Если не конец
            // отрубить таймер себе
            // Выбрать некст ведущего
            // Запустить игру
            // Восстановить таймеры
        }
        private void RandomWord()
        {
            var numOfWords = WordList.Count;
            var random = new Random();
            SelectedWord = WordList[random.Next(0, numOfWords - 1)];
        }
        private User SelectUser()
        {
            var sortedUsers = from user in UserList
                              orderby user.NumOfLeads ascending
                              select user;
            return sortedUsers.First();

        }
        private void UpdateUserList()
        {
            ltPlayers.Items.Clear();
            foreach (var user in UserList)
            {
                ltPlayers.Items.Add(user.Username + " | " + user.Score);
            }
        }

        // User
        private void UserSilentCloseConnection()
        {
            Server.Listen = false;
            Server.Dispose();
        }
        private void UpdatePlayerList()
        {
            ltPlayers.Items.Clear();
            var tmpPlayerList = new List<string>(PlayerList);
            foreach (var user in tmpPlayerList)
            {
                ltPlayers.Items.Add(user);
            }
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
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    MessageBox.Show("Лобби было закрыто хостом.");
                                    UserFormClose();
                                }));
                                break;
                            case TcpFamily.TYPE_KICK:
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    MessageBox.Show("Вас исключили из лобби.");
                                    UserFormClose();
                                }));
                                break;
                            case TcpFamily.TYPE_CLEAR_CANVAS:
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    ClearCanvas();
                                }));
                                break;
                            case TcpFamily.TYPE_YOU_CHATTER:
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    PrepareChatter();
                                }));
                                break;
                            case TcpFamily.TYPE_YOU_LEADER:
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    PrepareLeader();
                                }));
                                break;
                            case TcpFamily.TYPE_USER_LIST:
                            case TcpFamily.TYPE_TIME:
                            case TcpFamily.TYPE_ROUNDS:
                            case TcpFamily.TYPE_RESULT:
                            case TcpFamily.TYPE_MESSAGE:
                            case TcpFamily.TYPE_DOT:
                            case TcpFamily.TYPE_FILL_CANVAS:
                            case TcpFamily.TYPE_HEADER:
                                messageLength = BitConverter.ToInt32(typeAndLength, 1);
                                try
                                {
                                    message = Server.ReceiveMessage(messageLength);
                                }
                                catch
                                {
                                    this.Invoke(new MethodInvoker(() =>
                                    {
                                        MessageBox.Show("Ошибка, получен поврежденный пакет, соединение будет разорвано");
                                        UserFormClose();
                                    }));
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
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            tbTime.Text = Encoding.UTF8.GetString(message);
                                        }));
                                        break;
                                    case TcpFamily.TYPE_ROUNDS:
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            tbRound.Text = Encoding.UTF8.GetString(message);
                                        }));
                                        break;
                                    case TcpFamily.TYPE_MESSAGE:
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            tbChat.Text += Encoding.UTF8.GetString(message) + Environment.NewLine;
                                        }));
                                        break;
                                    case TcpFamily.TYPE_DOT:
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            PaintDotAccepted(message);
                                        }));
                                        break;
                                    case TcpFamily.TYPE_FILL_CANVAS:
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            FillCanvasAccepted(message);
                                        }));
                                        break;
                                    case TcpFamily.TYPE_HEADER:
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            tbLeaderAndWord.Text = Encoding.UTF8.GetString(message);
                                        }));
                                        break;
                                    case TcpFamily.TYPE_RESULT:
                                        UserSilentCloseConnection();
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            MessageBox.Show("Игра завершена!\nИтоговый рейтинг:\n" + Encoding.UTF8.GetString(message), "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.None);
                                            BackToMain();
                                        }));
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
                    this.Invoke(new MethodInvoker(() =>
                    {
                        MessageBox.Show("Потеряно соединение с сервером");
                        UserFormClose();
                    }));
                };
            }
        }
        private void UserFormClose()
        {
            FreeResources();
            BackToMain();
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
            PaintDot(Color, trbRadius.Value, e.X, e.Y);
            if (!Server.SendDot(Color, (byte)trbRadius.Value, e.X, e.Y))
            {
                MessageBox.Show("Потеряно соединение с сервером");
                UserFormClose();
            }
        }
    }
}
