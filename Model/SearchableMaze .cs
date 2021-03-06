﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
namespace Model
{
    public class SearchableMaze : ISearchable<Position>
    {
        private Maze myMaze;
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
                
                if (myMaze[p.Row, p.Col].Equals(CellType.Free))
                    //list.Add(StatePool<Position>.getState(p, s, s.cost + 1));
                    list.Add(new State<Position>(p));
            }
            //neghboor left
            if (s.state.Col - 1 >= 0)
            {
                Position p = new Position(s.state.Row, s.state.Col - 1);
                if (myMaze[p.Row, p.Col].Equals(CellType.Free))
                    //list.Add(StatePool<Position>.getState(p, s, s.cost + 1));
                    list.Add(new State<Position>(p));
            }
            //right neghboor
            if (s.state.Col + 1 < myMaze.Cols)
            {
                Position p = new Position(s.state.Row, s.state.Col + 1);
                if (myMaze[p.Row, p.Col].Equals(CellType.Free))
                    // list.Add(StatePool<Position>.getState(p, s, s.cost + 1));
                    list.Add(new State<Position>(p));

            }
            //down neghbhor
            if (s.state.Row - 1 >= 0)
            {
                Position p = new Position(s.state.Row - 1, s.state.Col);
                if (myMaze[p.Row, p.Col].Equals(CellType.Free))
                    //list.Add(StatePool<Position>.getState(p, s, s.cost + 1));
                    list.Add(new State<Position>(p));
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