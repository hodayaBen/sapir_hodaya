using MazeLib;
using System.Net.Sockets;
using SearchAlgorithmsLib;
using server.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using server.View;
namespace server.Controller
{
    class SolveMazeCommand : ICommand
    {
        private IModel model;
        public SolveMazeCommand(IModel model)
        {
            this.model = model;
        }
        //public string Execute(string[] args, TcpClient client)
        public string Execute(string[] args, IClientHandler client)
        {
            string name = args[0];
            int algo = int.Parse(args[1]);
            SolutionDetails<Direction> sol= model.SolveMaze(name, algo);
            int num = sol.NodesEvaluated;
            PasrseSolve p = new PasrseSolve(name, sol.getSolve(),num);
            Console.WriteLine(JsonConvert.SerializeObject(p));
            return JsonConvert.SerializeObject(p);
           
        }
    }
}