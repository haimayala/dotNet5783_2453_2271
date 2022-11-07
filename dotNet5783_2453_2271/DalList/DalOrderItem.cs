//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using DO;
using System.Drawing;

namespace Dal;

public class DalOrderItem
{
    private void addNewOrderItem(OrderItem newOrderItem)
    {
        for(int i=0;i<50;i++)
        {
            if (DataSource.arr3[i].ID == newOrderItem.ID)
                throw new Exception ( "this order item is allresdy exsist" );
        }
       
    }

    private void deleteOrderItem(OrderItem newOrderItem)
    {
    
        for (int i = 0; i < 200; i++)
        {
            if (DataSource.arr3[i].ID == newOrderItem.ID)
            {
                return;
            }
        }

        throw new Exception("this order item is not exsist");
    }

    private OrderItem searchOrderItem(int id)
    {
        for(int i=0;i<200;i++)
        {
            if (DataSource.arr3[i].ID ==id )
                return DataSource.arr3[i];
        }
        throw new Exception("this order item is not exsist");
    }
    private void updateOrderItem(OrderItem newOrderItem)
    {
        for(int i=0;i<200;i++)
        {
            if (DataSource.arr3[i].ID == newOrderItem.ID)
            {
                DataSource.arr3[i] = newOrderItem;
                return;
            }  
        }
        throw new Exception("this order item is not exsist");
    }
}

//private OrderItem callOrderItem(Product product, Order order)
//{
//    for (int i = 0; i < 200; i++)
//    {
//        if (DataSource.arr3[i].ID == product.ID)
//            if (DataSource.arr3[i].ProductID == product.ID)
//                return DataSource.arr3[i];
//    }
   
    
//   throw new Exception("this order item is not exsist");
//}

//private OrderItem[] callOrderItem(int id)
//{

//}


