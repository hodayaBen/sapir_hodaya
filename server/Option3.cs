//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace Server1
//{
//    class Option3 : ICommandable
//    {
//        /// <summary>
//        /// a player want to begin a game with the name 
//        /// given in msg
//        /// </summary>
//        /// <param name="msg">name of the game</param>
//        /// <param name="game">what is our world of games</param>
//       public Package1 execute(string msg, MazeModel game, int idc) { 
//            string[] commend = msg.Split(' ');
//            string maze_name = commend[1];
//            Package1 pac = new Package1();
//            Game g = game.GetGame(maze_name);
//            g.AddPlayer(idc);
//            if (!g.canStart())
//            {
//                pac.AddID(idc, "wait");
//                return pac;
//            }
//            ICollection<int> col = g.GetID();
           
//            foreach(int x in col)
//            {
//                pac.AddID(x,g.getString(x));
//            } 
//            return pac;
//        }
//    }
//}
