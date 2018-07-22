using CMK_WebSiteDeveloperStudio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Color = CMK_WebSiteDeveloperStudio.Enums.Color;
using Colour = System.Windows.Media.Color;

namespace CMK_WebSiteDeveloperStudio.Factories
{
    public class ColorBrushFactory
    {
        public static SolidColorBrush GetBrush(Color color)
        {
            var brush = new SolidColorBrush();
            switch (color)
            {
                case Color.Black:
                    brush.Color = Colour.FromArgb(255, 0, 0, 0);
                    break;
                case Color.White:
                    brush.Color = Colour.FromArgb(255, 255, 255, 255);
                    break;
                case Color.Red:
                    brush.Color = Colour.FromArgb(255, 255, 0, 0);
                    break;
                case Color.Green:
                    brush.Color = Colour.FromArgb(255, 0, 255, 0);
                    break;
                case Color.Blue:
                    brush.Color = Colour.FromArgb(255, 0, 0, 255);
                    break;
                case Color.Pink:
                    brush.Color = Colour.FromArgb(255, 255, 0, 255);
                    break;
                case Color.Yellow:
                    brush.Color = Colour.FromArgb(255, 255, 255, 0);
                    break;
                case Color.Turquoise:
                    brush.Color = Colour.FromArgb(255, 0, 255, 255);
                    break;
                case Color.Orange:
                    brush.Color = Colour.FromArgb(255, 255, 128, 0);
                    break;
                case Color.Lila:
                    brush.Color = Colour.FromArgb(255, 127, 0, 255);
                    break;
                case Color.Gray:
                    brush.Color = Colour.FromArgb(255, 96, 96, 96);
                    break;
                case Color.DarkRed:
                    brush.Color = Colour.FromArgb(255, 153, 0, 0);
                    break;
                case Color.DarkGreen:
                    brush.Color = Colour.FromArgb(255, 0, 153, 0);
                    break;
                case Color.DarkBlue:
                    brush.Color = Colour.FromArgb(255, 0, 0, 153);
                    break;
                case Color.DarkPink:
                    brush.Color = Colour.FromArgb(255, 153, 0, 153);
                    break;
                case Color.DarkYellow:
                    brush.Color = Colour.FromArgb(255, 153, 153, 0);
                    break;
                case Color.DarkTurquoise:
                    brush.Color = Colour.FromArgb(255, 0, 153, 153);
                    break;
                case Color.DarkOrange:
                    brush.Color = Colour.FromArgb(255, 153, 96, 0);
                    break;
                case Color.DarkLila:
                    brush.Color = Colour.FromArgb(255, 96, 0, 153);
                    break;
                case Color.DarkGray:
                    brush.Color = Colour.FromArgb(255, 50, 50, 50);
                    break;
            }
            return brush;
        }
    }
}
