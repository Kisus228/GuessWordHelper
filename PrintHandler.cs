using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace GuessWordHelper
{
    public class PrintHandler
    {
        public static void PrintMatches(HashSet<string> matchingWords)
        {
            if (matchingWords.Count == 0)
            {
                Console.WriteLine("Подохдящие слова не были найдены.");
                return;
            }
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