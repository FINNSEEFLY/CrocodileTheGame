using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CrocodileTheGame
{
    class User : IDisposable
    {
        public TcpClient tcpClient;
        public NetworkStream stream;
        private object locker = new object();
        public string Username { get; set; }
        public IPAddress IPv4Address { get; set; }
        public bool Listen { get; set; } = true;

        public void SendUserList(List<User> list)
        {
            int countOfUsers = list.Count;
            int lengthNicknames = 0;
            lock (locker)
            {
                foreach (User user in list)
                {
                    lengthNicknames += Encoding.UTF8.GetBytes(user.Username).Length;
                }

                int sizeOfData = 1 + lengthNicknames + (countOfUsers + 1) * sizeof(int);
                var data = new byte[sizeOfData];
                data[0] = (byte)TcpFamily.TypeSendUserList;
                int offset = 1;
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
                int zero = 0;
                var zeroBytes = BitConverter.GetBytes(zero);
                Buffer.BlockCopy(zeroBytes, 0, data, offset, zeroBytes.Length);
            }
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
