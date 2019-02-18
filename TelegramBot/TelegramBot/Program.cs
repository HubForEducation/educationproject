using System;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
           BotEngine bot = new BotEngine();
<<<<<<< HEAD
           var answ = bot.Command("ipconfig /all");
           Console.WriteLine(answ);
=======
           var filemss = bot.Download("http://wallpapers-image.ru/1280x720/flowers/wallpapers-1280x720/zastavki-khrizantema-cvety-1280x720.jpg", "D:/picture.jpg");
           Console.WriteLine(filemss);
>>>>>>> parent of 1db0c66... Add new classes.
        }
    }
}