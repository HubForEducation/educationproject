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
        static readonly BotLogic BotLogic = new BotLogic();
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
            _botClient.OnMessage += BotCommands.GetCommands;

            _botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        public static void CheckUpdate()
        {
            while (true)
            {
                BotLogic.Check(_settings.CheckPath);
                string checkedanswer = BotLogic.Checked(BotLogic.Checkedstring);
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

                BotLogic.Checkedstring = null;
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
    }
}