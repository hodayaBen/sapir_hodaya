using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
namespace SearchAlgorithmsLib
{
    /// <summary>
    /// interface of from we which can solve
    /// </summary>
    public interface ISearchable
    {
        State<Position> getInitialState();
        State<Position> getGoalState();
        List<State<Position>> getAllPossibleStates(State<Position> s);
    }

}
