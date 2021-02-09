using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GuessWordHelper
{
    public static class WordsFinder
    {
        public static HashSet<string> FindWords(string wordToGuess, HashSet<string> wordsDic)
        {
            var lettersCount = wordToGuess.Length;
            wordToGuess = wordToGuess.Replace("_", @"\w").ToLower();
            var regex = new Regex(wordToGuess);
            return wordsDic
                .Where(word => word.Length == lettersCount && regex.Match(word).Success)
                .ToHashSet();
        }
    }
}