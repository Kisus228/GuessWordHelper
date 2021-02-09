using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GuessWordHelper
{
    public static class TxtReader
    {
        public static HashSet<string> ReadTxt(string pathToTxt)
        {
            var words = File.ReadLines(pathToTxt);
            return words
                .ToHashSet();
        }
    }
}