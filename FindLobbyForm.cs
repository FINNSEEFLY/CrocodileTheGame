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
    public partial class FindLobbyForm : Form
    {
        private string LocalIP;
        private string NickName;
        private string UdpBroadcastAddress;
        private bool IsWaiting;
        public event StringTransfer TakeNickname;
        public delegate string StringTransfer();
        public FindLobbyForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Dispose();
        }

        private void FindLobbyForm_Load(object sender, EventArgs e)
        {
            NickName = TakeNickname();
            LocalIP = CalculationsForNetwork.GetLocalIP();
            UdpBroadcastAddress = CalculationsForNetwork.GetBroadcastAddress(LocalIP);
            MessageBox.Show("Nickname = " + NickName + ";\nLocalIP = " + LocalIP + ";\nBroadcastIP = " + UdpBroadcastAddress);
            IsWaiting = true;
            UserList = new List<User>();
            ltPlayers.DataSource = UserList;
            ltPlayers.DisplayMember = "Username";
            ltPlayers.ValueMember = "IPv4Address";
            Task.Factory.StartNew(ListenBroadcastUDP);
            Task.Factory.StartNew(ListeningForConnections);
        }
    }
}
