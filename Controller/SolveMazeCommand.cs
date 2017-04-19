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
using System.Net.Sockets;
using SearchAlgorithmsLib;

namespace Controller
{
    class SolveMazeCommand : ICommand {
        private MazeModle model;
        public SolveMazeCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int algo = int.Parse(args[1]);

            SolutionDetails sol = model.SolveMaze(name, algo);
            return Sol.ToJSON();
        }
    }
}