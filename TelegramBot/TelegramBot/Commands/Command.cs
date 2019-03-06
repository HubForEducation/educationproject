using System.Diagnostics;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot.Commands
{
    class Command
    {
        private string command { get; set; }
        private ITelegramBotClient BotClient { get; set; }

        public Command(string command, ITelegramBotClient BotClient)
        {
            this.command = command;
            this.BotClient = BotClient;
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
            if (e.Message.Text == "/command")
            {
                var commandanswer = Logic(command);

                await BotClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: commandanswer
                );
            }
        }
    }
}