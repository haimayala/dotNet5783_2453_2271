

namespace BO;

public class OrderItem
{
    public int Id { get; set; } 
    public int ProductId { get; set; }    
    public string? ProductName { get; set; }  
    public int Price { get; set; } 
    public int Amount { get; set; } 
    public double TotalPrice { get; set; }
    //    public override string ToString() => $@"
    //    ID: {Id}
    //    Product Id:  {ProductId}
    //    Product Name:   {ProductName} 
    //    Price:  {Price}
    //    Amount:   {Amount}
    //    TotalProductPrice :{TotalPrice}

    //";
    public override string ToString()
    {
        return this.ToStringProperty();
    }


}
