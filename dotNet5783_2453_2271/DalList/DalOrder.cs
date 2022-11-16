

using DO;

namespace Dal;

public class DalOrder
{
   
    public int Add(Order newOrder)
    {
        newOrder.ID = DataSource.nextOrder;
        DataSource._orders[DataSource._numOfOrders] = newOrder;
        DataSource._numOfOrders++;
        return newOrder.ID;
    }
    public void Delete(int id)
    {
        for (int i = 0; i < DataSource._numOfOrders; i++)
        {

            if (DataSource._orders[i].ID == id)
            {
                DataSource._orders[i] = DataSource._orders[DataSource._numOfOrders - 1];
                DataSource._numOfOrders--;
                return; ;
            }
        }
        throw new Exception("This order is not exsist");
    }

    public Order GetByID(int id)
    {
        for (int i = 0; i < DataSource._numOfOrders; i++)
        {
            if (DataSource._orders[i].ID == id)
                return DataSource._orders[i];
        }
        throw new Exception("This order is not exsist");
    }

    public void Uppdate(Order newOrder)
    {

        for (int i = 0; i < DataSource._numOfOrders; i++)
        {
            if (DataSource._orders[i].ID == newOrder.ID)
            {
                DataSource._orders[i] = newOrder;
                return;
            }
        }
        throw new Exception("This order is not exsist");
    }

    public Order[] GetAll()
    {
        Order[] orr = new Order[DataSource._numOfOrders];
        for (int i = 0; i < DataSource._numOfOrders; i++)
        {
            orr[i] = DataSource._orders[i];
        }
        return orr;
    }
}
