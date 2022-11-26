using DO;
namespace Dal;
using DalApi;

internal class DalOrder :IOrder
{
    public int Add(Order newOrder)
    {//the method adds an order to the order's arry 
        newOrder.ID = DataSource.nextOrder;
        DataSource.s_orders.Add(newOrder);      
        return newOrder.ID;
    }

    public void Delete(int id)
    {//The method deletes the order with the received ID
        for (int i = 0; i < DataSource.s_orders.Count; i++)
        {//Goes through the array

            if (DataSource.s_orders[i].ID == id)
            {
                DataSource.s_orders.Remove(DataSource.s_orders[i]);             
                return; ;
            }
        }
        //If the order is not found
        throw new Exception("This order is not exsist");
    }

    public Order GetByID(int id)
    {//Finds a order by ID
        for (int i = 0; i < DataSource.s_orders.Count; i++)
        {
            if (DataSource.s_orders[i].ID == id)
                return DataSource.s_orders[i];
        }
        throw new Exception("This order is not exsist");
    }

    public void Uppdate(Order newOrder)
    {//Updates a order according to the ID
        for (int i = 0; i < DataSource.s_orders.Count; i++)
        {
            if (DataSource.s_orders[i].ID == newOrder.ID)
            {
                DataSource.s_orders.Add(newOrder);
                return;
            }
        }
        throw new Exception("This order is not exsist");
    }

    public IEnumerable<Order> GetAll()
    {//Returns an array containing all orders
        List<Order> list = new List<Order>();
        list = DataSource.s_orders;
        return list;
    }
}
