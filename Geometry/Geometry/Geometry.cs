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
                var brush = "*";
                var body = new String(brush, n);
                Console.WriteLine(body);
                int i = 0;
                while (i != size - 2)
                {
                    Console.WriteLine(brush + new string(' ', size - 2) + brush);
                    i++;
                }
                Console.WriteLine(body);
                Console.ReadKey();
            }
            }
        }
    }
}