using BlApi;
namespace BlImplementation;

sealed internal class Bl : IBl
{
    public Bl() { }
    public IOrder Order { get; set; } = new Order();
    public IProduct Product { get; set; } = new Product();
    public ICart Cart { get; set; } = new Cart();
    IUser IBl.User { get => throw new NotImplementedException();  }
}

