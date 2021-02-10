using System;
using System.Collections.Generic;
using System.Text;

namespace GuessWordHelper
{
    public static class PrintHandler
    {
        public static void PrintMatches(HashSet<string> matchingWords)
        {
            if (matchingWords.Count == 0)
            {
                Console.WriteLine("Подходящие слова не были найдены.");
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