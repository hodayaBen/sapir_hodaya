using System.Net.Sockets;
using server.View;
namespace server.Controller
{
    /// <summary>
    ///  command pattern that just execute a method by order name
    /// </summary>
    interface ICommand
    {
        //string Execute(string[] args, TcpClient client = null);
        string Execute(string[] args, IClientHandler client = null);
    }
}
