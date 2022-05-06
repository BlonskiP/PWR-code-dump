import javax.management.*;
import java.lang.management.ManagementFactory;
import java.util.Random;

import static java.lang.Math.abs;

public class Main {
    static Random generator = new Random();
    static int numberOfThreads=20;
    static int seedRange=900;
    public static void main(String[] args) throws MalformedObjectNameException, NotCompliantMBeanException, InstanceAlreadyExistsException, MBeanRegistrationException {
        MBeanServer mbs = ManagementFactory.getPlatformMBeanServer();
        SystemConfig mBean = new SystemConfig(numberOfThreads, ResultStorage.size);
        ObjectName name = new ObjectName("lab10:type=SystemConfig");
        mbs.registerMBean(mBean, name);
        while(true)
        {
            runNewThread("brute");
            runNewThread("random");
        }
    }

    public static void runNewThread(String type)
    {
        if(!(Thread.activeCount()>numberOfThreads)) {
            Thread t = new ProblemSolverThread(abs(generator.nextLong() % seedRange), type);
            t.start();
        }
    }
}
