using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CommandLine;

namespace GuessWordHelper
{
    [Verb("find", true)]
    public class FindWordCommand
    {
        [Value(0)] public string WordToGuess { get; set; }

        public static void FindWords(FindWordCommand opts, HashSet<string> wordsDic)
        {
            var lettersCount = opts.WordToGuess.Length;
            opts.WordToGuess = opts.WordToGuess.Replace("_", @"\w").ToLower();
            var regex = new Regex(opts.WordToGuess);
            var matches = wordsDic
                .Where(word => word.Length == lettersCount && regex.Match(word).Success)
                .ToHashSet();
            PrintHandler.PrintMatches(matches);
        }
    }
}