//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using DO;

namespace Dal;

static internal class DataSource

{

    static DataSource()
    {
        s_Initialize();
    }




    static readonly Random NAME = new Random();
    static internal List<Product> Products { get; } = new List<Product>();
    static internal List<Order> Orders { get; } = new List<Order>();
    static internal List<OrderItem> OrderItems { get; } = new List<OrderItem>();


    internal static class Config
    {
        // run number fo order class
        internal const int s_startOrderNumber = 1000;
        private static int s_nextOrderNumber = s_startOrderNumber;
        internal static int NextOrder { get { return s_nextOrderNumber++; } }


        // run number for orderitem class

        internal const int s_startOrderItemNumber = 1000;
        private static int s_nextOrderItemNumber = s_startOrderItemNumber;
        internal static int NextOrderItem { get { return s_nextOrderItemNumber++; } }
    }

    
    private static void s_Initialize()
    {
        createAndInitProduct();
        createAndInitOrder();
        createAndInitOrderItem();
    }

    private static void createAndInitProduct()
    {

    }

    private static void createAndInitOrder()
    {

    }

    private static void createAndInitOrderItem()
    {

    }

}


