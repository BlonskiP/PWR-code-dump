package GUI;

import GUI.Controls.BetterScene;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;

import java.io.IOException;
import java.text.DateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.time.format.FormatStyle;
import java.util.Date;
import java.util.Locale;
import java.util.ResourceBundle;
import java.util.SimpleTimeZone;
import java.util.regex.Pattern;

public class NationalizationManager {
    public static String actualLang = "pl-PL";
    private static Locale locale=new Locale(actualLang);
    private static ResourceBundle LR=ResourceBundle.getBundle("res/LR",locale);
    public static DateTimeFormatter  timeFormatter= DateTimeFormatter.ofLocalizedDate(FormatStyle.MEDIUM).withLocale(locale);

    public static void setLocal(String localizationCode)
    {

        locale=new Locale(localizationCode);
        LR=ResourceBundle.getBundle("res/LR",locale);
        try {
            System.out.println("Lang change to " + localizationCode);
            actualLang=localizationCode;
            timeFormatter= DateTimeFormatter.ofLocalizedDate(FormatStyle.FULL).withLocale(locale);
            Parent newRoot=FXMLLoader.load(App.url,getResourceBundle());
            App.scene.setRoot(newRoot);

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static Locale getLocale()
    {
        return locale;
    }

    public  static ResourceBundle getResourceBundle()
    {
        return LR;
    }

}
