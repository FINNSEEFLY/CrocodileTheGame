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
    public partial class FindLobbyForm : Form
    {
        private string LocalIP;
        private string NickName;
        private string UdpBroadcastAddress;
        private bool IsListening;
        private bool IsUpdating;
        private UdpClient UdpListener;
        private List<Server> LobbyList;
        public event StringTransfer TakeNickname;
        public delegate string StringTransfer();

        public FindLobbyForm()
        {
            InitializeComponent();
        }

        private void ListenBroadcastUDP()
        {
            UdpListener = new UdpClient(UdpFamily.BROADCAST_PORT);
            UdpListener.EnableBroadcast = true;
            while (IsListening)
            {
                try
                {
                    IPEndPoint remoteHost = null;
                    var recievedData = UdpListener.Receive(ref remoteHost);
                    if (recievedData[0] == UdpFamily.TYPE_SERVER_EXIST)
                    {
                        if (!LobbyExist(remoteHost.Address)) {
                            var lobby = new Server();
                            lobby.IPv4Address = remoteHost.Address;
                            lobby.Username = Encoding.UTF8.GetString(recievedData, 1, recievedData.Length - 1);
                            LobbyList.Add(lobby);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            IsListening = false;
            UdpListener.Dispose();
            Owner.Show();
            Dispose();
        }

        private void FindLobbyForm_Load(object sender, EventArgs e)
        {
            NickName = TakeNickname();
            LocalIP = CalculationsForNetwork.GetLocalIP();
            UdpBroadcastAddress = CalculationsForNetwork.GetBroadcastAddress(LocalIP);
            MessageBox.Show("Nickname = " + NickName + ";\nLocalIP = " + LocalIP + ";\nBroadcastIP = " + UdpBroadcastAddress);
            IsListening = true;
            LobbyList = new List<Server>();
            ltLobby.DataSource = LobbyList;
            ltLobby.DisplayMember = "Username";
            ltLobby.ValueMember = "IPv4Address";
            Task.Factory.StartNew(ListenBroadcastUDP);
        }

        public void ClearServerList()
        {
            foreach (var server in LobbyList)
            {
                server.Dispose();
            }
            LobbyList.Clear();
            UpdateLobbyList();
        }

        public void SendFindMessage()
        {
            var udpClient = new UdpClient(UdpBroadcastAddress, UdpFamily.BROADCAST_PORT);
            udpClient.EnableBroadcast = true;
            var data = new byte[1];
            data[0] = UdpFamily.TYPE_CLIENT_REQUEST;
            for (int i = 0; i < UdpFamily.NUM_OF_UDP_PACKET; i++)
            {
                udpClient.Send(data, data.Length);
            }
            udpClient.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsUpdating)
            {
                IsUpdating = true;
                ClearServerList();
                SendFindMessage();
                IsUpdating = false;
            }
        }
        private void UpdateLobbyList()
        {
            ltLobby.DataSource = null;
            ltLobby.DataSource = LobbyList;
            ltLobby.DisplayMember = "Username";
            ltLobby.ValueMember = "IPv4Address";
        }
        
        private bool LobbyExist(IPAddress ip)
        {
            bool result = false;
            foreach(var lobby in LobbyList)
            {
                if (lobby.IPv4Address.Equals(ip))
                {
                    result = true;
                    break;
                } 
            }
            return result;
        }
    }
}
