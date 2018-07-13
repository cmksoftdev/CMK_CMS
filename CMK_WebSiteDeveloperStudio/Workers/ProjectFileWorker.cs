using CMK_WebSiteDeveloperStudio.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.Workers
{
    public class ProjectFileWorker
    {
        public ProjectFile FileInfos { get; }
        public bool UnsaveChanges { get; private set; }

        private string content;
        public string Content
        {
            get
            {
                if (String.IsNullOrEmpty(content))
                    content = GetFileAsString();
                return content;
            }
            set
            {
                content = value;
                UnsaveChanges = true;
            }
        }

        public ProjectFileWorker(ProjectFile FileInfos)
        {
            this.FileInfos = FileInfos;
        }

        public string GetFileAsString()
        {
            using (var fileStream = File.Open(FileInfos.FilePath, FileMode.Open))
            {
                using (var reader = new StreamReader(fileStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public void Save()
        {
            using (var fileStream = File.Open(FileInfos.FilePath, FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write(Content);
                }
            }
        }

        public void Create()
        {
            Save();
        }
    }
}
