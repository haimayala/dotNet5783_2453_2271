

using DalFacade;
using System.Diagnostics;

namespace DO;

public struct Order
{
    public Order()
    {
        ID=0;
        CustomerName = "";
        CustomerEmail = "";
        CustomerAdress = "";
    }
    public int ID { get; set; }
    
    public string CustomerName { get; set; }    
    
    public string CustomerEmail { get; set; }   
    
    public string CustomerAdress { get; set; }  
   
    public DateTime OrderDate { get; set; } =DateTime.MinValue;
    public DateTime ShipDate { get; set; } =DateTime.MinValue;  
   
    public DateTime DeliveryDate { get; set; } =DateTime.MinValue;

    public override string ToString() => $@"
ID:  {ID},
CustomerName:  {CustomerName},
CustomerEmail:  {CustomerEmail},
CustomerAdress:  {CustomerAdress},
OrderDate:  {OrderDate},
ShipDate:  {ShipDate},
DeliveryDate:  {DeliveryDate},
";
}
