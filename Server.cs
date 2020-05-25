using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
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
            return SendMessage(TcpFamily.TYPE_DISCONNECT);
        }

        public bool SendRequestList()
        {
            if (!SendMessage(TcpFamily.TYPE_REQUEST_USER_LIST))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool SendNickname()
        {
            if (!SendMessage(TcpFamily.TYPE_NICKNAME, this.Username))
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
                tcpClient.Connect(new IPEndPoint(IPv4Address, TcpFamily.DEFAULT_PORT));
                stream = tcpClient.GetStream();
                return true;
            }
            catch
            {
                return false;
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
