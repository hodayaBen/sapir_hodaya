using MazeLib;
using System.Net.Sockets;
using SearchAlgorithmsLib;
using server.Model;
namespace server.Controller
{
    class SolveMazeCommand : ICommand
    {
        private IModel model;
        public SolveMazeCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int algo = int.Parse(args[1]);

            SolutionDetails<Direction> sol = model.SolveMaze(name, algo);
            return sol.ToJSON();
        }
    }
}