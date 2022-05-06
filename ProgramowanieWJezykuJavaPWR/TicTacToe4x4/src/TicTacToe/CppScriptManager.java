package TicTacToe;

import java.io.File;
import java.io.FilenameFilter;
import java.util.ArrayList;

public class CppScriptManager {

    static ArrayList<Script> scripts=new ArrayList<>();
    static File scriptsFolder;
    public static void init(){}
    public static void updateScripts(){

        if(scriptsFolder==null)
        {
            scriptsFolder=new File(ClassLoader.getSystemClassLoader().getResource(".").getPath()+"/scripts");
            if(!createScriptFolder())
            {
                System.out.println("There is 'scripts' file and it is not a directory");
                while(!createScriptFolder());
            }
        }
        scripts.clear();
        getAllCppScripts();

    }

    private static void getAllCppScripts() {
        FilenameFilter c = new CppFileFilter();
        ArrayList<File> cFiles=new ArrayList<>();
        for (File script:scriptsFolder.listFiles(c)
        ) {
            scripts.add(new Script(script,"c"));
        }
    }

    private static boolean createScriptFolder() {
        if(!scriptsFolder.exists()) {

            boolean succes = scriptsFolder.mkdir();
            if(scriptsFolder.exists())
            {
                System.out.println("Scripts folder created. Give me new AI scripts!!");
                return true;
            }
            System.out.println(succes);
        }
        else if(scriptsFolder.isDirectory()){
            return true;
        }


        return false;
    }
}
