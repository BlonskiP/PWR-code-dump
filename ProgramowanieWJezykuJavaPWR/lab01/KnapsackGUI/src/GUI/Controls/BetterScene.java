package GUI.Controls;

import javafx.collections.ObservableList;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.SceneAntialiasing;
import javafx.scene.control.Label;
import javafx.scene.paint.Paint;
import javafx.scene.control.TextField;
import java.util.Observable;

public class BetterScene extends Scene {

    public BetterScene(Parent root) {
        super(root);

    }

    public BetterScene(Parent root, double width, double height) {
        super(root, width, height);
    }

    public BetterScene(Parent root, Paint fill) {
        super(root, fill);
    }

    public BetterScene(Parent root, double width, double height, Paint fill) {
        super(root, width, height, fill);
    }

    public BetterScene(Parent root, double width, double height, boolean depthBuffer) {
        super(root, width, height, depthBuffer);
    }

    public BetterScene(Parent root, double width, double height, boolean depthBuffer, SceneAntialiasing antiAliasing) {
        super(root, width, height, depthBuffer, antiAliasing);
    }

    public void setValues(Parent newRoot)
    {



    }

}
