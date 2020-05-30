using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Drawing;

namespace CrocodileTheGame
{
    public class User : ConnectionEntity, IDisposable
    {
        public bool IsHost { get; set; } = false;

        public int Score { get; set; } = 0;

        public int NumOfLeads { get; set; } = 0;

        public User()
        {
            var rand = new Random();
            Username = "Player#" + rand.Next(0, 9999);
        }

        public bool SendUserListInGame(List<User> list)
        {
            int countOfUsers = list.Count;
            int lengthNicknames = 0;
            foreach (User user in list)
            {
                lengthNicknames += Encoding.UTF8.GetBytes(user.Username + " | " + user.Score).Length;
            }

            int sizeOfData = lengthNicknames + countOfUsers * sizeof(int);
            var data = new byte[sizeOfData];
            int offset = 0;
            foreach (User user in list)
            {
                var usernameBytes = Encoding.UTF8.GetBytes(user.Username + " | " + user.Score);
                int usernameBytesLength = usernameBytes.Length;
                byte[] lengthBytes = BitConverter.GetBytes(usernameBytesLength);
                Buffer.BlockCopy(lengthBytes, 0, data, offset, lengthBytes.Length);
                offset += lengthBytes.Length;
                Buffer.BlockCopy(usernameBytes, 0, data, offset, usernameBytes.Length);
                offset += usernameBytes.Length;
            }
            return SendMessage(TcpFamily.TYPE_USER_LIST, data);
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

        public bool SendRounds(int currentround, int maxround)
        {
            string str = currentround + " / " + maxround;
            return SendMessage(TcpFamily.TYPE_ROUNDS, str);
        }

        public bool SendUserResults(string result)
        {
            return SendMessage(TcpFamily.TYPE_RESULT, result);
        }

        public bool SendBeginGame()
        {
            return SendMessage(TcpFamily.TYPE_BEGIN_GAME);
        }

        public bool SendTime(string time)
        {
            return SendMessage(TcpFamily.TYPE_TIME, time);
        }

        public bool SendHeader(string message)
        {
            return SendMessage(TcpFamily.TYPE_HEADER, message);
        }

        public bool SendPrepareChatter()
        {
            return SendMessage(TcpFamily.TYPE_YOU_CHATTER);
        }
       
        public bool SendPrepareLeader()
        {
            return SendMessage(TcpFamily.TYPE_YOU_LEADER);
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
