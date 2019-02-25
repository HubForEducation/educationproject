using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    class Program
    {
        static ITelegramBotClient _botClient;
        static readonly BotEngine BotEngine = new BotEngine();

        static void Main()
        {
            Thread menuThread = new Thread(Menu);
            menuThread.Start();

            _botClient = new TelegramBotClient("GIVE_ME_YOUR_STUPID_TOKEN_RICK");
            _botClient.OnMessage += Bot_Commands;
            _botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
            Console.WriteLine("EducationTelegramBot.");
        }


        public static int Keypressed;

        public static void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("TelegramEducationBot.");
                Console.WriteLine("1. Save settings.");
                Console.WriteLine("2. Load Settings.");
                Console.WriteLine("3. Exit.");

                if (!Int32.TryParse(Console.ReadLine(), out Keypressed))
                {
                    Console.WriteLine("Only number.");
                    Console.ReadKey();
                }
                else
                {
                    if (Keypressed == 1)
                    {
                        Console.Write(Settings.Save());
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