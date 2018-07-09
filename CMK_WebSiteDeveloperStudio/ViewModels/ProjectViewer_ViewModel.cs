using CMK.Services;
using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class ProjectViewer_ViewModel
    {
        public CommandMethodReflectionProvider com { get; }

        public string Title => core.GetTranslation(5);

        private Core core;

        public ProjectViewer_ViewModel(Core core)
        {
            this.core = core;
            this.com = new CommandMethodReflectionProvider(this);
        }
    }
}
