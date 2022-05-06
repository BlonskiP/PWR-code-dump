package TicTacToe;

import java.io.File;
import java.io.FilenameFilter;

public class JsFileFilter implements FilenameFilter {
    public JsFileFilter(){}
    @Override
    public boolean accept(File dir, String name) {
       return name.endsWith(".js");
    }
}
