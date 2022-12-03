using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BlApi;
using BO;

namespace BlImplementation;

internal class Order : IOrder
{
    DalApi.IDal dal = new Dal.DalList();
    public IEnumerable<OrderForList?> GetLitedOrders()
    {
        //IEnumerable<Order?> orders = (IEnumerable<Order?>)dal.order.GetAll();
        //IEnumerable<OrderItem?> items = (IEnumerable<OrderItem?>)dal.order.GetAll();
        //return from DO.Order item in orders
        //       select new BO.OrderForList
        //       {
        //           ID = item.ID,
        //           CustomerName = item.CustomerName,
        //           //Status=
        //           ProductAmount = items.Count();
        ////TotalPrice= doOrder?.
    }

    public BO.Order GetOrderDetails(int OrderId)
    {
        throw new NotImplementedException();
    }

    public OrderTracking OrderTracking(int OrderId)
    {
        throw new NotImplementedException();
    }

    public BO.Order UppdateDeliveryDate(int OrderId)
    {
        throw new NotImplementedException();
    }

    public BO.Order UppdateShipDate(int OrderId)
    {
        throw new NotImplementedException();
    }
}

public BO.Order GetOrderDetails(int OrderId)
    {
        if (OrderId > 0)
        {
            DO.Order ord = dal.order.GetByID(OrderId);
            IEnumerable<DO.OrderItem?> items = (IEnumerable<DO.OrderItem?>)dal.orderItem.GetByOrderId(OrderId);
            BO.Order order = new BO.Order()
            {
                CustomerName = ord.CustomerName,
                CustomerEmail = ord.CustomerEmail,
                CustonerAddres = ord.CustomerAdress,
                Id = OrderId,

            };
            return order;
        }
        throw new NotImplementedException();
    }


   