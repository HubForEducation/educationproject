using System;
using System.IO;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot.Commands
{
    class Download
    {
        private string downloadAdress { get; set; }
        private string downloadPath { get; set; }
        private ITelegramBotClient BotClient { get; set; }

        public Download(string downloadAdress, string downloadPath, ITelegramBotClient botClient)
        {
            this.downloadAdress = downloadAdress;
            this.downloadPath = downloadPath;
            BotClient = botClient;
        }

        public string Logic(string downloadAdress, string downloadPath)
        {
            try
            {
                Random pictureseed = new Random();
                var client = new WebClient();
                client.DownloadFile(downloadAdress, downloadPath + "botpicture" + pictureseed.Next() + ".png");
                return "File from " + downloadAdress + " to " + downloadPath +
                       " downloaded successfully.";
            }
            catch (WebException)
            {
                return "File link " + downloadAdress + " is incorrect, or file in" + downloadPath + "can not be created.";
            }
            catch (DirectoryNotFoundException)
            {
                return "File from " + downloadAdress + " to " + downloadPath +
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
                var downloadmessage = Logic(downloadAdress, downloadPath);
                await BotClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: downloadmessage
                );
            }
        }
    }
}
