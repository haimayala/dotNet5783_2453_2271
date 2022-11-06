//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using DalFacade;

namespace DO;

public struct Order
{
    static int getId
    {
        set { getId = 100000; }
    }
    public int ID
    {
        get { return ID; }
        set { ID = getId++; }
    }
    public string CustomerName
    {
        get { return CustomerName; }
        set { CustomerName = value; }
    }
    public string CustomerEmail
    {
        get { return CustomerEmail; }
        set { CustomerEmail = value; }
    }
    public string CustomerAdress
    {
        get { return CustomerAdress; }
        set { CustomerAdress = value; }
    }
    public DateTime OrderDate;
    public DateTime ShipDate
    {
        get { return ShipDate; }
        set { ShipDate = DateTime.MinValue; }
    }
    public DateTime DeliveryDate
    {
        get { return DeliveryDate; }
        set { DeliveryDate = DateTime.MinValue; }
    }
}
