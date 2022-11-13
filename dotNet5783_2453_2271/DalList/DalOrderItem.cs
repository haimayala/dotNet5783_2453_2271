

using DO;
using System.Drawing;

namespace Dal;

public class DalOrderItem
{
    public void Add(OrderItem newOrderItem)
    {
        for (int i = 0; i < DataSource.Config.NumOfOrderItems; i++)
        {
            if (DataSource.OrdersItmes[i].ID == newOrderItem.ID)
                throw new Exception("This order item is already exists");
        }
        DataSource.OrdersItmes[DataSource.Config.NumOfOrderItems] = newOrderItem;
        DataSource.Config.NumOfOrderItems++;
    }

    public void Delete(int id)
    {

        for (int i = 0; i < DataSource.Config.NumOfOrderItems; i++)
        {

            if (DataSource.OrdersItmes[i].ID == id)
            {
                DataSource.OrdersItmes[i] = DataSource.OrdersItmes[DataSource.Config.NumOfOrderItems - 1];
                DataSource.Config.NumOfOrderItems--;
            }
        }
        throw new Exception("This order item is not exsist");
    }

    public OrderItem GetByID(int id)
    {
        for (int i = 0; i < DataSource.Config.NumOfOrderItems; i++)
        {
            if (DataSource.OrdersItmes[i].ID == id)
                return DataSource.OrdersItmes[i];
        }
      
        throw new Exception("This order item is not exsist");
    }
    public void Uppdate(OrderItem newOrderItem)
    {
        for (int i = 0; i < DataSource.Config.NumOfOrderItems; i++)
        {
            if (DataSource.OrdersItmes[i].ID == newOrderItem.ID)
            {
                DataSource.OrdersItmes[i] = newOrderItem;
                return;
            }
        }
        throw new Exception("This order item is not exsist");
    }

    public IEnumerable<OrderItem> GetAll()
    {
        OrderItem[] odr = new OrderItem[DataSource.Config.NumOfOrderItems];
        for (int i = 0; i < DataSource.Config.NumOfOrderItems; i++)
        {
            odr[i] = DataSource.OrdersItmes[i];
        }
        return odr;
    }

    public OrderItem GetByProductAndOrder(int p, int or)
    {
        foreach (OrderItem o in DataSource.OrderItems)
        {
            if (o.ProductID == p && o.OrderID == or)
                return o;
        }
        throw new Exception("This order item is not exsist");
    }

}


