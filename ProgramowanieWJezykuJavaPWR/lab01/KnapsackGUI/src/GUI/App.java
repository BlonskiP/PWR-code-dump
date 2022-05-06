package GUI;

import GUI.Controls.BetterScene;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.print.PrinterJob;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.net.URL;
import java.util.Locale;
import java.util.ResourceBundle;

public class App extends Application {

    public static Parent root;
    public static URL url;
    public static BetterScene scene;
    @Override
    public void start(Stage primaryStage) throws Exception{
        url = getClass().getResource("GUI.fxml");
        root = FXMLLoader.load(url, NationalizationManager.getResourceBundle());
        primaryStage.setTitle("Knapsack GUI");
        scene=new BetterScene(root, 600, 400);
        primaryStage.setScene(scene);

        primaryStage.show();
    }




    public static void main(String[] args) {
        launch(args);
    }
}
