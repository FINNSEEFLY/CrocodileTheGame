using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Drawing;
using System.Net.Sockets;

namespace CrocodileTheGame
{
    public class Server : ConnectionEntity, IDisposable
    { 
        public List<string> ParseStringList(byte[] data, int length)
        {
            var result = new List<string>();
            int offset = 0;
            while (offset < length)
            {
                int usernameLength = BitConverter.ToInt32(data, offset);
                offset += sizeof(int);
                var usernameBytes = new byte[usernameLength];
                Buffer.BlockCopy(data, offset, usernameBytes, 0, usernameLength);
                offset += usernameLength;
                result.Add(Encoding.UTF8.GetString(usernameBytes));
            }
            return result;
        }

        public bool SendDisconnect()
        {
            return SendMessage(TcpConst.TYPE_DISCONNECT);
        }

        public bool SendRequestList()
        {
            if (!SendMessage(TcpConst.TYPE_REQUEST_USER_LIST))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool SendNickname(string nickname)
        {
            if (!SendMessage(TcpConst.TYPE_NICKNAME, nickname))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Connect()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(new IPEndPoint(IPv4Address, TcpConst.DEFAULT_PORT));
                stream = tcpClient.GetStream();
                return true;
            }
            catch
            {
                return false;
            }
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

        public bool SendDot(Color color, byte Radius, int x, int y)
        {
            var data = new byte[3 + 1 + 4 + 4];
            data[0] = color.R;
            data[1] = color.G;
            data[2] = color.B;
            data[3] = Radius;
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
