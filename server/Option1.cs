using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using MazeLib;
using MazeGeneratorLib;
namespace Server1
{
   public class Option1 : ICommandable
    {
        /// <summary>
        ///create maze according to number that 
        ///was input before the maze name in mag
        /// </summary>
        /// <param name="msg">what we got from the client with the number 1 </param>
        /// <param name="game">the gaming arena that we in</param>
        public Package1 execute(string msg, MazeModel game, int id)
        {
            string[] commend = msg.Split(' ');
            string maze_name = commend[1];
            int row = Int32.Parse(commend[2]);
            int col = Int32.Parse(commend[3]);
            Maze maze = game.GetMaze(maze_name);
            string str = maze.ToJSON();
            Package1 pac = new Package1(str , id);
            return pac;
        }
       
       
           

    }
}
