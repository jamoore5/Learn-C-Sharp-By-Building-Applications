using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;

namespace SimpleWebScraper.Workers
{
    public static class CraigslistScraper
    {
        private const string Method = "search";
        
        public static void Execute()
        {
            try
            {
                Console.WriteLine("Please enter which city you would like to scrape information from: ");
                var craigslistCity = Console.ReadLine() ?? string.Empty;

                Console.WriteLine(
                    "Please enter the CraigsList category that you would like to scrape information from:");
                var craigslistCategory = Console.ReadLine() ?? string.Empty;

                List<ScrappedElement> scrappedElements = Scrape(craigslistCity, craigslistCategory);

                DisplayScrappedElements(scrappedElements);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured: {0}", ex.Message);
            }
        }

        private static List<ScrappedElement> Scrape(string city, string category)
        {
            string content;
            using (var client = new WebClient())
            {
                content = client.DownloadString(
                    $"http://{city.Replace(" ", string.Empty)}.craigslist.org/{Method}/{category}");
            }

            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                .WithRegexOption(RegexOptions.ExplicitCapture)
                .WithPart(new ScrapeCriteriaPartBuilder()
                    .WithName("Description")
                    .WithRegex(@">(.*?)</a>")
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .WithPart(new ScrapeCriteriaPartBuilder()
                    .WithName("Link")
                    .WithRegex(@"href=\""(.*?)\""")
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .Build();

            var scraper = new Scraper();
            return scraper.Scrape(scrapeCriteria);
        }

        private static void DisplayScrappedElements(List<ScrappedElement> elements)
        {
            foreach (var element in elements)
            {
                var complexElemet = element as ComplexScrappedElement;
                var link = complexElemet.GetPartValue("Link");
                var description = complexElemet.GetPartValue("Description");
                Console.WriteLine("{0} ({1})", description, link);
            }
            
        }
    }
}