using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.Data;
using WordUnscrambler.Worker;

namespace WorkUnscramber.Test.Unit
{
    [TestClass]
    public class WordMatcherTest
    {
        private readonly WordMatcher _wordMatcher = new WordMatcher();
        private readonly WordListParser _wordListParser = new WordListParser();
        
        [TestMethod]
        public void ScrambledWordMatchesGiveWordInList()
        {
            string[] words = {"cat", "chair", "more"};
            var worldList = _wordListParser.Parse(words);
            string[] scrambledWords = {"omre"};
            var matchedWords = _wordMatcher.Match(scrambledWords, worldList);
            
            Assert.IsTrue(matchedWords.Count == 1);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));
        }
        
        [TestMethod]
        public void ScrambledWordMatchesGiveWordsInList()
        {
            string[] words = {"cat", "chair", "more"};
            var worldList = _wordListParser.Parse(words);
            string[] scrambledWords = {"omre", "act"};
            var matchedWords = _wordMatcher.Match(scrambledWords, worldList);
            
            Assert.IsTrue(matchedWords.Count == 2);
            Assert.IsTrue(matchedWords.Contains(new MatchedWord {ScrambledWord = "omre", Word = "more"}));
            Assert.IsTrue(matchedWords.Contains(new MatchedWord {ScrambledWord = "act", Word = "cat"}));
        }
    }
}