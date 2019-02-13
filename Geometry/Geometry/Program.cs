using System;

namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            var geometry = new Geometry();
            geometry.DrawSquare(10);
        }
    }

    class Geometry
    { 
        public void DrawSquare(int size)
        {
            var horisontal = new string('*', size*2);
            var vertical = new string(' ', size-2);
            vertical = '*' + vertical + vertical + '*';

            for (int i = 0; i < size; i++)
            {
                if (i == 0 || i == size-1)
                {
                    Console.WriteLine(horisontal);
                }
                else
                {
                    Console.WriteLine(vertical);
                }
            }
        }
    }
}