using System;

namespace Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double pi = Math.PI;
            bool continuar = false;

            do
            {
                continuar = true;
                Console.WriteLine("\nEnter a radius:");
                string input = Console.ReadLine();
                float radius = float.Parse(input);
                if (radius >= 0)
                {
                    double area = pi * Math.Pow(radius, 2);
                    Console.WriteLine("The area of a circle with radius " + radius + " is: " + area);                    
                    Console.WriteLine("Do you want to continue y/n?");
                    string input2 = Console.ReadLine();
                    if(input2 == "n" || input2 == "N")
                    {
                        continuar = false;
                    }
                }
                else
                {
                    Console.WriteLine("!!! Error !!!, you have to input positive numbers only");                    
                }

            } while (continuar);
            

            //Console.ReadLine();
        }
    }
}