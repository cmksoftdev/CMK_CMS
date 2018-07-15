using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class XmlLoader
    {
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
