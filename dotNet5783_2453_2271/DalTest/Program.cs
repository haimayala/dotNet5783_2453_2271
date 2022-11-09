//using System;
//using System.Reflection;
using DO;
using DalList;

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

        int x = Console.Read();

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
                    int y = Console.Read();
                    switch(y)
                    {
                        case 0:
                            Product p = new Product();
                            Console.WriteLine("please enter the product name");
                            p.Name= Console.ReadLine();
                            Console.WriteLine("please enter the product price");
                            p.Price = Console.Read();
                            Console.WriteLine("please enter the product category");
                            break;
                    }
                    break;
                   
            }
        }
    }

}

