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
public class Hotel {
    protected City city;
    protected String name;
    
    protected String description;
    protected String address;
    protected int stars;
    protected String photo;
    
    public List<Room> roomList;
    
    private Factory factory;
   
    public Hotel(City city, String name)
    {
        this.city = city;
        this.name = name;
        
        roomList = new ArrayList<Room>();
        
        factory = new Factory();
    }
    
    public void SetName(String name)
    {
        this.name = name;
    }
    
    public void SetDescription(String desc)
    {
        this.description = desc;
    }
    
    public void SetAddress(String address)
    {
        this.address = address;
    }
    
    public void SetStars(int stars)
    {
        this.stars = stars;
    }
    
    public void SetPhoto(String photo)
    {
        this.photo = photo;
    }
    
    public String GetName()
    {
        return this.name;
    }
    
    public String GetAddress()
    {
        return this.address;
    }
    
    public int GetStars()
    {
        return this.stars;
    }
    
    public String GetPhoto()
    {
        return this.photo;
    }
    
    public List GetRoomList()
    {
        return this.roomList;
    }
    
    public boolean AddRoom(int number, int size, int price)
    {
        Room room = factory.CreateRoom(this, number, size, price);
        if(FindRoom(room) != null)
        {
            return false;
        }

        return this.roomList.add(room);
    }
    
    public Room FindRoom(Room room)
    {
        int index = -1;
        
        if((index = this.roomList.indexOf(room)) != -1)
            return this.roomList.get(index);
        
        return null;
    }
    
    public boolean Reserve(Client client, int size, int price, LocalDate startDate, LocalDate endDate)
    {
        for(Room loopRoom : this.roomList)
        {
            if(loopRoom.CompareAttributes(size, price))
            {
                if(loopRoom.Reserve(client, startDate, endDate))
                {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    public boolean CancelReservations()
    {
        for(Room room : roomList)
        {
            if(!room.CancelReservations())
            {
                return false;
            }
        }
        
        return true;
    }
    
    @Override
    public boolean equals(Object o)
    {
        Hotel hotel = (Hotel) o;
        return this.name.equals(hotel.name);
    }
}
