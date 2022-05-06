import java.lang.ref.Reference;
import java.lang.ref.WeakReference;
import java.util.ArrayList;

public class ResultStorage {

    static ArrayList<Result> resultList=new ArrayList<>();
    static double found=0;
    static double notfound=0;
    static double steps=0;
    static  int size=100;
    static synchronized void addNewResult(Result newResult, long id)
    {
       // Reference<Result> newRefResult = new WeakReference<Result>(newResult);
    //    resultRefList.add(newRefResult);
        if(resultList.size()<ResultStorage.size) {
            resultList.add(newResult);
        }
        else {
            resultList.remove(0);
            resultList.add(newResult);
        }
        System.out.println("New Result added! Thead id: "+id+" Seed: " + newResult.seed);
        newResult.knapsackResut.PrintResult();

    }

    public synchronized static boolean findResult(long seed) {
        Result temp = new Result(null,seed);
        ArrayList<Result> killList = new ArrayList<>();
        for (Result res:resultList
             ) {
            try {
                if (res.seed==seed) {
                    resultList.removeAll(killList);
                    found++;
                    steps++;

                    return true;
                }
            }
            catch(NullPointerException e) {
                killList.add(res);
            }
        }
        notfound++;
        steps++;
        resultList.removeAll(killList);

        return false;
    }
    public synchronized static void PrintFounded()
    {
        System.out.println("Ref list size: " +resultList.size());
        System.out.println("Found: " +found);
        System.out.println("NotFound:" + notfound);
        double state = ((double)found/(double)notfound);
        System.out.printf("\nActual found/notfound: %.5f \n", state);
    }
    public synchronized static void changeSize(int x) {
        if (resultList != null && resultList.size()>0) {
            ArrayList<Result> tempResultList = new ArrayList<>();

            for (int i = 0; i < x; i++) {
                tempResultList.add(ResultStorage.resultList.get(i));
            }
            ResultStorage.size = x;
            ResultStorage.resultList = tempResultList;
        }
        else
            ResultStorage.size=x;
    }
}
