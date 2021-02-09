using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GuessWordHelper
{
    internal static class Program
    {
        private static void Main()
        {
            /*var words = DicReader.ReadDic(Path.Combine("Dics", "Russian.dic"), Path.Combine("Dics", "Russian.aff"));*/
            var words = TxtReader.ReadTxt(Path.Combine("Dics", "word_rus.txt"));
            Console.WriteLine("Введите слово по шаблону: \"__п___а__\"\n");
            var consoleInput = string.Empty;
            while (true)
            {
                consoleInput = Console.ReadLine();
                if (consoleInput == "stop")
                {
                    break;
                }

                PrintMatches(WordsFinder.FindWords(consoleInput, words));
            }
        }

        private static void PrintMatches(HashSet<string> matchingWords)
        {
            var strBuilder = new StringBuilder();
            var counter = 0;
            foreach (var word in matchingWords)
            {
                strBuilder.Append(word);
                strBuilder.Append(", ");
                counter++;
                if (counter != 10)
                {
                    continue;
                }

                strBuilder.Append("\n");
                counter = 0;
            }
            Console.WriteLine(strBuilder);
        }
    }
}