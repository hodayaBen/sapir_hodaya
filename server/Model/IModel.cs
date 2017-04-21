using System;
using System.Net.Sockets;
using MazeLib;
using SearchAlgorithmsLib;
using server.View;
namespace server.Model
{
    public interface IModel
    {

        Maze GenerateMaze(string name, int rows, int cols);
        SolutionDetails<Direction> SolveMaze(string name, int algo);
        //string StartGame(string name, int rows, int cols, TcpClient client);
        string StartGame(string name, int rows, int cols, IClientHandler client);
        String list();
        // Game JoinGame(string name, TcpClient client);
        //string Play(string move, TcpClient client);
        //string Close(string name, TcpClient client);
        Game JoinGame(string name, IClientHandler client);
        string Play(string move, IClientHandler client);
        string Close(string name, IClientHandler client);

    }
}
