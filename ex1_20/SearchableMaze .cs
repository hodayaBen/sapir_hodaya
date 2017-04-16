using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
namespace ex1_20
{
    public class SearchableMaze : ISearchable
    {
        private Maze myMaze;
        private State<Position> s;

        public SearchableMaze(Maze maze)
        {
            this.myMaze = maze;
            
        }

        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {
            //neghboor up
            List<State<Position>> list = new List<State<Position>>();
            if ((s.state.Row) + 1 < myMaze.Rows)
            {
                Position p = new Position(s.state.Row + 1, s.state.Col);
                if (p.GetType().ToString().Equals("Free"))
                    list.Add(StatePool.getState(p, s, s.cost + 1));
            }
            //neghboor left
            if (s.state.Col - 1 >= 0)
            {
                Position p = new Position(s.state.Row, s.state.Col - 1);
                if (p.GetType().ToString().Equals("Free"))
                    list.Add(StatePool.getState(p, s, s.cost + 1));
            }
            //right neghboor
            if (s.state.Col + 1 < myMaze.Cols)
            {
                Position p = new Position(s.state.Row, s.state.Col + 1);
                if (p.GetType().ToString().Equals("Free"))
                    list.Add(StatePool.getState(p, s, s.cost + 1));

            }
            //down neghbhor
            if (s.state.Row - 1 >= 0)
            {
                Position p = new Position(s.state.Row - 1, s.state.Col);
                if (p.GetType().ToString().Equals("Free"))
                    list.Add(StatePool.getState(p, s, s.cost + 1));
            }
            return list;
        }
        public State<Position> getGoalState()
        {
            return new State<Position>(this.myMaze.GoalPos);
        }

        public State<Position> getInitialState()
        {
            return new State<Position>(this.myMaze.InitialPos);
        }
    }
}