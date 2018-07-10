using CMK_WebSiteDeveloperStudio.Configs;
using CMK_WebSiteDeveloperStudio.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class ProjectLoader
    {
        private List<Project> projects;
        private readonly string path;

        public ProjectLoader(Config config)
        {
            path = config.ProjectPath;
        }
        
        public List<Project> GetProjects()
        {
            loadProjects();
            return projects;
        }

        private void loadProjects()
        {
            projects = new List<Project>();
            var folders = Directory.GetDirectories(path);
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectConfig));
            foreach (var folder in folders)
            {
                var configFilePath = folder + "\\Project.xml";
                if (File.Exists(configFilePath))
                    using (var stream = File.Open(configFilePath, FileMode.Open))
                    {
                        projects.Add(new Project
                        {
                            Name = folder,
                            Config = serializer.Deserialize(stream) as ProjectConfig
                        });
                    }
            }
        }
    }
}
