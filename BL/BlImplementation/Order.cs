
using BO;

using static BO.Enums;
using IOrder = BlApi.IOrder;

namespace BlImplementation;

internal class Order : IOrder
{
    private static readonly DalApi.IDal dal = DalApi.Factory.Get()!;

    ////  A function that show all the orders to the manager
    public IEnumerable<OrderForList?> GetLitedOrders()
    {
        IEnumerable<DO.Order?> orders = dal.order.GetAll();
        IEnumerable<DO.OrderItem?> items = dal.orderItem.GetAll();
        return from DO.Order item in orders
               let orderItems = items.Where(items => items?.OrderID == item.ID)
               select new BO.OrderForList()
               {
                   ID = item.ID,
                   CustomerName = item.CustomerName,
                   Status = GetStatus(item),
                   ProductAmount = orderItems.Count(),
                   TotalPrice =orderItems.Sum(items => (int)items?.Price!),
                    
               };
    }

    /*A function that gets a order id and in case of correct input
      try to return the match order bt the data layer , in case of incorrect input 
     an exception will be thrown*/
    public BO.Order GetOrderDetails(int OrderId)
    {
        if (OrderId > 0)
        {
            try
            {
                DO.Order order = dal.order.GetByID(OrderId);
                IEnumerable<DO.OrderItem?> items = dal.orderItem.GetByOrderId(OrderId);
                Console.WriteLine(items.Count());
                return new BO.Order
                {
                    ID = order.ID,
                    CustomerName = order.CustomerName,
                    CustomerEmail = order.CustomerEmail,
                    CustonerAddres = order.CustomerAdress,
                    OrderDate = order.OrderDate,
                    ShipDate = order.ShipDate,
                    DeliveryDate = order.DeliveryDate,
                    Status = GetStatus(order), 
                    
                                 
                    Items = GetOrderItems(dal.orderItem.GetAll().Where(x => x?.OrderID == order.ID)),
                    TotalPrice = GetOrderItems(dal.orderItem.GetAll().Where(x => x?.OrderID == order.ID)).Sum(x => x!.TotalPrice)
                };
            }
           catch (DO.DalDoesNotExsistExeption )
            {
                throw new BlNotExsistExeption("cannot get, order not exsist");
            }
        }
        else
            throw new BlUnCorrectIDExeption("unncorrect id");
    }

    /* A function that gets a order id and in case of correct input 
    an update will be made to the customer that the order has been sent*/
    public BO.Order UppdateShipDate(int OrderId)
    {
        DO.Order order= new DO.Order();

        try
        {
            order = dal!.order.GetByID(OrderId);

        }
        catch (DO.DalDoesNotExsistExeption)
        {
            throw new DO.DalDoesNotExsistExeption("cannot uppdate, order not exsist");
        }
        if (order.ShipDate == null)
            order.ShipDate = DateTime.Now;
        else
            throw new BlOrderAlredyShiped("cannot update the ship date, order alredy shiped");
        dal.order.Uppdate(order);
        return GetOrderDetails(OrderId);


    }

        /* A function that gets a order id and in case of correct input 
      an update will be made to the customer that that the order has been delivered*/
        public BO.Order UppdateDeliveryDate(int OrderId)
    {
        DO.Order order = new DO.Order();

        try
        {
            order = dal!.order.GetByID(OrderId);

        }
        catch (DO.DalDoesNotExsistExeption)
        {
            throw new DO.DalDoesNotExsistExeption("cannot uppdate, order not exsist");
        }
        if (order.DeliveryDate == null)
            order.DeliveryDate = DateTime.Now;
        else
            throw new BlOrderAlredyDelivered("cannot update the delivery date, order alredy delivered");
        dal.order.Uppdate(order);
        return GetOrderDetails(OrderId);

    }

    public OrderTracking OrderTracking(int OrderId)
    {
        try
        {
            DO.Order order = dal.order.GetByID(OrderId);
            return new BO.OrderTracking()
            {
                Id = order.ID,
                Status = GetStatus(order),
               Trecking= new List<Tuple<DateTime?, string>>() { new Tuple<DateTime?, string>(order.OrderDate,"order date" ),
              new Tuple<DateTime?, string>(order.ShipDate,"ship date" ),
              new Tuple<DateTime?, string>(order.DeliveryDate,"delivery date" )
               }
            };
        }
        catch (DO.DalDoesNotExsistExeption )
        {
            throw new BlNotExsistExeption("Order not exist");
        }
    }

    //A help functon that return the order status
    private OrderStatus GetStatus(DO.Order order)
    {
        if (order.ShipDate != null && order.DeliveryDate != null)
            return OrderStatus.Delivered;

        if (order.ShipDate != null && order.DeliveryDate == null)
            return OrderStatus.Shipped;
        else
            return OrderStatus.Ordered;
       
    }
   

    //A helpfuntion that return the match BO orderr items to the DO order items
    private IEnumerable<BO.OrderItem?> GetOrderItems(IEnumerable<DO.OrderItem?> itemList)
    {
        return from DO.OrderItem items in itemList
               select new BO.OrderItem()
               {
                   Id = items.ID,
                   ProductName = dal.Product.GetByID(items.ProductID).Name,
                   Price = (int)dal.Product.GetByID(items.ProductID).Price,
                   Amount = items.Amount,
                   ProductId = dal.Product.GetByID(items.ProductID).ID,
                   TotalPrice = items.Price,
                   ImageRelativeName = @"\picss\IMG" + items.ProductID + ".jpg"
               };
}

   
}



   