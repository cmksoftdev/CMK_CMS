using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMK_WebSiteDeveloperStudio.DTOs
{
    public class Language
    {
        public string Symbol { get; set; }

        [XmlArray]
        [XmlArrayItem(ElementName = "TL")]
        public List<string> Translations { get; set; }
    }
}
