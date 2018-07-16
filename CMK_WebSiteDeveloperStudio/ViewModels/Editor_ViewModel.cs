using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK_WebSiteDeveloperStudio.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class Editor_ViewModel : ViewModelBase
    {
        Core core;

        public Editor_ViewModel(Core core)
        {
            this.core = core;
        }

        public ProjectFileWorker MyProperty
        {
            get;
            set;
        }
    }
}
