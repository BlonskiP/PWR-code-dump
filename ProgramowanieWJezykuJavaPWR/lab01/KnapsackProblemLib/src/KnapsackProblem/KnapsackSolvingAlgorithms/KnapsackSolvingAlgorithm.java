package KnapsackProblem.KnapsackSolvingAlgorithms;
import KnapsackProblem.Item;
import java.util.ArrayList;
/**
An abstract class that provides methods like GetDescription, CompareResults, abstract method Solve.
Also contains properties like description, reference to problem, reference to bestResult.
*/
public abstract class KnapsackSolvingAlgorithm {
	/**
	Name of Solving algorithm.
	Example: "Brute Force"
	*/
    protected String description;
	/**
	It is a reference to InstanceProblem.
	@see InstanceProblem
	*/	
    protected InstanceProblem problem;
    /**
	Reference to best result that have been found.
	@see KnapsackSolvingResult
	*/
	protected KnapsackSolvingResult bestResult;
	/**
	Derived class should implement Solving algorithm.
	@return best result which has been found
	*/
    public abstract KnapsackSolvingResult Solve();
	/**
	Creates a KnapsackSolvingAlgorithm instance, and first empty result as best result.
	 @param problem Instance of Knapsack Problem
	 @see InstanceProblem
	*/
    public KnapsackSolvingAlgorithm(InstanceProblem problem){
        this.problem=problem;
        bestResult=new KnapsackSolvingResult();
    }
	/**
	@return Returns description of Algorithm.
	Example: "BruteForce"
	*/
    public String GetDescription() {
        return description;
    }
	/**
	Compares a result with bestResult.
	If bestResult is wors that given result, given result will become the bestResult
	@return True if given result is better than best.
	 @param newResult is the result that we want to check if is better than the best found
	*/
    protected boolean compareResults(KnapsackSolvingResult newResult)
    {
        if(newResult.getBagValue()>bestResult.getBagValue())
        {
            bestResult=new KnapsackSolvingResult(newResult);
            return true;
        }
        return false;
    }
}
