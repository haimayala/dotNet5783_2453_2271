using DO;
namespace Dal;
using DalApi;

internal class DalOrderItem : IOrderItem
{
    public int Add(OrderItem newOrderItem)
    {//the method adds an orderItem to the orderItem's arry 
        newOrderItem.ID = DataSource.nextOrderItem;
        DataSource.s_orderItems.Add(newOrderItem);
        return newOrderItem.ID;
    }

    public void Delete(int id)
    {//The method deletes the orderItem with the received ID

        for (int i = 0; i < DataSource.s_orderItems.Count; i++)
        {//Goes through the array

            if (DataSource.s_orderItems[i].ID == id)
            {
                DataSource.s_orderItems.Remove(DataSource.s_orderItems[i]);
                return;
            }
        }
        //If the orderItem is not found
        throw new Exception("This order item is not exsist");
    }

    public OrderItem GetByID(int id)
    {//Finds a orderItem by ID
        for (int i = 0; i < DataSource.s_orderItems.Count; i++)
        {
            if (DataSource.s_orderItems[i].ID == id)
                return DataSource.s_orderItems[i];
        }
        throw new Exception("This order item is not exsist");
    }

    public void Uppdate(OrderItem newOrderItem)
    {//Updates a orderItem according to the ID
        for (int i = 0; i < DataSource.s_orderItems.Count; i++)
        {
            if (DataSource.s_orderItems[i].ID == newOrderItem.ID)
            {
                DataSource.s_orderItems.Add( newOrderItem);
                return;
            }
        }
        throw new Exception("This order item is not exsist");
    }

    public IEnumerable<OrderItem> GetAll()
    {//Returns an array containing all orderItems
        List<OrderItem> list = new List<OrderItem>();
        list = DataSource.s_orderItems;
        return list;

    }

    public OrderItem GetByProductAndOrder(int p, int or)
    {//Search by product ID and order ID
        foreach (OrderItem o in DataSource.s_orderItems)
        {//Goes through the orderItem's array
            if (o.ProductID == p && o.OrderID == or)
                return o;
        }
        throw new Exception("This order item is not exsist");
    }

    public IEnumerable<OrderItem> GetByOrderId(int id)
    {//The method returns an array of all the items of the order with the received ID

        List<OrderItem> list= new List<OrderItem>();
        for (int i = 0; i < DataSource.s_orderItems.Count; i++)
        {
            if (DataSource.s_orderItems[i].OrderID == id)
            {
                list.Add(DataSource.s_orderItems[i]);
            }
        }
        return list;
        
    }

}


