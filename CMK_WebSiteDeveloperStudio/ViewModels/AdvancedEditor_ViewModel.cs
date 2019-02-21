using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using System.Windows.Controls;
using CMK_WebSiteDeveloperStudio.Workers;
using CMK_WebSiteDeveloperStudio.Services;
using CMK_WebSiteDeveloperStudio.Views;
using System.IO;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class AdvancedEditor_ViewModel : Editor_ViewModel
    {
        Canvas canvas;

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
            if(Text != null && worker != null)
                CanvasKannWas.Render(canvas, Text, Path.GetExtension(worker.FileInfos.FilePath));
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

        public void HandleStartClick()
        {
            core.StartBrowser(worker.FileInfos.FilePath);
        }
    }
}
