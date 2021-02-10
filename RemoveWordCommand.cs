using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;

namespace GuessWordHelper
{
    [Verb("remove")]
    public class RemoveWordCommand
    {
        [Value(0)] public string WordToDelete { get; set; }

        public static void RemoveWord(RemoveWordCommand opts, HashSet<string> wordsDic)
        {
            if (!wordsDic.Contains(opts.WordToDelete))
            {
                Console.WriteLine("Такого слова нет в словаре");
                return;
            }

            wordsDic.Remove(opts.WordToDelete);
            File.WriteAllLines(Path.Combine("Dics", "custom.txt"), wordsDic);
            Console.WriteLine($"Слово \"{opts.WordToDelete}\" успешно удалено.");
        }
    }
}