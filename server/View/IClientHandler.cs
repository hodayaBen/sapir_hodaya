//tcplistener
using System.Net.Sockets;

namespace server.View
{
    interface IClientHandler
    {
        void HandleClient(TcpClient client, Controller.Controller controller);
    }
}
