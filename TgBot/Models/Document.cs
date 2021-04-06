using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgBot.Models
{
    public class Document
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Username { get; set; }

        public string DocumentGuid {get; set;}

        public DateTime Date { get; set; }
    }
}
