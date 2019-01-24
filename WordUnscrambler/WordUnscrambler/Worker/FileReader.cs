using System;
using System.Collections.Generic;
using System.IO;

namespace WordUnscrambler.Worker
{
    public class FileReader
    {
        public string[] Read(string filename)
        {
            List<string> fileContent  = new List<string>();
            try
            {
                foreach (var word in File.ReadLines(filename))
                {
                    fileContent.Add(word.Trim());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return fileContent.ToArray();
        }
        
        public Dictionary<string, HashSet<string>> ParseWordList(string filename)
        {
            WordListParser parser = new WordListParser();
            return parser.Parse(File.ReadLines(filename));
        }
    }
    
    
}