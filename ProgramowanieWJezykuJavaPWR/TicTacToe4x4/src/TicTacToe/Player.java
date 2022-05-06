package TicTacToe;

import java.util.Scanner;

public class Player {
    public static final char symbol = 'x';
    public static int[] makeMove()
    {
        Scanner sc = new Scanner(System.in);
        int column = -1;
        int row = -1;
        while(column>3 || column<0) {
            System.out.print("It is your turn. Please type field row: ");
            column = sc.nextInt();
        }
        while(row>3 || row<0) {
            System.out.print("\nNow type column number: ");
            row = sc.nextInt();
        }
        int move[]=new int[2];
        move[0]=column;
        move[1]=row;
        return move;


    }
}
