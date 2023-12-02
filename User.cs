using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ckopopehatonie
{
    public class User
    {
        public string UserName { get; set; }
        public int WordsPerMinute { get; set; }
        public int TypingErrors { get; set; }

        public User(string userName, int wordsPerMinute, int typingErrors)
        {
            UserName = userName;
            WordsPerMinute = wordsPerMinute;
            TypingErrors = typingErrors;
        }

        public override string ToString()
        {
            return $"Имя: {UserName}, Слов в минуту: {WordsPerMinute}, Ошибок: {TypingErrors}";
        }
    }
}