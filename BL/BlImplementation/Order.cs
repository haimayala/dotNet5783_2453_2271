
using BO;
using static BO.Enums;
using IOrder = BlApi.IOrder;

namespace BlImplementation;

internal class Order : IOrder
{
    DalApi.IDal dal = new Dal.DalList();

    ////  A function that show all the orders to the manager
    public IEnumerable<OrderForList> GetLitedOrders()
    {
        IEnumerable<DO.Order> orders = dal.order.GetAll();
        IEnumerable<DO.OrderItem> items = dal.orderItem.GetAll();
        return from DO.Order item in orders
               let orderItems = items.Where(items => items.OrderID == item.ID)
               select new BO.OrderForList()
               {
                   ID = item.ID,
                   CustomerName = item.CustomerName,
                   Status = GetStatus(item),
                   ProductAmount = orderItems.Count(),
                   TotalPrice = orderItems.Sum(items => items.Amount * items.Price)
               };
        throw new NotImplementedException();
    }

    /*A function that gets a order id and in case of correct input
      try to return the match order bt the data layer , in case of incorrect input 
     an exception will be thrown*/
    public BO.Order GetOrderDetails(int OrderId)
    {
        if (OrderId > 0)
        {
            DO.Order order = dal.order.GetByID(OrderId);
            IEnumerable<DO.OrderItem> items = dal.orderItem.GetByOrderId(OrderId);
            Console.WriteLine(items.Count());
            return new BO.Order
            {
                ID = order.ID,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                CustonerAddres = order.CustomerAdress,
                Status = GetStatus(order),
                OrderDate = order.OrderDate,
                ShipDate = order.ShipDate,
                DeliveryDate = order.DeliveryDate,
                PayMentDate = DateTime.MinValue,
                Items = GetOrderItems(dal.orderItem.GetAll().Where(x => x.OrderID == order.ID)),
                TotalPrice = GetOrderItems(dal.orderItem.GetAll().Where(x => x.OrderID == order.ID)).Sum(x => x.TotalPrice)
            };
        }
        else
            throw new BlUnCorrectID("unncorrect id");
    }

    /* A function that gets a order id and in case of correct input 
    an update will be made to the customer that the order has been sent*/
    public BO.Order UppdateShipDate(int OrderId)
    {
        //try...
        DO.Order order = dal.order.GetByID(OrderId);
        if(order.ShipDate<DateTime.Now)
        {
            order.ShipDate = DateTime.Now;
            IEnumerable<DO.OrderItem> items = dal.orderItem.GetByOrderId(OrderId);
            return new BO.Order
            {
                ID = order.ID,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                CustonerAddres = order.CustomerAdress,
                Status = BO.Enums.OrderStatus.Shipped,
                OrderDate = order.OrderDate,
                ShipDate = order.ShipDate,
                DeliveryDate = order.DeliveryDate,
                PayMentDate = DateTime.MinValue,
                Items = GetOrderItems(dal.orderItem.GetAll().Where(x => x.OrderID == order.ID)),
                TotalPrice = GetOrderItems(dal.orderItem.GetAll().Where(x => x.OrderID == order.ID)).Sum(x => x.TotalPrice)
            };
        }
        
        throw new NotImplementedException();
    }

    /* A function that gets a order id and in case of correct input 
  an update will be made to the customer that that the order has been delivered*/
    public BO.Order UppdateDeliveryDate(int OrderId)
    {
        DO.Order order = dal.order.GetByID(OrderId);
        if (order.DeliveryDate<DateTime.Now)
        {
            order.DeliveryDate = DateTime.Now;
            IEnumerable<DO.OrderItem> items = dal.orderItem.GetByOrderId(OrderId);
            return new BO.Order
            {
                ID = order.ID,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                CustonerAddres = order.CustomerAdress,
                Status = BO.Enums.OrderStatus.Delivered,
                OrderDate = order.OrderDate,
                ShipDate = order.ShipDate,
                DeliveryDate = order.DeliveryDate,
                PayMentDate = DateTime.MinValue,
                Items = GetOrderItems(dal.orderItem.GetAll().Where(x => x.OrderID == order.ID)),
                TotalPrice = GetOrderItems(dal.orderItem.GetAll().Where(x => x.OrderID == order.ID)).Sum(x => x.TotalPrice)
            };
        }

            throw new NotImplementedException();
    }

    public OrderTracking OrderTracking(int OrderId)
    {
        DO.Order order = dal.order.GetByID(OrderId);
        return new BO.OrderTracking()
        {
            Id = order.ID,
            Status = GetStatus(order),
            Trecking = new List<Tuple<DateTime, string>>() { new Tuple<DateTime, string>(order.OrderDate, "The order has been created"),
                new Tuple<DateTime, string>(order.ShipDate, "The order has been sent"),
                new Tuple<DateTime, string>(order.DeliveryDate, "The order has been delivered") }
        };
    }

    //A help functon that return the order status
    private BO.Enums.OrderStatus GetStatus(DO.Order order)
    {
        if (order.DeliveryDate != null)
            return OrderStatus.Delivered;
        else if (order.ShipDate != null)
            return OrderStatus.Shipped;
        else
            return OrderStatus.Ordered;
    }

    //A helpfuntion that return the match BO orderr items to the DO order items
    private IEnumerable<BO.OrderItem> GetOrderItems(IEnumerable<DO.OrderItem> itemList)
    {
        return from DO.OrderItem items in itemList
               select new BO.OrderItem()
               {
                   Id = items.ID,
                   ProductName = dal.Product.GetByID(items.ProductID).Name,
                   Price = (int)items.Price,
                   Amount = items.Amount,
                   ProductId = dal.Product.GetByID(items.ProductID).ID,
                   TotalPrice = items.Price,
               };
}

   
}



   