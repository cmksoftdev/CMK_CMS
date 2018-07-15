using CMK_WebSiteDeveloperStudio.Configs;
using CMK_WebSiteDeveloperStudio.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class TemplateFunnel
    {
        TemplateConfig templates;

        public TemplateFunnel()
        {
            templates = XmlLoader.Load<TemplateConfig>("Templates.xml");
        }

        public List<Template> GetFileTemplates()
        {
            return templates.Templates.FindAll(x => x.FileTemplate == "1");
        }

        public List<Template> GetCodeTemplates()
        {
            return templates.Templates.FindAll(x => x.FileTemplate == "2");
        }

        public string Fill(Template template)
        {
            using (var reader = File.OpenText(template.FilePath))
            {
                var content = reader.ReadToEnd();
                foreach (var placeholder in template.PlaceHolders)
                {
                    content.Replace(placeholder.Symbol, placeholder.Content);
                }
                return content;
            }
        }
    }
}
