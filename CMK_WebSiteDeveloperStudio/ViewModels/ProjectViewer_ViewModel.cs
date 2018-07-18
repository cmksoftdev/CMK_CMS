using CMK.Services;
using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK_WebSiteDeveloperStudio.DTOs;
using CMK_WebSiteDeveloperStudio.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class ProjectViewer_ViewModel : ViewModelBase
    {
        float columnWidth;
        public float ColumWidth
        {
            get
            {
                return columnWidth;
            }
            set
            {
                columnWidth = value - 30f;
                ColumWidthThird = (columnWidth) / 3f;
            }
        }
        float columnWidthThird;
        public float ColumWidthThird
        {
            get
            {
                return columnWidthThird;
            }
            set
            {
                columnWidthThird = value;
                OnPropertyChanged(nameof(ColumWidthThird));
                OnPropertyChanged(nameof(ColumWidthTwoThird));
                OnPropertyChanged(nameof(ColumWidthSixth));
            }
        }

        public float ColumWidthTwoThird
        {
            get
            {
                return ColumWidth / 2f;
            }
        }

        public float ColumWidthSixth
        {
            get
            {
                return ColumWidth / 4f;
            }
        }

        public ProjectFile SelectedProjectFile
        {
            get;
            set;
        }

        public ObservableCollection<ProjectFile> ProjectFiles
        {
            get
            {
                ObservableCollection<ProjectFile> collection = new ObservableCollection<ProjectFile>();
                foreach(var file in core.SelectedProject.Config.ProjectFiles)
                {
                    collection.Add(file);
                }
                return collection;
            }
        }

        public string Title => $"{core.GetTranslation(8)}: {core.SelectedProject.Name}";
        public string B1 => core.GetTranslation(9);
        public string B2 => core.GetTranslation(10);
        public string B3 => core.GetTranslation(11);
        public string B4 => core.GetTranslation(12);
        public string B5 => core.GetTranslation(13);
        public string B6 => core.GetTranslation(14);
        public string L1 => core.GetTranslation(15);
        public string L2 => core.GetTranslation(16);
        public string L3 => core.GetTranslation(17);

        private Core core;

        public ProjectViewer_ViewModel(Core core)
        {
            this.core = core;
            this.com = new CommandMethodReflectionProvider(this);
            columnWidth = 500f;
            ColumWidthThird = ColumWidth / 3f - 2f;
        }

        public void HandleNewFileClick()
        {
            if (core.CreateWindowDialog(WindowEnum.NewFile) != null)
            {
                OnPropertyChanged(nameof(ProjectFiles));
            }
        }

        public void HandleOpenFileClick()
        {
            var window = core.GetEditorForFile(SelectedProjectFile);
            if (!window.IsVisible)
                window.Show();
            else
                window.Focus();
        }

        public void HandleDeleteFileClick()
        {
            if (SelectedProjectFile != null)
            {
                core.DeleteFile(SelectedProjectFile);
                SelectedProjectFile = null;
                OnPropertyChanged(nameof(ProjectFiles));
            }
        }
    }
}
