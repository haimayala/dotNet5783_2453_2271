
using DO;
using System.Drawing;

namespace Dal;

public class DalOrderItem
{
    public int Add(OrderItem newOrderItem)
    {
        newOrderItem.ID = DataSource.nextOrderItem/*+ DataSource._numOfOrderItems*/;
        DataSource._ordersItmes[DataSource._numOfOrderItems] = newOrderItem;
        DataSource._numOfOrderItems++;
        return newOrderItem.ID;
    }

    public void Delete(int id)
    {

        for (int i = 0; i < DataSource._numOfOrderItems; i++)
        {

            if (DataSource._ordersItmes[i].ID == id)
            {
                DataSource._ordersItmes[i] = DataSource._ordersItmes[DataSource._numOfOrderItems - 1];
                DataSource._numOfOrderItems--;
                return;
            }
        }
        throw new Exception("This order item is not exsist");
    }

    public OrderItem GetByID(int id)
    {
        for (int i = 0; i < DataSource._numOfOrderItems; i++)
        {
            if (DataSource._ordersItmes[i].ID == id)
                return DataSource._ordersItmes[i];
        }
      
        throw new Exception("This order item is not exsist");
    }
    public void Uppdate(OrderItem newOrderItem)
    {
        for (int i = 0; i < DataSource._numOfOrderItems; i++)
        {
            if (DataSource._ordersItmes[i].ID == newOrderItem.ID)
            {
                DataSource._ordersItmes[i] = newOrderItem;
                return;
            }
        }
        throw new Exception("This order item is not exsist");
    }

    public OrderItem[] GetAll()
    {
        OrderItem[] odr = new OrderItem[DataSource._numOfOrderItems];
        for (int i = 0; i < DataSource._numOfOrderItems; i++)
        {
            odr[i] = DataSource._ordersItmes[i];
        }
        return odr;
    }

    public OrderItem GetByProductAndOrder(int p, int or)
    {
        foreach (OrderItem o in DataSource._ordersItmes)
        {
            if (o.ProductID == p && o.OrderID == or)
                return o;
        }
        throw new Exception("This order item is not exsist");
    }

    public OrderItem[] GetByOrderId(int id)
    {
        int counter = 0;
        for(int i=0;i<DataSource._ordersItmes.Length;i++)
        {
            if (DataSource._ordersItmes[i].OrderID == id) ;
            counter++;
        }
        OrderItem[] odr = new OrderItem[counter];
        for (int i = 0; i < DataSource._ordersItmes.Length; i++)
        {
            if (DataSource._ordersItmes[i].OrderID == id) ;
            odr[i] = DataSource._ordersItmes[i];
        }
        return odr;
    }

}


