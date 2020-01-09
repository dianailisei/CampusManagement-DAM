using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UCM.Domain.Entities;

namespace UCM.Domain.TextConverters
{
    public class XmlConverter
    {
        public XDocument GetXML()
        {
            var xDocument = new XDocument();
            var xElement = new XElement("Articles");
            var article1 = Article.Create(new Admin(), "title1", "content", "img.jpg");
            var article2 = Article.Create(new Admin(), "title2", "content", "img.jpg");
            var article3 = Article.Create(new Admin(), "title3", "content", "img.jpg");
            var articles = new List<Article>() { article1, article2, article3 };

            var xAttributes = articles
                .Select(a => new XElement("Article",
                                    new XAttribute("Title", a.Title),
                                    new XAttribute("Content", a.Content),
                                    new XAttribute("Image", a.Image)));

            xElement.Add(xAttributes);
            xDocument.Add(xElement);

            Console.WriteLine(xDocument);

            return xDocument;
        }
    }
}
