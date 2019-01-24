using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.Worker;

namespace WorkUnscramber.Test.Unit
{
    [TestClass]
    public class WordListParserTest
    {  
        private readonly WordListParser _wordListParser = new WordListParser();
        
        [TestMethod]
        public void PraseWordsIntoDictionary()
        {
            var words = new string[] { "rome", "cat", "more", "act", "there", "here", "hey"};
            var dictionary = _wordListParser.Parse(words);

            bool hasKey;
            HashSet<string> value;
            
            hasKey = dictionary.TryGetValue("emor", out value);
            Assert.IsTrue(hasKey);
            Assert.IsTrue(value.Contains("rome"));
            Assert.IsTrue(value.Contains("more"));
            
            hasKey = dictionary.TryGetValue("act", out value);
            Assert.IsTrue(hasKey);
            Assert.IsTrue(value.Contains("act"));
            Assert.IsTrue(value.Contains("cat"));
            
            hasKey = dictionary.TryGetValue("eehrt", out value);
            Assert.IsTrue(hasKey);
            Assert.IsTrue(value.Contains("there"));
            
            hasKey = dictionary.TryGetValue("eehr", out value);
            Assert.IsTrue(hasKey);
            Assert.IsTrue(value.Contains("here"));
            
            hasKey = dictionary.TryGetValue("ehy", out value);
            Assert.IsTrue(hasKey);
            Assert.IsTrue(value.Contains("hey"));
        }
    }
}