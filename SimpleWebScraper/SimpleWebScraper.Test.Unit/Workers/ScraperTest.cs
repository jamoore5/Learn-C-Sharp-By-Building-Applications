using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;

namespace SimpleWebScraper.Test.Unit.Workers
{
    [TestClass]
    public class ScraperTest
    {
        private readonly Scraper _scraper = new Scraper();
        
        [TestMethod]
        public void FindCollectionWithNoParts()
        {
            var content =
                "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text></a> more fluff data";
            ScrapeCriteria scrapeCriteria =  new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                .WithRegexOption(RegexOptions.ExplicitCapture)
                .Build();

            var foundElements = _scraper.Scrape(scrapeCriteria);
            Assert.IsTrue(foundElements.Count == 1);
            Assert.IsTrue(foundElements[0].GetType() == typeof(SimpleScrappedElement));
            var scrappedElement = foundElements[0] as SimpleScrappedElement;
            Assert.AreEqual(scrappedElement.Value, "<a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text></a>");
        }
        
        [TestMethod]
        public void FindCollectionWithTwoParts()
        {
            var content =
                "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> more fluff data";
            
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

            var foundElements = _scraper.Scrape(scrapeCriteria);
            Assert.IsTrue(foundElements.Count == 1);
            Assert.IsTrue(foundElements[0].GetType() == typeof(ComplexScrappedElement));
            var scrappedElement = foundElements[0] as ComplexScrappedElement;
            Assert.IsTrue(scrappedElement.HasPart("Link"));
            Assert.AreEqual(scrappedElement.GetPartValue("Link"), "http://domain.com");
            Assert.IsTrue(scrappedElement.HasPart("Description"));
            Assert.AreEqual(scrappedElement.GetPartValue("Description"), "some text");
    }
    }
}