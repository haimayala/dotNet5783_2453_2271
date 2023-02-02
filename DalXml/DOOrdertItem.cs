
using DalApi;
using DO;

namespace Dal;

internal class DOOrdertItem : IOrderItem
{
    string s_orderItems = "orderItems";


    public int Add(OrderItem i)
    {
        List<DO.OrderItem?> items = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
        if (items.Exists(x => x?.ID == i.ID))
            throw new DalAllredyExsisExeption("order item allredy exsist");
        else
        {
            //still not exsist
            i.ID = DalConfig.GetOrderItemId();
            items.Add(i);
            DalConfig.SaveNextOrderItemId(i.ID+1);
            XMLTools.SaveListToXMLSerializer(items, s_orderItems);
            return i.ID;
        }
    }

    public void Delete(int id)
    {
        List<DO.OrderItem?> items = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
        if (!items.Exists(x => x?.ID == id))
            throw new DalDoesNotExsistExeption("orderItem not exsist");
        else
        {
            items.Remove(items.Find(x => x?.ID == id));
            XMLTools.SaveListToXMLSerializer(items, s_orderItems);
        }
    }

    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? func = null)
    {
        List<DO.OrderItem?> items = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
        if (func != null)
            return items.Where(item => func(item)).Select(item => item);
        return items.Select(item => item);

    }

    public OrderItem GetByID(int id)
    {
        List<DO.OrderItem?> items = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
        return items.Find(x => x?.ID == id) ?? throw new DalDoesNotExsistExeption("orderItem notexsist");
    }

    public IEnumerable<OrderItem?> GetByOrderId(int id)
    {
        List<DO.OrderItem?> items = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
        return items.ToList().Where(item => item?.OrderID == id).Select(item => item);
    }

    public OrderItem GetByProductAndOrder(int p, int or)
    {
        List<DO.OrderItem?> items = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
        return items.Find(item => item?.OrderID == or && item?.ProductID == p) ?? throw new Exception("This order item is not exsist");
    }

    public OrderItem GetItem(Func<OrderItem?, bool>? func)
    {
        List<DO.OrderItem?> items = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
        return items.FirstOrDefault(item => func!(item)) ?? throw new DalDoesNotExsistExeption("order item not exist");
    }

    public void Uppdate(OrderItem i)
    {
        List<DO.OrderItem?> items = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_orderItems);
        if (!items.Exists(x => x?.ID == i.ID))
            throw new DalDoesNotExsistExeption("odetItem not exsist");
        else
        {
            items.Remove(items.Find(x => x?.ID == i.ID));
            items.Add(i);
            XMLTools.SaveListToXMLElement(items, s_orderItems);
        }
    }
}

