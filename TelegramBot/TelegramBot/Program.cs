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
            _botClient = new TelegramBotClient("GIVE_ME_YOUR_STUPID_TOKEN_MORTY");
            _botClient.OnMessage += Bot_Commands;
            _botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
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
        }
    }
}