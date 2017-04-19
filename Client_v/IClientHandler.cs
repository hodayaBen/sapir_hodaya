﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client_v
{
    /// <summary>
    /// interface of the methods of
    /// communication that are separate 
    /// to allow to send message even if we didnt 
    /// recived a anwser to prev send
    /// </summary>
    public interface IClientHandler {
        void HandleClient(TcpClient client);
    }
}
