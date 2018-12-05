using CMK_WebSiteDeveloperStudio.Configs;
using CMK_WebSiteDeveloperStudio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class CodeSchemeProvider
    {
        private const string CONFIG_NAME = @"CodeDescriptions\ProgrammerLanguages.xml";
        private ProgrammerLanguages programmerLanguages;

        public CodeSchemeProvider()
        {
            programmerLanguages = XmlLoader.Load<ProgrammerLanguages>(CONFIG_NAME);
        }

        public Dictionary<int, List<ColorScheme>> GetLayers(string fileExtension)
        {
            var languageConfig = XmlLoader.Load<ColorScheme[]>(programmerLanguages.Languages.FirstOrDefault(x => x.FileExtensions.Contains(fileExtension)).ConfigFile);
            Dictionary<int, List<ColorScheme>> layers = new Dictionary<int, List<ColorScheme>>();
            foreach (var colorScheme in languageConfig)
            {
                if(layers.ContainsKey(colorScheme.Layer))
                {
                    layers[colorScheme.Layer].Add(colorScheme);
                }
                else
                {
                    layers[colorScheme.Layer] = new List<ColorScheme> { colorScheme };
                }
            }
            return layers;
        }
    }
}
