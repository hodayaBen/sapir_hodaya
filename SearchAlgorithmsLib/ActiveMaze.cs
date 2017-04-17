using Newtonsoft.Json;
using System.Text;
//using System.Web.Script.Serialization;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public class ActiveMaze
    {
        
        private Maze myMaze;
        public Position Position;
        Solution<Position> sol;
        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="maze"> IMaze the will be our maze</param>
        /// <param name="pos">where is the player in the maze</param>
        public ActiveMaze(Maze maze, Position pos)
        {
            this.myMaze = maze;
            this.Position = pos;
        }
        /// <summary>
        /// check if after we move if we got
        /// to goal Position
        /// </summary>
        /// <returns> if we got to goal Position </returns>

        public bool Win()
        {
            if (this.Position.Equals(myMaze.GoalPos))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// cheack if we can go to given 
        /// direction if we can we change the 
        /// player position 
        /// </summary>
        /// <param name="d">direction</param>
        /// <returns>if we can go to direction d </returns>
        public bool Go(Direction d)
        {
            switch (d)
            {
                case Direction.Down:
                    if (myMaze[Position.Row + 1, Position.Col].Equals(CellType.Free))
                    {
                        this.Position = new Position(Position.Row + 1, Position.Col);
                        PutSolve(Position);
                        return true;
                    }
                    break;
                case Direction.Left:
                    if (myMaze[Position.Row, Position.Col - 1].Equals(CellType.Free))
                    {
                        this.Position = new Position(Position.Row, Position.Col - 1);
                        PutSolve(Position);
                        return true;
                    }
                    break;
                case Direction.Right:
                    if (myMaze[Position.Row, Position.Col + 1].Equals(CellType.Free))
                    {
                        this.Position = new Position(Position.Row, Position.Col + 1);
                        PutSolve(Position);
                        return true;
                    }
                    break;
                case Direction.Up:
                    if (myMaze[Position.Row - 1, Position.Col].Equals(CellType.Free))
                    {
                        this.Position = new Position(Position.Row - 1, Position.Col);
                        PutSolve(Position);
                        return true;
                    }
                    break;
            }
            return false;
        }


        /// <summary>
        /// getter of End of maze
        /// </summary>
        /// <returns>this.maze.End</returns>
        public Position GetEnd()
        {
            return myMaze.GoalPos;
        }
        /// <summary>
        /// getter of Height 
        /// </summary>
        /// <returns>this.maze.Height</returns>
        public int GetHeight()
        {
            return myMaze.Rows;
        }
        /// <summary>
        /// getter of maze start point
        /// </summary>
        /// <returns>this.Maze.start</returns>
        public Position GetStart()
        {
            return myMaze.InitialPos;
        }
        /// <summary>
        ///getter of maze width
        /// </summary>
        /// <returns>this.Maze.Width</returns>
        public int GetWidth()
        {
            return myMaze.Cols;
        }
        /// <summary>
        /// getter of this.Maze
        /// </summary>
        /// <returns></returns>
        public Maze getMaze()
        {
            return this.myMaze;
        }
        /// <summary>
        /// mark Position n as part of a soltion 
        /// of this maze
        /// </summary>
        /// <param name="n">the Position we want to mark</param>
        public void PutSolve(Position n)
        {
            sol.addNode(new State<Position>(n));
        }
        /// <summary>
        /// set an end point to this.maze
        /// </summary>
        /// <param name="n">the new end</param>
        public void SetEnd(Position n)
        {
            myMaze.GoalPos = n;
        }
        /// <summary>
        /// this.maze.name getter
        /// </summary>
        /// <returns> this.Maze.Name</returns>
        public string GetName()
        {
            return this.myMaze.Name;
        }
        /// <summary>
        /// to string method of this class
        /// </summary>
        /// <returns>string rep of maze</returns>
        public string GetString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("{\n");
            //sb.Append("\"Name\": " + this.myMaze.Name + ",\n\"Maze\": ");
            sb.Append(this.myMaze.ToJSON());
            //sb.Append(",\n\"Start\": {\n\"Row\":" + this.myMaze.GetStart().Row + ",\n\"Col\":" + this.myMaze.GetStart().Col + "\n}\n");
            //sb.Append("\"End\": {\n\"Row\":" + this.myMaze.GetEnd().Row + ",\n\"Col\":" + this.myMaze.GetEnd().Col + "\n}\n");
            //sb.Append("}");
            return sb.ToString();
        }
        /// <summary>
        /// set a name to this.maze
        /// </summary>
        /// <param name="name">the name we want to set for this.maze</param>
        public void setName(string name)
        {
            this.myMaze.Name = name;
        }
    }
}