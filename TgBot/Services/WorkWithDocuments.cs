using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace TgBot.Services
{
    class WorkWithDocuments
    {
        public TelegramBotClient botClient = TgBot.Program.botClient;

        public string DowloadFile(MessageEventArgs messageEventArgs)
        {
            string result;
            string DirectoryToDownload = Directory.GetCurrentDirectory() + "/Files/";
            if (Directory.Exists(DirectoryToDownload) != true)
            {
                Directory.CreateDirectory(DirectoryToDownload);
            }
            var file = botClient.GetFileAsync(messageEventArgs.Message.Document.FileId);
            
            var download_url = $"https://api.telegram.org/file/bot{Config.TelegramToken}/" + file.Result.FilePath;
            try
            {
                using (WebClient client = new WebClient())
                {
                    result = client.DownloadString(new Uri(download_url));
                }
            }
            catch
            {
                Console.WriteLine("Url not found");
                result = null;
            }
            return result;
        }

        public InputOnlineFile UploadStringAsFile(string str, string DocumentName)
        {
            InputOnlineFile inputOnlineFile;
            string g = Guid.NewGuid().ToString();

            //CreateFileAndDirectory
            string DirectoryToDownload = Directory.GetCurrentDirectory() + "/ConverteredFiles/";
            if (Directory.Exists(DirectoryToDownload) != true)
            {
                Directory.CreateDirectory(DirectoryToDownload);
            }
            
            //Write to file
            using (StreamWriter sr = System.IO.File.CreateText(DirectoryToDownload + g + ".py"))
            {
                sr.Write(str);
                sr.Flush();
            }

            //UploadFile
            using (var stream = System.IO.File.Open(DirectoryToDownload + g + ".py", FileMode.Open))
            {
                inputOnlineFile = new InputOnlineFile(stream);
                inputOnlineFile.FileName = g + ".py";    
            }

            return inputOnlineFile;
        }
    }
}
