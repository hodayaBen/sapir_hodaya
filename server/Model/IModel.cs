using System;
using System.Net.Sockets;
using MazeLib;
using SearchAlgorithmsLib;
namespace server.Model
{
    public interface IModel
    {

        Maze GenerateMaze(string name, int rows, int cols);
        Solution<Direction> SolveMaze(string name, int algo);
        string StartGame(string name, int rows, int cols, TcpClient client);
        String list();
        Game JoinGame(string name, TcpClient client);
        string Play(string move, TcpClient client);
        string Close(string name, TcpClient client);
    }
}
