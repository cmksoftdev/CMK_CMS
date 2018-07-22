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

        public static void Render(Canvas canvas, string text)
        {
            if (canvas == null || String.IsNullOrEmpty(text))
                return;
            canvas.Children.Clear();
            CodeHighlighter ch = new CodeHighlighter(1);
            var font = new FontFamily("Courier New");
            List<List<string>> rowLines = new List<List<string>>();
            var rows = text.Split('\n');
            int i = 0;
            foreach (var row in rows)
            {
                double j = 0;
                var words = ch.GetColoredLine(row);
                foreach (var word in words)
                {
                    var lab = new Label();
                    lab.FontFamily = font;
                    lab.Content = word.Word;
                    lab.Foreground = word.ColorBrush;
                    Canvas.SetTop(lab, i * 13.5d - 4d);
                    Canvas.SetLeft(lab, j);
                    canvas.Children.Add(lab);
                    j += (word.Word.Length) * 7.2d;
                }
                i++;
            }
        }

        //public static void Render(Canvas canvas, string text)
        //{
        //    if (canvas == null || String.IsNullOrEmpty(text))
        //        return;
        //    canvas.Children.Clear();
        //    List<List<string>> rowLines = new List<List<string>>();
        //    var rows = text.Split('\n');
        //    int i = 0;
        //    var b = true;
        //    foreach (var row in rows)
        //    {
        //        double j = 0;
        //        rowLines.Add(new List<string>(row.Split(' ')));
        //        var words = row.Split(' ');
        //        foreach (var word in words)
        //        {
        //            b = !b;
        //            var newWord = splitstring(word);
        //            int k = 0;
        //            foreach (var w in newWord)
        //            {
        //                var lab = new Label();
        //                if (k % 2 == 1)
        //                {
        //                    lab.Content = w;
        //                    lab.Foreground = ColorBrushFactory.GetBrush(Color.DarkLila);
        //                    Canvas.SetTop(lab, i * 13d - 5d);
        //                    Canvas.SetLeft(lab, j);
        //                    canvas.Children.Add(lab);
        //                    j += (w.Length) * 7d;
        //                }
        //                else
        //                {
        //                    lab.Content = w;
        //                    if (b)
        //                    {
        //                        lab.Foreground = ColorBrushFactory.GetBrush(Color.Green);
        //                    }
        //                    Canvas.SetTop(lab, i * 13.5d - 5d);
        //                    Canvas.SetLeft(lab, j);
        //                    canvas.Children.Add(lab);
        //                    j += (w.Length) * 7d;
        //                }
        //                //j += 7d;
        //                k++;
        //            }

        //        }
        //        i++;
        //    }
        //}

        //private static List<string> splitstring(string str)
        //{
        //    var newStr = str.Split('"').ToList();
        //    for (var i=0;i < newStr.Capacity;i++)
        //    {
        //        if (i%2 == 1)
        //        {
        //            newStr[i] = "\"" + newStr[i] + "\"";
        //        }
        //    }
        //    return newStr;
        //}
    }
}
