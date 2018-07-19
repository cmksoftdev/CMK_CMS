using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class CanvasKannWas
    {
        public static void Render(Canvas canvas, string text)
        {
            if (canvas == null || String.IsNullOrEmpty(text))
                return;
            canvas.Children.Clear();
            List<List<string>> rowLines = new List<List<string>>();
            var rows = text.Split('\n');
            int i = 0;
            var b = true;
            foreach (var row in rows)
            {
                double j = 0;
                rowLines.Add(new List<string>(row.Split(' ')));
                var words = row.Split(' ');
                foreach (var word in words)
                {
                    b = !b;
                    var lab = new Label();
                    lab.Content = word;
                    if (b)
                    {
                        var scb = new SolidColorBrush();
                        scb.Color = Color.FromArgb(255, 0, 0, 255);
                        lab.Foreground = new SolidColorBrush();
                        lab.Foreground = scb;
                    }
                    Canvas.SetTop(lab, i * 13d);
                    Canvas.SetLeft(lab, j);
                    canvas.Children.Add(lab);
                    j += (word.Length + 1) * 7d;
                }
                i++;
            }
        }
    }
}
