package GUI;

import GUI.Controls.Warehouse;
import KnapsackProblem.Item;
import KnapsackProblem.KnapsackSolvingAlgorithms.InstanceProblem;

import KnapsackProblem.KnapsackSolvingAlgorithms.KnapsackBForceAlgorithm;
import KnapsackProblem.KnapsackSolvingAlgorithms.KnapsackRSearchAlgorithm;
import KnapsackProblem.KnapsackSolvingAlgorithms.KnapsackSolvingAlgorithm;
import com.sun.jnlp.ApiDialog;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.Scene;
import javafx.scene.control.*;

import java.time.format.DateTimeFormatter;
import java.util.Observable;


public class Controller {
    ObservableList<String> algorithms = FXCollections.observableArrayList(
            NationalizationManager.getResourceBundle().getString("BruteForce"),
            NationalizationManager.getResourceBundle().getString("RandomSearch"));
    ObservableList<String> langs = FXCollections.observableArrayList("en-GB","pl-PL","en-US");
    @FXML
    private TextField itemNameInput;
    @FXML
    private TextField itemValueInput;
    @FXML
    private TextField itemWeightInput;
    @FXML
    private Label todayDate;
    @FXML
    private TextField maxCapacityInput;
    @FXML
    private ListView<Item> itemList;
    @FXML
    private ListView<Item> resultItemList;
    @FXML
    private ComboBox comboBox;
    @FXML
    private ComboBox ChangeLanguageCombo;
    @FXML
    private Label bagWeight;
    @FXML
    private Label bagValue;
    @FXML
    public void addItem()
    {
        Item item = new Item(Float.parseFloat(itemValueInput.getText()),Integer.parseInt(itemWeightInput.getText()),itemNameInput.getText());
        Warehouse.ItemList.add(item);
        itemList.getItems().add(item);
        System.out.println(item.toString());
    }
    @FXML
    public void LangChange(String code)
    {
        Warehouse.tempItemName=itemNameInput.getText();
        Warehouse.tempItemValue=itemValueInput.getText();
        Warehouse.tempItemWeight=itemWeightInput.getText();

        System.out.println("TEST COMPLETE");
        NationalizationManager.setLocal(code);


    }
    @FXML
    public void Solve(){

        if(Warehouse.ItemList.size()>0)
        {

            System.out.println("SOLIVING");
            Warehouse.maxCapacity = Integer.parseInt(maxCapacityInput.getText());
            Warehouse.KnapProblem=new InstanceProblem(Warehouse.ItemList,Warehouse.maxCapacity);
            if(setAlgorithms()) {

                resultItemList.getItems().clear();


                Warehouse.result = Warehouse.algorithm.Solve();
                Warehouse.result.PrintResult();

                for (Item item:Warehouse.result.getBagItems()
                     ) {
                    resultItemList.getItems().add(item);

                }
                resultItemList.refresh();
                bagValue.setText(
                        NationalizationManager.getResourceBundle().getString("BagValue") + " "
                +Warehouse.result.getBagValue());

                bagWeight.setText(
                        NationalizationManager.getResourceBundle().getString("BagWeight")
                               +" " +Warehouse.result.GetBagWeight());
                Warehouse.result=null;
            }
        }
        else
            System.out.println("need items and algorithm");
    }
    @FXML
    public void LangEN()
    {
        LangChange("en");
    }
    public void LangPL()
    {
        LangChange("pl");
    }

    public void restoreValue()
    {
        itemNameInput.setText(Warehouse.tempItemName);
        itemValueInput.setText(Warehouse.tempItemValue);
        itemWeightInput.setText(Warehouse.tempItemWeight);

    }
    @FXML
    public void initialize()
    {
        System.out.println("initialize");
       comboBox.setItems(algorithms);
       ChangeLanguageCombo.setItems(langs);
       update();


    }
    public  void update()
    {
        ChangeLanguageCombo.setValue(NationalizationManager.actualLang);
        System.out.println(NationalizationManager.timeFormatter.getLocale());
        System.out.println(NationalizationManager.timeFormatter.format(Warehouse.today));
        todayDate.setText(NationalizationManager.timeFormatter.format(Warehouse.today));
        itemNameInput.setText(Warehouse.tempItemName);
        restoreValue();
    }
    public boolean setAlgorithms()
    {
        String brute=NationalizationManager.getResourceBundle().getString("BruteForce");
        String random=NationalizationManager.getResourceBundle().getString("RandomSearch");
        Object option = comboBox.getValue();
        if(option!=null) {
            option=option.toString();
            if (option.equals(brute)) {
                Warehouse.algorithm = new KnapsackBForceAlgorithm(Warehouse.KnapProblem);
                return true;
            } else if (comboBox.getValue().toString().equals(random)) {
                Warehouse.algorithm = new KnapsackRSearchAlgorithm(Warehouse.KnapProblem);
                return true;
            } else {
                System.out.println("Algorithm error?");
                return false;
            }
        }
        return  false;
    }

    @FXML
    public void ChangeLanguage(){
    NationalizationManager.setLocal(ChangeLanguageCombo.getValue().toString());
    update();
    }
    @FXML
    public void About()
    {
        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Information Dialog");
        alert.setHeaderText(null);
        alert.setContentText(NationalizationManager.getResourceBundle().getString("AboutDesc"));

        alert.showAndWait();
    }



}
