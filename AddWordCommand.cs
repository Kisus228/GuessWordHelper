using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;

namespace GuessWordHelper
{
    [Verb("add")]
    public class AddWordCommand
    {
        [Value(0)] public string WordToAdd { get; set; }

        public static void AddWord(AddWordCommand opts, HashSet<string> wordsDic)
        {
            wordsDic.Add(opts.WordToAdd);
            File.WriteAllLines(Path.Combine("Dics", "custom.txt"), wordsDic);
            Console.WriteLine($"Слово \"{opts.WordToAdd}\" успешно добавлено.");
        }
    }
}