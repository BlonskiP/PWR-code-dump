import KnapsackProblem.Item;
import KnapsackProblem.KnapsackSolvingAlgorithms.*;

import java.util.ArrayList;

public class Tester {

    public static void main(String[] args) {
        ArrayList<Item> bag = new ArrayList<Item>();
        bag.add(new Item(1,1,"gold"));
        bag.add(new Item(3,2,"Silver"));
        bag.add(new Item(2,4, "banana"));
        bag.add(new Item(4,1,"tin"));
        bag.add(new Item(1,3,"Amelinium"));
        bag.add(new Item(3,3,"rock"));
        bag.add(new Item(2,3,"magic rock"));
        bag.add(new Item(5,3, "bag of cheeteos"));
        bag.add(new Item(6,3, "wasted dreams"));




        InstanceProblem problem= new InstanceProblem(bag,15);
        KnapsackBForceAlgorithm BF=new KnapsackBForceAlgorithm(problem);
        KnapsackRSearchAlgorithm RS = new KnapsackRSearchAlgorithm(problem);
        RS.Solve().PrintResult();
        BF.Solve().PrintResult();
        problem.printItems();
        System.out.println(problem.getCapacity());
    }

}
