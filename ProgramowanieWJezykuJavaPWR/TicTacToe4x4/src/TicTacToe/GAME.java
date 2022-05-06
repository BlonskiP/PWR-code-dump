package TicTacToe;

public class GAME {
    public static char[][] gameBoard= new char[4][4];
    public static boolean win = false;
    public static void newGameInit(){
        CppScriptManager.init();
        for(int i=0;i<4;i++)
        {
            for (int k = 0; k < 4; k++)
                    gameBoard[i][k]=' ';
        }
    }

    public static void printBoard()
    {
        System.out.println("---------------");
        for(int i=0;i<4;i++) {
            for (int k = 0; k < 4; k++){
                System.out.print("|" + gameBoard[i][k] + "| ");}
            System.out.println();
            System.out.println("---------------");
        }
    }
    public static boolean acceptMove(int[] move, char symbol)
    {
        int column = move[0];
        int row = move[1];

        if(gameBoard[column][row]==' '){
            gameBoard[column][row]=symbol;
            System.out.println("This move is OK. This tile will be taken by: " + gameBoard[column][row]);
            return true;}
        System.out.println("This move is forbidden. This tile is taken by: " + gameBoard[column][row]);
        return false;
    }
    public static boolean checkBoardForWin()
    {
        //check ->
        for(int i=0;i<4;i++)
        {
            int k=1;
            if(gameBoard[i][k]!=' ')
            if(gameBoard[i][k-1]==gameBoard[i][k] && gameBoard[i][k+1]==gameBoard[i][k]){
                return true;
            }
            k++;
            if(gameBoard[i][k]!=' ')
            if(gameBoard[i][k-1]==gameBoard[i][k] && gameBoard[i][k+1]==gameBoard[i][k]){
                return true;
            }
        }
        // check V
        for(int k=0;k<4;k++)
        {
            int i=1;
            if(gameBoard[i][k]!=' ')
            if(gameBoard[i+1][k]==gameBoard[i][k] && gameBoard[i-1][k]==gameBoard[i][k]){
                return true;
            }
            i++;
            if(gameBoard[i][k]!=' ')
            if(gameBoard[i+1][k]==gameBoard[i][k] && gameBoard[i-1][k]==gameBoard[i][k]){
                return true;
            }
        }
        // check /
        for(int i=1;i<3;i++)
        {
            for(int k=1;k<3;k++)
            {   if(gameBoard[i][k]!=' ') {
                if (gameBoard[i - 1][k - 1] == gameBoard[i][k] && gameBoard[i + 1][k + 1] == gameBoard[i][k])
                    return true;
                if (gameBoard[i - 1][k + 1] == gameBoard[i][k] && gameBoard[i + 1][k - 1] == gameBoard[i][k])
                    return true;
            }
            }
        }

        return false;
    }
    public static void gameLoop()
    {
        newGameInit();
        while(!win)
        {
            clearScreen();

            while (!acceptMove(Player.makeMove(),Player.symbol) && !win);
            clearScreen();
            if(win = checkBoardForWin())
            {
                System.out.println("Winner is " + Player.symbol);
                break;
            }
            while (!acceptMove(AIBrain.makeMove(),AIBrain.symbol) && !win);
            clearScreen();
            if(win = checkBoardForWin())
            {
                System.out.println("Winner is " + AIBrain.symbol);
                break;
            }

        }
        clearScreen();
    }
    public static void clearScreen() {
        System.out.print("\033[H\033[2J");
        System.out.flush();
        printBoard();
    }
}
