

using DO;

namespace Dal;

public class DalOrder
{
   
    public int Add(Order newOrder)
    {//the method adds an order to the order's arry 

        newOrder.ID = DataSource.nextOrder;
        DataSource._orders[DataSource._numOfOrders] = newOrder;
        DataSource._numOfOrders++;
        return newOrder.ID;
    }

    public void Delete(int id)
    {//The method deletes the order with the received ID
        for (int i = 0; i < DataSource._numOfOrders; i++)
        {//Goes through the array

            if (DataSource._orders[i].ID == id)
            {
                DataSource._orders[i] = DataSource._orders[DataSource._numOfOrders - 1];
                DataSource._numOfOrders--;
                return; ;
            }
        }
        //If the order is not found
        throw new Exception("This order is not exsist");
    }

    public Order GetByID(int id)
    {//Finds a order by ID
        for (int i = 0; i < DataSource._numOfOrders; i++)
        {
            if (DataSource._orders[i].ID == id)
                return DataSource._orders[i];
        }
        // in case the order not exsist
        throw new Exception("This order is not exsist");
    }

    public void Uppdate(Order newOrder)
    {//Updates a order according to the ID
        for (int i = 0; i < DataSource._numOfOrders; i++)
        {
            if (DataSource._orders[i].ID == newOrder.ID)
            {
                DataSource._orders[i] = newOrder;
                return;
            }
        }
        // in case the order is not exsist
        throw new Exception("This order is not exsist");
    }

    public Order[] GetAll()
    {//Returns an array containing all orders
        Order[] orr = new Order[DataSource._numOfOrders];
        for (int i = 0; i < DataSource._numOfOrders; i++)
        {
            orr[i] = DataSource._orders[i];
        }
        return orr;
    }
}
