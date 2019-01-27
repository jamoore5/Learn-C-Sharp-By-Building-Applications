using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SimpleWebScraper.Data;

namespace SimpleWebScraper.Workers
{
    public class Scraper
    {
        public List<ScrappedElement> Scrape(ScrapeCriteria scrapeCriteria)
        {
            var scrappedElements = new List<ScrappedElement>();

            MatchCollection matches =
                Regex.Matches(scrapeCriteria.Data, scrapeCriteria.Regex, scrapeCriteria.RegexOption);

            foreach (Match match in matches)
            {
                if (!scrapeCriteria.Parts.Any())
                {
                    var simpleElement = new SimpleScrappedElement(match.Groups[0].Value);
                    scrappedElements.Add(simpleElement);
                }
                else
                {
                    var complexElement = new ComplexScrappedElement();
                    foreach (var part in scrapeCriteria.Parts)
                    {
                        Match matchedPart = Regex.Match(match.Groups[0].Value, part.Regex, part.RegexOption);
                        if (matchedPart.Success) complexElement.AddPart(part.Name, matchedPart.Groups[1].Value);  
                    }

                    if (complexElement.HasParts()) scrappedElements.Add(complexElement);
                }
            }

            return scrappedElements;
        }
    }
}