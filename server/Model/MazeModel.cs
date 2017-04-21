using System.Collections.Generic;
using System.Text;
using MazeGeneratorLib;
using MazeLib;
using System.Net.Sockets;
using SearchAlgorithmsLib;
using System;
using server.Controller;
namespace server.Model
{
   
    /// <summary>
    /// the model of the project that has all the main class we want to acess
    /// </summary>
    public class MazeModel : IModel
    {
        //contains
        public Dictionary<string, Game> games { get; set; }
        //contain value  ICClientHandler-class that manage connection with one client
        // according name of maze
        public Dictionary<ICClientHandler, string> clientInGames { get; set; }
        //contains value maze acorrding key name of maze
        public Dictionary<string, Maze> Mazes { get; set; }
        public Dictionary<string, SolutionDetails<Direction>> Sol { get; set; }
        public Controller.Controller controller { get; set; }
        const int BFS = 0;
        const int DFS1 = 1;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conr">recive controller </param>

        public MazeModel(Controller.Controller conr)
        {
            Mazes = new Dictionary<string, Maze>();
            games = new Dictionary<string, Game>();
            Sol = new Dictionary<string, SolutionDetails<Direction>>();
            clientInGames = new Dictionary<ICClientHandler, string>();
            controller = conr;
        }
        /// <summary>
        /// commit task 1
        /// </summary>
        /// <param name="name">name maze</param>
        /// <param name="rows">row maze</param>
        /// <param name="cols">col maze</param>
        /// <returns></returns>
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            Maze m;
            if (Mazes.ContainsKey(name))
            { 
                return null;

            }
            else
            {
                IMazeGenerator mg = new DFSMazeGenerator();
                m = mg.Generate(rows, cols);
                m.Name = name;
                this.Mazes.Add(name, m);
                return m;
            }
        }

        public SolutionDetails<Direction> SolveMaze(string name, int algo)
        {
            SolutionDetails<Direction> sol_det;
            Searcher<Position, Direction> s;
            if (Sol.TryGetValue(name, out sol_det))
            {
                return sol_det;
            }
            Maze maze;
            Mazes.TryGetValue(name, out maze);
            if (maze == null)
            {
                return null;
            }
            if (algo == BFS)
            {
                s = new BestFS();
            }
            else
            {
                s = new DFS();
            }

            sol_det = s.search(new SearchableMaze(maze));
            //sol_det = new SolutionDetails<Direction>(s.search(new SearchableMaze(maze)), s.getNumberOfNodesEvaluated());
            Sol.Add(name, sol_det);
            return sol_det;
        }

        //public string StartGame(string name, int rows, int cols, TcpClient client)
        public string StartGame(string name, int rows, int cols, ICClientHandler client)
        {
            if (games.ContainsKey(name))
            {
                return "there is such game";
            }
            else
            {
                Game g = new Game(name, rows, cols);
                g.AddClient(client);
                clientInGames.Add(client, name);
                this.games.Add(name, g);
                return "wait for the second player";
            }
        }

        public string list()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[\n");
            foreach (Game g in games.Values)
            {
                if (g.numOfClient == 1)
                {
                    sb.Append(g.GetName());
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        //public Game JoinGame(string name, TcpClient client)
        public Game JoinGame(string name, ICClientHandler client)
        {
            Game g;
            if (games.TryGetValue(name, out g))
            {
                if (g.numOfClient == 1)
                {
                    g.AddClient(client);
                    this.clientInGames.Add(client, name);
                    //   Console.WriteLine("check" + g.ToJSON());
                    controller.SendToClient(g.GetSecondPlayer(client), g.ToJSON());
                    return g;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //public string Play(string move, TcpClient client)
        public string Play(string move, ICClientHandler client)
        {
            string name;
            Game g;
            if (clientInGames.TryGetValue(client, out name))
            {
                if (games.TryGetValue(name, out g))
                {
                    string s = g.Play(move, client);
                    controller.SendToClient(g.GetSecondPlayer(client), s);
                    return "got your move, and sent it to the second client";
                }
            }
            return "the game not found";
        }

        //public string Close(string name, TcpClient client)
        public string Close(string name, ICClientHandler client)
        {
            Game g;
            ICClientHandler secondClient = null;
            if (games.TryGetValue(name, out g))
            {
                secondClient = g.GetSecondPlayer(client);
                controller.SendToClient(secondClient, "close");
            }
            //update the DB
            this.games.Remove(name);
            this.clientInGames.Remove(client);
            this.clientInGames.Remove(secondClient);
            return "close";
        }
    }
}
