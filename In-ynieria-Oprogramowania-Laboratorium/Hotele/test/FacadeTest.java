/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import categories.TestControl;
import categories.TestEntity;
import java.time.LocalDate;
import mockit.Mocked;
import mockit.StrictExpectations;
import mockit.Verifications;
import mockit.integration.junit4.JMockit;
import org.junit.*;
import static org.junit.Assert.*;
import org.junit.experimental.categories.Category;
import org.junit.runner.RunWith;
import org.junit.runners.MethodSorters;
import warstwa_biznesowa.*;

/**
 *
 * @author Cezary
 */
@Category({TestControl.class, TestEntity.class}) 
@FixMethodOrder(MethodSorters.NAME_ASCENDING)
@RunWith(JMockit.class)

public class FacadeTest {
    static Data data;
    static Facade facade;
    
    @BeforeClass
    public static void setUp()
    {
        data = new Data();
        facade = new Facade();
    }
    
    @Test
    public void test1AddClient()
    {
        for(int i = 0; i < data.clientsData.length; i++)
        {
            assertTrue(facade.AddClient(data.clientsData[i][0], data.clientsData[i][1]));
            assertEquals(i + 1, facade.clientList.size());
            assertEquals(data.clients[i], facade.clientList.get(i));
        }
    }
    
    @Test
    public void test2AddCity()
    {
        for(int i = 0; i < data.citiesData.length; i++)
        {
            assertTrue(facade.AddCity(data.citiesData[i]));
            assertEquals(i + 1, facade.cityList.size());
            assertEquals(data.cities[i], facade.cityList.get(i));
        }
    }
    
    @Test
    public void test3AddHotel()
    {
        for(int i = 0; i < data.hotelsData.length; i++)
        {
            City city = facade.cityList.get(i);
            
            assertTrue(facade.AddHotel(data.hotelsData[i][0], data.hotelsData[i][1]));
            assertEquals(1, city.hotelList.size());
            assertEquals(data.hotels[i], city.hotelList.get(0));
        }
    }
    
    //@Category({AddRoomTestCategory.class})
    @Test
    public void test4AddRoom()
    {
        for(int i = 0; i < data.roomsData.length; i++)
        {
            City city = facade.cityList.get(i);
            Hotel hotel = city.hotelList.get(0);
            
            assertTrue(facade.AddRoom(city.GetName(), hotel.GetName(), data.roomsData[i][0], data.roomsData[i][1], data.roomsData[i][2]));
            assertFalse(facade.AddRoom(city.GetName(), hotel.GetName(), data.roomsData[i][0], data.roomsData[i][1], data.roomsData[i][2]));
            
            Room room = hotel.roomList.get(0);
            assertEquals(1, hotel.roomList.size());
            assertEquals(data.rooms[i], hotel.roomList.get(0));
        }
    }
    
    @Test
    public void test5Reserve()
    {
        assertTrue(facade.Reserve(data.clientsData[0][0], data.clientsData[0][1], data.citiesData[0], data.hotelsData[0][1], data.roomsData[0][1], data.roomsData[0][2], LocalDate.now(), LocalDate.now()));
    }
    
    @Test
    public void test6FindClient(@Mocked Client client)
    {
        facade.FindClient(data.clients[0]);
    
        new Verifications() {{ 
            client.equals(any);
            times = 3;
        }};
    }
    
    @Test
    public void test6FindCity(@Mocked City city)
    {
        facade.FindCity(data.cities[0]);
    
        new Verifications() {{ 
            city.equals(any);
            times = 3;
        }};
    }
    
    @Test
    public void test7AddClient(@Mocked Factory factory, @Mocked Client client)
    {
        facade.AddClient(data.clientsData[0][0], data.clientsData[0][1]);
    
        new Verifications() {{ 
            factory.CreateClient(data.clientsData[0][0], data.clientsData[0][1]);
            times = 1;
            
            client.equals(any);
            times = 3;
        }};
    }
}
