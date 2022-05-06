import java.io.File;
import java.net.URL;
import java.net.URLClassLoader;

public class Main {

    public static void main(String[] args) throws Exception {

        Class testClass = Class.forName("TestClasses.TestClassAbs.class");
        System.out.println(testClass.getName());

    }
}
