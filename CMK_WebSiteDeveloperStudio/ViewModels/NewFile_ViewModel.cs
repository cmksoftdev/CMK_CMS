using CMK.Services;
using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK_WebSiteDeveloperStudio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class NewFile_ViewModel : ViewModelBase
    {
        Core core;

        public string Filename { get; set; }

        public NewFile_ViewModel(Core core)
        {
            this.core = core;
            this.com = new CommandMethodReflectionProvider(this);
        }

        public void HandleNewFileClick()
        {
        }
    }
}
