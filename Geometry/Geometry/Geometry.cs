using System;

namespace Geometry
{
    public class Geometry
    {
        public void DrawSquare(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Only 1 and more!");
            }
            else
            {
                var brush = '*';
                var font = ' ';

                var horisontal = new string(brush, size);
                var vertical = new string(font, size);
                vertical = brush + vertical + brush;

                for (int i = 0; i < size; i++)
                {
                    if (i == 0 || i == size - 1)
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
}