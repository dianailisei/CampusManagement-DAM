using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UCM.Domain.Entities;

namespace UCM.Domain.TextConverters
{
    public class JsonConverter
    {
        private IEnumerable<Article> _articles;

        public JsonConverter(IEnumerable<Article> articles)
        {
            _articles = articles;
        }

        public void ConvertToJson()
        {
            var jsonArticles = JsonConvert.SerializeObject(_articles, Formatting.Indented);

            Console.WriteLine("\nPrinting JSON list\n");
            Console.WriteLine(jsonArticles);
        }
    }
}
