using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK_WebSiteDeveloperStudio.Enums;
using CMK_WebSiteDeveloperStudio.ViewModels;
using CMK_WebSiteDeveloperStudio.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class WindowManager
    {
        private readonly Core core;

        public WindowManager(Core core)
        {
            this.core = core;
        }

        public void CreateWindow(WindowEnum winEnum)
        {
            switch (winEnum)
            {
                case WindowEnum.StartWindow:
                    new StartWindow(new StartWindow_ViewModel(core)).Show();
                    break;
                case WindowEnum.ProjectView:
                    new ProjectViewer(new ProjectViewer_ViewModel(core)).Show();
                    break;
            }
        }
    }
}
