using System;

namespace Geometry
{
    internal class Program
    {
        private static void Main()
        {
            var drawing = new Geometry();
            int number;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter number of figure.");
                Console.WriteLine("1. Square.");
                Console.WriteLine("2. Triangle.");
            } while (int.TryParse(Console.ReadLine(), out number) != true);
            
            int size;

            do
            {
                Console.Clear();
                Console.WriteLine("Okay, new enter size.");
            } while (int.TryParse(Console.ReadLine(), out size) != true);

            if (number == 1)
            {
                drawing.DrawSquare(size);
            }
            else if (number == 2)
            {
                drawing.DrawTrangle(size);
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