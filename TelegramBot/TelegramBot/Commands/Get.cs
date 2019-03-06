using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot.Commands
{
    public class Get
    {
        private string _settingsGet { get; set; }
        private ITelegramBotClient BotClient { get; set; }

        public Get(string _settingsGet, ITelegramBotClient BotClient)
        {
            this._settingsGet = _settingsGet;
            this.BotClient = BotClient;
        }

        public string Logic(string get)
        {
            try
            {
                List<string> fileslist = new List<string>();

                Directory
                    .EnumerateFiles(get, "*")
                    .Select(Path.GetFileName)
                    .ToList()
                    .ForEach(f => fileslist.Add(f));

                var files = string.Join("\n", fileslist.ToArray());
                return files;
            }
            catch (DirectoryNotFoundException)
            {
                return "Directory " + get + "not found.";
            }
            catch (ArgumentNullException)
            {
                return "Directory " + get + " can not be NULL.";
            }
        }

        public async void Api(object sender, MessageEventArgs e)
        {

            if (e.Message.Text == "/get")
            {
                var files = Logic(_settingsGet);
                await BotClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: files
                );
            }
        }
    }
}