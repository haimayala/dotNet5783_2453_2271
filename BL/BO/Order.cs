
using System.Diagnostics;
using System.Xml.Linq;
using static BO.Enums;

namespace BO;

public class Order
{
    public int ID { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustonerAddres { get; set; }  
    public OrderStatus? Status { get; set; }
    public DateTime? OrderDate { get; set; } = null; 
    public DateTime? ShipDate{ get; set; } = null;
    public DateTime? DeliveryDate { get; set; } = null;

    public IEnumerable<BO.OrderItem?>? Items { get; set; }
    public double TotalPrice    { get; set; }
    
    public override string ToString()
    {
        return this.ToStringProperty();
    }


}
