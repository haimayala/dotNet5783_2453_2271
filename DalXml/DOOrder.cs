
using DalApi;
using DO;

namespace Dal;

internal class DOOrder : IOrder
{
    string s_orders = "orders";

    public int Add(Order obj)
    {
        throw new NotImplementedException();
    }

    //public int Add(Order o)
    //{
    //    //List<DO.Order?> orders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_orders);
    //    //o.ID = nextOrder;
    //    //if (orders.Exists(x => x?.ID == o.ID))
    //    //    throw new DalAllredyExsisExeption("orer allredy exsist");
    //    //else
    //    //{
    //    //    o.ID = DataSource.nextOrder;

    //    //    orders.Add(o);
    //    //    XMLTools.SaveListToXMLElement(orders, s_orders);
    //    //    return newOrder.ID;
    //    //}
    //}

    public void Delete(int id)
    {
        List<DO.Order?> orders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_orders);
        if (!orders.Exists(x => x?.ID == id))
            throw new DalDoesNotExsistExeption("order not exsist");
        else
        {
            orders.Remove(orders.Find(x => x?.ID == id));
            XMLTools.SaveListToXMLElement(orders, s_orders);
        }
    }

    public IEnumerable<Order?> GetAll(Func<Order?, bool>? func = null)
    {
        List<DO.Order?> orders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_orders);
        if (func != null)
            return orders.Where(item => func(item)).Select(item => item);
        return orders.Select(item => item);
    }

    public Order GetByID(int id)
    {
        List<DO.Order?> orders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_orders);
        return orders.Find(x => x?.ID == id) ?? throw new DalDoesNotExsistExeption("order not exist");
    }

    public Order GetItem(Func<Order?, bool>? func)
    {

        List<DO.Order?> orders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_orders);
        return orders.FirstOrDefault(item => func!(item)) ?? throw new DalDoesNotExsistExeption("order not exist");
    }

    public void Uppdate(Order o)
    {
        List<DO.Order?> orders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_orders);
        if (!orders.Exists(x => x?.ID == o.ID))
            throw new DalDoesNotExsistExeption("order not exsist");
        else
        {
            orders.Remove(orders.Find(x => x?.ID == o.ID));
            orders.Add(o);
            XMLTools.SaveListToXMLElement(orders, s_orders);
        }
    }
}
