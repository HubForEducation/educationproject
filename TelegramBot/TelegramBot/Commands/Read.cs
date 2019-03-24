using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;


namespace TelegramBot.Commands
{
    class Read : ICommands
    {
        private string SettingsRead { get; set; }
        private ITelegramBotClient BotClient { get; set; }

        public Read(string settingsRead, ITelegramBotClient botClient)
        {
            SettingsRead = settingsRead;
            BotClient = botClient;
        }

        public string Logic(string read)
        {
 
            string fileText;
            try
            {
                fileText = File.ReadAllText(SettingsRead);
                return fileText;
            }
            catch (DirectoryNotFoundException)
            {
                return "File " + SettingsRead + " not found.";
            }
        }

        public async void Api(object sender, MessageEventArgs e)
        {

            if (e.Message.Text == "/read")
            {
                var file = Logic(SettingsRead);

            await BotClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: file

            );
            }
        }
}
}
