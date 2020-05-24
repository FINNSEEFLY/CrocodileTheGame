using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CrocodileTheGame
{
    class User : ConnectionEntity, IDisposable
    {
        public User()
        {
            var rand = new Random();
            Username = "Player#" + rand.Next(0, 9999);
        }

        public bool SendUserList(List<User> list)
        {
            int countOfUsers = list.Count;
            int lengthNicknames = 0;
            foreach (User user in list)
            {
                lengthNicknames += Encoding.UTF8.GetBytes(user.Username).Length;
            }

            int sizeOfData = lengthNicknames + countOfUsers * sizeof(int);
            var data = new byte[sizeOfData];
            int offset = 0;
            foreach (User user in list)
            {
                var usernameBytes = Encoding.UTF8.GetBytes(user.Username);
                int usernameBytesLength = usernameBytes.Length;
                byte[] lengthBytes = BitConverter.GetBytes(usernameBytesLength);
                Buffer.BlockCopy(lengthBytes, 0, data, offset, lengthBytes.Length);
                offset += lengthBytes.Length;
                Buffer.BlockCopy(usernameBytes, 0, data, offset, usernameBytes.Length);
                offset += usernameBytes.Length;
            }
            return SendMessage(TcpFamily.TYPE_USER_LIST, data);
        }

        public void SendDisconnect()
        {
            SendMessage(TcpFamily.TYPE_DISCONNECT);
        }

        public void SendKick()
        {
            SendMessage(TcpFamily.TYPE_KICK);
        }

        public void Dispose()
        {
            try
            {
                stream.Dispose();
                tcpClient.Dispose();
            }
            catch { }
        }
    }
}
