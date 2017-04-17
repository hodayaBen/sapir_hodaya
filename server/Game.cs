//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web.Script.Serialization;
//using System.IO;


//namespace Server1
//{ /// <summary>
/// game save the maze of a mulitiplayer game 
/// </summary>
//    public class Game
//    {
//        private int Width;
//        private int Height;
//        private string Name;
//        public Dictionary<int, ActiveMaze> idOfClientAndMazes;
//        private Random r;
//        / <summary>
//        / constructor of Game
//        / </summary>
//        / <param name="myName">this.name</param>
//        / <param name="h">this.height</param>
//        / <param name="w">this.width</param>
//        public Game(string myName, int h, int w)
//        {
//            this.Height = h;
//            this.Width = w;
//            r = new Random();
//            Name = myName;
//            idOfClientAndMazes = new Dictionary<int, ActiveMaze>();
//        }

//        / <summary>
//        / add a player to game
//        / </summary>
//        / <param name="id">the player we wish to add id</param>
//        public void AddPlayer(int id)
//        {
//            ActiveMaze am = null;
//            if (this.idOfClientAndMazes.Count == 0)
//            {
//                DfsClass2 dfs = new DfsClass2(this.Height, this.Width);
//                IMaze maze = dfs.creatMaze(Name + "0");
//                am = new ActiveMaze(maze, maze.GetStart());
//            }
//            else
//            {
//                am = new ActiveMaze(this.idOfClientAndMazes.First().Value.getMaze(), idOfClientAndMazes.First().Value.GetStart());
//                int x = r.Next(am.GetHeight() - 1) + am.GetHeight() / 4;
//                if (x >= am.GetHeight())
//                {
//                    x = am.GetHeight() - 1;
//                }
//                int y = r.Next(am.GetWidth() - 1) + am.GetWidth() / 4;
//                if (y >= am.GetWidth())
//                {
//                    y = am.GetWidth() - 1;
//                }
//                am.SetEnd(new Node(x, y));
//                am.setName(Name + this.idOfClientAndMazes.Count);
//            }
//            idOfClientAndMazes.Add(id, am);
//        }
//        / <summary>
//        / check to see if a player with id=num 
//        / exist in this game
//        / </summary>
//        / <param name="num">player id</param>
//        / <returns>if player exist</returns>
//        public bool IsExistClient(int num)
//        {
//            return this.idOfClientAndMazes.ContainsKey(num);
//        }
//        / <summary>
//        / check if we have more then 1 player 
//        / so we can have a multiplayer game
//        / </summary>
//        / <returns>true if we have more then 1 player</returns>
//        public bool canStart()
//        {
//            if (this.idOfClientAndMazes.Count > 1)
//            {
//                return true;
//            }
//            return false;
//        } 
//        / <summary>
//        / a string of the curr maze to 
//        / send our players (player with this id and it's 
//        / Yarivim )
//        / </summary>
//        / <param name="id">the id of player </param>
//        / <returns>string rep </returns>
//        public string getString(int id)
//        {
//            StringBuilder sb = new StringBuilder();
//            sb.Append("\"Name\": " + this.Name + ",\n");
//            ActiveMaze am;
//            this.idOfClientAndMazes.TryGetValue(id, out am);
//            if (am != null)
//            {
//                sb.Append("\"MazeName\": " + am.GetName() + ",");
//                sb.Append("\"You\": " + am.GetString() + ",");
//            }
//            foreach (var x in this.idOfClientAndMazes)
//            {
//                if (x.Key != id)
//                {
//                    sb.Append("\"Other\": " + am.GetString() + "");
//                }
//            }
//            return sb.ToString();
//        }
//        / <summary>
//        / move the player of given id
//        / in direction d if can 
//        / </summary>
//        / <param name="id">who we want move</param>
//        / <param name="d">direction to move </param>
//        / <returns></returns>
//        public Package1 Move(int id, direction d)
//        {
//            Package1 pac = new Package1();
//            ActiveMaze am;
//            bool flag = false;
//            this.idOfClientAndMazes.TryGetValue(id, out am);
//            if (am != null)
//            {
//                flag = am.Go(d);
//                if(!flag)
//                {
//                    pac.AddID(id, "you can't walk in to wall");
//                }
//            }

//            if (flag)
//            {
//                if(am.Win())
//                {
//                    foreach (var x in this.idOfClientAndMazes.Keys)
//                    {
//                        if (x != id)
//                        {
//                            string s = "yariv won";
//                            pac.AddID(x, s);
//                        }
//                    }
//                    pac.AddID(id, "win");
//                    return pac;
//                }
//                foreach (var x in this.idOfClientAndMazes.Keys)
//                {
//                    if (x != id)
//                    {
//                        string s = "{\n \"Name\": " + this.Name + ",\n\"Move\": " + d + "}\n";
//                        pac.AddID(x, s);
//                    }
//                }
//                string s1 = "You moved \n";
//                pac.AddID(id, s1);
//            }
//            return pac ;
//        }
//        / <summary>
//        / close the game to player with given 
//        /id 
//        / </summary>
//        / <param name="id">who want to close the game</param>
//        / <returns>package of ids and the string to send</returns>
//        public Package1 close(int id)
//        {
//            Package1 pac = new Package1();
//            foreach (var x in this.idOfClientAndMazes.Keys)
//            {
//                if(x != id)
//                    pac.AddID(x, "yariv close");//yriv close the game so from now on you can play
//                else
//                    pac.AddID(x, "close");//close game and communiction with server 
//            }
//            return pac;

//        }
//        / <summary>
//        / getter of game.name
//        / </summary>
//        / <returns></returns>
//        public string getName()
//        {
//            return this.Name;
//        }
//        / <summary>
//        / get a collection of id that belong to the game
//        / </summary>
//        / <returns>Collection of int</returns>
//        public ICollection<int> GetID()
//        {
            
//            return idOfClientAndMazes.Keys;
//        }
//        / <summary>
//        / get the maze of arg id 
//        / </summary>
//        / <param name="id">the client we r looking for his game</param>
//        / <returns>id active maze</returns>
//        public ActiveMaze getAcId(int id)
//        {
//            ActiveMaze am;
//            this.idOfClientAndMazes.TryGetValue(id, out am);
//            return am;
//        }
//    }

    
//}
