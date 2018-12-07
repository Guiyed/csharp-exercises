using System;
using System.Collections.Generic;

namespace ComputerStudio
{
    class Program
    {
        static void Main(string[] args)
        {

            Computer comp1 = new Computer("Guille", "Windows");
            Laptop comp2= new Laptop("Mari", "Mac OS");
            Desktop comp3 = new Desktop("Casa", "Windows 10");
            MobilePhone comp4 = new MobilePhone("Samsung", "Android 7.1");


            Console.WriteLine(comp1 + "\n");
            Console.WriteLine(comp2 + "\n");
            Console.WriteLine(comp3 + "\n");
            Console.WriteLine(comp4 + "\n");

            Console.ReadLine();

        }
                       

    }
}
