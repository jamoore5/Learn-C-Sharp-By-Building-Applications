using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimpleWebScraper.Data
{
    public class ComplexScrappedElement : ScrappedElement
    {
        private Dictionary<string, string> Value { get; set; }

        public ComplexScrappedElement()
        {
            this.Value = new Dictionary<string, string>();
        }

        public void AddPart(string name, string value)
        {
            this.Value.Add(name, value);
        }

        public bool HasParts()
        {
            return this.Value.Count > 0;
        }

        public List<string> PartNames()
        {
            var partNames = new List<string>();
            foreach (var partName in this.Value.Keys)
            {
                partNames.Add(partName);
            }

            return partNames;
        }

        public string GetPartValue(string partName)
        {
            bool isSuccess = this.Value.TryGetValue(partName, out var value);
            if (!isSuccess) throw new Exception("Invalid ScrappedCriteriaPart Name in ScrappedElement: {partName}");

            return value;
        }

        public bool HasPart(string partName)
        {
            return this.Value.ContainsKey(partName);
        }
    }
}