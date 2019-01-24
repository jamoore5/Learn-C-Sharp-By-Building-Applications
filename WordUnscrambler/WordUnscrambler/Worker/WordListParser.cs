using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WordUnscrambler.Worker
{
    public class WordListParser
    {
        public Dictionary<string, HashSet<string>> Parse(IEnumerable<string> words)
        {
            var wordList  = new Dictionary<string, HashSet<string>>();
            try
            {
                foreach (var word in words)
                {
                    var sortedWord = StringSorter.Sort(word);
                    var hasKey = wordList.TryGetValue(sortedWord, out var similarWords);
                    if (!hasKey)
                    {
                        similarWords = new HashSet<string> {word};
                        wordList.Add(sortedWord, similarWords);
                    }
                    else
                    {
                        similarWords.Add(word);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return wordList;
        }


    }
}