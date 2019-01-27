using System.Text.RegularExpressions;

namespace SimpleWebScraper.Data
{
    public class ScrapeCriteriaPart
    {
        public string Name { get; set; }
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }
    }
}