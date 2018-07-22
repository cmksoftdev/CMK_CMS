using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using System.Windows.Controls;
using CMK_WebSiteDeveloperStudio.Workers;
using CMK_WebSiteDeveloperStudio.Services;
using CMK_WebSiteDeveloperStudio.Views;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class AdvancedEditor_ViewModel : Editor_ViewModel
    {
        Canvas canvas;

        public TextBox TextBox { get; set; }

        public Canvas Canvas
        {
            get
            {
                return canvas;
            }
            set
            {
                canvas = value;
                RenderText();
            }
        }

        public AdvancedEditor_ViewModel(Core core) : base(core)
        {
        }

        public void RenderText() 
        {
            CanvasKannWas.Render(canvas, Text);
        }

        public new string Text
        {
            get
            {
                return worker?.Content;
            }
            set
            {
                var test = TextBox?.SelectionStart;
                worker.Content = value;
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(B1));
                RenderText();
            }
        }

        public new ProjectFileWorker MyProperty
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
                RenderText();
            }
        }
        public void HandleInsertTemplateClick()
        {
            var vm = new CodeTemplate_ViewModel(core);
            vm.ReturnFunc = (x) =>
             {
                 Text = Text.Insert(TextBox.SelectionStart, x);
             };
            var win = new CodeTemplate(vm);
            win.ShowDialog();
        }
    }
}
