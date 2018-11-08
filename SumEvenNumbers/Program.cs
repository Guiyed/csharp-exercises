using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Array Method
             * 
             * int[] list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
             * Console.WriteLine(string.Join(",", list));
            */

            List<int> numbersList = new List<int>();
            numbersList.Add(1);
            numbersList.Add(2);
            numbersList.Add(3);
            for (int i =4; i<11; i++)
            {
                numbersList.Add(i);
            }


            //List<int> numbersList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Sum Even Numbers in list\n");

            

            foreach (int number in numbersList)
            {
                Console.Write(number.ToString()+",");
                //Console.Write(number);

            }
            Console.WriteLine("\nThe Sum of even numbers in previous list is: " + Funciones.SumEven(numbersList));
            Console.ReadLine();
        }
    }

    class Funciones
    {

        public static int SumEven(List<int> args)
        {
            int sum = 0;
            for (int i = 0; i < args.Count; i++)
            {
                if (args[i] % 2 == 0)
                    sum += args[i];
            }

            return sum;
        }

        public static int SumEven(int[] args)
        {
            int sum=0;
            for (int i = 0; i < args.Length; i++) {
                if (args[i] % 2 == 0)
                    sum += args[i];
            }

            return sum;
        }
    }
}
