//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using DO;

namespace Dal;

public class DalOrder
{
    public void Add(Order newOrder)
    {
        for (int i = 0; i < DataSource.Config.NumOfOrders; i++)
        {
            if (DataSource.Orders[i].ID == newOrder.ID)
                throw new Exception("This order is already exists");
        }
        DataSource.Orders[DataSource.Config.NumOfOrders] = newOrder;
        DataSource.Config.NumOfOrders++;
    }
    public void Delete(int id)
    {
        for (int i = 0; i < DataSource.Config.NumOfOrders; i++)
        {

            if (DataSource.Orders[i].ID == id)
            {
                DataSource.Orders[i] = DataSource.Orders[DataSource.Config.NumOfOrders - 1];
                DataSource.Config.NumOfOrders--;
            }
        }
        throw new Exception("This order is not exsist");
    }

    public Order GetByID(int id)
    {
        for (int i = 0; i < DataSource.Config.NumOfOrders; i++)
        {
            if (DataSource.Orders[i].ID == id)
                return DataSource.Orders[i];
        }
        throw new Exception("This order is not exsist");
    }

    public void Uppdate(Order newOrder)
    {
        for (int i = 0; i < DataSource.Config.NumOfOrders; i++)
        {
            if (DataSource.Orders[i].ID == newOrder.ID)
            {
                DataSource.Orders[i] = newOrder;
                return;
            }
        }
        throw new Exception("This order is not exsist");
    }

    public IEnumerable<Order> GetAll()
    {
        Order[] orr = new Order[DataSource.Config.NumOfOrders];
        for (int i = 0; i < DataSource.Config.NumOfOrders; i++)
        {
            orr[i] = DataSource.Orders[i];
        }
        return orr;
    }
}
