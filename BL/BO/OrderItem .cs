

namespace BO;

public class OrderItem
{
    public int Id { get; set; } 
    public int OrderId { get; set; }    
    public string? ProductName { get; set; }  
    public int Price { get; set; } 
    public int Amount { get; set; } 
    public double TotalProductPrice { get; set; }
    public override string ToString()
    {
        return this.ToStringProperty();
    }

}
