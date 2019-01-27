using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleWebScraper.Data
{
    public class ScrapeCriteria
    {
        public ScrapeCriteria()
        {
            Parts = new List<ScrapeCriteriaPart>();
        }
        
        public string Data { get; set; }
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }
        public List<ScrapeCriteriaPart> Parts { get; set; }
    }
}