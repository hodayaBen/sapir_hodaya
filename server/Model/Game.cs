using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;

namespace Model
{
    public class Game
    {
        Maze myMaze;
        public int numOfClient { get; set; }
        TcpClient client1;
        TcpClient client2;

        public Game(string name, int row, int col)
        {
            DFSMazeGenerator dfs = new DFSMazeGenerator();
            myMaze = dfs.Generate(row, col);
            myMaze.Name = name;
        }
        public void AddClient(TcpClient c)
        {
            if (numOfClient == 0)
            {
                client1 = c;
            }
            else
            {
                client2 = c;
                //client1.Client.Send() - myMaze.ToJSON()
            }
            numOfClient++;
        }
        public string GetName()
        {
            return this.myMaze.Name;
        }
    }
}
