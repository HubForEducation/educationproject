using System;

namespace Geometry
{
    public class Geometry
    {
        public char Brush { get; set; } = '*';
        public char Font { get; set; } = '*';

        public void DrawSquare(int size)
        {
            Console.Clear();
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Only 1 and more!");
            }
            else
            {
                var brush = '*';
                var line = new String(Brush, size);
                Console.WriteLine(line);
                int i = 0;
                while (i != size - 2)
                {
                    Console.WriteLine(brush + new string(Font, size - 2) + Font + brush + Font);
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
                Console.WriteLine("Only 1 and more!");
                Console.ReadKey();
            }
            else
            {
                int count = 1;
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
                Console.WriteLine("Only 1 and more!");
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