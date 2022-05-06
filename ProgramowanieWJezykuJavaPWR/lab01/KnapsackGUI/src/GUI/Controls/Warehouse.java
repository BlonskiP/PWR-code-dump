package GUI.Controls;

import KnapsackProblem.Item;
import KnapsackProblem.KnapsackSolvingAlgorithms.InstanceProblem;
import KnapsackProblem.KnapsackSolvingAlgorithms.KnapsackSolvingAlgorithm;
import KnapsackProblem.KnapsackSolvingAlgorithms.KnapsackSolvingResult;
import javafx.collections.ObservableList;
import javafx.scene.control.TextField;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class Warehouse {
    public static LocalDate today = LocalDate.now();
    public static String tempItemName;
    public static String tempItemValue;
    public static String tempItemWeight;
    public static int maxCapacity;
    public static KnapsackSolvingAlgorithm algorithm;
    public static KnapsackSolvingResult result;
    private TextField itemNameInput;
    public static InstanceProblem KnapProblem;
    public static ArrayList<Item> ItemList=new ArrayList<>();



}

