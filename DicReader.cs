using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WeCantSpell.Hunspell;
using MyStemWrapper;

namespace GuessWordHelper
{
    public static class DicReader
    {
        private static readonly MyStem Stemmer = new MyStem {Parameters = "-i", PathToMyStem = Path.Combine("mystem-3.1-win-64bit", "MyStem.exe")};
        public static HashSet<string> ReadDic(string dicPath, string affPath)
        {
            var wordList = WordList.CreateFromFiles(dicPath, affPath);
            return wordList.RootWords.Where(IsNoun).ToHashSet();
        }

        private static bool IsNoun(string word)
        {
            var index = word.Length * 2 + 2;
            var analyse = Stemmer.Analysis(word);
            Console.Write(word[0]);
            return analyse[index] == 'S';
        }
    }
}