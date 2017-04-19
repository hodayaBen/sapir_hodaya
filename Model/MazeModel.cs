using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
using System.Net.Sockets;

namespace Model
{
   // public delegate void answer(int id, string msg);
    /// <summary>
    /// the model of the project that has all the main class we want to acess
    /// </summary>
   public class MazeModel : IModel
    {

        public Dictionary<string, Game> games { get; set; }
        public Dictionary<TcpClient, string> clientInGames { get; set; }
        public Dictionary<string, Maze> Mazes { get; set; }
        public Dictionary<string, SolutionDetails<Direction>> Sol { get; set; }


        const int BFS = 0;
        const int DFS1 = 1;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="h">height </param>
        /// <param name="w">width</param>

        public MazeModel(Contr)
        {
            Mazes = new Dictionary<string, Maze>();
            games = new Dictionary<string, Game>();
            Sol = new Dictionary<string, SolutionDetails<Direction>>();
            clientInGames = new Dictionary<TcpClient, string>();
        }

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

            sol_det = new SolutionDetails<Direction>(s.search(new SearchableMaze(maze)), s.getNumberOfNodesEvaluated());

            Sol.Add(name, sol_det);
            return sol_det;
        }

        public string StartGame(string name, int rows, int cols, TcpClient client)
        {
            if (games.ContainsKey(name))
            {
                return "there is such game";
            }
            else
            {
                Game g = new Game(name, rows, cols);
                g.AddClient(client);
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

        public Game JoinGame(string name, TcpClient client)
        {
            Game g;
            if (games.TryGetValue(name, out g))
            {
                g.AddClient(client);
                
                return g;
            }
            else
            {
                return null;
            }
        }

        public string Play(string move, TcpClient client)
        {
            throw new NotImplementedException();
        }

        public string Close(string name)
        {
            throw new NotImplementedException();
        }
    }
}
