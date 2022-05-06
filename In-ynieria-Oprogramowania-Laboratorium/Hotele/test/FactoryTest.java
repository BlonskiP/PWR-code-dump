/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import categories.TestControl;
import categories.TestEntity;
import java.util.Arrays;
import java.util.Collection;
import org.junit.Test;
import static org.junit.Assert.*;
import org.junit.experimental.categories.Category;

import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;
import warstwa_biznesowa.Factory;

/**
 *
 * @author Cezary
 */

@Category({TestControl.class, TestEntity.class}) 
@RunWith(Parameterized.class)

public class FactoryTest {
    Data data = new Data();
    Factory factory = new Factory();
    
    @Parameterized.Parameter
    public int id;

    @Parameterized.Parameters
    public static Collection<Object[]> data()
    {
        Object[][] data1 = new Object[][]{
            {0}, {1}, {2},
        };
        
        return Arrays.asList(data1);
    }
    
    @Test
    public void testCreateClient()
    {
        assertEquals(data.clients[id], factory.CreateClient(data.clientsData[id][0], data.clientsData[id][1]));
    }
    
    @Test
    public void testCreateCity()
    {
        assertEquals(data.cities[id], factory.CreateCity(data.citiesData[id]));
    }
}
