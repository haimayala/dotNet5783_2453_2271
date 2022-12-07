using DO;
namespace Dal;
using DalApi;
using System.Data;

internal class DalOrder :IOrder
{
    // A function that gets a new order and in case its allredy not exsist add the order to the order list
    public int Add(Order newOrder)
    {//the method adds an order to the order's arry 
        newOrder.ID = DataSource.nextOrder;
        if (DataSource.s_orders.Exists(x => x.ID == newOrder.ID))
            throw new DalAllredyExsis("orer allredy exsist");
        else
        {
            newOrder.ID = DataSource.nextOrder;

            DataSource.s_orders.Add(newOrder);
            return newOrder.ID;

        }

    }

    // A function that gets a order id and delete the match order from the order list
    public void Delete(int id)
    {//The method deletes the order with the received ID
        if (DataSource.s_orders.Exists(x => x.ID == id))
            throw new DalAllredyExsis("orer allredy exsist");
        else
        {
            DataSource.s_orders.Remove(DataSource.s_orders.Find(x => x.ID == id));           
        }
    }

    // A function that gets a order id and return the match order
    public Order GetByID(int id)
    {//Finds a order by ID
        if (!DataSource.s_orders.Exists(x => x.ID == id))
            throw new DalDoesNotExsist("order not exist");
        else
        {
            return DataSource.s_orders.Find(x => x.ID == id);
        }
    }
    // A function that gets a new order and update the match order in the order list
    public void Uppdate(Order newOrder)
    {//Updates a order according to the ID
        if (!DataSource.s_orders.Exists(x => x.ID == newOrder.ID))
            throw new DalDoesNotExsist("order not exsist");
        else
        {
            DataSource.s_orders.Remove(DataSource.s_orders.Find(x => x.ID == newOrder.ID));
            DataSource.s_orders.Add(newOrder);
        }
    }

    // A function that return all the order list
    public IEnumerable<Order> GetAll()
    {//Returns an array containing all orders
        List<Order> list = new List<Order>();
        list = DataSource.s_orders;
        return list;
    }
}
