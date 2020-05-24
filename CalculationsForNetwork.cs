using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CrocodileTheGame
{
    public static class  CalculationsForNetwork
    {
        public static string GetBroadcastAddress(string localip)
        {
            var ipInBytes = IPAddress.Parse(localip).GetAddressBytes();
            ipInBytes[3] = 255;
            return new IPAddress(ipInBytes).ToString();
        }
        public static string GetLocalIP()
        {
            string localIP;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0);
            try
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint point = socket.LocalEndPoint as IPEndPoint;
                localIP = point.Address.ToString();
            }
            catch
            {
                IPEndPoint point = socket.LocalEndPoint as IPEndPoint;
                localIP = point.Address.ToString();
            }
            return localIP;
        }
    }
}
