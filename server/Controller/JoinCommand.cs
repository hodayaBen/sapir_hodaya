using System.Net.Sockets;
using server.Model;
using server.View;
namespace server.Controller
{
    public class JoinCommand : ICommand
    {
        private IModel model;
        public JoinCommand(IModel model)
        {
            this.model = model;
        }
        // public string Execute(string[] args, TcpClient client)
        public string Execute(string[] args, IClientHandler client)
        {
            string name = args[0];
            Game g = model.JoinGame(name, client);
            return g.ToJSON();
        }
    }
}