using System;

namespace Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double area;
            float lenght=0;
            float height=0;
            Console.WriteLine("Area of a Rectanlge");
            Console.WriteLine("Please enter the Lenght of the Rectangle:");
            lenght = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Height of the Rectangle");
            height = float.Parse(Console.ReadLine());
            area = lenght * height;
            Console.WriteLine("\nThe area of the Rectanlge of lenght " + lenght + " and height " + height + " is: " + area);
            Console.ReadLine();

        }
    }
}
