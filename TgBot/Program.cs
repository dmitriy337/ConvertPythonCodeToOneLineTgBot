using System;
using System.IO;
using System.Collections.Generic;
using Telegram.Bot;


namespace TgBot
{
    class Program
    {
        public static TelegramBotClient botClient;

        public static Models.DbHelper dbHelper;

        public static Services.ConvertToOneLine convertToOneLine;

        static void Main(string[] args)
        {
            
            //Init
            botClient = new TelegramBotClient(Config.TelegramToken);
            dbHelper = new Models.DbHelper();
            convertToOneLine = new Services.ConvertToOneLine();
            //Register handlers
            Handlers.MessageHandler messageHandler = new Handlers.MessageHandler();
            Handlers.MessageEdited messageEdited = new Handlers.MessageEdited();
            Handlers.UpdateHandler updateHandler = new Handlers.UpdateHandler();

            botClient.OnMessage += messageHandler.Handler;

            botClient.StartReceiving();
            Console.WriteLine("Press enter to stop it!");
            Console.ReadLine();
        }
    }
}