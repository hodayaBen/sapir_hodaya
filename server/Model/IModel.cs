using System;
using System.Net.Sockets;
using MazeLib;
using SearchAlgorithmsLib;
using server.Controller;
namespace server.Model
{
    /// <summary>
    /// interface that Defines the function of model
    /// </summary>
    public interface IModel
    {

        Maze GenerateMaze(string name, int rows, int cols);
        SolutionDetails<Direction> SolveMaze(string name, int algo);
        //string StartGame(string name, int rows, int cols, TcpClient client);
        string StartGame(string name, int rows, int cols, ICClientHandler client);
        String list();
        Game JoinGame(string name, ICClientHandler client);
        string Play(string move, ICClientHandler client);
        string Close(string name, ICClientHandler client);

    }
}
