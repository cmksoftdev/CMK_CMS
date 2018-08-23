using System.Web.Script.Serialization;
using System.IO;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class JsonLoader
    {
        public static T Load<T>(string filename)
        {
            var serializer = new JavaScriptSerializer();
            using (var stream = File.OpenText(filename))
            {
                return serializer.Deserialize<T>(stream.ReadToEnd());
            }
        }
    }
}
