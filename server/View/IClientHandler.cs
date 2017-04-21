//tcplistener
using System.Net.Sockets;

namespace server.View
{
    public interface IClientHandler
    {
        void HandleClient(TcpClient client, Controller.Controller controller);
        void sendMssage(string s);
    }
}
