using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using server.Model;
using server.View;
namespace server.Controller
{
    public class GenerateMazeCommand : ICommand
    {
        private IModel model;
        public GenerateMazeCommand(IModel model)
        {
            this.model = model;
        }
        //public string Execute(string[] args, TcpClient client)
        public string Execute(string[] args, IClientHandler client)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            Maze maze = model.GenerateMaze(name, rows, cols);

            return maze.ToJSON();
        }
    }
}