
namespace SearchAlgorithmsLib
{
    /// <summary>
    /// 
    ///hold the Solution and the number of evaluated node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SolutionDetails<T> 
    {
        public int NodesEvaluated { get; set; }
       public  Solution<T> solv { get; }
        public SolutionDetails(Solution<T>s,int numberOfNode)
        {
            this.solv = s;
            this.NodesEvaluated = numberOfNode;
        }
      
        
       
    }
}
