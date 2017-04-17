using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
namespace Server1
{
    public delegate void answer(int id, string msg);
    /// <summary>
    /// the model of the project that has all the main class we want to acess
    /// </summary>
    class MazeModel
    { 
        private Dictionary<string, ICommandable> commandDic;
        public Dictionary<string, Game> games;
        public Dictionary<string, Maze> Mazes;
        public Dictionary<string, SolutionDetails> Sol;

        const int BFS = 0;
        const int DFS1 = 1;
        
        private answer ans;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="h">height </param>
        /// <param name="w">width</param>

        public MazeModel(int h, int w)
        {
            games = new Dictionary<string, Game>();
            commandDic = new Dictionary<string, ICommandable>();
            commandDic.Add("generate", new Option1());
            commandDic.Add("solve", new Option2());
            commandDic.Add("start", new Option3());
            commandDic.Add("list", new Option4());
            commandDic.Add("join", new Option5());
            commandDic.Add("play", new Option6());
            commandDic.Add("close", new Option7());


        }
        /// <summary>
        /// get maze from this.Mazes and create in the way given 
        /// if there is not
        /// </summary>
        /// <param name="name">maze name</param>
        /// <param name="way">way to generte the maze</param>
        /// <returns>Imaze with the name </returns>
        public Maze GetMaze(string name, int row, int col)
        {
            Maze m;
            if (Mazes.ContainsKey(name))
            {
                m = Mazes[name];

                return m;
            }

            else {
                IMazeGenerator mg = new DFSMazeGenerator();
                m = mg.Generate(row, col);
                return m;
            }
        }

        /// <summary>
        /// get solutionMatrix of maze with 
        /// name arg the was solve in arg way 
        /// create if there is not
        /// </summary>
        /// <param name="name">maze name</param>
        /// <param name="way">the wat to solve</param>
        /// <returns></returns>
        public SolutionDetails GetSolve(string name, int way)
        {
            if (way == DFS1)
            {
                SolutionDetails sim;
                if (Sol.TryGetValue(name, out sim))
                {
                    return sim;
                }
                BestFS best = new BestFS();
                IMaze i;
                Mazes.TryGetValue(name, out i);
                if (i == null)
                {
                    return null;
                }
                Solution s = best.search(new SearchableMaze(i));
                sim = i.PutSolve(s);
                BestSol.Add(name, sim);
                SaveSol(way);
                return sim;
            }
            else
            {
                SolutionInMatrix sim;
                if (DFSol.TryGetValue(name, out sim))
                {
                    return sim;
                }
                BreadthFS breadt = new BreadthFS();
                IMaze i;
                Mazes.TryGetValue(name, out i);
                if (i == null)
                {
                    return null;
                }

                Solution s = breadt.search(new SearchableMaze(i));
                sim = i.PutSolve(s);
                DFSol.Add(name, sim);
                SaveSol(way);
                return sim;
            }
        }
        public Dictionary<string, SolutionInMatrix> LoadSol(string file)
        {
            Dictionary<string, SolutionInMatrix> dict = new Dictionary<string, SolutionInMatrix>();
            if (File.Exists(file))
            {


                string js = File.ReadAllText(file);
                dict = JsonConvert.DeserializeObject<Dictionary<string, SolutionInMatrix>>(js);
            }
            return dict;
        }

        public void SaveSol(int way)
        {
            string s;
            string file;

            if (way == DFS1)
            {

                s = JsonConvert.SerializeObject(this.BestSol, Formatting.Indented);
                file = "BestSol.json";

            }
            else
            {
                s = JsonConvert.SerializeObject(this.DFSol, Formatting.Indented);
                file = "BFSol.json";

            }
            File.WriteAllText(file, s);
        }
        /// <summary>
        /// close game with argm name
        /// </summary>
        /// <param name="name">name of game to close</param>
        public void close(string name)
        {
            this.games.Remove(name);
        }
        /// <summary>
        /// get id of the game which the 
        /// player with id play
        /// </summary>
        /// <param name="id">player id</param>
        /// <returns>game</returns>
        public Game GetGameAcId(int id)
        {
            foreach (var x in this.games)
            {
                if (x.Value.IsExistClient(id))
                {
                    return x.Value;
                }
            }
            return null;
        }
        /// <summary>
        /// add game to the model 
        /// </summary>
        /// <param name="name">game name</param>
        /// <returns>game we created</returns>
        public Game AddGame(string name)
        {
            Game g = new Game(name, height, width);
            this.games.Add(name, g);
            return g;
        }
        /// <summary>
        /// get game with the name 
        /// create if there is none
        /// </summary>
        /// <param name="name">game name</param>
        /// <returns>game with name</returns>
        public Game GetGame(string name)
        {
            Game g;
            games.TryGetValue(name, out g);
            if (g != null)
            {
                return g;
            }
            else
            {
                return AddGame(name);
            }
        }
        /// <summary>
        /// get the commend and split it
        /// to send to right commend
        /// </summary>
        /// <param name="id">id of socket</param>
        /// <param name="task">the task/commend</param>
        public void DoTask(int id, string task)
        {
            string[] commend = task.Split(' ');
            string com = commend[0];
            task = task + " " + id;
            Package1 msn = commandDic[com].execute(task, this, id);
            foreach (var x in msn.idMsg)
            {
                this.ans(x.Key, x.Value);
            }
        }
        /// <summary>
        /// and listner to answer to
        /// </summary>
        /// <param name="ans1">the answer</param>
        public void addListner(answer ans1)
        {
            this.ans += ans1;
        }
        public Dictionary<string, IMaze> load()
        {
            MazeSelizer dict = new MazeSelizer();
            if (File.Exists("MazeDict.json"))
            {
                string json = File.ReadAllText("MazeDict.json");
                dict.SetLstOfSer(json);
            }
            return dict.GetLstOfSer();
        }
        public Dictionary<string, Game> loadGame()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            if (File.Exists("Games.json"))
            {
                string json = File.ReadAllText("Games.json");
                Dictionary<string, Game> m = ser.Deserialize<Dictionary<string, Game>>(json);
                return m;
            }
            return new Dictionary<string, Game>();
        }


    }
}
