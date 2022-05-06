import java.lang.ref.Reference;
import java.lang.ref.WeakReference;
import java.util.ArrayList;

public class ResultStorage {
    static ArrayList<Reference<Result>> resultRefList=new ArrayList<>();
    static ArrayList<Result> resultList=new ArrayList<>();
    static double found=0;
    static double notfound=0;
    static synchronized void addNewResult(Result newResult, long id)
    {
        Reference<Result> newRefResult = new WeakReference<Result>(newResult);
        resultRefList.add(newRefResult);
//        resultList.add(newResult);
        System.out.println("New Result added! Thead id: "+id+" Seed: " + newResult.seed);
        newResult.knapsackResut.PrintResult();
    }

    public synchronized static boolean findResult(long seed) {
        Result temp = new Result(null,seed);
        ArrayList<Reference<Result>> killList = new ArrayList<>();
        for (Reference<Result> res:resultRefList
             ) {
            try {
                if (res.get().equals(temp)) {
                    resultRefList.removeAll(killList);
                    found++;

                    return true;
                }
            }
            catch(NullPointerException e) {
                killList.add(res);
            }
        }
        notfound++;
        resultRefList.removeAll(killList);

        return false;
    }
    public synchronized static void PrintFounded()
    {
        System.out.println("Ref list size: " +resultRefList.size());
        System.out.println("Found: " +found);
        System.out.println("NotFound:" + notfound);
        double state = ((double)found/(double)notfound);
        System.out.printf("\nActual found/notfound: %.5f \n", state);
    }
}
