using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;

namespace GuessWordHelper
{
    [Verb("д")]
    public class AddWordCommand
    {
        [Value(0)] public string WordToAdd { get; set; }

        public static void AddWord(AddWordCommand opts, HashSet<string> wordsDic)
        {
            if (wordsDic.Contains(opts.WordToAdd))
            {
                Console.WriteLine($"Слово \"{opts.WordToAdd}\" уже существует.");
                return;
            }
            wordsDic.Add(opts.WordToAdd);
            File.WriteAllLines(Path.Combine("Dics", "custom.txt"), wordsDic);
            Console.WriteLine($"Слово \"{opts.WordToAdd}\" успешно добавлено.");
        }
    }
}