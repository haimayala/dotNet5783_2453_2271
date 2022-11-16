
using DO;
using static DO.Enums;
//using Dal;
//using System.Runtime.CompilerServices;
//using System.Collections.Specialized;
//using System.Data.Common;
//using System.Reflection.Metadata.Ecma335Stage0 Final commit
namespace Dal;




partial class Program
{
    // options
    enum Options { ADD, DELETE, GET, UPPDATE, GETALL ,PRINTALL };
    enum Menu { EXIT, PRODUCT, ORDER, ORDERITEM };

  
    static void Main()
    {
        DalProduct dalproduct = new DalProduct();
        DalOrder dalOrder = new DalOrder();
        DalOrderItem dalOrderItem = new DalOrderItem();

        // choose a menu
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
                // options
                    case 1:


                        Console.WriteLine(
                            @"shop Menu:
0- Add a new product
1- Delete a product
2-Get a product
3-Uppdate a product
4-Get all the products
5- Print all the product list");
                    int.TryParse(Console.ReadLine(), out int number);
                        switch (number)
                        { // add a product
                            case 0:
                          
                                Product p = new Product();
                            Console.WriteLine("please enter a product id:");                          
                            int.TryParse(Console.ReadLine(), out int id);
                            p.ID = id;
                            Console.WriteLine(@"please enter the product category
for animal enter - 0
for food enter - 1
for equipment enter - 2
for games enter - 3
for Cultivation enter -4");
                           
                            int.TryParse(Console.ReadLine(), out int cat);
                            p.Category = (Category)cat;

                                Console.WriteLine("please enter the product name");
                                p.Name = Console.ReadLine();
                                Console.WriteLine("please enter the product price");

                            int.TryParse(Console.ReadLine(), out int price);
                            p.Price = price;
                                Console.WriteLine("please enter the amount of the product in stock");
                            int.TryParse(Console.ReadLine(), out int stock);
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
                            // delete a product
                            Console.WriteLine("please enter the id of the product that you want to delete ");
                            int.TryParse(Console.ReadLine(), out int pid);
                            try
                            {
                                dalproduct.Delete(pid);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                           
                                break;
                            case 2:
                            // get a product
                            Console.WriteLine("please enter the id of the product that you want to get ");
                            int.TryParse(Console.ReadLine(), out int get);
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
                            // uppdate a product
                            Product n = new Product();
                            Console.WriteLine("please enter a product id:");
                            int.TryParse(Console.ReadLine(), out int proId);
                            n.ID = proId;
                            Console.WriteLine(@"please enter the product category
for animal enter - 0
for food enter - 1
for equipment enter - 2
for games enter - 3
for Cultivation enter -4");

                            int.TryParse(Console.ReadLine(), out int t);
                            n.Category = (Category)t;

                                Console.WriteLine("please enter the product name");
                                n.Name = Console.ReadLine();
                                Console.WriteLine("please enter the product price");

                            int.TryParse(Console.ReadLine(), out int y);
                            n.Price = y;
                                Console.WriteLine("please enter the amount of the product in stock");
                            int.TryParse(Console.ReadLine(), out int num);
                            n.InStock = num;
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
                            // get all products
                            Product[] arr = dalproduct.GetAll();                            
                                break;
                        case 5:
                            // print all products
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
                    int.TryParse(Console.ReadLine(), out int orOp);
                    switch (orOp)
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
                            int.TryParse(Console.ReadLine(), out int d);

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
                            int.TryParse(Console.ReadLine(), out int g);
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
                            int.TryParse(Console.ReadLine(), out int orderid);
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
                    int.TryParse(Console.ReadLine(), out int orderItemOp);
                    switch (orderItemOp)
                        {
                            case 0:
                                OrderItem orit = new OrderItem();
                                Console.WriteLine("please enter the order id");
                            int.TryParse(Console.ReadLine(), out int orid);
                            orit.OrderID = orid;
                                Console.WriteLine("please enter the product id");
                            int.TryParse(Console.ReadLine(), out int pid);
                            orit.ProductID = pid;
                                Console.WriteLine("please enter the order item price");
                            int.TryParse(Console.ReadLine(), out int pr);
                            orit.Price = pr;
                                Console.WriteLine("please enter the order item amount");
                            int.TryParse(Console.ReadLine(), out int am);
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
                            int.TryParse(Console.ReadLine(), out int oritid);
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
                            int.TryParse(Console.ReadLine(), out int g);
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
                            int.TryParse(Console.ReadLine(), out int orrid);
                            orUpp.ID = orrid;
                                Console.WriteLine("please enter the product id");
                            int.TryParse(Console.ReadLine(), out int ppid);
                            orUpp.ProductID = ppid;
                                Console.WriteLine("please enter the order item price");
                            int.TryParse(Console.ReadLine(), out int ppr);
                            orUpp.Price = ppr;
                                Console.WriteLine("please enter the order item amount");
                            int.TryParse(Console.ReadLine(), out int amm);
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
            int.TryParse(Console.ReadLine(), out menu);

            }
              
    }

}

