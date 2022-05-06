package TicTacToe;

import java.io.File;
import java.nio.file.Path;

public class Script {
    public Script(File scriptFile, String type){
        name=scriptFile.getName();
        path=scriptFile.toPath();
        this.type = type;
    }
    String name;
    Path path;
    String type;
}
