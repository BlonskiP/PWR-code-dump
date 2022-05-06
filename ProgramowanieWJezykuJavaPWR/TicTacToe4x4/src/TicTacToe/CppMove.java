package TicTacToe;

public class CppMove {

    public CppMove(String libraryName)
    {
        System.loadLibrary(libraryName);

    }

    public native int[] makeMove(char[][] board);
}
