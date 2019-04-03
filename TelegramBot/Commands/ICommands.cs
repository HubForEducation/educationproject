using System;
using Telegram.Bot.Args;

namespace TelegramBot.Commands
{
    interface ICommands
    {
        string Logic(string paramString);
        void Api(object eventobject, MessageEventArgs eargs);
    }
}
