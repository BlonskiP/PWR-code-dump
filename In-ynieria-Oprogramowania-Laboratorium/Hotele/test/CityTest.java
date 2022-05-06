/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import categories.ReserveTestCategory;
import categories.TestControl;
import categories.TestEntity;
import java.time.LocalDate;
import org.junit.Test;
import static org.junit.Assert.*;
import org.junit.FixMethodOrder;
import org.junit.experimental.categories.Category;
import org.junit.runners.MethodSorters;
import warstwa_biznesowa.City;
import warstwa_biznesowa.Client;
import warstwa_biznesowa.Facade;
import warstwa_biznesowa.Hotel;
import org.junit.BeforeClass;

/**
 *
 * @author Cezary
 */

@Category({TestControl.class, TestEntity.class}) 
@FixMethodOrder(MethodSorters.NAME_ASCENDING)

public class CityTest {
    static Data data;
    static Facade facade;
    City city = data.cities[0];
    
    @BeforeClass
    public static void setUp()
    {
        data = new Data();
        facade = new Facade();
    }

    @Test
    public void test1AddHotel()
    {
        for(int i = 0; i < data.hotelsData.length; i++)
        {
            assertTrue(city.AddHotel(data.hotelsData[i][1]));
            assertFalse(city.AddHotel(data.hotelsData[i][1]));
            
            assertEquals(i + 1, city.hotelList.size());
            assertEquals(data.hotels[i], city.hotelList.get(i));
        }
    }

    //@Category({AddRoomTestCategory.class})
    @Test
    public void test2AddRoom() 
    {
        for(int i = 0; i < data.roomsData.length; i++)
        {
            Hotel hotel = city.hotelList.get(i);
            
            assertTrue(city.AddRoom(hotel.GetName(), data.roomsData[i][0], data.roomsData[i][1], data.roomsData[i][2]));
            assertFalse(city.AddRoom(hotel.GetName(), data.roomsData[i][0], data.roomsData[i][1], data.roomsData[i][2]));
            
            assertEquals(1, hotel.roomList.size());
            assertEquals(data.rooms[i], hotel.roomList.get(0));
        }
    }
    
    //@Category({ReserveTestCategory.class})
    @Test
    public void test3Reserve()
    {
        Client client = data.clients[0];

        assertTrue(city.Reserve(client, data.hotelsData[0][1], data.roomsData[0][1], data.roomsData[0][2], LocalDate.now(), LocalDate.now()));
    }
}
