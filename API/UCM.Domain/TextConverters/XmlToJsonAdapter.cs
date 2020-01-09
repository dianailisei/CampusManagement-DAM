using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UCM.Domain.Entities;

namespace UCM.Domain.TextConverters
{
    public class XmlToJsonAdapter : IXmlToJson
    {
        private readonly XmlConverter _xmlConverter;

        public XmlToJsonAdapter(XmlConverter xmlConverter)
        {
            _xmlConverter = xmlConverter;
        }

        public void ConvertXmlToJson()
        {
            var articles = _xmlConverter.GetXML()
                    .Element("Articles")
                    .Elements("Article")
                    .Select(a =>
                    Article.Create(
                        new Admin(),
                        a.Attribute("Title").Value,
                        a.Attribute("Content").Value,
                        a.Attribute("Image").Value)
                    );

            new JsonConverter(articles)
                .ConvertToJson();
        }
    }
}
