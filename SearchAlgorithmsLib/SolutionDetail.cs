
namespace SearchAlgorithmsLib
{
    public class SolutionDetails<T> : Solution<T>
    {
        public int NodesEvaluated { get; set; }

        public SolutionDetails(): base()
        {
            
            this.NodesEvaluated = 0;
        }
      
        
       
    }
}
