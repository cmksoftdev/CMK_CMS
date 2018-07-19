using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using System.Windows.Controls;
using CMK_WebSiteDeveloperStudio.Workers;
using System.Windows.Media;
using CMK_WebSiteDeveloperStudio.Services;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class AdvancedEditor_ViewModel : Editor_ViewModel
    {
        Canvas canvas;
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
            //if(Canvas != null && Text != null)
            //{
            //    var texte = Text.Split(' ');
            //    var b = true;
            //    foreach (var text in texte)
            //    {
            //        var tb = new Label();
            //        tb.Content = text;
            //        tb.FontFamily = new FontFamily("Courier New");
            //        if (b)
            //        {
            //            var scb = new SolidColorBrush();
            //            scb.Color = Color.FromArgb(255, 0, 0, 255);
            //            tb.Foreground = new SolidColorBrush();
            //            tb.Foreground = scb;
            //        }
            //        b = !b;
            //        Canvas.Children.Clear();
            //        Canvas.Children.Add(tb);
            //    }
            //} 
        }

        public new string Text
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
    }
}
