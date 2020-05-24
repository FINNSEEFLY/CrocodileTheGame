using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CrocodileTheGame
{
    class Server : ConnectionEntity, IDisposable
    {
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
