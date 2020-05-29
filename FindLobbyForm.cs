﻿using System;
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
using System.Threading;

namespace CrocodileTheGame
{
    public partial class FindLobbyForm : Form
    {
        private string LocalIP;
        public string Nickname { get; set; }
        private string UdpBroadcastAddress;
        private bool IsListening;
        private bool IsUpdating;
        private Server SelectedServer;
        private UdpClient UdpListener;
        private UdpClient UdpSender;
        private List<Server> ServerList;
        private LobbyPlayerForm lobbyPlayerForm;

        public FindLobbyForm()
        {
            InitializeComponent();
        }

        private void ListenBroadcastUDP()
        {
            while (IsListening)
            {
                try
                {
                    IPEndPoint remoteHost = null;
                    var recievedData = UdpListener.Receive(ref remoteHost);
                    if (recievedData[0] == UdpFamily.TYPE_SERVER_EXIST)
                    {
                        if (!LobbyExist(remoteHost.Address))
                        {
                            ServerList.Add(new Server() { Username = Encoding.UTF8.GetString(recievedData, 1, recievedData.Length - 1), IPv4Address = remoteHost.Address });
                            this.Invoke(new MethodInvoker(() =>
                            {
                                UpdateServerList();
                            }));

                        }
                    }
                }
                catch //(Exception e)
                {
                    // MessageBox.Show(e.Message);
                }
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            IsListening = false;
            UdpListener.Dispose();
            UdpSender.Dispose();
            Owner.Show();
            Dispose();
        }

        private void FindLobbyForm_Load(object sender, EventArgs e)
        {
            LocalIP = CalculationsForNetwork.GetLocalIP();
            UdpBroadcastAddress = CalculationsForNetwork.GetBroadcastAddress(LocalIP);
            UdpListener = new UdpClient(UdpFamily.BROADCAST_PORT);
            UdpListener.EnableBroadcast = true;
            UdpSender = new UdpClient(UdpBroadcastAddress, UdpFamily.BROADCAST_PORT);
            UdpSender.EnableBroadcast = true;
            MessageBox.Show("Nickname = " + Nickname + ";\nLocalIP = " + LocalIP + ";\nBroadcastIP = " + UdpBroadcastAddress);
            IsListening = true;
            ServerList = new List<Server>();
            ltLobby.DataSource = ServerList;
            ltLobby.DisplayMember = "Username";
            ltLobby.ValueMember = "IPv4Address";
            Task.Factory.StartNew(ListenBroadcastUDP);
            SendFindMessage();
        }

        public void ClearServerList()
        {
            foreach (var server in ServerList)
            {
                server.Dispose();
            }
            ServerList.Clear();
        }

        public void SendFindMessage()
        {

            var data = new byte[1];
            data[0] = UdpFamily.TYPE_CLIENT_REQUEST;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsUpdating)
            {
                IsUpdating = true;
                ClearServerList();
                UpdateServerList();
                SendFindMessage();
                IsUpdating = false;
            }
        }

        private void UpdateServerList()
        {
            ltLobby.DataSource = null;
            ltLobby.DataSource = ServerList;
            ltLobby.DisplayMember = "Username";
            ltLobby.ValueMember = "IPv4Address";
        }

        private bool LobbyExist(IPAddress ip)
        {
            bool result = false;
            foreach (var lobby in ServerList)
            {
                if (lobby.IPv4Address.Equals(ip))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var server = ServerList.FirstOrDefault(someserver => someserver.IPv4Address.Equals(ltLobby.SelectedValue));
            if (server != null)
            {
                if (!server.Connect())
                {
                    MessageBox.Show("Подключение не удалось, данный узел не доступен");
                    server = ServerList[ServerList.IndexOf(server)];
                    ServerList.Remove(server);
                    this.Invoke(new MethodInvoker(() =>
                    {
                        UpdateServerList();
                    }));
                }
                else
                {
                    UdpSender.Dispose();
                    IsListening = false;
                    UdpListener.Dispose();
                    SelectedServer = server;
                    lobbyPlayerForm = new LobbyPlayerForm();
                    lobbyPlayerForm.Owner = this;
                    lobbyPlayerForm.LocalIP = LocalIP;
                    lobbyPlayerForm.Nickname = Nickname;
                    lobbyPlayerForm.Server = SelectedServer;
                    lobbyPlayerForm.Back += BackToMain;
                    lobbyPlayerForm.Show();
                    this.Hide();
                    MessageBox.Show("Подключение установлено");
                }
            }
        }
        private void BackToMain()
        {
            ClearServerList();

            BeginInvoke(new MethodInvoker(() =>
            {
                Owner.Show();
                lobbyPlayerForm.Dispose();
                Dispose();
            }));

        }

    }
}
