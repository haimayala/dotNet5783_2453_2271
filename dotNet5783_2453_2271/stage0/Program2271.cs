using System;

namespace Targil0
{
    partial class Program
    {
        static void Main(string[] agrs)
        {
            welcome2271();
            welcome2453();
            Console.ReadKey();
        }

        static partial void welcome2453();
        private static void welcome2271()
        {
            Console.WriteLine("Enter your name: ");
            string username = Console.ReadLine();
            Console.WriteLine("{ 0}, welcome to my first console application", username);
        }

    }
}