using System;
using System.Threading;

namespace TelegramBot
{
    class Program
    {

        static void Main()
        {
           
           Thread CheckFilesThread = new Thread(new ThreadStart(CheckFiles));
           CheckFilesThread.Start();

           while (true)
           {
               Console.WriteLine("Ha ha!");
               Thread.Sleep(2000);
           }
        }

        static void CheckFiles()
        {
            BotEngine bot = new BotEngine();

            while (true)
            {
                if (bot.Check() == true)
                {
                    Console.WriteLine("Найден новый файл!");
                }
            }
        }
    }
}