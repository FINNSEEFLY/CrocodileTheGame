﻿using System;
using System.Collections.Generic;
using System.Text;
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
            return SendMessage(TcpConst.TYPE_USER_LIST, data);
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
            return SendMessage(TcpConst.TYPE_USER_LIST, data);
        }
        public void SendDisconnect()
        {
            SendMessage(TcpConst.TYPE_DISCONNECT);
        }
        public void SendKick()
        {
            SendMessage(TcpConst.TYPE_KICK);
        }
        public bool SendRounds(int currentround, int maxround)
        {
            string str = currentround + " / " + maxround;
            return SendMessage(TcpConst.TYPE_ROUNDS, str);
        }
        public bool SendUserResults(string result)
        {
            return SendMessage(TcpConst.TYPE_RESULT, result);
        }
        public bool SendBeginGame()
        {
            return SendMessage(TcpConst.TYPE_BEGIN_GAME);
        }
        public bool SendTime(string time)
        {
            return SendMessage(TcpConst.TYPE_TIME, time);
        }
        public bool SendHeader(string message)
        {
            return SendMessage(TcpConst.TYPE_HEADER, message);
        }
        public bool SendPrepareChatter()
        {
            return SendMessage(TcpConst.TYPE_YOU_CHATTER);
        }
        public bool SendPrepareLeader()
        {
            return SendMessage(TcpConst.TYPE_YOU_LEADER);
        }
        public bool SendClearCanvas()
        {
            return SendMessage(TcpConst.TYPE_CLEAR_CANVAS);
        }
        public bool SendFillCanvas(Color color)
        {
            var data = new byte[3];
            data[0] = color.R;
            data[1] = color.G;
            data[2] = color.B;
            return SendMessage(TcpConst.TYPE_FILL_CANVAS, data);
        }
        public bool SendFillCanvas(byte[] data)
        {
            return SendMessage(TcpConst.TYPE_FILL_CANVAS, data);
        }
        public bool SendDot(byte[] data)
        {
            return SendMessage(TcpConst.TYPE_DOT, data);
        }
        public bool SendDot(Color color, byte radius, int x, int y)
        {
            var data = new byte[3 + 1 + 4 + 4];
            data[0] = color.R;
            data[1] = color.G;
            data[2] = color.B;
            data[3] = radius;
            Buffer.BlockCopy(BitConverter.GetBytes(x), 0, data, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(y), 0, data, 8, 4);
            return SendMessage(TcpConst.TYPE_DOT, data);
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
