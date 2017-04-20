using System.Text;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;

namespace server.Model
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
        public string ToJSON()
        {
            return myMaze.ToJSON();
        }
        public TcpClient GetSecondPlayer(TcpClient client)
        {
            if (client1.Equals(client))
            {
               return client2;
            }
            return client1;
        }
        public string Play(string move, TcpClient client)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\n");
            sb.Append("\"Name\": " + "\"" + this.myMaze.Name + "\",\n");
            sb.Append("\"Direction\": " + move + "\n");
            sb.Append("}");
            return sb.ToString();
        }
    }
}

