using static BO.Enums;
namespace BO;

public class OrderForList
{
    public int ID { get; set; } 
    public string? CustomerName { get; set; }
    public OrderStatus? Status { get; set; }
    public int ProductAmount { get; set; }  
    public double TotalPrice { get; set; }
    public string? ImageRelativeName { get; set; }


    public override string ToString()
    {
        return this.ToStringProperty();
    }

}
