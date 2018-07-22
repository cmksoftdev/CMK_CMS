using CMK_WebSiteDeveloperStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CMK_WebSiteDeveloperStudio.Views
{
    /// <summary>
    /// Interaktionslogik für CodeTemplate.xaml
    /// </summary>
    public partial class CodeTemplate : Window
    {
        public CodeTemplate(CodeTemplate_ViewModel vm)
        {
            vm.CloseAction = () =>
            {
                this.Close();
            };
            DataContext = vm;
            InitializeComponent();
        }
    }
}
