using CMK.Services;
using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK_WebSiteDeveloperStudio.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class Editor_ViewModel : ViewModelBase
    {
        Core core;
        
        public Editor_ViewModel(Core core)
        {
            this.core = core;
            this.com = new CommandMethodReflectionProvider(this);
        }

        ProjectFileWorker worker;

        public string B1
        {
            get
            {
                if (worker != null)
                    return worker.UnsaveChanges ? "Save *" : "Save";
                return "...";
            }
        }

        public string Text
        {
            get
            {
                return worker?.Content;
            }
            set
            {
                worker.Content = value;
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(B1));
            }
        }

        public ProjectFileWorker MyProperty
        {
            get
            {
                return worker;
            }
            set
            {
                worker = value;
                OnPropertyChanged(nameof(MyProperty));
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(B1));
            }
        }

        public void HandleSaveClick()
        {
            worker.Save();
            OnPropertyChanged(nameof(B1));
        }
    }
}
