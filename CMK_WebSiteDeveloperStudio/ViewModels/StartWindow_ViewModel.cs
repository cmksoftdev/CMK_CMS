using CMK.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class StartWindow_ViewModel
    {
        public CommandMethodReflectionProvider com { get; }

        public StartWindow_ViewModel()
        {
            this.com = new CommandMethodReflectionProvider(this);
        }

        public void HandleLoadClick()
        {
            MessageBox.Show("Test");
        }

        public void HandleNewClick()
        {
            MessageBox.Show("Test2");
        }
    }
}
