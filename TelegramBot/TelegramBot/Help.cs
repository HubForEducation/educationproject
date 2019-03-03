using System;
using System.Collections.Generic;
using System.Text;
using Com.CloudRail.SI.ServiceCode.Commands;

namespace TelegramBot
{
    class Help
    {
        public string Show()
        {
            return
                "/help - Commands list.\n" +
                "/get - Get file from directory in settings.\n" +
                "/read - Read file from settings.\n" +
                "/download - Download file from settings.\n" +
                "/check - Force update directory status from settings.\n";
        }
    }
}
