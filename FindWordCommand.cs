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

        private static readonly Regex RegexPattern = new Regex(@"(?<count>\d+)_");

        public static void FindWords(FindWordCommand opts, HashSet<string> wordsDic)
        {
            foreach (Match match in RegexPattern.Matches(opts.WordToGuess))
            {
                opts.WordToGuess =
                    opts.WordToGuess.Replace(match.Value, @"(\w|-){" + $"{match.Groups["count"].Value}" + @"}");
            }
            opts.WordToGuess = @"\A" + opts.WordToGuess
                .Replace("_", @"(\w|-)")
                .ToLower() + @"\Z";
            var regex = new Regex(opts.WordToGuess);
            var matches = wordsDic
                .Where(word => regex.Match(word).Success)
                .ToHashSet();
            PrintHandler.PrintMatches(matches);
        }
    }
}