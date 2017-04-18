using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using MazeLib;
using MazeGeneratorLib;
namespace Server1
{
    public class GenerateMazeCommand : ICommand {
            private MazeModle model;
            public GenerateMazeCommand(IModel model) { this.model = model; }
            public string Execute(string[] args, TcpClient client)
            {
                string name = args[0];
                int rows = int.Parse(args[1]);
                int cols = int.Parse(args[2]);
                Maze maze = model.GenerateMaze(name, rows, cols);
                return maze.ToJSON();
            }
        }
    }
}