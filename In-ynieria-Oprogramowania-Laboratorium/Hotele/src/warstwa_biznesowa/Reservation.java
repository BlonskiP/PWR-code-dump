/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package warstwa_biznesowa;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;

/**
 *
 * @author Cezary
 */
public class Reservation {
    public String number;
    public LocalDate startDate;
    public LocalDate endDate;
    
    public Client client;
    public Room room;
    
    public Reservation(Client client, Room room, LocalDate startDate, LocalDate endDate)
    {
        this.client = client;
        this.room = room;
        this.startDate = startDate;
        this.endDate = endDate;

        this.GenerateNumber();
    }
    
    public Reservation(String number)
    {
        this.number = number;
    }
    
    public void GenerateNumber()
    {
        // client start date + email + city name + hotel name + room number
        String dateString = startDate.format(DateTimeFormatter.ofPattern("yyyyMMdd"));
        
        String cityName = room.hotel.city.GetName().replaceAll(" ", "").toLowerCase();
        String hotelName = room.hotel.GetName().replaceAll(" ", "").toLowerCase();
        
        String number = dateString + "_" + client.GetEmail() + "_" + cityName + "_" + hotelName + "_" + room.GetNumber();
        
        this.number = number;
    }
    
    public boolean Cancel()
    {
        this.room.RemoveReservation(this);
        this.client.RemoveReservation(this);
        
        return true;
    }
    
    public boolean CheckDate()
    {
        return (startDate.compareTo(LocalDate.now().plus(2, ChronoUnit.WEEKS)) >= 0);
    }
    
    public boolean CompareDates(Reservation reservation)
    {
        return this.startDate.compareTo(reservation.startDate) >= 0 && this.startDate.compareTo(reservation.endDate) < 0 || this.endDate.compareTo(reservation.startDate) > 0 && this.endDate.compareTo(reservation.endDate) <= 0;
    }
    
    @Override
    public boolean equals(Object o)
    {
        Reservation reservation = (Reservation) o;
        return this.number.equals(reservation.number);
    }
}
