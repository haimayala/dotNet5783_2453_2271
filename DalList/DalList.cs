using DalApi;
namespace Dal;


sealed internal class DalList : IDal
{
    private DalList() { }
    public static IDal Instance { get; } = new DalList();
    public IProduct Product => new DalProduct();
    public IOrder order => new DalOrder();
    public IOrderItem orderItem => new DalOrderItem();
    public IUder uder => throw new NotImplementedException();
}
 