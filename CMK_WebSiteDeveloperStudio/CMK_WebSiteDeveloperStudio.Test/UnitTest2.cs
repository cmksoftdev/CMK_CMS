using CMK_WebSiteDeveloperStudio.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace CMK_WebSiteDeveloperStudio.Test
{
    [TestClass]
    public class UnitTest2
    {

        public class T1
        {
            public string T2 { get; set; }
        }

        public class Test
        {
            public T1 T1 { get; set; }
        }

        public dynamic Convert(XElement x)
        {
            var dyn = new ExpandoObject() as IDictionary<string, Object>;
            dyn.Add(x.Name.LocalName,"");
            XNode next = x.NextNode;
            while (next != null)
            {
                //dyn[next.Document];
                next = x.NextNode;
            }
            return dyn;
        }

        public class Element
        {
            public string Key { get; set; }
            public object Value { get; set; }
        }

        public List<Element> Conv(XElement data)
        {
            List<Element> dataDictionary = new List<Element>();
            if (data.HasElements)
            {
                var e = new Element { Key = data.Name.LocalName, Value = new List<Element>() };
                dataDictionary.Add(e);
                foreach (var x in data.Elements())
                {
                    if (x.HasElements)
                        ((List<Element>)e.Value).AddRange(Conv(x));
                    else
                        ((List<Element>)e.Value).Add(new Element { Key = x.Name.LocalName, Value = x.Value });
                }
            }
            else
                dataDictionary.Add(new Element { Key = data.Name.LocalName, Value = data.Value });

            return dataDictionary;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var test1 = XmlLoader.Load<Test>("XMLFile1.xml");
            var test2 = XmlLoader.Load<XElement>("XMLFile1.xml");
            //var test3 = XmlLoader.Load<object[]>("XMLFile1.xml");
            var test4 = Conv(test2);
            var test5 = JsonLoader.Load<dynamic>("json1.json");
        }
    }
}
