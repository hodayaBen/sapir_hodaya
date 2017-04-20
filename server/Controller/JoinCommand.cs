using System.Net.Sockets;
using server.Model;
namespace server.Controller
{
    public class JoinCommand : ICommand
    {
        private IModel model;
        public JoinCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            Game g = model.JoinGame(name, client);
            return g.ToJSON();
        }
    }
}