package KnapsackProblem.KnapsackSolvingAlgorithms;

import KnapsackProblem.Item;

import java.util.ArrayList;
/**
Instance of Knapsack Problem 0/1
Properties: 
1.List of Items that can be used in algorithm
2.Max capacity of bag
It can print items from bag.
*/
public class InstanceProblem {
	/**
	This property contains all items that can be used in this knapsack problem.
	*/
    private ArrayList<Item> bag;
	/**
	Max capacity of bag
	*/
    private int capacity;
	/**
	This constructor creates InstanceProblem with given items and max Capacity
	 @param bag list of all possible items in bag
	 @param capacity max capacity of result
	*/
    public InstanceProblem(ArrayList<Item> bag,  int capacity)
    {
        this.bag=bag;

        this.capacity=capacity;
    }
	/**
	@return capacity
	*/
    public int getCapacity() {
        return capacity;
    }
	/**
	Prints all items that can be used in knapsack problem.
	Items which we can put in bag of result
	*/
    public void printItems()
    {
        for (Item item:bag
             ) {
            System.out.println(item.getName() + " Value " + item.getValue() + " Weight: " + item.getWeight());

        }
    }
	/**
	@return The list of Items that can be used in solving algorithm
	*/
    public ArrayList<Item> getBag(){return bag;}

}
