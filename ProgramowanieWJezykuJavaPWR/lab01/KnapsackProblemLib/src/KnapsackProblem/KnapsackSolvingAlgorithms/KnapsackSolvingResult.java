package KnapsackProblem.KnapsackSolvingAlgorithms;
import KnapsackProblem.Item;
import java.util.ArrayList;
/**
An result of the Knapsack Problem.
Contains list of Items, sum of their weight and value
*/
public class KnapsackSolvingResult {
	/**
	List of Items that are choosen by Solving algorithm
	*/
    private ArrayList<Item> bagItems;
	/**
	Sum of Items value. Value of Bag
	*/
    private int bagValue=0;
	/**
	Sum of Items weight. Value of Bag
	*/
    private int bagWeight=0;
	/**
	No parameter constructor which creates empty bag ( empty list of items)
	*/
    public KnapsackSolvingResult()
    {
        bagItems=new ArrayList<Item>();
    }
	/**
	@param bag List of Items that Result will contain as choosen items.
	Uses countValue to know how much Item bag weights and costw
     @param bag Complete list of items
	*/
    public KnapsackSolvingResult(ArrayList<Item> bag)
    {
        if(bag!=null){
            bagItems=bag;
            countValue();
        }

    }

	/**
	Counts bag value and weight.
	Changes bagValue and bagWeight based on calculation
	*/
    private void countValue() {
        bagValue=0;
        for (Item item:bagItems
        ) {
            bagValue+=item.getValue();
            bagWeight+=item.getWeight();
        }
    }
	/**
	Copy constructor.
     @param newResult result to copy
	*/
    public KnapsackSolvingResult(KnapsackSolvingResult newResult)  {
        bagItems=newResult.getBagItems();
        countValue();

    }
	/**
	@return value of bag
	*/
    public int getBagValue() {
        return bagValue;
    }
	/**
	@return list of items from bag.
	*/
    public ArrayList<Item> getBagItems(){ return this.bagItems; }
	/**
	Prints on console every Item name value, weight 
	*/
    public void PrintResult()
    {
        System.out.println();
        for (Item item:bagItems
             ) {
            System.out.print(item.getName()+" "+ item.getValue()+" "+item.getWeight());

        }
        System.out.println("capacity used:"+ bagWeight);
        System.out.println("value:"+ bagValue);

    }
	/**
	Add new item to bag. Changes value and weight of bag.
     @param item Item which we want to add to result bag.
	*/
    public void AddNewItem(Item item)
    {
        bagItems.add(item);
        bagValue+=item.getValue();
        bagWeight+=item.getWeight();
    }
	/**
	@return Weight of bag
	*/
    public int GetBagWeight(){return bagWeight;}




}
