import KnapsackProblem.KnapsackSolvingAlgorithms.InstanceProblem;
import KnapsackProblem.KnapsackSolvingAlgorithms.KnapsackSolvingResult;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

public class AlgorithClassLoader extends ClassLoader{
    public Method solve;
    private Object solverObject;

    public AlgorithClassLoader(String classBinName, InstanceProblem problem)
    {
        try{
            ClassLoader classLoader=this.getClass().getClassLoader();
            Class<?> loadedMyClass = classLoader.loadClass(classBinName);
            Constructor[] allConstructors = loadedMyClass.getDeclaredConstructors();
            solverObject = allConstructors[0].newInstance(problem);
            solve=loadedMyClass.getMethod("Solve");
        }
        catch(ClassNotFoundException e)
        {
            e.printStackTrace();
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
    public KnapsackSolvingResult Solve() throws InvocationTargetException, IllegalAccessException {
        return (KnapsackSolvingResult) solve.invoke(solverObject);
    }


}
