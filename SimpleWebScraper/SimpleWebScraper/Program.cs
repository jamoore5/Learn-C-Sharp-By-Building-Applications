using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;

namespace SimpleWebScraper
{
    class Program
    {
        private const string Method = "search";
        
        static void Main(string[] args)
        {
            ObituariesScraper.Execute();
        }
    }
}