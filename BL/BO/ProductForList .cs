namespace BO;
using static BO.Enums;
public class ProductForList
{
    public int Id { get; set; } 
    public string? Name { get; set; }   
    public int Price { get; set; }
    public Category? category { get; set; }

    public string? ImageRelativeName { get; set; }

    public override string ToString()
    {
        return this.ToStringProperty();
    }




}
