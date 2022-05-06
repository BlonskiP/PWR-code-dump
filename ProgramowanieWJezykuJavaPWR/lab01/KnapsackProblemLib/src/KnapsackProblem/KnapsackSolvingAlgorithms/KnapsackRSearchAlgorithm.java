package KnapsackProblem.KnapsackSolvingAlgorithms;

import KnapsackProblem.Item;

import java.util.ArrayList;
import java.util.Random;
/**
Extends SolvingAlgorith, Implements RS search
*/
public class KnapsackRSearchAlgorithm extends KnapsackSolvingAlgorithm {

    private Random rnd  = new Random();
	/**
	Calls constructor of a base class, Sets description to "Random Search Algorithm"
     @param problem Instance of Knapsac Problem
     @see InstanceProblem
	*/
    public  KnapsackRSearchAlgorithm(InstanceProblem problem)
    {
        super(problem);
        description="Random Search Algorithm";
    }
	/**
	Implementation of Random Search Algorithm
	@return best result given by rs Search
	*/
    @Override
    public KnapsackSolvingResult Solve() {
        ArrayList<Item> bag= new ArrayList<>(problem.getBag());

        int randomItemIndex;
        Item tempItem;
        KnapsackSolvingResult newResult;
        for(int i=0;i<1000;i++)
        {
            newResult=new KnapsackSolvingResult();
            while(newResult.GetBagWeight()<=problem.getCapacity() && bag.size()>0)
            {
            randomItemIndex=rnd.nextInt(bag.size());
            tempItem= bag.get(randomItemIndex);
            if(newResult.GetBagWeight()+tempItem.getWeight()<problem.getCapacity())
            {
                newResult.AddNewItem(tempItem);
                bag.remove(tempItem);

            }
            else if(bag.size()>0)
            {
                bag.remove(tempItem);
            }
            else
            {
                break;
            }
            }
            compareResults(newResult);
            bag= new ArrayList<>(problem.getBag());
        }

        return bestResult;
    }
}
