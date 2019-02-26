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

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class ProjectManager
    {
        private Project project;
        private Core core;

        public ProjectManager(Core core)
        {
            this.core = core;
        }

        public void Set(Project project)
        {
            this.project = project;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectConfig));
            var configFilePath = project.Name + "\\Project.xml";
            if (File.Exists(configFilePath))
                using (var stream = File.Open(configFilePath, FileMode.Create))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        serializer.Serialize(writer, project.Config);
                    }
                }
        }

        public void Build()
        {
            var script = File.ReadAllText(project.Name + "\\Project.build");
            script = core.GetBuildScript(script);
            System.Diagnostics.Process.Start("cmd.exe", script);
        }
    }
}
