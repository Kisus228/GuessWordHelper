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

        private static readonly Regex RegexForNumber = new Regex(@"\d+");
        private static readonly MatchEvaluator MatchEvaluator = ReplaceNumber;

        public static void FindWords(FindWordCommand opts, HashSet<string> wordsDic)
        {
            opts.WordToGuess = RegexForNumber.Replace(opts.WordToGuess, MatchEvaluator);
            opts.WordToGuess = @"\A" + opts.WordToGuess
                .Replace("_", @"(\w|-)")
                .ToLower() + @"\Z";
            var regex = new Regex(opts.WordToGuess);
            var matches = wordsDic
                .Where(word => regex.Match(word).Success)
                .ToHashSet();
            PrintHandler.PrintMatches(matches);
        }

        private static string ReplaceNumber(Match m)
        {
            return @"(\w|-){" + $"{m.Value}" + @"}";
        }
    }
}