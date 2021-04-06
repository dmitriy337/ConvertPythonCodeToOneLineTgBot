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
    class CommandHandler
    {
        public static TelegramBotClient botClient = TgBot.Program.botClient;
        public static Models.DbHelper dbHelper = TgBot.Program.dbHelper;

        public static void Handler(object sender, MessageEventArgs messageEventArgs)
        {
            switch (messageEventArgs.Message.Text.ToLower())
            {
                case ("/help"):
                case ("/start"): { 
                        botClient.SendTextMessageAsync(messageEventArgs.Message.Chat.Id,
                            "Hello, i'm the bot that converts your python code to oneline)\nMy GitRepos: [ConvertPythonCodeToOneLine](https://github.com/dmitriy337/ConvertPythonCodeToOneLineTgBot)",
                            disableWebPagePreview: true,
                            parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
                        Task.Delay(5).Wait();

                        botClient.SendTextMessageAsync(messageEventArgs.Message.Chat.Id,
                            "Send me your *.py* file❗",
                            disableWebPagePreview: true,
                            parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
                        if (dbHelper.CheckUserRegister(messageEventArgs)!=true) {dbHelper.RegisterUser(messageEventArgs);}
                        break;}

                default: {
                        botClient.SendTextMessageAsync( messageEventArgs.Message.Chat.Id, "Unknown command❗");
                        break;}
                    
            }


        }
    }

    enum Commands
    {

    }
}
