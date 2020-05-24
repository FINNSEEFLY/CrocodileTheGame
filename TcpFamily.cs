using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrocodileTheGame
{
    public static class TcpFamily
    {
        public const int DEFAULT_PORT = 1337;
        public const int TYPE_FAILED = 0;
        public const int TYPE_SEND_USER_LIST = 1;
        public const int TYPE_DISCONNECT = 2;
        public const int TYPE_NICKNAME = 4;
        public const int TYPE_KICK = 6;
    }
}
