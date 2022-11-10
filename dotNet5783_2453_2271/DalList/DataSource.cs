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

    internal static class Config
    {
        //counterד for the arrays
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

    static string[,] NameOfProduct = new string[5, 5];
    private static void s_Initialize()
    {
        createAndInitProduct();
        createAndInitOrder();
        createAndInitOrderItem();
    }

    private static void createAndInitProduct()
    {
        string[] nameOfAnimals = new string[5] { "dog", "cat", "parrot", "fish", "rabbit" };
        string[] nameOfFoods = new string[5] { "Snacks", "natural food", "Dry food", "vitamins", "GealthyFood" };
        string[] nameOfEquipment = new string[5] { "cage", "strip", "Food facility", "Aquarium", "collar" };
        string[] nameOfGames = new string[5] { "Training games", "Cage games", "ball", "dol", "swings" };
        string[] nameOfCultivation = new string[4] { "shampoo", "fur brush", "perfume", "mouth cleaning" };
        for (int i = 0; i < 10; i++)
        {
            Product p = new Product();
            p.ID = i;
            p.Category = (Category)s_rand.Next(5);
            if (p.Category.Equals(Enums.Category.Animals))
            {
                p.Name = nameOfAnimals[s_rand.Next(5)];
                p.Price = s_rand.Next(1000, 3000);
                p.InStock = s_rand.Next(15, 30);
            }

            if (p.Category.Equals(Enums.Category.Food))
            {
                p.Name = nameOfFoods[s_rand.Next(5)];
                p.Price = s_rand.Next(150, 250);
                p.InStock = s_rand.Next(70, 100);
            }

            if (p.Category.Equals(Enums.Category.Equipment))
            {
                p.Name = nameOfEquipment[s_rand.Next(5)];
                p.Price = s_rand.Next(100, 200);
                p.InStock = s_rand.Next(50);
            }

            if (p.Category.Equals(Enums.Category.Games))
            {
                p.Name = nameOfGames[s_rand.Next(5)];
                p.Price = s_rand.Next(30, 70);
                p.InStock = s_rand.Next(35);
            }

            if (p.Category.Equals(Enums.Category.Cultivation))
            {
                p.Name = nameOfCultivation[s_rand.Next(4)];
                p.Price = s_rand.Next(50, 150);
                p.InStock = s_rand.Next(90);
            }

            Products[DataSource.Config.NumOfProducts] = p;
            DataSource.Config.NumOfProducts++;
        }
    }
    private static void createAndInitOrder()
    {
      
       for(int i=0;i<20;i++)
        {
            Order or = new Order();
           or.ID = i;
            Orders[DataSource.Config.NumOfOrders] = or;
            DataSource.Config.NumOfOrders++;
        }
    }
    private static void createAndInitOrderItem()
    {
        for (int i = 0; i < 40; i++)
        {
            OrderItem o = new OrderItem();
            o.ID = i;
            o.Price = s_rand.Next(100, 500);
            o.Amount = s_rand.Next(5);
           OrdersItmes[DataSource.Config.NumOfOrderItems] = o;
            DataSource.Config.NumOfOrderItems++;
        }
    }

}


