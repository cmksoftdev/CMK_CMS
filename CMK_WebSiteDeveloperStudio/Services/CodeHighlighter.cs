using CMK_WebSiteDeveloperStudio.DTOs;
using CMK_WebSiteDeveloperStudio.Enums;
using CMK_WebSiteDeveloperStudio.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class CodeHighlighter
    {
        private readonly int codeSyntax;

        public CodeHighlighter(int codeSyntax)
        {
            this.codeSyntax = codeSyntax;
        }

        public List<ColoredCode> GetColoredLine(string line)
        {
            List<ColoredCode> codeLine = new List<ColoredCode>();
            ColoredCode substring = new ColoredCode
            {
                Word = "",
                ColorBrush = ColorBrushFactory.GetBrush(Color.Black)
            };
            int i = 0;
            foreach (var c in line)
            {
                if(i / 2 % 2 == 1 && c == '"')
                {
                    substring.Word += c;
                    codeLine.Add(substring);
                    if (i % 2 == 1)
                    {
                        substring = new ColoredCode
                        {
                            Word = "",
                            ColorBrush = ColorBrushFactory.GetBrush(Color.Lila)
                        };
                        i = 1;
                    }
                    else
                    {
                        substring = new ColoredCode
                        {
                            Word = "",
                            ColorBrush = ColorBrushFactory.GetBrush(Color.Black)
                        };
                        i = 0;
                    }
                }
                else if (c == '<')
                {
                    i += 1;
                    codeLine.Add(substring);
                    substring = new ColoredCode
                    {
                        Word = "",
                        ColorBrush = ColorBrushFactory.GetBrush(Color.Lila)
                    };
                    substring.Word += c;
                }
                else if (c == '>')
                {
                    i -= 1;
                    codeLine.Add(substring);
                    substring.Word += c;
                    substring = new ColoredCode
                    {
                        Word = "",
                        ColorBrush = ColorBrushFactory.GetBrush(Color.Black)
                    };
                }
                else if (c == '"')
                {
                    i += 2;
                    codeLine.Add(substring);
                    substring = new ColoredCode
                    {
                        Word = "",
                        ColorBrush = ColorBrushFactory.GetBrush(Color.Red)
                    };
                    substring.Word += c;
                }
                else
                {
                    substring.Word += c;
                }
            }
            codeLine.Add(substring);
            return codeLine;
        }
    }
}
