/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package warstwa_biznesowa;

import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Cezary
 */
public class Facade {
    public List<City> cityList;
    public List<Client> clientList;
    
    private Factory factory;

    public Facade()
    {
        factory = new Factory();
        cityList = new ArrayList<City>();
        clientList = new ArrayList<Client>();
    }
    
    public static void main(String[] args)
    {
        Facade facade = new Facade();
       
        facade.AddClient("test@gmail.com", "haslo");
        
        // ------ DODAWANIE MIAST ------ //
        facade.AddCity("Gdańsk");
        facade.AddCity("Poznań");
        facade.AddCity("Wrocław");
        
        
        // ------ DODAWANIE HOTELI DO MIAST ------ //
        
        // Gdańsk
        facade.AddHotel("Gdańsk", "Hotel 3 Gwiazdkowy");
        facade.AddHotel("Gdańsk", "Hotel 4 Gwiazdkowy");
        facade.AddHotel("Gdańsk", "Hotel 5 Gwiazdkowy");
        
        // Poznań
        facade.AddHotel("Poznań", "Hotel 3 Gwiazdkowy");
        facade.AddHotel("Poznań", "Hotel 4 Gwiazdkowy");
        
        // Wrocław
        facade.AddHotel("Wrocław", "Hotel 3 Gwiazdkowy");
        facade.AddHotel("Wrocław", "Hotel 4 Gwiazdkowy");
        facade.AddHotel("Wrocław", "Hotel 5 Gwiazdkowy");
        
        
        // ------ DODAWANIE POKOI DO HOTELI ------ //
        
        facade.AddRoom("Gdańsk", "Hotel 3 Gwiazdkowy", 1, 2, 200);
        facade.AddRoom("Gdańsk", "Hotel 3 Gwiazdkowy", 2, 2, 200);
        facade.AddRoom("Gdańsk", "Hotel 3 Gwiazdkowy", 3, 2, 200);

        facade.AddRoom("Gdańsk", "Hotel 4 Gwiazdkowy", 1, 1, 100);
        facade.AddRoom("Gdańsk", "Hotel 4 Gwiazdkowy", 101, 1, 100);
        facade.AddRoom("Gdańsk", "Hotel 4 Gwiazdkowy", 2, 2, 200);
        facade.AddRoom("Gdańsk", "Hotel 4 Gwiazdkowy", 102, 2, 200);
        facade.AddRoom("Gdańsk", "Hotel 4 Gwiazdkowy", 3, 3, 300);
        facade.AddRoom("Gdańsk", "Hotel 4 Gwiazdkowy", 103, 3, 300);
        facade.AddRoom("Gdańsk", "Hotel 4 Gwiazdkowy", 4, 4, 400);

        facade.AddRoom("Poznań", "Hotel 3 Gwiazdkowy", 1, 2, 100);
        facade.AddRoom("Poznań", "Hotel 3 Gwiazdkowy", 2, 2, 200);
        facade.AddRoom("Poznań", "Hotel 3 Gwiazdkowy", 3, 2, 300);

        facade.AddRoom("Poznań", "Hotel 4 Gwiazdkowy", 1, 2, 100);
        facade.AddRoom("Poznań", "Hotel 4 Gwiazdkowy", 2, 2, 200);
        facade.AddRoom("Poznań", "Hotel 4 Gwiazdkowy", 3, 2, 300);
        
        facade.AddRoom("Wrocław", "Hotel 3 Gwiazdkowy", 1, 1, 300);
        facade.AddRoom("Wrocław", "Hotel 3 Gwiazdkowy", 2, 2, 400);
        facade.AddRoom("Wrocław", "Hotel 3 Gwiazdkowy", 3, 3, 500);

        facade.AddRoom("Wrocław", "Hotel 4 Gwiazdkowy", 1, 1, 600);
        facade.AddRoom("Wrocław", "Hotel 4 Gwiazdkowy", 2, 2, 700);
        facade.AddRoom("Wrocław", "Hotel 4 Gwiazdkowy", 3, 3, 800);

        facade.AddRoom("Wrocław", "Hotel 5 Gwiazdkowy", 1, 1, 900);
        facade.AddRoom("Wrocław", "Hotel 5 Gwiazdkowy", 2, 2, 1000);
        facade.AddRoom("Wrocław", "Hotel 5 Gwiazdkowy", 3, 3, 1100);
        
        
        System.out.println("Dane: (Nazwa miasta - Liczba hoteli - Liczba pokoi)");
        for(City loopCity : facade.cityList)
        {
            int rooms = 0;
            for(Hotel loopHotel : loopCity.hotelList)
            {
                rooms += loopHotel.roomList.size();
            }
            
            System.out.println("- " + loopCity.name + " - " + loopCity.hotelList.size() + " - " + rooms);
            
            for(Hotel loopHotel : loopCity.hotelList)
            {
                System.out.println(" - " + loopHotel.name);
               
                for(Room loopRoom : loopHotel.roomList)
                {
                   System.out.println("  - Nr: " + loopRoom.number + " | Rozmiar: " + loopRoom.size + " | Cena: " + loopRoom.price);
                }
            }
            
            System.out.println("");
        }
        
        System.out.println("");
        
        
        
        // ------ DOKONYWANIE REZERWACJI ------ //
        
        // Dodanie do daty początkowej 3 tygodni, ponieważ anulować można tylko max 2 tyg przed datą początkową
        LocalDate startDate = LocalDate.now().plus(3, ChronoUnit.WEEKS),
                endDate = startDate.plus(7, ChronoUnit.DAYS);
        
        boolean status;
        System.out.println("Dokonywanie rezerwacji | Miasto: Wrocław | Hotel: Hotel 5 Gwiazdkowy | Rozmiar pokoju: 2 | Cena: 1000");
        status = facade.Reserve("test@gmail.com", "haslo", "Wrocław", "Hotel 5 Gwiazdkowy", 2, 1000, startDate, endDate);
        System.out.println((status ? "Zarezerwowano" : "Błąd") + "\n");
        
        System.out.println("Dokonywanie rezerwacji | Miasto: Wrocław | Hotel: Hotel 5 Gwiazdkowy | Rozmiar pokoju: 2 | Cena: 1000");
        status = facade.Reserve("test@gmail.com", "haslo", "Wrocław", "Hotel 5 Gwiazdkowy", 2, 1000, startDate, endDate);
        System.out.println((status ? "Zarezerwowano" : "Błąd (istnieje rezerwacja na tą datę, nie ma innych takich pokoi)") + "\n");
        
        System.out.println("Dokonywanie rezerwacji | Miasto: Gdańsk | Hotel: Hotel 3 Gwiazdkowy | Rozmiar pokoju: 2 | Cena: 200");
        status = facade.Reserve("test@gmail.com", "haslo", "Gdańsk", "Hotel 3 Gwiazdkowy", 2, 200, startDate, endDate);
        System.out.println((status ? "Zarezerwowano" : "Błąd") + "\n");
        
        System.out.println("Dokonywanie rezerwacji | Miasto: Gdańsk | Hotel: Hotel 3 Gwiazdkowy | Rozmiar pokoju: 2 | Cena: 200");
        status = facade.Reserve("test@gmail.com", "haslo", "Gdańsk", "Hotel 3 Gwiazdkowy", 2, 200, startDate, endDate);
        System.out.println((status ? "Zarezerwowano (istnieje rezerwacja ale są inne takie pokoje)" : "Błąd") + "\n");
        
        
        // ------ ANULOWANIE REZERWACJI ------ //
        
        Client client = facade.FindClient(facade.factory.CreateClient("test@gmail.com", "haslo"));
        Reservation reservation = (Reservation) client.GetReservationList().get(0);

        System.out.println("Anulowanie rezerwacji numer: " + reservation.number);
        status = facade.CancelReservation("test@gmail.com", "haslo", reservation.number);
        System.out.println((status ? "Anulowano" : "Błąd") + "\n");
        
        System.out.println("Anulowanie rezerwacji numer: " + reservation.number);
        status = facade.CancelReservation("test@gmail.com", "haslo", reservation.number);
        System.out.println((status ? "Anulowano" : "Błąd (Nie istnieje już taka rezerwacja)") + "\n");
        
        reservation = (Reservation) client.GetReservationList().get(0);
        System.out.println("Anulowanie rezerwacji numer: " + reservation.number);
        status = facade.CancelReservation("test@gmail.com", "haslo", reservation.number);
        System.out.println((status ? "Anulowano" : "Błąd (Nie istnieje już taka rezerwacja)") + "\n");
    }
    
    public boolean AddClient(String email, String password)
    {
        Client client = factory.CreateClient(email, password);
        
        if(FindClient(client) != null)
        {
            return false;
        }
  
        return clientList.add(client);
    }
    
    public boolean AddCity(String name)
    {
        City city = factory.CreateCity(name);
        
        if(FindCity(city) != null)
        {
            return false;
        }
        
        return cityList.add(city);
    }
    
    public boolean AddHotel(String cityName, String hotelName)
    {
        City city;
        City cityTemp = factory.CreateCity(cityName);
        
        if((city = FindCity(cityTemp)) == null)
        {
            return false;
        }
        
        
        return city.AddHotel(hotelName);
    }
    
    public boolean AddRoom(String cityName, String hotelName, int number, int size, int price)
    {
        City city;
        City cityTemp = factory.CreateCity(cityName);
        
        if((city = this.FindCity(cityTemp)) == null)
        {
            return false;
        }

        return city.AddRoom(hotelName, number, size, price);
    }
    
    public Client FindClient(Client client)
    {
        int index = -1;
        
        if((index = this.clientList.indexOf(client)) != -1)
            return this.clientList.get(index);
        
        return null;
    }
    
    public City FindCity(City city)
    {
        int index = -1;
        
        if((index = this.cityList.indexOf(city)) != -1)
            return this.cityList.get(index);
        
        return null;
    }
    
    public boolean Reserve(String email, String password, String cityName, String hotelName, int size, int price, LocalDate startDate, LocalDate endDate)
    {
        Client client;
        City city;
        
        Client clientTemp = factory.CreateClient(email, password);
        if((client = this.FindClient(clientTemp)) == null)
        {
            return false;
        }
     
        City cityTemp = factory.CreateCity(cityName);
        if((city = this.FindCity(cityTemp)) == null)
        {
            return false;
        }
        
        return city.Reserve(client, hotelName, size, price, startDate, endDate);
    }
    
    public boolean CancelReservation(String email, String password, String reservationNumber)
    {
        Client client;
 
        Client clientTemp = factory.CreateClient(email, password);
        if((client = this.FindClient(clientTemp)) == null)
        {
            return false;
        }
        
        return client.CancelReservation(reservationNumber);
    }
    
    public boolean RemoveClient(String email, String password)
    {
        return true;
    }
    
    public boolean RemoveCity(String cityName)
    {        
        City city;
        
        City cityTemp = factory.CreateCity(cityName);
        if((city = this.FindCity(cityTemp)) == null)
        {
            return false;
        }
        
        if(!city.CancelReservations())
        {
            return false;
        }
        
        return this.cityList.remove(city);
    }
    
    public boolean RemoveHotel(String cityName, String hotelName)
    {
        return true;
    }
    
    public boolean RemoveRoom(String cityName, String hotelName, int number)
    {
        return true;
    }
}
