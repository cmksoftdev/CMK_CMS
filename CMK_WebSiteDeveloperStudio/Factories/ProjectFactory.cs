using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK_WebSiteDeveloperStudio.Configs;
using CMK_WebSiteDeveloperStudio.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMK_WebSiteDeveloperStudio.Factories
{
    public class ProjectFactory
    {
        Core core;

        public ProjectFactory(Core core)
        {
            this.core = core;
        }

        public Project Create(string name)
        {
            var project = new Project
            {
                Name = $"{core.Config.ProjectPath}/{name}/",
                Config = new ProjectConfig
                {
                    ProjectType = 1,
                    ProjectFiles = new List<ProjectFile>()
                }
            };
            Directory.CreateDirectory(project.Name);
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectConfig));
            using (var s = new FileStream(project.Name + "Project.xml", FileMode.Create))
                using (var sw = new StreamWriter(s))
                    serializer.Serialize(sw, project);
            return project;
        }
    }
}
