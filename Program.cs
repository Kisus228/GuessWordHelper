using System;
using System.IO;
using CommandLine;

namespace GuessWordHelper
{
    internal static class Program
    {
        private static void Main()
        {
            var words = TxtReader.ReadTxt(Path.Combine("Dics", "custom.txt"));
            Console.WriteLine("Введите слово по шаблону: \"__п___а__\"\n");
            var consoleInput = string.Empty;
            while (true)
            {
                consoleInput = Console.ReadLine();
                if (consoleInput == string.Empty)
                {
                    break;
                }

                var args = consoleInput?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Parser.Default.ParseArguments<AddWordCommand, RemoveWordCommand, FindWordCommand>(args)
                    .WithParsed<AddWordCommand>(o => AddWordCommand.AddWord(o, words))
                    .WithParsed<RemoveWordCommand>(o => RemoveWordCommand.RemoveWord(o, words))
                    .WithParsed<FindWordCommand>(o => FindWordCommand.FindWords(o, words));
            }
        }
    }
}