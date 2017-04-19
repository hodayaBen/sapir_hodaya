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
        List<TcpClient> clients;
        
        public Game(string name, int row,int col)
        {
            DFSMazeGenerator dfs = new DFSMazeGenerator();
            myMaze = dfs.Generate(row, col);
            myMaze.Name = name;
        }
        public void AddClient(TcpClient c)
        {
            if(numOfClient == 0)
            {
                clients.Add(c);
            }
            else
            {
                clients.Add(c);
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
