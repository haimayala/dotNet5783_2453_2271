using System;


namespace Targil0
{
    partial class Program
    {
        enum Menu
        {
            EXIT, CHECKORDER, CHECKORDERITEM, CHECKPRODUCT
        }
        enum Options
        {
            addToList = 'a', showById = 'b', showByDall = 'c', update = 'd', delete = 'e';
        }
        static void Main()
        {
            int x;
            x = System.Console.Read();

            switch (x)
            {
                case (int)Menu.EXIT:
                    {
                        char option = (char)System.Console.Read();
                        switch (option)
                        {
                            case (char)Options.addToList:

                            default:
                                break;
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}