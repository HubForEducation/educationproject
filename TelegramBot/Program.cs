using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Commands;

namespace TelegramBot
{
    class Program
    {
        public static ITelegramBotClient BotClient;
        public static Settings Settings = new Settings();
        public static string ApiToken = Settings.ApiToken;
        public static string ChatId = Settings.ChatId;


        static void Main()
        {
            Thread menuThread = new Thread(Menu.Get);
            menuThread.Start();

            //Update update = new Update();
            //Thread checkUpdateThread = new Thread(delegate () { TelegramBot.Update(); });
            //checkUpdateThread.Start();

            Task.Factory.StartNew(() =>
            {
                var update = new Update();
                update.CheckUpdate(ApiToken, ChatId, Settings.CheckPath, Settings.CheckTime);
            });

            BotClient = new TelegramBotClient(ApiToken);

            var get = new Get(Settings.Get, BotClient);
            BotClient.OnMessage += get.Api;
            var read = new Read(Settings.Read, BotClient);
            BotClient.OnMessage += read.Api;
            var download = new Download(Settings.DownloadAdress, BotClient);
            BotClient.OnMessage += download.Api;
            var command = new Command(Settings.Command, BotClient);
            BotClient.OnMessage += command.Api;

            BotClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }
    }
}