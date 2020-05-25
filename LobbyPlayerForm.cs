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
    public partial class LobbyPlayerForm : Form
    {
        private string LocalIP;
        private string Nickname;
        private Server Server;
        private List<string> PlayerList;
        public event StringTransfer TakeIP;
        public event StringTransfer TakeNickname;
        public event ServerTransfer TakeServer;
        public event BackToMain Back;
        public delegate void BackToMain();
        public delegate Server ServerTransfer();
        public delegate string StringTransfer();

        public LobbyPlayerForm()
        {
            InitializeComponent();
        }

        private void ListenTCP()
        {
            while (Server.Listen)
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
                                }
                                catch
                                {
                                    MessageBox.Show("Ошибка, получен поврежденный пакет, соединение будет разорвано");
                                    CloseForm();
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
                    CloseForm();
                };
            }
        }

        private void CloseForm()
        {
            Server.Listen = false;
            Server.Dispose();
            Back();
        }

        private void LobbyPlayerForm_Load(object sender, EventArgs e)
        {
            LocalIP = TakeIP();
            Nickname = TakeNickname();
            Server = TakeServer();
            PlayerList = new List<string>();
            Server.SendNickname();
            Task.Factory.StartNew(ListenTCP);
            Server.SendRequestList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Server.SendDisconnect();
            CloseForm();
        }
    }
}
