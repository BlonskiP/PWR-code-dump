
import warstwa_biznesowa.City;
import warstwa_biznesowa.Client;
import warstwa_biznesowa.Facade;
import warstwa_biznesowa.Hotel;
import warstwa_biznesowa.Room;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Cezary
 */
public class Data {
    public static Facade facade = new Facade();
    
    public static String clientsData[][] = new String[][] {
        {"testowy@gmail.com", "haslo"},
        {"testowy_2@gmail.com", "haslo_2"},
        {"testowy_3@gmail.com", "haslo_3"},
    };
    
    public static Client clients[] = {
        new Client("testowy@gmail.com", "haslo"),
        new Client("testowy_2@gmail.com", "haslo_2"),
        new Client("testowy_3@gmail.com", "haslo_3")
    };
    
    public static String citiesData[] = new String[] {
        "Wrocław",
        "Poznań",
        "Warszawa",
    };
    
    public static City cities[] = {
        new City("Wrocław"),
        new City("Poznań"),
        new City("Warszawa"),
    };
    
    public static String hotelsData[][] = new String[][] {
        {"Wrocław", "Hotel 1 Gwiazdkowy"},
        {"Poznań", "Hotel 2 Gwiazdkowy"},
        {"Warszawa", "Hotel 3 Gwiazdkowy"},
    };
    
    public static Hotel hotels[] = {
        new Hotel(cities[0], "Hotel 1 Gwiazdkowy"),
        new Hotel(cities[1], "Hotel 2 Gwiazdkowy"),
        new Hotel(cities[2], "Hotel 3 Gwiazdkowy"),
    };
    
    public static Room rooms[] = {
        new Room(hotels[0], 1, 1, 50),
        new Room(hotels[1], 2, 2, 100),
        new Room(hotels[2], 3, 3, 150),
    };
    
    public static int roomsData[][] = {
        {1, 1, 50},
        {2, 1, 100},
        {3, 1, 150},
    };

    
}//End of Data
