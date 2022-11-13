
using DO;
using DalList;
using static DO.Enums;
using Dal;
using System.Runtime.CompilerServices;

namespace Dal;

partial class Program
{
    enum Options { ADD, DELETE, GET, UPPDATE, GETALL };
    enum Menu {  EXIT, PRODUCT, ORDER, ORDERITEM };
    static void Main()
    {
        DalProduct dalproduct = new DalProduct();
        DalOrder dalOrder = new DalOrder();
        DalOrderItem dalOrderItem = new DalOrderItem();

        Console.WriteLine(
            @"shop Menu:
0- Exit
1- Product
2-Order
3-OrderItem");

       int x= int.Parse(Console.ReadLine());

        while (x != 0)
        {           
            switch (x)
            {
                case 1:

                    Console.WriteLine(
           @"Product options:
0- Add a new product
1- Delete a product
2-Get a product
3-Uppdate a product
4-Get all the products");
                    int pOp = int.Parse(Console.ReadLine());
                    switch (pOp)
                    {
                        case 0:
                            Product p = new Product();
                            Console.WriteLine("please enter the product category" +
                                       "for animal enter - 0" +
                                       "for food enter - 1" +
                                       "for equipment enter - 2" +
                                       "for games enter - 3" +
                                       "for Cultivation enter -4");
                            int t = int.Parse(Console.ReadLine());
                            p.Category = (Category)t;

                            Console.WriteLine("please enter the product name");
                            p.Name = Console.ReadLine();
                            Console.WriteLine("please enter the product price");

                            int y = int.Parse(Console.ReadLine());
                            p.Price = y;
                            Console.WriteLine("please enter the amount of the product in stock");
                            int e = int.Parse(Console.ReadLine());
                            p.InStock = e;
                            dalproduct.Add(p);
                            break;

                        case 1:
                            Console.WriteLine("please enter the id of the product that you want to delete ");
                               int d=int.Parse(Console.ReadLine());
                            dalproduct.Delete(d);
                            break;
                        case 2:
                            Console.WriteLine("please enter the id of the product that you want to get ");
                            int g = int.Parse(Console.ReadLine());
                            dalproduct.GetByID(g);
                            break;
                        case 3:
                            Product n = new Product();
                            Console.WriteLine("please enter the product category" +
                                       "for animal enter - 0" +
                                       "for food enter - 1" +
                                       "for equipment enter - 2" +
                                       "for games enter - 3" +
                                       "for Cultivation enter -4");
                            int tt = int.Parse(Console.ReadLine());
                           n.Category = (Category)tt;

                            Console.WriteLine("please enter the product name");
                            n.Name = Console.ReadLine();
                            Console.WriteLine("please enter the product price");

                            int yy = int.Parse(Console.ReadLine());
                           n.Price =yy;
                            Console.WriteLine("please enter the amount of the product in stock");
                            int ee = int.Parse(Console.ReadLine());
                            n.InStock = ee;
                            dalproduct.Uppdate(n);
                            break;
                       case 4:
                            break;

                    }
                    break;
                case 2:
                    Console.WriteLine(
          @"Order options:
0- Add a new Order
1- Delete a Order
2-Get a Order
3-Uppdate a Order
4-Get all the Orders");
                    int oOp=int.Parse(Console.ReadLine());  
                    switch(oOp)
                    {
                        case 0:

                           Order or=new Order();
                            Console.WriteLine("please enter your name");
                                 or.CustomerName = Console.ReadLine();
                            Console.WriteLine("please enter your email");
                            or.CustomerEmail = Console.ReadLine();
                            Console.WriteLine("please enter tyour address");
                            or.CustomerAdress = Console.ReadLine();
                            or.OrderDate=DateTime.Now; 
                            dalOrder.Add(or);   
                            break;

                        case 1:
                            Console.WriteLine("please enter the id of the order that you want to delete ");
                            int d = int.Parse(Console.ReadLine());
                           dalOrder.Delete(d);  
                            break;
                        case 2:
                            Console.WriteLine("please enter the id of the order that you want to get ");
                            int g = int.Parse(Console.ReadLine());
                            dalOrder.GetByID(g);
                            break;
                        case 3:
                            Order orUpp = new Order();
                            Console.WriteLine("please enter your name");
                            orUpp.CustomerName = Console.ReadLine();
                            Console.WriteLine("please enter your email");
                            orUpp.CustomerEmail = Console.ReadLine();
                            Console.WriteLine("please enter tyour address");
                            orUpp.CustomerAdress = Console.ReadLine();
                            orUpp.OrderDate = DateTime.Now;
                            dalOrder.Uppdate(orUpp);
                            break;
                        case 4:
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine(
         @"Order Item options:
0- Add a new OrderItem
1- Delete a Order Item
2-Get a Order Item
3-Uppdate a Order Item
4-Get all the Order Items");
                    int orOp = int.Parse(Console.ReadLine());
                    switch(orOp)
                    {
                        case 0:
                            OrderItem orit = new OrderItem();
                            Console.WriteLine("please enter the order id");
                                int orid = int.Parse(Console.ReadLine());
                            orit.OrderID = orid;
                            Console.WriteLine("please enter the product id");
                            int pid = int.Parse(Console.ReadLine());
                            orit.ProductID = pid;
                            Console.WriteLine("please enter the order item price");
                            int pr = int.Parse(Console.ReadLine());
                            orit.Price=pr;
                            Console.WriteLine("please enter the order item amount");
                            int am = int.Parse(Console.ReadLine());
                            orit.Amount=am;
                            dalOrderItem.Add(orit);
                            break;
                        case 1:
                            Console.WriteLine("please enter the id of the order item you want to delete");
                            int oritid = int.Parse(Console.ReadLine());
                            dalOrderItem.Delete(oritid);
                            break;
                        case 2:
                            Console.WriteLine("please enter the id of the order item that you want to get ");
                            int g = int.Parse(Console.ReadLine());
                          dalOrderItem.GetByID(g);
                            break;
                        case 3:
                            OrderItem orUpp = new OrderItem();
                            Console.WriteLine("please enter the order id");
                            int orrid = int.Parse(Console.ReadLine());
                            orUpp.OrderID = orrid;
                            Console.WriteLine("please enter the product id");
                            int ppid = int.Parse(Console.ReadLine());
                            orUpp.ProductID = ppid;
                            Console.WriteLine("please enter the order item price");
                            int ppr = int.Parse(Console.ReadLine());
                            orUpp.Price = ppr;
                            Console.WriteLine("please enter the order item amount");
                            int amm = int.Parse(Console.ReadLine());
                            orUpp.Amount = amm;
                            dalOrderItem.Uppdate(orUpp);
                            break;
                        case 4:
                            break;
                    }
                    break;
            }
            Console.WriteLine(
          @"shop Menu:
0- Exit
1- Product
2-Order
3-OrderItem");
            x = int.Parse(Console.ReadLine());
        }
    }
}

