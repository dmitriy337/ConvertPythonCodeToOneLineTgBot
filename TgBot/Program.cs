using System;
using Telegram.Bot;


namespace TgBot
{
    class Program
    {
        public static TelegramBotClient botClient;

        public static Models.DbHelper dbHelper;

        static void Main(string[] args)
        {
            botClient = new TelegramBotClient(Config.TelegramToken);
            dbHelper = new Models.DbHelper();

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