using System;
using System.Collections.Generic;
using System.Linq;

namespace ListStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> stringList = new List<string>() { "hello", "hola", "Superior", "Elefante", "Carro", "uno"};

            Console.WriteLine("5 Letters Stringst\n");            
            Console.WriteLine("In the next list: " + string.Join(",", stringList) + "\nThese are the words with 5 characters or less: " );

            foreach (string s in stringList)
            {
                if (isFive(s))
                    Console.WriteLine(s);

            }
            Console.ReadLine();


        }

        public static bool isFive(string s)
        {
            if (s.Length <= 5)
                return true;
            else
                return false;
        }
    }
}
