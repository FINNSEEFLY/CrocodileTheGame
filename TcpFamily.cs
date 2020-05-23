using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrocodileTheGame
{
    public enum TcpFamily
    {
        DefaultPort = 1337,
        TypeSendUserList = 1,
        TypeDisconnect = 2,
        typeNickname = 4,
        typeFailed = 0
    }
}
