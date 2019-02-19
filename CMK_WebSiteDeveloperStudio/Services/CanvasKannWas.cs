using CMK_WebSiteDeveloperStudio.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Color = CMK_WebSiteDeveloperStudio.Enums.Color;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class CanvasKannWas
    {

        public static void Render(Canvas canvas, string text, string extension)
        {
            if (canvas == null || String.IsNullOrEmpty(text))
                return;
            canvas.Children.Clear();
            CodeHighlighter ch = new CodeHighlighter(new CodeSchemeProvider());
            var font = new FontFamily("Courier New");

            var blocks = ch.GetColoredBlocks(text, extension);
            foreach (var word in blocks)
            {
                var lab = new Label();
                lab.FontFamily = font;
                lab.Content = word.Word;
                lab.Foreground = word.ColorBrush;
                //Canvas.SetTop(lab, i * 13.5d - 4d);
                //Canvas.SetLeft(lab, j);
                canvas.Children.Add(lab);
                //j += (word.Word.Length) * 7.2d - 1.2d;
            }

            //List<List<string>> rowLines = new List<List<string>>();
            //var rows = text.Split('\n');
            //int i = 0;
            //foreach (var row in rows)
            //{
            //    double j = 0;
            //    var words = ch.GetColoredBlocks(row, extension);
            //    foreach (var word in words)
            //    {
            //        var lab = new Label();
            //        lab.FontFamily = font;
            //        lab.Content = word.Word;
            //        lab.Foreground = word.ColorBrush;
            //        Canvas.SetTop(lab, i * 13.5d - 4d);
            //        Canvas.SetLeft(lab, j);
            //        canvas.Children.Add(lab);
            //        j += (word.Word.Length) * 7.2d - 1.2d;
            //    }
            //    i++;
            //}
        }
    }
}
