using System;

namespace Geometry
{
    internal class Program
    {
        private static void Main()
        {
            var drawing = new Geometry();
            int number;

            Console.WriteLine("Press any key to start.");
            while (int.TryParse(Console.ReadLine(), out number) != true)
            {
                Console.Clear();
                Console.WriteLine("Enter number of figure.");
                Console.WriteLine("1. Square.");
                Console.WriteLine("2. Triangle.");
                Console.WriteLine("3. Circle.");
            }

            int size;
            Console.WriteLine("Okay, new enter size.");
            while (int.TryParse(Console.ReadLine(), out size) != true)
            {
                Console.Clear();
                Console.WriteLine("Okay, new enter size.");
            }

            if (number == 1)
            {
                drawing.DrawSquare(size);
            }
            else if (number == 2)
            {
                drawing.DrawTrangle(size);
            }
            else if (number == 3)
            {
                drawing.DrawCircle(size);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid number of figure.");
                Console.ReadKey();
            }
        }
    }
}