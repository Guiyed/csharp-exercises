using System;

namespace MPG
{
    class Program
    {
        static void Main(string[] args)
        {
            double mpg;
            float miles = 0;
            float gallonsOfGas = 0;
            Console.WriteLine("Miles Per Gallon");
            Console.WriteLine("Please enter the miles you have driven:");
            miles  = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the amount of gas you have used (in gallons)");
            gallonsOfGas = float.Parse(Console.ReadLine());
            mpg = miles / gallonsOfGas;
            Console.WriteLine("\nYour curret MPG rating is {0}", mpg);
            Console.ReadLine();
        }
    }
}
