using System.Collections.Generic;
using System.Linq;
using WeCantSpell.Hunspell;

namespace GuessWordHelper
{
    public static class DicReader
    {
        public static HashSet<string> ReadDic(string dicPath, string affPath)
        {
            var wordList = WordList.CreateFromFiles(dicPath, affPath);
            return wordList.RootWords.ToHashSet();
        }
    }
}