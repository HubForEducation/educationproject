using System;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
           BotEngine bot = new BotEngine();
           var answ = bot.Command("ipconfig /all");
           Console.WriteLine(answ);
           
        }
    }
}