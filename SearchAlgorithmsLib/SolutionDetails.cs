
namespace SearchAlgorithmsLib
{
    public class SolutionDetails<T> : Solution<T>
    {
        public int NodesEvaluated { get; set; }
        public SolutionDetails(Solution<T> s, int ne)
        {
            this.solve = s.getSolve();
            this.NodesEvaluated = ne;
        }
       
    }
}
