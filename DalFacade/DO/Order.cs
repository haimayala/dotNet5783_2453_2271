

using DalFacade;
using System.Diagnostics;

namespace DO;
public struct Order
{
    public Order()
    {
        ID = 0;
        CustomerName = "";
        CustomerEmail = "";
        CustomerAdress = "";
    }
    public int ID { get; set; }
    
    public string? CustomerName { get; set; }    
    
    public string? CustomerEmail { get; set; }   
    
    public string? CustomerAdress { get; set; }  
   
    public DateTime? OrderDate { get; set; } =null;
    public DateTime? ShipDate { get; set; } =null;  
   
    public DateTime? DeliveryDate { get; set; } =null;

    public override string ToString()
    {
        return this.ToStringProperty();
    }

}
