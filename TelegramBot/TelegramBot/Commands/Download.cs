using System;
using System.IO;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot.Commands
{
    class Download : ICommands
    {
        Settings settings = new Settings();
        private string DownloadAdress { get; set; }
        private ITelegramBotClient BotClient { get; set; }

        public Download(string downloadAdress, ITelegramBotClient botClient)
        {
            DownloadAdress = downloadAdress;
            BotClient = botClient;
        }

        public string Logic(string downloadAdress)
        {
            try
            {
                Random pictureseed = new Random();
                var client = new WebClient();
                client.DownloadFile(downloadAdress, settings.DownloadPath + "botpicture" + pictureseed.Next() + ".png");
                return "File from " + downloadAdress + " to " + settings.DownloadPath +
                       " downloaded successfully.";
            }
            catch (WebException)
            {
                return "File link " + downloadAdress + " is incorrect, or file in" + settings.DownloadPath + "can not be created.";
            }
            catch (DirectoryNotFoundException)
            {
                return "File from " + downloadAdress + " to " + settings.DownloadPath +
                       " not downloaded. Directory nor found.";
            }
            catch (ArgumentNullException)
            {
                return "File link is null.";
            }
        }

        public async void Api(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "/download")
            {
                var downloadmessage = Logic(DownloadAdress);
                await BotClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: downloadmessage
                );
            }

            if (e.Message.Text.StartsWith("/download"))
            {
                string downloadanswer;

                if (e.Message.Text.Length == 9)
                {
                    downloadanswer = Logic(DownloadAdress);
                }
                else
                {
                    var newmessage = e.Message.Text.Remove(0, 10);
                    downloadanswer = Logic(newmessage);
                }
                await BotClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: downloadanswer
                );
            }
        }
    }
}
