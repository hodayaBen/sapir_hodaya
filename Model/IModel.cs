using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using SearchAlgorithmsLib;
namespace Model
{
    public interface IModel
    {
        Maze GenerateMaze(string name, int rows, int cols);
        SolutionDetails<Direction> SolveMaze(string name, int algo);
        string StartGame(string name, int rows, int cols, TcpClient client);
        String list();
        Game JoinGame(string name, TcpClient client);
        string Play(string move, TcpClient client);
        void Close(string name);
    }
}
