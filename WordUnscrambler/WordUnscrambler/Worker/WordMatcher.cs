using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using WordUnscrambler.Data;

namespace WordUnscrambler.Worker
{
    public class WordMatcher
    {

        public List<MatchedWord> Match(string[] scrambledWords, Dictionary<string, HashSet<string>> wordList)
        {
            var matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords)
            {
                var sortedScrambledWord = StringSorter.Sort(scrambledWord);

                var hasMatches = wordList.TryGetValue(sortedScrambledWord, out var matches);
                if (!hasMatches) continue;
                foreach (var word in matches)
                {
                    matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                }
            }

            return matchedWords;
        }

        private static MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            var matchedWord = new MatchedWord
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchedWord;
        }
    }
}