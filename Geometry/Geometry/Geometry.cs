using System;

namespace Geometry
{
    public class Geometry
    {
        public char Brush { get; set; } = '*';
        public char Font { get; set; } = ' ';

        public void DrawSquare(int size)
        {
            Console.Clear();
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException("Bad input params.");
            }
            else
            {
                var line = new String(Brush, size);
                Console.WriteLine(line);
                var i = 0;
                while (i != size - 2)
                {
                    Console.WriteLine(Brush + new string(Font, size - 2) + Font + Brush + Font);
                    i++;
                }

                Console.WriteLine(line);
                Console.ReadKey();
            }
        }

        public void DrawTrangle(int size)
        {
            Console.Clear();
            if (size < 1)
            {
                Console.WriteLine("Bad input params.");
                Console.ReadKey();
            }
            else
            {
                var count = 1;
                while (size-- != 0)
                {
                    int c = count;
                    while (c-- != 0)
                    {
                        Console.Write(Brush);
                    }

                    Console.WriteLine();
                    count = count + 2;
                }

                Console.ReadKey();
            }
        }

        public void DrawCircle(int size)
        {
            Console.Clear();
            if (size < 1)
            {
                Console.WriteLine("Bad input params.");
                Console.ReadKey();
            }
            else
            {
                void Write(int xp, int yp)
                {
                    Console.SetCursorPosition(xp, yp);
                    Console.Write(Brush);
                }

                int centerX = size * 2, centerY = size, radius = size, x = -radius;
                while (x < radius)
                {
                    var y = (int) Math.Floor(Math.Sqrt(radius * radius - x * x));

                    Write(x + centerX, y + centerY);
                    y = -y;
                    Write(x + centerX, y + centerY);
                    x++;
                }

                Console.ReadLine();
            }
        }
    }
}