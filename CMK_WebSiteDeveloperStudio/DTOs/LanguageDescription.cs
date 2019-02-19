using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMK_WebSiteDeveloperStudio.DTOs
{
    [XmlRoot(ElementName = "LanguageDescription")]
    public class LanguageDescriptions
    {
        [XmlElement(ElementName = "ColorScheme")]
        public List<ColorScheme> LanguageDescription { get; set; }
    }
}
