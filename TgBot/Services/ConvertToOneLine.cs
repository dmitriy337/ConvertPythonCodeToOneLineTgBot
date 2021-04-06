using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TgBot.Services
{
    class ConvertToOneLine
    {
        public string ConvertToSingleLine(string code)
        {
            string result = "exec(\"\"\"";

            code = code.Replace("\\", "\\\\")
                .Replace("\"\"\"", "\\\"\\\"\\\"");

            code = Regex.Replace(code, @"(\r\n|\r|\n)", "\\n");

            result = result + code  + "\"\"\")";

            return result;
        }

    }
}
