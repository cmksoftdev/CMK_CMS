using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.DTOs
{
    public class ProjectFile
    {
        public string FileExtension => Path.GetExtension(FilePath);
        public string FileName => Path.GetFileName(FilePath);
        public string FilePath { get; set; }
        public string Tags { get; set; } = "";
        public string[] TagCollection => Tags.Split(',');
        public int FileType { get; set; }
        public long LastModified { get; set; }
    }
}
