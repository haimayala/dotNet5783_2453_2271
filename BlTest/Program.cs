using BlImplementation;
using BlApi;
using BO;
using static BO.Enums;
using System.Security.Cryptography;

namespace BlTest;
internal class Program
{

    enum Menu { EXIT, PRODUCT, ORDER, CART };
    static void Main(string[] args)
    {
        IBl bl = new Bl();
        BO.Cart cart = new Cart();


        List<OrderItem>s = new List<OrderItem>();   
        for(int i=0;i<2;i++)
        {
            BO.OrderItem o = new()
            {
                ProductId = i,
                Price = i,
                TotalPrice = 0,
            };
            s.Add(o);
        }


        cart.CustonerAddres = "elad";
        cart.CustonerAddres = "ayala";
        cart.CustomerEmail ="ala@";
        cart.TotalPrice = 0;
        cart.Items = s;

        Console.WriteLine(
            @"shop Menu:
0- Exit
1- Product
2-Order
3-Cart");
        int option1 = int.Parse(Console.ReadLine());

        while (option1 != 0)
        {
            switch (option1)
            {
                case 1:
                    Console.WriteLine(
           @"shop Menu:
0- Get Products for list
1-Get Product by id
2-Get product details
3-Add product
4-Delete product
5-Uppdate product");
                    int option2 = int.Parse(Console.ReadLine());
                    switch (option2)
                    {
                        case 0:
                            IEnumerable<ProductForList?> productForLists = bl.Product.GetListedProducts();
                            foreach (var item in productForLists)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case 1:
                            Console.WriteLine("Please enter the product id you want to get");
                            int pId = int.Parse(Console.ReadLine());
                            BO.Product product = bl.Product.GetProductById(pId);
                            Console.WriteLine(product);
                            break;
                        case 2:
                            Console.WriteLine("Please enter the product id you want to get the details");
                            pId = int.Parse(Console.ReadLine());
                            BO.ProductItem productItem = bl.Product.GetProductDetails(pId);
                            Console.WriteLine(productItem);
                            break;
                        case 3:
                            BO.Product product1 = new BO.Product();
                            Console.WriteLine("Please enter the product id for adding:");
                            product1.ID = int.Parse(Console.ReadLine());
                            Console.WriteLine(@"please enter the product category
for animal enter - 0
for food enter - 1
for equipment enter - 2
for games enter - 3
for Cultivation enter -4");
                            int category = int.Parse(Console.ReadLine());
                            product1.Category = (Category)category;
                            Console.WriteLine("Please enter the product name:");
                            product1.Name = Console.ReadLine();                          
                            Console.WriteLine("Please enter the product in stock:");
                            product1.InStock = int.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the product price:");
                            product1.Price = int.Parse(Console.ReadLine());
                            bl.Product.Add(product1);
                            Console.WriteLine(product1);
                            break;
                        case 4:
                            Console.WriteLine("Please enter the product id you want to delete:");
                            pId = int.Parse(Console.ReadLine());
                            bl.Product.Delete(pId);
                            break;
                        case 5:
                            BO.Product product2 = new BO.Product();
                            Console.WriteLine("Please enter the product id for uppdating:");
                            product2.ID = int.Parse(Console.ReadLine());
                            Console.WriteLine(@"please enter the product category
for animal enter - 0
for food enter - 1
for equipment enter - 2
for games enter - 3
for Cultivation enter -4");
                            category = int.Parse(Console.ReadLine());
                            product2.Category = (Category)category;
                            Console.WriteLine("Please enter the product name for uppdating:");
                            product2.Name = Console.ReadLine();                           
                            Console.WriteLine("Please enter the product in stock for uppdating:");
                            product2.InStock = int.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the product price for uppdating:");
                            product2.Price = int.Parse(Console.ReadLine());
                            bl.Product.Uppdate(product2);
                            break;

                    }

                    break;
                case 2:
                    Console.WriteLine(
          @"shop Menu:
0- Get orders for list
1-Get order by id
2-Update the order ship date
3-Uppdate the order delivery date
4-get the order tracking");
                    option2 = int.Parse(Console.ReadLine());
                    switch (option2)
                    {
                        case 0:
                            IEnumerable<OrderForList> orders = (IEnumerable<OrderForList>)bl.Order.GetLitedOrders();
                            foreach (var item in orders)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case 1:
                            Console.WriteLine("Please enter the order id you want to get");
                            int oId = int.Parse(Console.ReadLine());
                            BO.Order order = bl.Order.GetOrderDetails(oId);
                            Console.WriteLine(order);
                            break;
                        case 2:
                            Console.WriteLine("Please enter the order id you want to update order shipping");
                            oId = int.Parse(Console.ReadLine());
                            order = bl.Order.UppdateShipDate(oId);
                            Console.WriteLine(order);
                            break;
                        case 3:
                            Console.WriteLine("Please enter the order id you want to update order delivering");
                            oId = int.Parse(Console.ReadLine());
                            order = bl.Order.UppdateDeliveryDate(oId);
                            Console.WriteLine(order);
                            break;
                        case 4:
                            Console.WriteLine("Please enter the order id that you want to fet the tracking");
                            oId = int.Parse(Console.ReadLine());
                            BO.OrderTracking orderTracking = bl.Order.OrderTracking(oId);
                            Console.WriteLine(orderTracking);
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine(
         @"shop Menu:
0- Add a product to the cart
1-Update product amount in cart
2-Make an order");
                    option2 = int.Parse(Console.ReadLine());
                    switch (option2)
                    {
                        case 0:
                           
                            Console.WriteLine("Please enter your name:");
                            cart.CustomerName = Console.ReadLine();
                            Console.WriteLine("Please enter your email:");
                            cart.CustomerEmail = Console.ReadLine();
                            Console.WriteLine("Please enter your addres:");
                            cart.CustonerAddres = Console.ReadLine();
                            Console.WriteLine("Please enter the product id you want to add");
                            int cId = int.Parse(Console.ReadLine());
                           cart = bl.Cart.Add(cart,cId);
                            Console.WriteLine(cart);
                            break;
                        case 1:
                            Console.WriteLine("Please enter your name:");
                            cart.CustomerName = Console.ReadLine();
                            Console.WriteLine("Please enter your email:");
                            cart.CustomerEmail = Console.ReadLine();
                            Console.WriteLine("Please enter your addres:");
                            cart.CustonerAddres = Console.ReadLine();
                            Console.WriteLine("Please enter the product id you want to update the amount");
                            cId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the new amount");
                            int amount = int.Parse(Console.ReadLine());
                            cart = bl.Cart.Uppdate(cart,cId, amount);
                            Console.WriteLine(cart);
                            break;
                        case 2:
                            
                            Console.WriteLine("Please enter your name:");
                           string name = Console.ReadLine();
                            Console.WriteLine("Please enter your email:");
                           string email = Console.ReadLine();
                            Console.WriteLine("Please enter your addres:");
                            string addres = Console.ReadLine();
                            bl.Cart.OrderConfirmation(cart, name, email, addres);
                            Console.WriteLine(cart);
                            break;
                    }
                    break;
            }

            Console.WriteLine(
          @"shop Menu:
0- Exit
1- Product
2-Order
3-Cart");
           option1 = int.Parse(Console.ReadLine());

        }
    }
}




