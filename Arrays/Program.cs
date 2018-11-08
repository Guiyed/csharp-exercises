using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
             
            int[] list = new int[] { 1, 1, 2, 3, 5, 8};

            Console.WriteLine("Arrays Examples\n");

            foreach (int number in list)
            {               
                Console.WriteLine(number);
            }
                          
            Console.WriteLine("\nOtra forma de escribir en pantalla: \n");
            
            Console.Write(string.Join(",", list));
            

            Console.ReadLine();

        }
    }
}
