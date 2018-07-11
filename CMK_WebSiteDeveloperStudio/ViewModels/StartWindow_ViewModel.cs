using CMK.Services;
using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK_WebSiteDeveloperStudio.DTOs;
using CMK_WebSiteDeveloperStudio.Enums;
using CMK_WebSiteDeveloperStudio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class StartWindow_ViewModel : ViewModelBase
    {
        public string B1 { get; private set; }
        public string B2 { get; private set; }
        public string B3 { get; private set; }
        public string Label_Text { get; private set; }
        public string Label_Text2 { get; private set; }

        public List<Project> Projects { get; private set; }
        public Project SelectedProject
        {
            get;
            set;
        }

        public CommandMethodReflectionProvider com { get; }

        private Core core;

        public StartWindow_ViewModel(Core core)
        {
            this.core = core;
            B1 = core.GetTranslation(2);
            B2 = core.GetTranslation(3);
            B3 = core.GetTranslation(1);
            Label_Text = core.GetTranslation(4);
            Label_Text2 = core.GetTranslation(5);
            Projects = core.GetProjects();
            this.com = new CommandMethodReflectionProvider(this);
        }

        public void HandleLoadClick()
        {
            core.SelectedProject = SelectedProject;
            core.CreateWindow(WindowEnum.ProjectView);
        }

        public void HandleNewClick()
        {
            core.CreateProject("Test");
        }

        public void HandleSettingsClick()
        {
            MessageBox.Show("Test3");
        }
    }
}
