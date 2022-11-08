//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using DO;

namespace Dal;

public class DalOrder
{
    public void AddNewOrder(Order newOrder)
    {
        foreach (Order or in DataSource.Orders)
        {
            if (or.ID == newOrder.ID)
                throw new Exception("This order is already exists");

        }
        DataSource.Orders.Add(newOrder);
    }
    public void DeleteOrder(int id)
    {
        foreach (Order or in DataSource.Orders)
        {
            if (or.ID == id)
                DataSource.Orders.Remove(or);
        }
        throw new Exception("This order is not exsist");
    }

    public Order GetByID(int id)
    {
        foreach (Order or in DataSource.Orders)
        {
            if (or.ID == id)
                return or;
        }
        throw new Exception("This order is not exsist");
    }

    public void UpdateOrder(Order newOrder)
    {
        foreach (Order or in DataSource.Orders)
        {
            if (or.ID == newOrder.ID)
            {
                DataSource.Orders.Remove(or);
                DataSource.Orders.Add(newOrder);
                return;
            }

        }
        throw new Exception("This order is not exsist");
    }

    public IEnumerable<Order> GetAll()
    {
        return DataSource.Orders;
    }
}
