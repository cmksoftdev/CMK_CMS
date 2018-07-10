using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.DTOs
{
    public class ProjectFile
    {
        public string FilePath { get; set; }
        public int FileType { get; set; }
        public long LastModified { get; set; }
    }
}
