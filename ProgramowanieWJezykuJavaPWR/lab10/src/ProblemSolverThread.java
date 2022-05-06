import KnapsackProblem.KnapsackSolvingAlgorithms.KnapsackSolvingResult;

import java.lang.reflect.InvocationTargetException;

public class ProblemSolverThread extends Thread {
    InstanceProblemGenerator generator;
    AlgorithClassLoader loader;
    long seed;
    // algorith name= random or brute
    public ProblemSolverThread(long seed, String algorithName)
    {   this.seed = seed;
        generator=new InstanceProblemGenerator(seed);
        switch (algorithName){
            case "random":{
                loader=new AlgorithClassLoader("KnapsackProblem.KnapsackSolvingAlgorithms.KnapsackRSearchAlgorithm",generator.generateProblem());
                break;}
            case "brute":{
                loader=new AlgorithClassLoader("KnapsackProblem.KnapsackSolvingAlgorithms.KnapsackBForceAlgorithm",generator.generateProblem());
                break;}
            default: System.out.println("Wrong algorithName!!");
        }
    }
    public void run()
    {

        try {
            if(!ResultStorage.findResult(seed)) {
                Thread.sleep(2000);
                KnapsackSolvingResult knapRes = loader.Solve();
                Result newRes = new Result(knapRes, seed);
                ResultStorage.addNewResult(newRes, Thread.currentThread().getId());
            }else
            {
                System.out.println("FOUND RESULT ALREADY SOLVED! " + seed);
            }
        ResultStorage.PrintFounded();

        } catch (InvocationTargetException e) {
            e.printStackTrace();
        } catch (IllegalAccessException e) {
            e.printStackTrace();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
