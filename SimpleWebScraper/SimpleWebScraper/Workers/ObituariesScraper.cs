using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;

namespace SimpleWebScraper.Workers
{
    public class ObituariesScraper
    {
        private const string _carletonfuneralhome_url = "http://www.carletonfuneralhome.ca/obituaries";
        public static void Execute()
        {
            ScrapCarletonFuneralHomeObituaries();
        }

        private static void ScrapCarletonFuneralHomeObituaries()
        {
            string content = string.Empty;
            using (var client = new WebClient())
            {
                content = client.DownloadString(
                    $"{_carletonfuneralhome_url}").Replace("\n", "  ");
                
            }
            
            ScrapeCriteria tableCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<table class=\""obitList\"">(.*?)</table>")
                .WithRegexOption(RegexOptions.ExplicitCapture)
                .Build();
            
            var scraper = new Scraper();
            SimpleScrappedElement table = scraper.Scrape(tableCriteria)[0] as SimpleScrappedElement;
            
            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<td class=\""name\"">\s*<a href=\""(.*?)\)\""><!---->(.*?)<\/a><\/td>\s*<td class=\""dod\"">(.*?)<\/td>")
                .WithRegexOption(RegexOptions.ExplicitCapture)
                .WithPart(new ScrapeCriteriaPartBuilder()
                    .WithName("Name")
                    .WithRegex(@"<!---->(.*?)<\/a>")
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .WithPart(new ScrapeCriteriaPartBuilder()
                    .WithName("Dod")
                    .WithRegex(@"\""dod\"">(.*?)<\/td>")
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .Build();

            List<ScrappedElement> obituaries = scraper.Scrape(scrapeCriteria);

            foreach (var obituary in obituaries)
            {
                var element = obituary as ComplexScrappedElement;
                Console.WriteLine("{0} (Date of Death {1})", element.GetPartValue("Name").Trim(), element.GetPartValue("Dod"));
            }
            
        }
    }
}