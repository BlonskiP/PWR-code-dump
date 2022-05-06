/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package warstwa_biznesowa;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Cezary
 */
public class City {
    protected String name;
    protected String country;
    
    public List<Hotel> hotelList;
    
    private Factory factory;
    
    public City(String name)
    {
        this.name = name;
        
        hotelList = new ArrayList<Hotel>();
        
        factory = new Factory();
    }
    
    public void SetName(String name)
    {
        this.name = name;
    }
    
    public void SetCountry(String country)
    {
        this.country = country;
    }
    
    public String GetName()
    {
        return this.name;
    }
    
    public String GetCountry()
    {
        return this.country;
    }
    
    public List GetHotelList()
    {
        return this.hotelList;
    }
    
    public boolean AddHotel(String hotelName)
    {    
        Hotel hotel = factory.CreateHotel(this, hotelName);
        
        if(FindHotel(hotel) != null)
        {
            return false;
        }

        return this.hotelList.add(hotel);
    }
    
    public boolean AddRoom(String hotelName, int number, int size, int price)
    {
        Hotel hotel;
        Hotel hotelTemp = factory.CreateHotel(this, hotelName);
        if((hotel = FindHotel(hotelTemp)) == null)
        {
            return false;
        }
        
        return hotel.AddRoom(number, size, price);
    }
    
    public Hotel FindHotel(Hotel hotel)
    {
        int index = -1;
        
        if((index = this.hotelList.indexOf(hotel)) != -1)
            return this.hotelList.get(index);
        
        return null;
    }
    
    public boolean Reserve(Client client, String hotelName, int size, int price, LocalDate startDate, LocalDate endDate)
    {
        Factory factory = new Factory();
        
        Hotel hotel;
        Hotel hotelTemp = factory.CreateHotel(this, hotelName);
        if((hotel = this.FindHotel(hotelTemp)) == null)
        {
            return false;
        }
        
        return hotel.Reserve(client, size, price, startDate, endDate);
    }
    
    public boolean CancelReservations()
    {
        for(Hotel hotel : hotelList)
        {
            if(!hotel.CancelReservations())
            {
                return false;
            }
        }
        
        return true;
    }
    
    @Override
    public boolean equals(Object o)
    {
        City city = (City) o;
        return this.name.equals(city.name);
    }
}
