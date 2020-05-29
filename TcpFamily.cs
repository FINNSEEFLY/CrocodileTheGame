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
        // Не содержат тела
        public const int TYPE_FAILED = 0;
        public const int TYPE_DISCONNECT = 1;
        public const int TYPE_KICK = 2;
        public const int TYPE_REQUEST_USER_LIST = 3;
        public const int TYPE_BEGIN_GAME = 4;
        public const int TYPE_YOU_LEADER = 5;
        public const int TYPE_YOU_CHATTER = 6;
        public const int TYPE_CLEAR_CANVAS = 7;
        // Содержат тело
        public const int TYPE_USER_LIST = 8;       
        public const int TYPE_NICKNAME = 9;
        public const int TYPE_ROUNDS = 10;
        public const int TYPE_RESULT = 11;
        public const int TYPE_TIME = 12;
        public const int TYPE_MESSAGE = 13;
        public const int TYPE_DOT = 14;
        public const int TYPE_FILL_CAVNAS = 15;
        public const int TYPE_HEADER = 16;
    }
}
