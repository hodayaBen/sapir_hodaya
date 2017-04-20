using MazeLib;
using System.Net.Sockets;
using SearchAlgorithmsLib;
using server.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
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
            Solution<Direction> sol= model.SolveMaze(name, algo);
            PasrseSolve p = new PasrseSolve(name, sol.getSolve(), sol.getSolve().Count);
            Console.WriteLine(JsonConvert.SerializeObject(p));
            return JsonConvert.SerializeObject(p);
           
        }
    }
}