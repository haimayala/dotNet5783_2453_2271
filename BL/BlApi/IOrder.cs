using BO;
using System;

namespace BlApi;

public interface IOrder
{
    //  A function that show all the orders to the manager
    IEnumerable<OrderForList?> GetLitedOrders();

    /*A function that gets a order id and in case of correct input
     try to return the match order bt the data layer , in case of incorrect input 
    an exception will be thrown*/
    public BO.Order GetOrderDetails(int OrderId);

    /* A function that gets a order id and in case of correct input 
    an update will be made to the customer that the order has been sent*/
    public BO.Order UppdateShipDate(int OrderId);

    /* A function that gets a order id and in case of correct input 
    an update will be made to the customer that that the order has been delivered*/
    public BO.Order UppdateDeliveryDate(int OrderId);

    /* A function that gets a order id nand return the match order tracking ,
    in case of incorrect input an exception will be thrown*/
    public OrderTracking OrderTracking(int OrderId);


    public int  OrderOldest();


}
