using System.Net.Sockets;

namespace server.Controller
{
    /// <summary>
    ///  command pattern that just execute a method by order name
    /// </summary>
    interface ICommand
    {
        string Execute(string[] args, TcpClient client = null);
    }
}
