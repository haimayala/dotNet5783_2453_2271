

using DalFacade;

namespace DO;

public struct Order
{

    public int ID { get; set; }
    
    public string CustomerName { get; set; }    
    
    public string CustomerEmail { get; set; }   
    
    public string CustomerAdress { get; set; }  
   
    public DateTime OrderDate { get; set; } =DateTime.MinValue;
    public DateTime ShipDate { get; set; } =DateTime.MinValue;  
   
    public DateTime DeliveryDate { get; set; } =DateTime.MinValue;  
}
