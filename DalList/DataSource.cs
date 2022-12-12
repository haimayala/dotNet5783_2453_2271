

using DO;
using System.Collections.Specialized;
using static DO.Enums;

namespace Dal;

static internal class DataSource
{
    static DataSource()
    {
        s_Initialize();
    }

    static readonly Random s_rand = new Random();

    static internal List<Product?> s_products = new List<Product?>();
    static internal List<Order?> s_orders = new List<Order?>();
    static internal List<OrderItem?> s_orderItems = new List<OrderItem?>();    

    // run number for order class

    internal const int s_startOrderNumber = 1000;
    private static int s_nextOrderNumber = s_startOrderNumber;
    internal static int nextOrder { get { return s_nextOrderNumber++; } }

    // run number for orderitem class

    internal const int s_startOrderItemNumber = 1000;
    private static int s_nextOrderItemNumber = s_startOrderItemNumber;
    internal static int nextOrderItem { get { return s_nextOrderItemNumber++; } }


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
            Product myProduct = new Product();
            myProduct.ID = s_rand.Next(100000, 999999);
            bool flag = false;
            int counter = 0;
            while (!flag)
            {
                for (int j = 0; j < s_products.Count; j++)
                {
                    if (s_products[j]?.ID == myProduct.ID)
                        myProduct.ID = s_rand.Next(100000, 999999);
                    else
                        counter++;
                }
                if (counter == s_products.Count)
                    flag = true;
            }

            myProduct.Category = (Category)s_rand.Next(5);
            if (myProduct.Category.Equals(Enums.Category.Animals))
            {
                myProduct.Name = nameOfAnimals[s_rand.Next(5)];
                myProduct.Price = s_rand.Next(1000, 3000);
                myProduct.InStock = s_rand.Next(15, 30);
            }

            if (myProduct.Category.Equals(Enums.Category.Food))
            {
                myProduct.Name = nameOfFoods[s_rand.Next(5)];
                myProduct.Price = s_rand.Next(150, 250);
                myProduct.InStock = s_rand.Next(70, 100);
            }

            if (myProduct.Category.Equals(Enums.Category.Equipment))
            {
                myProduct.Name = nameOfEquipment[s_rand.Next(5)];
                myProduct.Price = s_rand.Next(100, 200);
                myProduct.InStock = s_rand.Next(50);
            }

            if (myProduct.Category.Equals(Enums.Category.Games))
            {
                myProduct.Name = nameOfGames[s_rand.Next(5)];
                myProduct.Price = s_rand.Next(30, 70);
                myProduct.InStock = s_rand.Next(35);
            }

            if (myProduct.Category.Equals(Enums.Category.Cultivation))
            {
                myProduct.Name = nameOfCultivation[s_rand.Next(4)];
                myProduct.Price = s_rand.Next(50, 150);
                myProduct.InStock = s_rand.Next(90);
            }

            s_products.Add(myProduct);
        }
    }
    private static void createAndInitOrder()
    {
        string[] names = new string[6] { "ayala", "noa", "tamar", "shani", "yael", "hadas" };
        for (int i = 0; i < 20; i++)
        {
            Order myOrder = new Order();
            myOrder.ID = DataSource.nextOrder;
            myOrder.CustomerName = names[s_rand.Next(6)];
            if (myOrder.CustomerName == "ayala")
            {
                myOrder.CustomerAdress = "elad";
                myOrder.CustomerEmail = "ayala@gmail.com";
            }
            if (myOrder.CustomerName == "noa")
            {
                myOrder.CustomerAdress = "ramat gan";
                myOrder.CustomerEmail = "noa@gmail.com";
            }
            if (myOrder.CustomerName == "tamar")
            {
                myOrder.CustomerAdress = "natanya";
                myOrder.CustomerEmail = "tamar@gmail.com";
            }
            if (myOrder.CustomerName == "shani")
            {
                myOrder.CustomerAdress = "petah tikva";
                myOrder.CustomerEmail = "shani@gmail.com";
            }
            if (myOrder.CustomerName == "yael")
            {
                myOrder.CustomerAdress = "givataim";
                myOrder.CustomerEmail = "yael@gmail.com";
            }
            if (myOrder.CustomerName == "hadas")
            {
                myOrder.CustomerAdress = "naharia";
                myOrder.CustomerEmail = "hadas@gmail.com";
            }
            myOrder.OrderDate = DateTime.Now;
            if (i <= 0.8 * 20)
                myOrder.DeliveryDate = myOrder.OrderDate?.AddDays(2);
            if (i <= 0.6 * 20)
                myOrder.ShipDate = myOrder.ShipDate?.AddHours(24);
            s_orders.Add(myOrder);
            
        }
    }
    private static void createAndInitOrderItem()  
    {
        int numOfOrders =0;
        int counter = 0;
        int stopCounter = 0;

        for(int i=0;i<40;i++)
        {
            
            if (counter == 20)
                counter = 0;
            int numOfProducts = s_rand.Next(1, 4);
            int amount = s_rand.Next(20, 35);
            for (int j = 0; j < numOfProducts; j++)
            {
                if (stopCounter >= 40)
                    break;
                stopCounter++;
                
                Product? p = s_products[s_rand.Next(9)];
                OrderItem myOrderItem = new OrderItem
                {
                    Amount = amount,
                    Price = (double)p?.Price! * amount,
                    ID = nextOrderItem,
                    OrderID = (int)s_orders[counter]?.ID!,
                    ProductID =(int) p?.ID!,
                };
                s_orderItems.Add(myOrderItem);  
            }

            counter++;
            numOfOrders++;
        }
    }
}


