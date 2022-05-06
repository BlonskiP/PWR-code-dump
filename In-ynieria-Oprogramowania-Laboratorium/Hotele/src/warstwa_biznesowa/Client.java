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
public final class Client {
    protected String email;
    protected String password;
    protected String firstName;
    protected String lastName;
    protected String phone;
    protected String address;
    
    private List<Reservation> reservationList;
    
    private Factory factory;
    
    public Client(String email, String password)
    {
        this.email = email;
        this.password = password;
        
        reservationList = new ArrayList<Reservation>();
        
        factory = new Factory();
    }
    
    public void SetEmail(String email)
    {
        this.email = email;
    }
    
    public void SetPassword(String password)
    {
        this.password = password;
    }
    
    public void SetFirstName(String firstName)
    {
        this.firstName = firstName;
    }
    
    public void SetLastName(String lastName)
    {
        this.lastName = lastName;
    }
    
    public void SetPhone(String phone)
    {
        this.phone = phone;
    }
    
    public void SetAddress(String address)
    {
        this.address = address;
    }
    
    public String GetEmail()
    {
        return this.email;
    }
    
    public String GetFirstName()
    {
        return this.firstName;
    }
    
    public String GetLastName()
    {
        return this.lastName;
    }
    
    public String GetPhone()
    {
        return this.phone;
    }
    
    public String GetAddress()
    {
        return this.address;
    }
    
    public List GetReservationList()
    {
        return this.reservationList;
    }
    
    public boolean CheckPassword(String password)
    {
        return true;
    }
    
    public Reservation FindReservation(Reservation reservation)
    {
        int index = -1;
        
        if((index = this.reservationList.indexOf(reservation)) != -1)
            return this.reservationList.get(index);
        
        return null;
    }
    
    public boolean Reserve(Reservation reservation)
    {
        return this.reservationList.add(reservation);
    }
    
    public boolean CancelReservation(String reservationNumber)
    {
        Reservation reservation;
        
        Reservation reservationTemp = factory.CreateReservation(reservationNumber);
        if((reservation = FindReservation(reservationTemp)) == null)
        {
            return false;
        }
        
        if(!reservation.CheckDate())
        {
            return false;
        }
        
        return reservation.Cancel();
    }
    
    public boolean RemoveReservation(Reservation reservation)
    {
        return reservationList.remove(reservation);
    }
    
    @Override
    public boolean equals(Object o)
    {
        Client client = (Client) o;
        return this.email.equals(client.email);
    }
}
