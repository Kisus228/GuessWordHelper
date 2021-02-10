using System;
using System.IO;
using System.Linq;
using CommandLine;

namespace GuessWordHelper
{
    internal static class Program
    {
        private static readonly string[] Commands = {"add", "remove"};
        
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

                var args = Commands.Any(command => consoleInput != null && consoleInput.StartsWith(command))
                    ? consoleInput?.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)
                    : new[] {consoleInput};
                Parser.Default.ParseArguments<AddWordCommand, RemoveWordCommand, FindWordCommand>(args)
                    .WithParsed<AddWordCommand>(o => AddWordCommand.AddWord(o, words))
                    .WithParsed<RemoveWordCommand>(o => RemoveWordCommand.RemoveWord(o, words))
                    .WithParsed<FindWordCommand>(o => FindWordCommand.FindWords(o, words));
            }
        }
    }
}