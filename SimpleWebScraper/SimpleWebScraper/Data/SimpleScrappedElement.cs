namespace SimpleWebScraper.Data
{
    public class SimpleScrappedElement : ScrappedElement
    {
        public string Value { get; set; }

        public SimpleScrappedElement(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}