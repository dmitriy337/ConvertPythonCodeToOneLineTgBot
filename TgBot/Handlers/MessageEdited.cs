using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Helpers;
using Telegram.Bot.Types;

namespace TgBot.Handlers
{
    class MessageEdited
    {
        public TelegramBotClient botClient = TgBot.Program.botClient;
        public static Models.DbHelper dbHelper = TgBot.Program.dbHelper;

        public void Handler(object sender, MessageEventArgs messageEventArgs)
        {
            if (messageEventArgs.Message.Text.StartsWith("/")) { CommandHandler.Handler(sender, messageEventArgs); }


        }
    }
}
