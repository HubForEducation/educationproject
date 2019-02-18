using System;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
           BotEngine bot = new BotEngine();
           var filemss = bot.Download("http://wallpapers-image.ru/1280x720/flowers/wallpapers-1280x720/zastavki-khrizantema-cvety-1280x720.jpg", "D:/picture.jpg");
           Console.WriteLine(filemss);
        }
    }
}