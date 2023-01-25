using DO;
namespace Dal;
using DalApi;

internal class DalOrderItem : IOrderItem
{

    // A function that gets a new orderItem and in case its allredy not exsist add the orderItem to the orderItem list
    public int Add(OrderItem newOrderItem)
    {
        // check if the ordder item is allredy exsist in the oreritem list
        if (DataSource.s_orderItems.Exists(x => x?.ID == newOrderItem.ID))
            throw new DalAllredyExsisExeption("order item allredy exsist");
        else
        {
           //still not exsist
            newOrderItem.ID = DataSource.Config.nextOrderItem;
            DataSource.s_orderItems.Add(newOrderItem);
            return newOrderItem.ID;
        }
       
    }

    // A function that gets a orderItem id and delete the match orderItem from the orderItem list
    public void Delete(int id)
    {
        // check if the order otemexist in the list
        if (!DataSource.s_orderItems.Exists(x => x?.ID == id))
            throw new DalDoesNotExsistExeption("orderItem not exsist");
        else
        {
            DataSource.s_orderItems.Remove(DataSource.s_orderItems. Find(x => x?.ID == id));
        }
    }

    // A function that gets a orderItem id and return the match orderItem
    public OrderItem GetByID(int id)
    {
        // check if the orer itm exsist in the list      
        return DataSource.s_orderItems.Find(x => x?.ID == id) ?? throw new DalDoesNotExsistExeption("orderItem notexsist");
    }

    // A function that gets a new orderItem and update the match orderItem in the orderItem list
    public void Uppdate(OrderItem newOrderItem)
    {//Updates a orderItem according to the ID
        if (!DataSource.s_orderItems.Exists(x => x?.ID == newOrderItem.ID))
            throw new DalDoesNotExsistExeption("odetItem not exsist");
        else
        {
            DataSource.s_orderItems.Remove(DataSource.s_orderItems.Find(x=>x?.ID==newOrderItem.ID));
            DataSource.s_orderItems.Add(newOrderItem);
        }
    }

    // A function that return all the orderItem list
    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? func)
    {//Returns an array containing all orderItems
        if (func != null)
            return DataSource.s_orderItems.Where(item => func(item)).Select(item => item);
        return DataSource.s_orderItems.Select(item => item);

    }

    public OrderItem GetByProductAndOrder(int p, int or)
    {//Search by product ID and order ID
        return DataSource.s_orderItems.Find(item => item?.OrderID == or && item?.ProductID == p) ?? throw new Exception("This order item is not exsist");

    }

    public IEnumerable<OrderItem?> GetByOrderId(int id)
    {//The method returns an array of all the items of the order with the received ID

        return DataSource.s_orderItems.ToList().Where(item=>item?.OrderID==id).Select(item=>item);  
    }

    public OrderItem GetItem(Func<OrderItem?, bool>? func)
    {
        return DataSource.s_orderItems.FirstOrDefault(item => func!(item)) ?? throw new DalDoesNotExsistExeption("order item not exist");
    }

}


