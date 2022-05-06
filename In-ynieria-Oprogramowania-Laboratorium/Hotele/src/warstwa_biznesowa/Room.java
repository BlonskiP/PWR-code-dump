/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package warstwa_biznesowa;

import java.util.ArrayList;
import java.time.LocalDate;
import java.util.List;

/**
 *
 * @author Cezary
 */
public class Room {
    protected Hotel hotel;
    protected int number;
    protected int size;
    protected int price;
    
    protected String description;
    protected String photo;
    
    private List<Reservation> reservationList;
    
    private Factory factory;
    
    public Room(Hotel hotel, int number, int size, int price)
    {
        this.hotel = hotel;
        this.number = number;
        this.size = size;
        this.price = price;
        
        reservationList = new ArrayList<Reservation>();
        
        factory = new Factory();
    }
 
    public void SetNumber(int number)
    {
        this.number = number;
    }
    
    public void SetSize(int size)
    {
        this.size = size;
    }
    
    public void SetPrice(int price)
    {
        this.price = price;
    }
    
    public void SetDescription(String des)
    {
        this.description = des;
    }
    
    public void SetPhoto(String photo)
    {
        this.photo = photo;
    }
    
    public int GetNumber()
    {
        return this.number;
    }
    
    public int GetPrice()
    {
        return this.price;
    }
    
    public int GetSize()
    {
        return this.size;
    }
    
    public String GetPhoto()
    {
        return this.photo;
    }
    
    public List<Reservation> GetReservationList()
    {
        return this.reservationList;
    }
    
    public Reservation FindReservation(Reservation reservation)
    {
        int index = -1;
        
        if((index = this.reservationList.indexOf(reservation)) != -1)
            return this.reservationList.get(index);
        
        return null;
    }
    
    public Reservation FindReservationByDate(Reservation reservation)
    {
        for(Reservation loopReservation : reservationList)
        {
            if(reservation.CompareDates(loopReservation))
            {
                return loopReservation;
            }
        }
        
        return null;
    }
    
    public boolean Reserve(Client client, LocalDate startDate, LocalDate endDate)
    {
        Reservation reservation = factory.CreateReservation(client, this, startDate, endDate);
        if(FindReservationByDate(reservation) != null)
        {
            return false;
        }
        
        this.reservationList.add(reservation);
        return client.Reserve(reservation);
    }
 
    public boolean CancelReservations()
    {
        for(Reservation reservation : reservationList)
        {
            if(!reservation.Cancel())
            {
                return false;
            }
        }
        
        return true;
    }
    
    public boolean RemoveReservation(Reservation reservation)
    {
        return this.reservationList.remove(reservation);
    }
    
    public boolean CompareAttributes(int size, int price)
    {
        if(this.size != size || this.price != price)
        {
            return false;
        }
        
        return true;
    }
    
    @Override
    public boolean equals(Object o)
    {
        Room room = (Room) o;
        return this.number == room.number;
    }
}
