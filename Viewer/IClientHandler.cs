using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
//tcplistener
using System.Net.Sockets;
//ipendpoint
using System.Net;
using Controller;
namespace Viewer
{ 
    interface IClientHandler
    {
        void HandleClient(TcpClient client,Controller.Controller controller);
    }
}
