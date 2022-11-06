//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using DO;

namespace Dal;

public class DalOrderItem
{
    private void addNewOrderItem(OrderItem newOrderItem)
    {


    }

    private void deleteOrderItem(OrderItem newOrderItem)
    {
        OrderItem delOrderItem=new OrderItem();
        for (int i = 0; i < 200; i++)
        {
            if (DataSource.arr3[i].OrderID == newOrderItem.OrderID)
                DataSource.arr3[i] = delOrderItem;
        }

    }

    private OrderItem searchOrderItem(int id)
    {
        for(int i=0;i<200;i++)
        {
            if (DataSource.arr3[i].ProductID ==id )
                return DataSource.arr3[i];
        }
        return new OrderItem();// to check it
    }
    private void updateOrderItem(OrderItem newOrderItem)
    {
        for(int i=0;i<200;i++)
        {
            if (DataSource.arr3[i].OrderID == newOrderItem.OrderID)
                DataSource.arr3[i] = newOrderItem;
        }
    }

    private OrderItem callOrderItem(Product product, Order order)
    {
       
    }
    private OrderItem[] callOrderItem(int id)
    {

    }

}
