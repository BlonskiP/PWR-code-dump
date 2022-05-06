import KnapsackProblem.KnapsackSolvingAlgorithms.KnapsackSolvingResult;
import com.sun.org.apache.xpath.internal.operations.Equals;

public class Result {
    public KnapsackSolvingResult knapsackResut;
    long seed;
    public Result(KnapsackSolvingResult knapResult, long seed)
    {
        knapsackResut=knapResult;
        this.seed=seed;
    }
    @Override
    public boolean equals(Object o) {
        Result result = (Result)o;
        if (result.seed== this.seed) {
            return true;
        }
        return false;
    }
}
