using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CMK_WebSiteDeveloperStudio.DTOs
{
    public class ColoredCode
    {
        public int Line { get; set; }
        public int Shift { get; set; }
        public string Word { get; set; }
        public SolidColorBrush ColorBrush { get; set; }
    }
}
