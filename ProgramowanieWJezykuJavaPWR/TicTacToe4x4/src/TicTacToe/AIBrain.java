package TicTacToe;

import javax.script.ScriptException;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class AIBrain {
    public static ArrayList<Script> allAIScripts=new ArrayList<>();
    public static char symbol = 'o';

    public static void updateScripts() throws FileNotFoundException, ScriptException {
        JavaScriptManager.updateScripts();
        CppScriptManager.updateScripts();
        allAIScripts.clear();
        allAIScripts.addAll(JavaScriptManager.scripts);
        allAIScripts.addAll(CppScriptManager.scripts);
    }
    public static int[] invokeScript(int x) throws FileNotFoundException, ScriptException {
        Script scriptToExe = allAIScripts.get(x);
        int[] move=null;
        switch(scriptToExe.type){
            case "js":{
                move= JavaScriptManager.invokeScript(allAIScripts.get(x));
                break;
               }
            case "c":{
                String moveName= allAIScripts.get(x).name;
                CppMove newMove = new CppMove(moveName.substring(0,moveName.length()-4));
                move = newMove.makeMove(GAME.gameBoard);

                break;}
        }
        if(move == null)
        {
            GAME.clearScreen();
            System.out.println("This script doesn't have moveTick function!");
            return AIBrain.makeMove();
        }
        System.out.println("Computer move: row: " + move[0] +"colm: "+ move[1]);
        return move;
    }
    public static int[] getMoveScript() throws FileNotFoundException, ScriptException {
        printAllScripts();
        System.out.println("Enter number of a script to invoke: ");
        Scanner sc = new Scanner(System.in);

        int scriptNumber=-1;
        int allScriptsCount = allAIScripts.size()-1;
        while(scriptNumber>allScriptsCount || scriptNumber<0){
        scriptNumber = sc.nextInt();
            if(scriptNumber>allScriptsCount || scriptNumber<0)
            {
                printAllScripts();
                System.out.println("Give script number from above list!");
            }
        }
       int move[] = invokeScript(scriptNumber);
        return move;
    }
    public static void printAllScripts() throws FileNotFoundException, ScriptException {
        updateScripts();
        int index=0;
        for (Script script:allAIScripts
             ) {
            System.out.println(index+". "+script.name);
            index++;
        }
    }

    public static int[] makeMove() {
        int[] move = new int[0];
        try {
            return move=getMoveScript();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (ScriptException e) {
            e.printStackTrace();
        }
        return move;
    }
}
