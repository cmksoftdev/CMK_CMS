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
        private readonly CodeSchemeProvider codeSchemeProvider;


        private bool comment;

        public CodeHighlighter(CodeSchemeProvider codeSchemeProvider)
        {
            this.codeSchemeProvider = codeSchemeProvider;
            comment = false;
        }

        public List<ColoredCode> GetColoredBlocks(string code, string extension)
        {
            Dictionary<int, List<ColorScheme>> layers = codeSchemeProvider.GetLayers(extension);
            List<ColoredCode> codeBlock = new List<ColoredCode>();
            var current = "";
            ColorScheme activeScheme = null;
            foreach (var c in code)
            {
                current += c;
                if(activeScheme != null)
                {
                    if(current.EndsWith(activeScheme.Closer))
                    {
                        codeBlock.Add(new ColoredCode
                        {
                            ColorBrush = ColorBrushFactory.GetBrush(activeScheme.Color),
                            Word = current
                        });
                        current = "";
                        activeScheme = null;
                    }
                }
                else
                {
                    foreach(var layer in layers)
                    {
                        var broken = false;
                        foreach (var scheme in layer.Value)
                        {
                            if (current.StartsWith(scheme.Opener))
                            {
                                activeScheme = scheme;
                                broken = true;
                                break;
                            }
                        }
                        if (broken)
                            break;
                    }
                }
            }
            return codeBlock;
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
            char old_c1 = '\0';
            char old_c2 = '\0';
            string commtentString = "";
            string afterComment = "";

            if (comment)
            {
                if (line.Contains("-->"))
                {
                    var index = line.IndexOf("-->") + 3;
                    substring.Word = line.Substring(0, index);
                    line = line.Substring(index + 1);
                    substring.ColorBrush = ColorBrushFactory.GetBrush(Color.DarkGreen);
                    codeLine.Add(substring);
                    substring = new ColoredCode
                    {
                        Word = "",
                        ColorBrush = ColorBrushFactory.GetBrush(Color.Black)
                    };
                    comment = false;
                }
                else
                {
                    substring.Word = line;
                    substring.ColorBrush = ColorBrushFactory.GetBrush(Color.DarkGreen);
                    codeLine.Add(substring);
                    return codeLine;
                }
            }
            else if(line.Contains("<!--"))
            {
                var index = line.IndexOf("<!--");
                var indexEnd = line.Contains("-->") ? line.IndexOf("-->") : 0;
                if (indexEnd == 0)
                    commtentString = line.Substring(index);
                else
                {
                    commtentString = line.Substring(index + 1, indexEnd + 4);
                    afterComment = line.Substring(indexEnd +4 );
                }
                line = line.Substring(0, index);
                comment = true;
            }

            foreach (var c in line)
            {
                if(i / 2 % 2 == 1 && c == '"' && !(old_c1 == '\\' && old_c2 != '\\'))
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
                else if (c == '"' && i / 2 % 2 == 0)
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
                old_c2 = old_c1;
                old_c1 = c;
            }
            codeLine.Add(substring);
            if (commtentString != "")
            {
                substring = new ColoredCode
                {
                    Word = commtentString,
                    ColorBrush = ColorBrushFactory.GetBrush(Color.DarkGreen)
                };
                codeLine.Add(substring);
            }
            if (afterComment != "")
            {
                codeLine.AddRange(GetColoredLine(afterComment));
            }

            return codeLine;
        }
    }
}
