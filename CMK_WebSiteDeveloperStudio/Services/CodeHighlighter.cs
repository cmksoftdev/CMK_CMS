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
            var activeSchemes = layers
                .Select(x => new KeyValuePair<int, ColorScheme>(x.Key, null))
                .ToDictionary(x => x.Key, x => x.Value);
            var lines = 0;
            var shift = 0;
            var newShift = 0;
            var newLines = 0;
            foreach (var c in code)
            {
                if (c == '\n')
                {
                    newLines++;
                    newShift = 0;
                }
                else if (c == '\t')
                {
                    newShift += 4;
                }
                else
                {
                    newShift++;
                }
                current += c;

                foreach (var layer in layers)
                {
                    if (activeSchemes[layer.Key] != null)
                    {
                        if (current.EndsWith(activeSchemes[layer.Key].Closer))
                        {
                            if (shift - activeSchemes[layer.Key].Closer.Length > 0)
                                shift -= activeSchemes[layer.Key].Closer.Length;
                            else
                                shift = 0;
                            var word = "".PadRight(shift, ' ') + current;
                            codeBlock.Add(new ColoredCode
                            {
                                ColorBrush = ColorBrushFactory.GetBrush(activeSchemes[layer.Key].ColorContent),
                                Word = word,
                                Line = lines,
                                Shift = shift
                            });
                            current = "";
                            activeSchemes[layer.Key] = null;
                            if (newLines > 0)
                                shift = 0;
                            shift += newShift;
                            lines += newLines;
                            newShift = 0;
                            newLines = 0;
                        }
                        break;
                    }
                    else
                    {
                        var broken = false;
                        foreach (var scheme in layer.Value)
                        {
                            if (current.EndsWith(scheme.Opener))
                            {
                                current = new string(current.Take(current.Length - scheme.Opener.Length).ToArray());
                                if (!string.IsNullOrEmpty(current))
                                {
                                    var word = "".PadRight(shift, ' ') + current;
                                    var a = activeSchemes.FirstOrDefault(x => x.Key == layer.Key + 1);
                                    var color = a.Value != null ? a.Value.ColorContent : Color.Black ;
                                    codeBlock.Add(new ColoredCode
                                    {
                                        ColorBrush = ColorBrushFactory.GetBrush(color),
                                        Word = word,
                                        Line = lines,
                                        Shift = shift
                                    });
                                    lines += newLines;
                                    if (newLines > 0)
                                        shift = 0;
                                    shift += newShift;
                                    newShift = 0;
                                    newLines = 0;
                                }
                                current = scheme.Opener;
                                newShift += scheme.Opener.Length;
                                activeSchemes[layer.Key] = scheme;
                                broken = true;
                                break;
                            }
                            if (broken)
                                break;
                        }
                    }
                }
            }
            if(!string.IsNullOrEmpty(current))
            {
                if (activeSchemes.FirstOrDefault(x => x.Value != null).Value != null && shift - activeSchemes.First(x => x.Value != null).Value.Closer.Length > 0)
                    shift -= activeSchemes.First(x => x.Value != null).Value.Closer.Length;
                else
                    shift = 0;
                var word = "".PadRight(shift, ' ') + current;
                codeBlock.Add(new ColoredCode
                {
                    ColorBrush = activeSchemes.FirstOrDefault(x => x.Value != null).Value != null ? 
                        ColorBrushFactory.GetBrush(activeSchemes.First(x => x.Value != null).Value.ColorContent) :
                        ColorBrushFactory.GetBrush(Color.Black),
                    Word = word,
                    Line = lines,
                    Shift = shift
                });
            }
            return codeBlock;
        }
    }
}
