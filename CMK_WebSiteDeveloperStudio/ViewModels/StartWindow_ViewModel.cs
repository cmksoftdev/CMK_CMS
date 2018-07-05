using CMK.Services;
using CMK_WebSiteDeveloperStudio.Services;
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
        public string B1 { get; private set; }
        public string B2 { get; private set; }
        public string B3 { get; private set; }
        public string Label_Text { get; private set; }

        public CommandMethodReflectionProvider com { get; }

        private TranslationService translation;

        public StartWindow_ViewModel(TranslationService translation)
        {
            this.translation = translation;
            B1 = translation.Get(2);
            B2 = translation.Get(3);
            B3 = translation.Get(1);
            Label_Text = translation.Get(4);
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
