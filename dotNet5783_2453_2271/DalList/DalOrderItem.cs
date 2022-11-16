
using DO;
using System;
using System.Drawing;

namespace Dal;

public class DalOrderItem
{
    public int Add(OrderItem newOrderItem)
    {//the method adds an orderItem to the orderItem's arry 
        newOrderItem.ID = DataSource.nextOrderItem;
        DataSource._ordersItmes[DataSource._numOfOrderItems] = newOrderItem;
        DataSource._numOfOrderItems++;
        return newOrderItem.ID;
    }

    public void Delete(int id)
    {//The method deletes the orderItem with the received ID

        for (int i = 0; i < DataSource._numOfOrderItems; i++)
        {//Goes through the array

            if (DataSource._ordersItmes[i].ID == id)
            {
                DataSource._ordersItmes[i] = DataSource._ordersItmes[DataSource._numOfOrderItems - 1];
                DataSource._numOfOrderItems--;
                return;
            }
        }
        //If the orderItem is not found
        throw new Exception("This order item is not exsist");
    }

    public OrderItem GetByID(int id)
    {//Finds a orderItem by ID
        for (int i = 0; i < DataSource._numOfOrderItems; i++)
        {
            if (DataSource._ordersItmes[i].ID == id)
                return DataSource._ordersItmes[i];
        }
        // in case the order item not exist
        throw new Exception("This order item is not exsist");
    }

    public void Uppdate(OrderItem newOrderItem)
    {//Updates a orderItem according to the ID
        for (int i = 0; i < DataSource._numOfOrderItems; i++)
        {
            if (DataSource._ordersItmes[i].ID == newOrderItem.ID)
            {
                DataSource._ordersItmes[i] = newOrderItem;
                return;
            }
        }
        // in case the order item not exist
        throw new Exception("This order item is not exsist");
    }

    public OrderItem[] GetAll()
    {//Returns an array containing all orderItems
        OrderItem[] odr = new OrderItem[DataSource._numOfOrderItems];
        for (int i = 0; i < DataSource._numOfOrderItems; i++)
        {
            odr[i] = DataSource._ordersItmes[i];
        }
        return odr;
    }

    public OrderItem GetByProductAndOrder(int p, int or)
    {//Search by product ID and order ID
        foreach (OrderItem o in DataSource._ordersItmes)
        {//Goes through the orderItem's array
            if (o.ProductID == p && o.OrderID == or)
                return o;
        }
        // in case the order item not exist
        throw new Exception("This order item is not exsist");
    }

    public OrderItem[] GetByOrderId(int id)
    {//The method returns an array of all the items of the order with the received ID

        int counter = 0;
        // count the total size
        for (int i = 0; i < DataSource._ordersItmes.Length; i++)
        {
            if (DataSource._ordersItmes[i].OrderID == id)
                counter++;
        }
        // copy all the order items to a new array
        OrderItem[] odr = new OrderItem[counter];
        for (int i = 0; i < DataSource._ordersItmes.Length; i++)
        {
            if (DataSource._ordersItmes[i].OrderID == id)
                odr[i] = DataSource._ordersItmes[i];
        }
        return odr;
    }

}


