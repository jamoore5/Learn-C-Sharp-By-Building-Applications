using System.Text.RegularExpressions;
using SimpleWebScraper.Data;

namespace SimpleWebScraper.Builders
{
    public class ScrapeCriteriaPartBuilder
    {
        private string _name;
        private string _regex;
        private RegexOptions _regexOptions;

        public ScrapeCriteriaPartBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _regex = string.Empty;
            _regexOptions = RegexOptions.None;
        }
        
        public ScrapeCriteriaPartBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ScrapeCriteriaPartBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public ScrapeCriteriaPartBuilder WithRegexOption(RegexOptions regextOption)
        {
            _regexOptions = regextOption;
            return this;
        }

        public ScrapeCriteriaPart Build()
        {
            var scrapeCriteriaPart = new ScrapeCriteriaPart();
            scrapeCriteriaPart.Name = _name;
            scrapeCriteriaPart.Regex = _regex;
            scrapeCriteriaPart.RegexOption = _regexOptions;
            return scrapeCriteriaPart;
        }
    }
}