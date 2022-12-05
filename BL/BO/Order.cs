
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
    public OrderStatus Status { get; set; }
    public DateTime? OrderDate { get; set; }    
    public DateTime? ShipDate { get; set; }  
    public DateTime DeliveryDate { get; set; }  
    public DateTime PayMentDate { get; set; }
    public IEnumerable<BO.OrderItem> Items { get; set; }
    public double TotalPrice    { get; set; }
    //public override string ToString() => $@"
    //ID:  {ID}
    //Customer Name:   {CustomerName}
    //Customer Email:   {CustomerEmail}
    //Status:   {Status}  
    //Order Date:  {OrderDate}   
    //Ship Date:{ShipDate}
    //Delivery Date{DeliveryDate}
    //Pay Ment Date {PayMentDate}
    //Items:{Items}
    //Total Price{TotalPrice}
    //";
    public override string ToString()
    {
        return this.ToStringProperty();
    }


}
