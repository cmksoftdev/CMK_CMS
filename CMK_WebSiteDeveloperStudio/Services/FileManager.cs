using CMK_WebSiteDeveloperStudio.DTOs;
using CMK_WebSiteDeveloperStudio.Workers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class FileManager
    {
        Dictionary<ProjectFile, ProjectFileWorker> files;

        public FileManager(List<ProjectFile> files)
        {
            this.files = new Dictionary<ProjectFile, ProjectFileWorker>();
            foreach (var file in files)
            {
                Add(file);
            }
        }

        public void Add(ProjectFile file)
        {
            if(!files.Any(x => x.Key == file))
            {
                var worker = new ProjectFileWorker(file);
                files.Add(file, worker);
                worker.Create();
            }
        }

        public void Remove(ProjectFile file)
        {
            files.Remove(file);
            File.Delete(file.FilePath);
        }
    }
}
