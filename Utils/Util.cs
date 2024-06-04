using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceInfoViewer.Utils
{
    internal class Util
    {
        public static string UppercaseFirstChar(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            input = input.ToLower();

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        public static string CapitalizeEachWord(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = UppercaseFirstChar(words[i]);
            }

            return string.Join(' ', words);
        }
    }
}
