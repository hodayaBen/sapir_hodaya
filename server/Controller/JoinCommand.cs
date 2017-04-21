using System.Net.Sockets;
using server.Model;
using server.View;
namespace server.Controller
{
    /// <summary>
    /// add a client to game
    /// </summary>
    public class JoinCommand : ICommand
    {
        private IModel model;
        public JoinCommand(IModel model)
        {
            this.model = model;
        }
        // public string Execute(string[] args, TcpClient client)
        public string Execute(string[] args, ICClientHandler client)
        {
            string name = args[0];
            Game g = model.JoinGame(name, client);
            if (g != null)
            {
                return g.ToJSON();
            }
            else
            {
                return "no such available game";
            }
        }
    }
}