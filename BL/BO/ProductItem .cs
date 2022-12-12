using static BO.Enums;
namespace BO;

public class ProductItem
{
    public int ID { get; set; } 
    public string? Name { get; set; }    
    public int Price { get; set; }  
    public Category? Category { get; set; }  
    public bool Availability { get; set; }  
    public int AmountInCart { get; set; }
   
    public override string ToString()
    {
        return this.ToStringProperty();
    }

}
