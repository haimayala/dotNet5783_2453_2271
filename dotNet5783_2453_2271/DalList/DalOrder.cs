//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using DO;

namespace Dal;

public class DalOrder
{
    public void addNewOrder(Order newOrderItem)
    {
        
    }
    public void deleteOrder(int id)
    {
        Order delOrder = new Order();
        for (int i = 0; i < 100; i++)
        {
            if (DataSource.arr2[i].ID == newProduct.ID)
                DataSource.arr2[i] = delOrder;
        }
    }

    public Order searchOrder(int id)
    {
        for (int i = 0; i < 100; i++)
        {
            if (DataSource.arr2[i].ID == id)
                return DataSource.arr2[i];
        }
        return new Order();// to check it
    }

    public void updateOrder(Order newOrderItem)
    {
        for (int i = 0; i < 100; i++)
        {
            if (DataSource.arr2[i].ID == newOrderItem.ID) 
                DataSource.arr2[i] = newOrderItem;
        }
    }
}
