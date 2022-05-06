import KnapsackProblem.Item;
import KnapsackProblem.KnapsackSolvingAlgorithms.InstanceProblem;
import KnapsackProblem.KnapsackSolvingAlgorithms.KnapsackSolvingResult;

import java.math.BigInteger;
import java.util.ArrayList;

public class InstanceProblemGenerator {
    // Based on Donald Knuth generator
    //https://eduinf.waw.pl/inf/alg/001_search/0020.php
    private long seed;
    public InstanceProblemGenerator(long seed){this.seed=seed;}
    public  InstanceProblem generateProblem()
    {
        ArrayList<Item> itemList=new ArrayList<>();

        int capacity=(int)getNextNumber(100);
        int numberOfItems=(int)getNextNumber(10);
        while(capacity>30 || capacity%20==0)capacity=(int)getNextNumber(100);
        if(numberOfItems<5)numberOfItems=(int)getNextNumber(10);

        for(int i=0;i<numberOfItems;i++)
        {
            float value=getNextNumber(10);
            int weight=(int)getNextNumber(capacity%20);
            String name="Item numer: "+i;

            Item tempItem=new Item(value,weight,name);
            itemList.add(tempItem);
        }
        return new InstanceProblem(itemList,capacity);

    }

    public long getNextNumber(int m2)
    {
        //m2 is result modulo
        String result="";
        try {
            BigInteger a = new BigInteger("3141592653");
            BigInteger b = new BigInteger("2718281829");
            BigInteger m = new BigInteger("34359738368");

            result = a.multiply(new BigInteger(Long.toString(seed))).toString();
            a = new BigInteger(result);
            result = (b.add(a).toString());
            b = new BigInteger(result);
            result = b.mod(m).toString();
            b = new BigInteger(result);
            seed = b.longValue();
            result = b.mod(new BigInteger(Integer.toString(m2))).toString();
        }
        catch(Exception e)
        {
System.out.println(e.getCause());
        }


        return Long.parseLong(result);
    }


}
