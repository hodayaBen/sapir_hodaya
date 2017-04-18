//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Web;
//using System.Threading.Tasks;
//using System.Web.Script.Serialization;

//namespace Server1
//{
//    class Option2 : ICommandable
//    {
//        /// <summary>
//        /// the commed of solving the maze with given name of maze
//        /// and what method we want to solve
//        /// </summary>
//        /// <param name="msg"></param>
//        /// <param name="game"></param>
//        public Package1 execute(string msg, MazeModel game, int id)
//        {
//            string[] commend = msg.Split(' ');
//            string maze_name = commend[1];
//            int type = Int32.Parse(commend[2]);
//            SolutionInMatrix sim = game.GetSolve(maze_name, type);
//            if (sim == null)
//            {
//                Package1 pac = new Package1("wait", id);
//                return pac;
//            }

//            else
//            {

//                string ser = JsonConvert.SerializeObject(sim,Formatting.Indented);
//                Package1 pac = new Package1(ser, id);
//                return pac;
//            }
//        }

//    }
//}