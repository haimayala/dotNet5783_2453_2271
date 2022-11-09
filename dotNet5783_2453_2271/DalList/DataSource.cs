//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using DO;
using static DO.Enums;

namespace Dal;

static internal class DataSource

{

    static DataSource()
    {
        s_Initialize();
    }




    static readonly Random s_rand = new Random();

    static internal Product[] Products = new Product[50];
    static internal Order[] Orders = new Order[100];
    static internal OrderItem[] OrdersItmes = new OrderItem[200];
    //static internal List<Product> Products { get; } = new List<Product>();
    //static internal List<Order> Orders { get; } = new List<Order>();
    //static internal List<OrderItem> OrderItems { get; } = new List<OrderItem>();


    internal static class Config
    {
        //counter for the arrays
        static internal int NumOfProducts = 0;
        static internal int NumOfOrders = 0;
        static internal int NumOfOrderItems = 0;
        // run number fo order class
        internal const int s_startOrderNumber = 1000;
        private static int s_nextOrderNumber = s_startOrderNumber;
        internal static int NextOrder { get { return s_nextOrderNumber++; } }


        // run number for orderitem class

        internal const int s_startOrderItemNumber = 1000;
        private static int s_nextOrderItemNumber = s_startOrderItemNumber;
        internal static int NextOrderItem { get { return s_nextOrderItemNumber++; } }
    }

    static string[,] NameOfProduct = new string[5, 5]; // srrays ames of all the products 
    private static void s_Initialize()
    {
        createAndInitProduct();
        createAndInitOrder();
        createAndInitOrderItem();
    }

    private static void createAndInitProduct()
    {
        for (int i = 1; i <= 10; i++)
        {
            Products.(
                new Product
                {
                    ID = i,
                    Name = " ",
                    Category = (Category)s_rand.Next(5),
                    Price = s_rand.Next(250),
                InStock = s_rand.Next(50)
                });
        }
    }

    private static void createAndInitOrder()
    {
        for(int i=1;i<=20;i++)
        {
            Orders.Add(
                new Order
                {
                    ID = i,
                    CustomerAdress = " ",
                    CustomerEmail="",
                    CustomerName="",
                }
                );
        }
    }

    private static void createAndInitOrderItem()
    {
        for(int i=1;i<=40;i++)
        {
            OrderItems.Add(
                new OrderItem
                {
                    ID=i,
                    OrderID=

                })
        }
    }

}


