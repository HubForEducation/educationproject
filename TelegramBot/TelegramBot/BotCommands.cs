using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    

    public static class BotCommands
    {
        static ITelegramBotClient _botClient;
        static readonly BotLogic BotLogic = new BotLogic();
        static Settings _settings = new Settings();


        public static async void GetCommands(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "/get")
            {
                var files = BotLogic.Get(_settings.Get);
                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: files
                );
            }

            if (e.Message.Text.StartsWith("/get "))
            {
                var message = e.Message.Text.Substring(5);
                var files = BotLogic.Get(message);
                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: files
                );
            }

            else if (e.Message.Text == "/read")
            {
                var file = BotLogic.Read(_settings.Read);

                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: file
                );
            }

            else if (e.Message.Text == "/download")
            {
                var downloadmessage = BotLogic.Download(_settings.DownloadAdress, _settings.DownloadPath);
                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: downloadmessage
                );
            }

            else if (e.Message.Text == "/command")
            {
                var commandanswer = BotLogic.Command(_settings.Command);

                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: commandanswer
                );
            }
            else if (e.Message.Text == "/check")
            {
                BotLogic.Check(_settings.CheckPath);
                string checkedanswer = BotLogic.Checked(BotLogic.Checkedstring);
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

                BotLogic.Checkedstring = null;
            }
            else if (e.Message.Text == "/help")
            {
                var help = new Help();

                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: help.Show()
                );
            }
        }
    }
}
