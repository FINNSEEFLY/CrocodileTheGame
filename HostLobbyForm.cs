using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace CrocodileTheGame
{
    public partial class HostLobbyForm : Form
    {
        private List<string> WordList;
        private string LocalIP;
        private IPAddress LocalIPv4Address;
        public string Nickname { get; set; }
        private bool IsWaiting;
        private UdpClient UdpListener;
        private UdpClient UdpSender;
        private string UdpBroadcastAddress;
        private List<User> UserList;
        private TcpListener TcpListener;
        private GameForm GameForm;
        public HostLobbyForm()
        {
            InitializeComponent();
        }

        private void CloseForm()
        {
            Owner.Show();
            Disconnect();
            IsWaiting = false;
            UdpListener.Dispose();
            UdpSender.Dispose();
            TcpListener.Stop();
            Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void LobbyHostForm_Load(object sender, EventArgs e)
        {
            WordList = new List<string>();
            LocalIP = CalculationsForNetwork.GetLocalIP();
            LocalIPv4Address = IPAddress.Parse(LocalIP);
            UdpBroadcastAddress = CalculationsForNetwork.GetBroadcastAddress(LocalIP);
            MessageBox.Show("Nickname = " + Nickname + ";\nLocalIP = " + LocalIP + ";\nBroadcastIP = " + UdpBroadcastAddress);
            IsWaiting = true;
            UserList = new List<User>();
            UserList.Add(new User() { Username = Nickname, IsHost = true, IPv4Address = LocalIPv4Address });
            ltPlayers.DataSource = UserList;
            ltPlayers.DisplayMember = "Username";
            ltPlayers.ValueMember = "IPv4Address";
            UdpSender = new UdpClient(UdpBroadcastAddress, UdpFamily.BROADCAST_PORT);
            UdpSender.EnableBroadcast = true;
            UdpListener = new UdpClient(UdpFamily.BROADCAST_PORT);
            UdpListener.EnableBroadcast = true;
            TcpListener = new TcpListener(IPAddress.Parse(LocalIP), TcpFamily.DEFAULT_PORT);
            tbNumOfRounds.Text = "3";
            Task.Factory.StartNew(ListenBroadcastUDP);
            Task.Factory.StartNew(ListeningForConnections);
            if (!TryToLoadDefaultPack())
            {
                CloseForm();
                return;
            }
            Owner.Hide();
            SendBroadcastLobby();

        }

        private void SendBroadcastLobby()
        {
            var nicknameBytes = Encoding.UTF8.GetBytes(Nickname);
            var data = new byte[nicknameBytes.Length + 1];
            data[0] = (byte)UdpFamily.TYPE_SERVER_EXIST;
            Buffer.BlockCopy(nicknameBytes, 0, data, 1, nicknameBytes.Length);
            try
            {
                for (int i = 0; i < UdpFamily.NUM_OF_UDP_PACKET; i++)
                {
                    Thread.Sleep(1);
                    UdpSender.Send(data, data.Length);
                }
            }
            catch { };
        }

        private bool TryToLoadDefaultPack()
        {
            var path = Environment.CurrentDirectory+"\\res\\Default Pack.wrdpack";
            if (!File.Exists(path))
            {
                MessageBox.Show("Стандартный комплект не найден\nПроверьте, что в папке res лежит файл 'Default Pack.wrdpack'\nПродолжение работы невозможно", "Чтение файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                try
                {
                    using (var streamReader = new StreamReader(path))
                    {
                        var firstLine = streamReader.ReadLine();
                        string packName;
                        try
                        {
                            packName = firstLine.Substring(firstLine.IndexOf("Name=") + 5).Trim();
                        }
                        catch
                        {
                            MessageBox.Show("Комплект слов поврежден, продолжение невозможно", "Чтение файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (packName.Trim().ToUpper() == "Default Pack".Trim().ToUpper())
                        {
                            WordList.Clear();
                            tbPack.Text = packName;
                            try
                            {
                                while (!streamReader.EndOfStream)
                                {
                                    var tmpstr = streamReader.ReadLine().Trim();
                                    if (tmpstr != null && tmpstr != "")
                                    {
                                        WordList.Add(tmpstr);
                                    }
                                }
                                return true;
                            }
                            catch
                            {
                                MessageBox.Show("Не удалось прочитать комплект слов. Продолжение работы невозможно", "Чтение файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Комплект слов поврежден, продолжение невозможно", "Чтение файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Неизвестная ошибка при чтении стандартного комплекта. Продолжение работы невозможно", "Чтение файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
        }

        private void ListenBroadcastUDP()
        {
            while (IsWaiting)
            {
                try
                {
                    IPEndPoint remoteHost = null;
                    var recievedData = UdpListener.Receive(ref remoteHost);
                    if (recievedData[0] == UdpFamily.TYPE_CLIENT_REQUEST)
                    {
                        SendBroadcastLobby();
                    }
                }
                catch { }
            }
        }

        private void ListeningForConnections()
        {
            TcpListener.Start();
            while (IsWaiting)
            {
                try
                {
                    var user = new User();
                    user.tcpClient = TcpListener.AcceptTcpClient();
                    user.IPv4Address = ((IPEndPoint)user.tcpClient.Client.RemoteEndPoint).Address;
                    user.stream = user.tcpClient.GetStream();
                    UserList.Add(user);
                    Task.Factory.StartNew(() => ListenTCP(UserList[UserList.IndexOf(user)]));
                    this.Invoke(new MethodInvoker(() =>
                    {
                        UpdatePlayerList();
                    }));
                }
                catch { }
            }
        }

        private void ListenTCP(User user)
        {
            while (user.Listen)
            {
                try
                {
                    if (user.stream.DataAvailable)
                    {
                        var typeAndLength = user.ReciveTypeAndLength();
                        var messageType = typeAndLength[0];
                        switch (messageType)
                        {
                            case TcpFamily.TYPE_FAILED:
                            case TcpFamily.TYPE_DISCONNECT:
                                user.Listen = false;
                                UserList.Remove(user);
                                user.Dispose();
                                SendUsersList();
                                break;
                            case TcpFamily.TYPE_REQUEST_USER_LIST:
                                if (!user.SendUserList(UserList))
                                {
                                    user.Listen = false;
                                    UserList.Remove(user);
                                    user.Dispose();
                                    SendUsersList();
                                }
                                break;
                            case TcpFamily.TYPE_NICKNAME:
                                try
                                {
                                    var messageLength = BitConverter.ToInt32(typeAndLength, 1);
                                    var message = user.ReceiveMessage(messageLength);
                                    user.Username = Encoding.UTF8.GetString(message);
                                }
                                catch
                                {
                                    user.Listen = false;
                                    UserList.Remove(user);
                                    user.Dispose();
                                }
                                finally
                                {
                                    SendUsersList();
                                }
                                break;
                            default:
                                throw new Exception("Неизвестный тип пакета!");
                        }
                    }
                }
                catch { };
            }
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

        private void SendUsersList()
        {
            bool Failed = false;
            foreach (var user in UserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendUserList(UserList))
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        Failed = true;
                        break;
                    }
                }
            }
            if (Failed)
            {
                SendUsersList();
            }
            else
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    UpdatePlayerList();
                }));
            }
        }

        private void UpdatePlayerList()
        {
            ltPlayers.DataSource = null;
            ltPlayers.DataSource = UserList;
            ltPlayers.DisplayMember = "Username";
            ltPlayers.ValueMember = "IPv4Address";
        }

        private void btnKick_Click(object sender, EventArgs e)
        {
            if (ltPlayers.SelectedIndex != -1)
            {
                if (!LocalIPv4Address.Equals(ltPlayers.SelectedValue))
                {
                    var user = UserList.FirstOrDefault((someuser) => someuser.IPv4Address.Equals(ltPlayers.SelectedValue));
                    if (user != null)
                    {
                        user.SendKick();
                        user = UserList[UserList.IndexOf(user)];
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                        SendUsersList();
                    }
                }
            }
        }

        private void btnLoadPack_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            using (var streamReader = new StreamReader(openFileDialog.FileName))
            {
                var firstLine = streamReader.ReadLine();
                string packName;
                try
                {
                    var indexOfName = firstLine.IndexOf("Name=");
                    if (indexOfName!=-1)
                    {
                        packName = firstLine.Substring(indexOfName + 5).Trim();
                    }
                    else
                    {
                        MessageBox.Show("Файл не верного формата, чтение невозможно", "Чтение файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Файл не верного формата, чтение невозможно", "Чтение файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                tbPack.Text = packName;
                WordList.Clear();
                try
                {
                    while (!streamReader.EndOfStream)
                    {
                        var tmpstr = streamReader.ReadLine().Trim();
                        if (tmpstr != null && tmpstr != "")
                        {
                            WordList.Add(tmpstr);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Чтение не удалось", "Чтение файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!TryToLoadDefaultPack())
                    {
                        CloseForm();
                        return;
                    }
                    return;
                }
            }
        }
    
        private void BackToMain()
        {
            GameForm.Dispose();
            Owner.Show();
            Dispose();
        }

        private void SendAllBeginGame()
        {
            foreach(var user in UserList)
            {
                if (!user.IsHost)
                {
                    if (!user.SendBeginGame())
                    {
                        user.Listen = false;
                        UserList.Remove(user);
                        user.Dispose();
                    }
                }
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            int numOfRounds;
            if (int.TryParse(tbNumOfRounds.Text.Trim(),out numOfRounds))
            {
                if (numOfRounds >= 1 && numOfRounds <= 30)
                {
                    IsWaiting = false;
                    UdpListener.Dispose();
                    UdpSender.Dispose();
                    TcpListener.Stop();
                    SendAllBeginGame();
                    GameForm = new GameForm(UserTypes.TYPE_SERVER);
                    GameForm.Nickname = Nickname;
                    GameForm.UserList = UserList;
                    GameForm.WordList = WordList;
                    GameForm.MaxRound = numOfRounds;
                    GameForm.BackToMain += BackToMain;
                    GameForm.Owner = this;
                    GameForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Некорректное значение количества раундов, введите число от 1 до 30", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Некорректное значение количества раундов, введите число от 1 до 30", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
