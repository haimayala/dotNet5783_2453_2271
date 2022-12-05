
using static BO.Enums;

namespace BO;

public class Product
{
    public int ID { get; set; } 
    public string? Name { get; set; }       
    public double Price { get; set; }  
    public Category Category { get; set; }
    public int InStock { get; set; }

    //public override string ToString() => $@"
    ////Product ID:  {ID}
    ////Name:   {Name}
    ////category:   {Category}
    ////Price:   {Price}   	
    ////Amount in stock:  {InStock}   	
    //";
    public override string ToString()
    {
        return this.ToStringProperty();
    }

}
