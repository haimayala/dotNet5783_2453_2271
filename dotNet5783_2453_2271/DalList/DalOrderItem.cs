//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using DO;
using System.Drawing;

namespace Dal;

public class DalOrderItem
{
    public void AddNewOrderItem(OrderItem newOrderItem)
    {
        foreach (OrderItem o in DataSource.OrderItems)
        {
            if (o.ID == newOrderItem.ID)
                throw new Exception("This order item is already exists");

        }
        DataSource.OrderItems.Add(newOrderItem);
    }

    public void DeleteOrderItem(int id)
    {

        foreach (OrderItem o in DataSource.OrderItems)
        {
            if (o.ID == id)
                DataSource.OrderItems.Remove(o);
        }
        throw new Exception("This order item is not exsist");
    }

    public OrderItem GetByID(int id)
    {
        foreach (OrderItem o in DataSource.OrderItems)
        {
            if (o.ID == id)
                return o;
        }
        throw new Exception("This order item is not exsist");
    }
    public void UpdateOrderItem(OrderItem newOrderItem)
    {
        foreach (OrderItem o in DataSource.OrderItems)
        {
            if (o.ID == newOrderItem.ID)
            {
                DataSource.OrderItems.Remove(o);
                DataSource.OrderItems.Add(newOrderItem);
                return;
            }

        }
        throw new Exception("This order item is not exsist");
    }

    public IEnumerable<OrderItem> GetAll()
    {
        return DataSource.OrderItems;
    }

}



