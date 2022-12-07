using DO;
namespace Dal;
using DalApi;

internal class DalOrderItem : IOrderItem
{

    // A function that gets a new orderItem and in case its allredy not exsist add the orderItem to the orderItem list
    public int Add(OrderItem newOrderItem)
    {
        // check if the ordder item is allredy exsist in the oreritem list
        if (DataSource.s_orderItems.Exists(x => x.ID == newOrderItem.ID))
            throw new DalAllredyExsis("order item allredy exsist");
        else
        {
           //still not exsist
            newOrderItem.ID = DataSource.nextOrderItem;
            DataSource.s_orderItems.Add(newOrderItem);
            return newOrderItem.ID;
        }
       
    }

    // A function that gets a orderItem id and delete the match orderItem from the orderItem list
    public void Delete(int id)
    {
        // check if the order otemexist in the list
        if (!DataSource.s_orderItems.Exists(x => x.ID == id))
            throw new DalDoesNotExsist("orderItem not exsist");
        else
        {
            DataSource.s_products.Remove(DataSource.s_products.Find(x => x.ID == id));
        }
    }

    // A function that gets a orderItem id and return the match orderItem
    public OrderItem GetByID(int id)
    {
        // check if the orer itm exsist in the list
        if (!DataSource.s_orderItems.Exists(x => x.ID == id))
            throw new DalDoesNotExsist("orderItem notexsist");
        else
        {
            return DataSource.s_orderItems.Find(x => x.ID == id);
        }
    }

    // A function that gets a new orderItem and update the match orderItem in the orderItem list
    public void Uppdate(OrderItem newOrderItem)
    {//Updates a orderItem according to the ID
        if (!DataSource.s_orderItems.Exists(x => x.ID == newOrderItem.ID))
            throw new DalDoesNotExsist("odetItem not exsist");
        else
        {
            DataSource.s_orderItems.Remove(DataSource.s_orderItems.Find(x=>x.ID==newOrderItem.ID));
            DataSource.s_orderItems.Add(newOrderItem);
        }
    }

    // A function that return all the orderItem list
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


