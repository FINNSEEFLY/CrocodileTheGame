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
        public event StringTransfer TakeIP;
        public event StringTransfer TakeNickname;
        public event ServerTransfer TakeServer;
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
                if (Server.stream.DataAvailable)
                {
                    var typeAndLength = Server.ReciveTypeAndLength();
                    var messageType = typeAndLength[0];
                    switch (messageType)
                    {
                        case TcpFamily.TYPE_FAILED:
                        case TcpFamily.TYPE_DISCONNECT:
                            
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
        }

        private void LobbyPlayerForm_Load(object sender, EventArgs e)
        {
            LocalIP = TakeIP();
            Nickname = TakeNickname();
            Server = TakeServer();
            Server.SendNickname();
            Server.SendRequestList();
        }
    }
}
