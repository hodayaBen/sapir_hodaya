using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Net.Sockets;

namespace Controller
{
    public class Controller
    {
        private Dictionary<string, ICommand> commands;
        private IModel model;
     
        public Controller()
        {
            model = new MazeModel();
            commands = new Dictionary<string, ICommand>();
            commands.Add("generate", new GenerateMazeCommand(model));
            commands.Add("Solve", new SolveMazeCommand(model));
        }


        public string ExecuteCommand(string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            return command.Execute(args, client);
        }
        public void SendMess(TcpClient client,string mazeString)
        {

        }
    }
    
}
