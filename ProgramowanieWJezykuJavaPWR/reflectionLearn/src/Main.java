import TestClasses.TestClassA;
import TestClasses.TestClassAbs;

import java.lang.reflect.Constructor;
import java.lang.reflect.Field;
import java.lang.reflect.Method;

public class Main {

    public static void main(String[] args) throws Exception {

        System.out.println("Java reflection example");

        //Object testAbs = new TestClassAbs();
        Object testA = new TestClassA();
        Object testObj=testA;
        Class testCls = testObj.getClass();
        System.out.println("The class name is: "+ testCls.getName());
        Constructor constructor = testCls.getConstructor();
        System.out.println("Class contructor is: " + constructor.getName());
        System.out.println("Class public methods: ");
        Method[] methods = testCls.getMethods();
        for(Method method: methods )
        {
            System.out.println(method.getName());
        }

        Method methodCall=testCls.getMethod("getTestValues");

        methodCall.invoke(testObj);


        Field field = testCls.getField("testString");
        field.setAccessible(true);
        field.set(testObj,"Nowy string ");
        methodCall.invoke(testObj);
    }
}
