using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK_WebSiteDeveloperStudio.Enums;
using CMK_WebSiteDeveloperStudio.ViewModels;
using CMK_WebSiteDeveloperStudio.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CMK_WebSiteDeveloperStudio.Factories
{
    public class WindowFactory
    {
        private readonly Core core;
        private List<object> viewModels;

        public WindowFactory(Core core)
        {
            this.core = core;
            viewModels = new List<object>();
        }

        public Window CreateWindow(WindowEnum winEnum)
        {
            object vm;
            switch (winEnum)
            {
                case WindowEnum.StartWindow:
                    vm = viewModels.FirstOrDefault<object>(x => x.GetType() == typeof(StartWindow_ViewModel));
                    if (vm == null)
                    {
                        vm = new StartWindow_ViewModel(core);
                        viewModels.Add(vm);
                    }
                    return new StartWindow(vm as StartWindow_ViewModel);
                case WindowEnum.ProjectView:
                    vm = viewModels.FirstOrDefault<object>(x => x.GetType() == typeof(ProjectViewer_ViewModel));
                    if (vm == null)
                    {
                        vm = new ProjectViewer_ViewModel(core);
                        viewModels.Add(vm);
                    }
                    return new ProjectViewer(vm as ProjectViewer_ViewModel);
                case WindowEnum.NewFile:
                    vm = viewModels.FirstOrDefault<object>(x => x.GetType() == typeof(NewFile_ViewModel));
                    if (vm == null)
                    {
                        vm = new NewFile_ViewModel(core);
                        viewModels.Add(vm);
                    }
                    return new NewFile(vm as NewFile_ViewModel);
                default:
                    return null;
            }            
        }
    }
}
