using DalApi;
namespace Dal;


sealed public class DalList : IDal
{
    public IProduct Product => new DalProduct();
    public IOrder order => new DalOrder();
    public IOrderItem orderItem => new DalOrderItem();

}
