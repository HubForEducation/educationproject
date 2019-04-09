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
            Task.Factory.StartNew(() =>
            {
                var menu = new Menu();
                menu.Get();
            });

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
            var cmd = new Cmd(Settings.Command, BotClient);
            BotClient.OnMessage += cmd.Api;

            BotClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }
    }
}