using CMK_WebSiteDeveloperStudio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.DTOs
{
    public class ColorScheme
    {
        public string Opener { get; set; }
        public string Closer { get; set; }
        public string Escaper { get; set; }
        public Color Color { get; set; }
        public Color ColorContent { get; set; }
        public int Layer { get; set; }
    }
}
