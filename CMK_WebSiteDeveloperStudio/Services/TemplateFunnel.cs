using CMK_WebSiteDeveloperStudio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class TemplateFunnel
    {
        Templates templates;

        public TemplateFunnel()
        {
            templates = XmlLoader.Load<Templates>("Templates.xml");
        }
    }
}
