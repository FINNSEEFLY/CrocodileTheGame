using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace CrocodileTheGame
{
    public partial class LobbyHostForm : Form
    {
        const int NUM_OF_UDP_PACKET = 50;
        private string LocalIP;
        private string NickName;
        private bool IsWaiting;
        private UdpClient UdpListener;
        private string UdpBroadcastAddress;
        private List<User> UserList;
        private TcpListener TcpListener;
        public event StringTransfer TakeNickname;
        public event StringTransfer TakeLocalIP;
        public delegate string StringTransfer();
        public LobbyHostForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Disconnect();
            IsWaiting = false;
            UdpListener.Dispose();
            TcpListener.Stop();
            Dispose();
        }

        private void LobbyHostForm_Load(object sender, EventArgs e)
        {
            NickName = TakeNickname();
            LocalIP = TakeLocalIP();
            UdpBroadcastAddress = CalcBroadcastAddress(LocalIP);
            MessageBox.Show("Nickname = " + NickName + ";\nLocalIP = " + LocalIP + ";\nBroadcastIP = " + UdpBroadcastAddress);
            IsWaiting = true;
            UserList = new List<User>();
            Task.Factory.StartNew(ListenBroadcastUDP);
            Task.Factory.StartNew(ListeningForConnections);
        }

        public string CalcBroadcastAddress(string localip)
        {
            var ipInBytes = IPAddress.Parse(localip).GetAddressBytes();
            ipInBytes[3] = 255;
            return new IPAddress(ipInBytes).ToString();
        }

        private void ListenBroadcastUDP()
        {
            UdpListener = new UdpClient((int)UdpFamily.BroadcastPort);
            UdpListener.EnableBroadcast = true;
            while (IsWaiting)
            {
                try
                {
                    IPEndPoint remoteHost = null;
                    var recievedData = UdpListener.Receive(ref remoteHost);
                    if (recievedData[0] == (int)UdpFamily.TypeClientRequest)
                    {
                        var udpClient = new UdpClient(UdpBroadcastAddress, (int)UdpFamily.BroadcastPort);
                        udpClient.EnableBroadcast = true;
                        var nicknameBytes = Encoding.UTF8.GetBytes(NickName);
                        var data = new byte[nicknameBytes.Length + 1];
                        data[0] = (byte)UdpFamily.TypeServerExist;
                        Buffer.BlockCopy(nicknameBytes, 0, data, 1, nicknameBytes.Length);
                        for (int i = 0; i < NUM_OF_UDP_PACKET; i++)
                        {
                            udpClient.Send(data, data.Length);
                        }
                        udpClient.Dispose();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void ListeningForConnections()
        {
            TcpListener = new TcpListener(IPAddress.Parse(LocalIP), (int)TcpFamily.DefaultPort);
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
                    SendUsersList();
                    Task.Factory.StartNew(() => ListenTCP(UserList[UserList.IndexOf(user)]));
                }
                catch { }
            }
        }

        private void ListenTCP(User user)
        {
            while (user.Listen)
            {
                if (user.stream.DataAvailable)
                {
                    var typeAndLength = user.ReciveTypeAndLength();
                    var messageType = typeAndLength[0];
                    var messageLength = BitConverter.ToInt32(typeAndLength, 1);
                    switch (messageType)
                    {
                        case (int)TcpFamily.typeFailed:
                        case (int)TcpFamily.TypeDisconnect:
                            user.Listen = false;
                            UserList.Remove(user);
                            user.Dispose();
                            SendUsersList();
                            break;
                        case (int)TcpFamily.typeNickname:
                            try
                            {
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
        }

        private void Disconnect()
        {
            foreach (var user in UserList)
            {
                user.Listen = false;
                user.SendDisconnect();
                user.Dispose();
            }
            UserList.Clear();
        }

        private void SendUsersList()
        {
            bool Failed = false;
            foreach (var user in UserList)
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
            if (Failed)
            {
                SendUsersList();
            }
        }
    }
}
