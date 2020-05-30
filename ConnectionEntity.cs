using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace CrocodileTheGame
{
    public class ConnectionEntity
    {
        public TcpClient tcpClient;
        public NetworkStream stream;
        public string Username { get; set; }
        public IPAddress IPv4Address { get; set; }
        public bool Listen { get; set; } = true;

        public byte[] ReciveTypeAndLength()
        {
            try
            {
                var receiveData = new byte[5];
                var numOfReciviedBytes = stream.Read(receiveData, 0, receiveData.Length);
                var returnData = new byte[numOfReciviedBytes];
                Buffer.BlockCopy(receiveData, 0, returnData, 0, numOfReciviedBytes);
                return returnData;
            }
            catch
            {
                return new byte[1];
            }
        }
        
        public byte[] ReceiveMessage(int messagelength)
        {
            var receiveData = new byte[messagelength];
            var numOfReceivedBytes = stream.Read(receiveData, 0, receiveData.Length);
            var returnData = new byte[numOfReceivedBytes];
            Buffer.BlockCopy(receiveData, 0, returnData, 0, numOfReceivedBytes);
            return returnData;
        }

        public bool SendMessage(byte type, string message)
        {
            try
            {
                var messageBytes = Encoding.UTF8.GetBytes(message);
                var data = new byte[1 + sizeof(int) + messageBytes.Length];
                data[0] = type;
                var messageLengthBytes = BitConverter.GetBytes(messageBytes.Length);
                Buffer.BlockCopy(messageLengthBytes, 0, data, 1, sizeof(int));
                Buffer.BlockCopy(messageBytes, 0, data, 1 + sizeof(int), messageBytes.Length);
                stream.Write(data, 0, data.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SendMessage(byte type, byte[] messageBytes)
        {
            try
            {
                var data = new byte[1 + sizeof(int) + messageBytes.Length];
                data[0] = type;
                var messageLengthBytes = BitConverter.GetBytes(messageBytes.Length);
                Buffer.BlockCopy(messageLengthBytes, 0, data, 1, sizeof(int));
                Buffer.BlockCopy(messageBytes, 0, data, 1 + sizeof(int), messageBytes.Length);
                stream.Write(data, 0, data.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SendMessage(byte type)
        {
            try
            {
                var data = new byte[5];
                data[0] = type;
                stream.Write(data, 0, data.Length);
                return true;
            }
            catch 
            {
                return false;
            };
        }
  
    }
}
