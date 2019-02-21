using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMK_WebSiteDeveloperStudio.Configs
{
    public class Language
    {
        public string Name { get; set; }
        public string ConfigFile { get; set; }

        [XmlArray]
        [XmlArrayItem(ElementName = "Ext")]
        public List<string> FileExtensions { get; set; }

    }
}
