using System;

namespace Geometry
{
    class Program
    {
        static void Main()
        {
            int number, size;
            var drawing = new Geometry();
            Console.WriteLine("Enter number of figure.");
            Console.WriteLine("1. Square.");
            Console.WriteLine("2. Triangle.");
            Console.WriteLine("2. Square.");
            number = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("The value cannot be empty."));
            Console.WriteLine("Okay, new enter size.");
            size = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("The value cannot be empty."));
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
                Console.WriteLine("Invalid number of figure.");
                Console.ReadKey();
            }
        }
    }
}
