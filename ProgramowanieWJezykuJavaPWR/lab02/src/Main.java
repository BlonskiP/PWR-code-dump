import java.util.Random;

import static java.lang.Math.abs;

public class Main {
    static Random generator = new Random();
    public static void main(String[] args) {

        while(true)
        {
            runNewThread("brute");
            runNewThread("random");
        }
    }

    public static void runNewThread(String type)
    {
        if(!(Thread.activeCount()>20)) {
            Thread t = new ProblemSolverThread(abs(generator.nextLong() % 100), type);
            t.start();
        }
    }
}
