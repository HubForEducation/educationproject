using System;
using System.IO;

namespace TelegramBot
{
    class Menu
    {
        static Settings _settings = new Settings();

        public static int Keypressed;

        public static async void Get()
        {
            do
            {
                Console.WriteLine("TelegramEducationBot.");
                Console.WriteLine("1. Save settings.");
                Console.WriteLine("2. Load Settings.");
                Console.WriteLine("3. Exit.");

                if (!Int32.TryParse(Console.ReadLine(), out Keypressed))
                {
                    Console.WriteLine("Only number.");
                    Console.ReadKey();
                    continue;
                }

                if (Keypressed == 1)
                {
                    await _settings.Save(_settings);
                }
                else if (Keypressed == 2)
                {
                    try
                    {
                        _settings = await _settings.Load();
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("File not found.");
                    }
                }
                else if (Keypressed == 3)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Wrong number.");
                }
            } while (Keypressed != 3);
        }
    }
}
