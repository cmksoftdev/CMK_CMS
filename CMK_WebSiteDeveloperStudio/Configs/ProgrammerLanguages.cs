using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMK_WebSiteDeveloperStudio.Configs
{
    [XmlRoot(ElementName = "Languages")]
    public class ProgrammerLanguages
    {
        [XmlElement(ElementName = "Language")]
        public List<Language> Languages { get; set; }
    }
}
