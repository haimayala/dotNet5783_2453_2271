
using DO;
using static DO.Enums;
using Dal;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace Dal;




partial class Program
{
    enum Options { ADD, DELETE, GET, UPPDATE, GETALL ,PRINTALL };
    enum Menu { EXIT, PRODUCT, ORDER, ORDERITEM };

  
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
      
        int menu = int.Parse(Console.ReadLine());
      
            while (menu != 0)
            {
                switch (menu)
                {
                    case 1:


                        Console.WriteLine(
                            @"shop Menu:
0- Add a new product
1- Delete a product
2-Get a product
3-Uppdate a product
4-Get all the products
5- Print all the product list");
                        int productOp = int.Parse(Console.ReadLine());
                        switch (productOp)
                        {
                            case 0:
                          
                                Product p = new Product();
                            Console.WriteLine("please enter a product id:");

                            int id = int.Parse(Console.ReadLine());
                            p.ID = id;
                            Console.WriteLine(@"please enter the product category
for animal enter - 0
for food enter - 1
for equipment enter - 2
for games enter - 3
for Cultivation enter -4");
                           
                                int c = int.Parse(Console.ReadLine());
                                p.Category = (Category)c;

                                Console.WriteLine("please enter the product name");
                                p.Name = Console.ReadLine();
                                Console.WriteLine("please enter the product price");

                                int price = int.Parse(Console.ReadLine());
                                p.Price = price;
                                Console.WriteLine("please enter the amount of the product in stock");
                                int stock = int.Parse(Console.ReadLine());
                                p.InStock = stock;
                            try
                            {
                                dalproduct.Add(p);
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }                              
                                break;

                            case 1:

                                Console.WriteLine("please enter the id of the product that you want to delete ");
                                int iid = int.Parse(Console.ReadLine());
                            try
                            {
                                dalproduct.Delete(iid);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                           
                                break;
                            case 2:

                                Console.WriteLine("please enter the id of the product that you want to get ");
                                int get = int.Parse(Console.ReadLine());
                            try
                            {
                               Product pro= dalproduct.GetByID(get);
                                Console.WriteLine(pro);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }

                           
                                break;
                            case 3:

                                Product n = new Product();
                            Console.WriteLine("please enter a product id:");
                            int idd = int.Parse(Console.ReadLine());
                            n.ID = idd;
                            Console.WriteLine(@"please enter the product category
for animal enter - 0
for food enter - 1
for equipment enter - 2
for games enter - 3
for Cultivation enter -4");

                                int tt = int.Parse(Console.ReadLine());
                                n.Category = (Category)tt;

                                Console.WriteLine("please enter the product name");
                                n.Name = Console.ReadLine();
                                Console.WriteLine("please enter the product price");

                                int yy = int.Parse(Console.ReadLine());
                                n.Price = yy;
                                Console.WriteLine("please enter the amount of the product in stock");
                                int ee = int.Parse(Console.ReadLine());
                                n.InStock = ee;
                            try
                            {
                                dalproduct.Uppdate(n);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }

                         
                                break;
                            case 4:
                                Product[] arr = dalproduct.GetAll();                            
                                break;
                        case 5:
                            Product[] pArr=dalproduct.GetAll();
                            for (int i = 0; i < pArr.Length; i++)
                            {
                                Console.WriteLine(pArr[i]);
                            }
                            break;

                    }
                        break;
                    case 2:

                        Console.WriteLine(
                            @"shop Menu:
0- Add a new order
1- Delete a order
2-Get a order
3-Uppdate a order
4-Get all the order
5- Print all the order list");
                        int orderOp = int.Parse(Console.ReadLine());
                        switch (orderOp)
                        {
                            case 0:

                                Order or = new Order();
                                Console.WriteLine("please enter your name");
                                or.CustomerName = Console.ReadLine();
                                Console.WriteLine("please enter your email");
                                or.CustomerEmail = Console.ReadLine();
                                Console.WriteLine("please enter your address");
                                or.CustomerAdress = Console.ReadLine();
                                or.OrderDate = DateTime.Now;
                            try
                            {
                                dalOrder.Add(or);
                            }

                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                                
                                break;

                            case 1:

                                Console.WriteLine("please enter the id of the order that you want to delete ");
                                int d = int.Parse(Console.ReadLine());

                            try
                            {
                                dalOrder.Delete(d);
                            }

                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }

                           
                                break;
                            case 2:

                                Console.WriteLine("please enter the id of the order that you want to get ");
                                int g = int.Parse(Console.ReadLine());
                            try
                            {
                               Order ord= dalOrder.GetByID(g);
                                Console.WriteLine(ord);
                            }

                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                           
                                break;
                            case 3:

                                Order orUpp = new Order();
                            Console.WriteLine("please enter your order id");
                            int orderid = int.Parse(Console.ReadLine());
                           orUpp.ID=orderid;
                            Console.WriteLine("please enter your name");
                                orUpp.CustomerName = Console.ReadLine();
                                Console.WriteLine("please enter your email");
                                orUpp.CustomerEmail = Console.ReadLine();
                                Console.WriteLine("please enter your address");
                                orUpp.CustomerAdress = Console.ReadLine();
                                orUpp.OrderDate = DateTime.Now;
                            try
                            {
                                dalOrder.Uppdate(orUpp);
                            }

                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                                
                                break;
                            case 4:
                            Order[] arr = dalOrder.GetAll();
                            break;

                        case 5:
                            Order[] Oarr = dalOrder.GetAll();
                            for (int i = 0; i < Oarr.Length; i++)
                            {
                                Console.WriteLine(Oarr[i]);
                            }
                            break;
                    }
                        break;
                    case 3:
                        Console.WriteLine(
                             @"shop Menu:
0- Add a new order item
1- Delete a order item
2-Get a order item
3-Uppdate a order item
4-Get all the order item
5-Print al the order item list");
                        int orderItemOp = int.Parse(Console.ReadLine());
                        switch (orderItemOp)
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
                                orit.Price = pr;
                                Console.WriteLine("please enter the order item amount");
                                int am = int.Parse(Console.ReadLine());
                                orit.Amount = am;
                            try
                            {
                                dalOrderItem.Add(orit);
                            }

                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            
                                break;
                            case 1:
                                Console.WriteLine("please enter the id of the order item you want to delete");
                                int oritid = int.Parse(Console.ReadLine());
                            try
                            {
                                dalOrderItem.Delete(oritid);
                            }

                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                           
                                break;
                            case 2:
                                Console.WriteLine("please enter the id of the order item that you want to get ");
                                int g = int.Parse(Console.ReadLine());
                            try
                            {
                                OrderItem orrit=dalOrderItem.GetByID(g);
                                Console.WriteLine(orrit);
                            }

                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }

                            
                                break;
                            case 3:
                                OrderItem orUpp = new OrderItem();
                                Console.WriteLine("please enter the order item id");
                                int orrid = int.Parse(Console.ReadLine());
                                orUpp.ID = orrid;
                                Console.WriteLine("please enter the product id");
                                int ppid = int.Parse(Console.ReadLine());
                                orUpp.ProductID = ppid;
                                Console.WriteLine("please enter the order item price");
                                int ppr = int.Parse(Console.ReadLine());
                                orUpp.Price = ppr;
                                Console.WriteLine("please enter the order item amount");
                                int amm = int.Parse(Console.ReadLine());
                                orUpp.Amount = amm;
                            try
                            {
                                dalOrderItem.Uppdate(orUpp);
                            }

                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            
                                break;
                            case 4:
                            OrderItem[] arr = dalOrderItem.GetAll();                            
                            break;
                        case 5:
                            OrderItem[] orarr = dalOrderItem.GetAll();
                            for (int i = 0; i < orarr.Length; i++)
                            {
                                Console.WriteLine(orarr[i]);
                            }
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
                menu = int.Parse(Console.ReadLine());
            }
              
    }

}

