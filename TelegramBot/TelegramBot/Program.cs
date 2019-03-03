using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    class Program
    {
        static ITelegramBotClient _botClient;
        static readonly BotEngine BotEngine = new BotEngine();
        static Settings _settings = new Settings();
        public static string ApiToken = _settings.ApiToken;
        public static string ChatId = _settings.ChatId;

        static void Main()
        {
            Thread menuThread = new Thread(Menu);
            menuThread.Start();

            Thread checkUpdateThread = new Thread(CheckUpdate);
            checkUpdateThread.Start();

            _botClient = new TelegramBotClient(ApiToken);
            _botClient.OnMessage += Bot_Commands;

            _botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        public static void CheckUpdate()
        {
            while (true)
            {
                BotEngine.Check(_settings.CheckPath);
                string checkedanswer = BotEngine.Checked(BotEngine.Checkedstring);
                if (checkedanswer != null)
                {
                    //api.telegram.org/bot<Bot_token>/getUpdates

                    string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                    string apiToken = ApiToken;
                    string chatId = ChatId;
                    string text = checkedanswer;
                    urlString = String.Format(urlString, apiToken, chatId, text);
                    WebRequest request = WebRequest.Create(urlString);
                    Stream rs = request.GetResponse().GetResponseStream();
                    StreamReader reader = new StreamReader(rs ?? throw new InvalidOperationException());
                    string line = "";
                    StringBuilder sb = new StringBuilder();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line != null)
                            sb.Append(line);
                    }
                }

                BotEngine.Checkedstring = null;
                Thread.Sleep(_settings.CheckTime);
            }
        }

        public static int Keypressed;

        public static async void Menu()
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

        static async void Bot_Commands(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "/get")
            {
                var files = BotEngine.Get(_settings.Get);
                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: files
                );
            }

            else if (e.Message.Text == "/read")
            {
                var file = BotEngine.Read(_settings.Read);

                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: file
                );
            }

            else if (e.Message.Text == "/download")
            {
                BotEngine.Download(_settings.DownloadAdress, _settings.DownloadPath);
                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "File from " + _settings.DownloadAdress + "to " + _settings.DownloadPath +
                          " downloaded successfully."
                );
            }

            else if (e.Message.Text == "/command")
            {
                var commandanswer = BotEngine.Command(_settings.Command);

                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: commandanswer
                );
            }
            else if (e.Message.Text == "/check")
            {
                BotEngine.Check(_settings.CheckPath);
                string checkedanswer = BotEngine.Checked(BotEngine.Checkedstring);
                if (checkedanswer != null)
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: checkedanswer
                    );
                }
                else
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "No changes."
                    );
                }

                BotEngine.Checkedstring = null;
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