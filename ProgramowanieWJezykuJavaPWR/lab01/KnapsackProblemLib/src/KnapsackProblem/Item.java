package KnapsackProblem;
/**
*Represents Item in bag.
*It has name, value and weight
*/
public class Item {
	/**
	Name of Item. Example:"Banana"
	*/
	private String name;
	/**
	Value of Item.
	This value is used in algorithm to find out which Item sets are best for bag.
	Example: 50
	*/
    private float value;
	/**
	Weight of Item.
	Used by algorithm to check if item can fit in bag.
	Example: 4
	*/
    private int weight;
	/**
	Constructor of Item object.
	@param value a value of item. Cannot be null
	@param weight a weight of item. Cannot be null
	@param name a name of item. 
	*/
    public Item(float value,int weight, String name){
        this.value=value;
        this.weight=weight;
		this.name=name;
    }
	/**
	@return value of item
	*/
    public float getValue(){return value;}
	/**
	@return weight of item
	*/
    public float getWeight(){return weight;}

	/**
	 * @return name of item
	 */
	public String getName(){return  name;}
	@Override
	public String toString()
	{
		return getName() +" "+ getWeight() + " " + getValue();
	}
}
