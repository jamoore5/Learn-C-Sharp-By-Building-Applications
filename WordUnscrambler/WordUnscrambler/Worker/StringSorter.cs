using System;

namespace WordUnscrambler.Worker
{
    public class StringSorter
    {
        public static string Sort(string word)
        {
            var wordArray = word.ToCharArray();
            Array.Sort(wordArray);
            return new string(wordArray);
        }
    }
}