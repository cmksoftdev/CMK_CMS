using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMK_WebSiteDeveloperStudio.Services;

namespace CMK_WebSiteDeveloperStudio.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sut = new TemplateFunnel();
            var temps = sut.GetFileTemplates();
            var temp = temps[1];
            var expected = "<!DOCTYPE html>\r\n<html lang=\"Test\">\r\n  <head>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title></title>\r\n  </head>\r\n  <body>\r\n  \r\n  </body>\r\n</html>";
            temp.PlaceHolders[0].Content = "Test";

            var content = sut.Fill(temp);

            Assert.AreEqual<string>(expected, content);
        }
    }
}
