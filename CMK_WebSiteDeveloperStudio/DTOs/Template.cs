using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.DTOs
{
    public class Template
    {
        public string FileTemplate { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public List<PlaceHolder> PlaceHolders { get; set; }
    }
}
