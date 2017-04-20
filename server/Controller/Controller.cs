using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using server.Model;
using System.Net.Sockets;
using server.View;
namespace server.Controller
{
    public class Controller
    {
        private Dictionary<string, ICommand> commands;
        private IModel model;
        private ClientSendMessage sender;
        public Controller()
        {
            model = new MazeModel(this);
            commands = new Dictionary<string, ICommand>();
            commands.Add("generate", new GenerateMazeCommand(model));
            commands.Add("solve", new SolveMazeCommand(model));
            commands.Add("start", new StartCommand(model));
            commands.Add("list", new ListCommand(model));
            commands.Add("join", new JoinCommand(model));
            commands.Add("play", new PlayCommand(model));
            commands.Add("close", new CloseCommand(model));
            sender = new ClientSendMessage();
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
        public void SendToClient(TcpClient client, string msg)
        {
            sender.SendToClient(client, msg);
        }
    }

}
