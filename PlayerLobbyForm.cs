﻿using System;
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
    public partial class PlayerLobbyForm : Form
    {
        public string LocalIP { get; set; }
        public string Nickname { get; set; }
        public Server Server { get; set; }
        public bool OnlyThisListen { get; set; } = true;
        private List<string> PlayerList;
        private GameForm GameForm;
        public event BackToMain Back;
        public delegate void BackToMain();
        public event Free FinalFree;
        public delegate void Free();

        public PlayerLobbyForm()
        {
            InitializeComponent();
        }

        private void ListenTCP()
        {
            while (Server.Listen && OnlyThisListen)
            {
                try
                {
                    if (Server.stream.DataAvailable)
                    {
                        var typeAndLength = Server.ReciveTypeAndLength();
                        var messageType = typeAndLength[0];
                        switch (messageType)
                        {
                            case TcpFamily.TYPE_FAILED:
                            case TcpFamily.TYPE_DISCONNECT:
                                MessageBox.Show("Лобби было закрыто хостом.");
                                CloseForm();
                                break;
                            case TcpFamily.TYPE_KICK:
                                MessageBox.Show("Вас исключили из лобби.");
                                CloseForm();
                                break;
                            case TcpFamily.TYPE_USER_LIST:
                                var messageLength = BitConverter.ToInt32(typeAndLength, 1);
                                try
                                {
                                    var message = Server.ReceiveMessage(messageLength);
                                    PlayerList.Clear();
                                    PlayerList = Server.ParseStringList(message, messageLength);
                                    this.Invoke(new MethodInvoker(() =>
                                    {
                                        UpdatePlayerList();
                                    }));
                                }
                                catch
                                {
                                    MessageBox.Show("Ошибка, получен поврежденный пакет, соединение будет разорвано");
                                    CloseForm();
                                }
                                break;
                            case TcpFamily.TYPE_BEGIN_GAME:
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    OnlyThisListen = false;
                                    GameForm = new GameForm(UserTypes.TYPE_USER);
                                    GameForm.FinalFree += ClosingWithGameForm;
                                    GameForm.Nickname = Nickname;
                                    GameForm.Server = Server;
                                    GameForm.BackToMain += BackToMainForm;
                                    GameForm.Owner = this;
                                    GameForm.Show();
                                    this.Hide();
                                }));
                                break;
                            default:
                                throw new Exception("Неизвестный тип пакета!");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Потеряно соединение с сервером");
                    CloseForm();
                };
            }
        }

        private void UpdatePlayerList()
        {
            ltPlayers.Items.Clear();

            foreach (var player in PlayerList)
            {
                ltPlayers.Items.Add(player);
            }
        }

        private void FreeResources()
        {
            Server.Listen = false;
            Server.Dispose();
        }

        private void CloseForm()
        {
            FreeResources();
            Back();
        }

        private void LobbyPlayerForm_Load(object sender, EventArgs e)
        {
            PlayerList = new List<string>();
            Server.SendNickname(Nickname);
            Task.Factory.StartNew(ListenTCP);
            Server.SendRequestList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Server.SendDisconnect();
            CloseForm();
        }

        private void BackToMainForm()
        {
            GameForm.Dispose();
            Back();
        }

        private void PlayerLobbyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Server.SendDisconnect();
            FreeResources();
            FinalFree();
        }

        private void ClosingWithGameForm()
        {
            GameForm.Dispose();
            FinalFree();
        }
    }
}
