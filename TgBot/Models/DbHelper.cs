using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;

namespace TgBot.Models
{
    class DbHelper
    {
        public bool CheckUserRegister(MessageEventArgs messageEventArgs)
        {
            using (AppContext db = new AppContext())
            {
                var result = db.Users.FirstOrDefault(x => x.Id == messageEventArgs.Message.From.Id);
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void RegisterUser(MessageEventArgs messageEventArgs)
        {
            using (AppContext db = new AppContext())
            {
                try
                {
                    User usr = new User
                    {
                        Id = messageEventArgs.Message.From.Id,
                        Date = DateTime.UtcNow,
                        FirstName = messageEventArgs.Message.Chat.FirstName,
                        LastName = messageEventArgs.Message.Chat.LastName,
                        Username = messageEventArgs.Message.Chat.Username
                    };

                    db.Add(usr);
                    db.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Smth wrong!");
                }
            }
        }

        public void LogDocument(MessageEventArgs messageEventArgs, string documentGuid)
        {
            using (AppContext db = new AppContext())
            {
                try
                {
                    Document document = new Document
                    {
                        UserId = messageEventArgs.Message.Chat.Id,
                        Username = messageEventArgs.Message.Chat.Username,
                        Date = DateTime.UtcNow,
                        DocumentGuid = documentGuid
                    };
                        

                    db.Add(document);
                    db.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Smth wrong!");
                }
            }
        }

    }
}
