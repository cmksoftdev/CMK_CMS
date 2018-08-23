using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class XmlLoader
    {
        public class Element
        {
            public string Key { get; set; }
            public object Value { get; set; }
        }

        private static List<Element> convert(XElement data)
        {
            List<Element> dataDictionary = new List<Element>();
            if (data.HasElements)
            {
                var e = new Element { Key = data.Name.LocalName, Value = new List<Element>() };
                dataDictionary.Add(e);
                foreach (var x in data.Elements())
                {
                    if (x.HasElements)
                        ((List<Element>)e.Value).AddRange(convert(x));
                    else
                        ((List<Element>)e.Value).Add(new Element { Key = x.Name.LocalName, Value = x.Value });
                }
            }
            else
                dataDictionary.Add(new Element { Key = data.Name.LocalName, Value = data.Value });

            return dataDictionary;
        }

        public static List<Element> Load(string filename)
        {
            var x = Load<XElement>(filename);
            return convert(x);
        }

        public static T Load<T>(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var stream = File.Open(filename, FileMode.Open))
            {
               return (T)serializer.Deserialize(stream);
            }
        }
    }
}
