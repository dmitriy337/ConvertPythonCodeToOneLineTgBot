using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Helpers;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace TgBot.Handlers
{
    class MessageHandler
    {
        public TelegramBotClient botClient = TgBot.Program.botClient;
        public static Models.DbHelper dbHelper = TgBot.Program.dbHelper;
        private Services.WorkWithDocuments workWithDocuments = new Services.WorkWithDocuments();
        private Services.ConvertToOneLine ConvertToOneLine = new Services.ConvertToOneLine();

        public void Handler(object sender, MessageEventArgs messageEventArgs) {
            if (messageEventArgs.Message.Text != null) {

                if (messageEventArgs.Message.Text.StartsWith('/'))
                {
                    CommandHandler.Handler(sender, messageEventArgs); return;
                }
                else
                {
                    botClient.SendTextMessageAsync(messageEventArgs.Message.Chat.Id, "Send me your file");
                }
            }

            if (messageEventArgs.Message.Document != null)
            {
                if (messageEventArgs.Message.Document.FileName.EndsWith(".py"))
                {
                    string StringFromFile = workWithDocuments.DowloadFile(messageEventArgs);
                    string StringFromFileConverteredToOneLine = ConvertToOneLine.ConvertToSingleLine(StringFromFile);

                    var UploadedFile = workWithDocuments.UploadStringAsFile(StringFromFileConverteredToOneLine, "OneLine_" + messageEventArgs.Message.Document.FileName);



                    //TODO Send document and catch exceptions
                    botClient.SendDocumentAsync(messageEventArgs.Message.Chat.Id,
                        UploadedFile
                        );


                    new Task(() => dbHelper.LogDocument(messageEventArgs, UploadedFile.FileName)).Start();
                }
                else
                {
                    botClient.SendTextMessageAsync(messageEventArgs.Message.Chat.Id,
                        "It is *not* .py file.\nSend my *.py* file!",
                        parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
                }
            }

            //"OneLine_" + messageEventArgs.Message.Document.FileName



        }


    }
}
