using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK_WebSiteDeveloperStudio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
