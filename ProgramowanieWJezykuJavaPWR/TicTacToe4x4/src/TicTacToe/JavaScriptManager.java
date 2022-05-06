package TicTacToe;

import javax.script.Invocable;
import javax.script.ScriptEngine;
import javax.script.ScriptEngineManager;
import javax.script.ScriptException;
import java.io.*;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;

import TicTacToe.JsFileFilter;
public class JavaScriptManager {

    static ArrayList<Script> scripts=new ArrayList<>();
    static ScriptEngine engine = new ScriptEngineManager().getEngineByName("nashorn");
    static File scriptsFolder;
    public static void updateScripts() throws FileNotFoundException, ScriptException {

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
    getAllJavaScript();


    }

    private static boolean createScriptFolder()
    {
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
    private static void getAllJavaScript() throws FileNotFoundException, ScriptException {
        FilenameFilter js = new JsFileFilter();
        ArrayList<File> jsFiles=new ArrayList<>();
        for (File script:scriptsFolder.listFiles(js)
             ) {
            scripts.add(new Script(script,"js"));
        }
    }
    public static void printAllScripts()
    {
        for (Script fileName:scripts
             ) {
            System.out.println(fileName.name);
        }
    }
    public static int[] invokeScript(Script script) throws FileNotFoundException, ScriptException {
        String path = script.path.toString();
        engine.eval(new FileReader(path));
        Invocable invocable = (Invocable) engine;
        Object move = new int[0];
        try {
            char[] convertedArr = new char[16];
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    convertedArr[4*i+j]=GAME.gameBoard[i][j];
                }
            }
            move = ((Invocable) engine).invokeFunction("moveTick",  convertedArr);

            return (int[])move;
        } catch (NoSuchMethodException e) {
            GAME.clearScreen();
        System.out.println("This script doesn't have moveTick function!");
        return AIBrain.makeMove();
    }

    }
}
