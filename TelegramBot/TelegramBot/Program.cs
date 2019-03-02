using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TelegramBot
{
    class Program
    {
        static ITelegramBotClient _botClient;
        static readonly BotEngine BotEngine = new BotEngine();
        private static Settings _settings { get; set; }
        
        static void Main()
        {
            _botClient = new TelegramBotClient("754861830:AAE98RFY3OILvgThAG7RR_livVSHbnJp5Wc");
            _botClient.OnMessage += Bot_Commands;

            _botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
            Console.WriteLine("EducationTelegramBot.");
        }


        public static int Keypressed;

        public void Menu()
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

                }
                else if (Keypressed == 2)
                {
                    Settings.Load();
                    Console.WriteLine(Settings.Load());
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

        static async void Bot_Commands(object sender, MessageEventArgs e)
        {

            if (e.Message.Text == "/get")
            {
                var files = BotEngine.Get();
                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: files
                );
            }

            else if (e.Message.Text == "/read")
            {
                var file = BotEngine.Read();

                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: file
                );
            }

            else if (e.Message.Text == "/download")
            {
                BotEngine.Download();
                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "File from " + Settings.DownloadAdress + "to " + Settings.DownloadPath +
                          " downloaded successfully."
                );
            }

            else if (e.Message.Text == "/command")
            {
                var commandanswer = BotEngine.Command();

                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: commandanswer
                );
            }
            else
            {
                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Command not found."
                );
            }
        }
    }
}