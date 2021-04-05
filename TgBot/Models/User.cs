using System;
using System.Collections.Generic;
using System.Text;


namespace TgBot.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }

    }
}