using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrocodileTheGame
{
    class Server : ConnectionEntity, IDisposable
    {
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
