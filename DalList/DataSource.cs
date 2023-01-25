

using DalApi;
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
    static internal List<User?> s_users = new List<User?>();



    internal static class Config
    {
        // run number for products

        internal const int s_startProductNumber = 1000;
        private static int s_nextProductNumber = s_startProductNumber;
        internal static int nextProduct { get { return s_nextProductNumber++; } }



        // run number for order class

        internal const int s_startOrderNumber = 1000;
        private static int s_nextOrderNumber = s_startOrderNumber;
        internal static int nextOrder { get { return s_nextOrderNumber++; } }

        // run number for orderitem class

        internal const int s_startOrderItemNumber = 1000;
        private static int s_nextOrderItemNumber = s_startOrderItemNumber;
        internal static int nextOrderItem { get { return s_nextOrderItemNumber++; } }

    }


    private static void s_Initialize()
    {
        createAndInitProduct();

        XmlTools.SaveListToXMLSerializer(s_products, "products");
        createAndInitOrder();
        XmlTools.SaveListToXMLSerializer(s_orders, "orders");
        createAndInitOrderItem();
        XmlTools.SaveListToXMLSerializer(s_orderItems, "orderItems");
        createAndInitUsers();
        
    }

    private static void createAndInitUsers()
    {
        s_users.Add(new User
        {
            userName = "AyalaHaim",
            password = 123456,
            Status = Status.Mannager
        });
        s_users.Add(new User
        {
            userName = "customer",
            password = 1111,
            Status = Status.Cutomer

        });
    }

    private static void createAndInitProduct()
    {
        string[] nameOfAnimals = new string[5] { "dog", "rabbit", "parrot", "fish","cat"  };
        string[] nameOfFoods = new string[5] { "Snacks", "natural food", "fish food", "vitamins", "GealthyFood" };
        string[] nameOfEquipment = new string[5] { "cage","collar" , "Food facility", "Aquarium", "strip" };
        string[] nameOfGames = new string[5] { "Training games", "Cage games", "ball", "dol", "swings" };
        string[] nameOfCultivation = new string[4] { "shampoo","fur brush" , "perfume", "mouth cleaning" };
        
        for (int i = 0; i < 5; i++)
        {
            
            for(int j=0;j<4;j++)
            {
                Product myProduct = new Product()
                {
                    ID = Config.nextProduct,
                    Category = (Category)i,
                   InStock = s_rand.Next(10),
                };
                if (i == 0)
                {
                    myProduct.Name = nameOfAnimals[j];
                    myProduct.Price = s_rand.Next(1000, 3000);
                }

                else if (i == 1)
                {
                    myProduct.Name = nameOfFoods[j];
                    myProduct.Price = s_rand.Next(30, 90);
                }

                else if (i == 2)
                {
                    myProduct.Name = nameOfEquipment[j];
                    myProduct.Price = s_rand.Next(50, 220);
                }

                else if (i == 3)
                {
                    myProduct.Name = nameOfGames[j];
                    myProduct.Price = s_rand.Next(70,150);
                }
                  
                else if (i == 4)
                {
                    myProduct.Name = nameOfCultivation[j];
                    myProduct.Price = s_rand.Next(70, 250);
                }
                  
                s_products.Add(myProduct);
                
            }
            
        }
    }
    private static void createAndInitOrder()
    {
        string[] names = new string[6] { "ayala", "noa", "tamar", "shani", "yael", "hadas" };
        for (int i = 0; i < 20; i++)
        {
            Order myOrder = new Order();
            myOrder.ID =Config.nextOrder;
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
            if (i < 0.8 * 20)
            {
                myOrder.ShipDate = DateTime.Now;
                myOrder.ShipDate = myOrder.ShipDate?.AddHours(24);
            }        
            else
            {
                myOrder.ShipDate = null;
            }
            if (i < 0.6 * 20)
            {
                myOrder.DeliveryDate = DateTime.Now;
                myOrder.DeliveryDate = myOrder.OrderDate?.AddDays(2);
            }
            else 
            {
                myOrder.DeliveryDate = null;
            }
               

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
            int amount = s_rand.Next(1,5);
            for (int j = 0; j < numOfProducts; j++)
            {
                if (stopCounter >= 40)
                    break;
                stopCounter++;
                
                Product? p = s_products[s_rand.Next(9)];
                OrderItem myOrderItem = new OrderItem
                {
                    Amount = amount,
                    Price = (double)p?.Price!* amount,
                    ID = Config.nextOrderItem,
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


