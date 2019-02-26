using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.Services
{
    class BuildJobInterpreter
    {
        const string OPENER = "##!";
        const string CLOSER = "!##";
        const string ALL = "all";
        const string PROJECT_FILES = "projectfiles";
        const string PROJECT_FILE = "projectfile";

        Core core;

        class ToReplace
        {
            public string Old;
            public string New;
        }

        public BuildJobInterpreter(Core core)
        {
            this.core = core;
        }

        public string GetCommand(string input)
        {
            var output = input;
            
            var matches = Regex.Matches(input, $"(?<={OPENER})(.*)(?={CLOSER})");
            var placeholders = new List<ToReplace>();
            foreach (Match match in matches)
            {
                output = output.Replace($"{OPENER}{match.Value}{CLOSER}", getString(match.Value));
            }

            return output;
        }

        private string getString(string input)
        {
            var split = input.Split(':');

            var output = input;
            switch (split[0])
            {
                case PROJECT_FILE:
                    output = core.SelectedProject.Config.ProjectFiles.
                        FirstOrDefault(x => x.TagCollection.Contains(split[1])).FilePath;
                    break;
                case PROJECT_FILES:
                    if (split[1] == ALL)
                    {
                        output = string.Join(split[2], core.SelectedProject.Config.ProjectFiles.
                            Select(x => x.FilePath));
                    }
                    else if(split[1].ElementAt(0) == '.')
                    {
                        output = string.Join(split[2], core.SelectedProject.Config.ProjectFiles.Where(x => x.FileExtension == split[1])
                            .Select(x => x.FilePath));
                    }
                    else
                    {
                        output = string.Join(split[2], core.SelectedProject.Config.ProjectFiles.Where(x => x.TagCollection.Contains(split[1]))
                            .Select(x => x.FilePath));
                    }
                    break;
                default:
                    break;
            }

            return output;
        }
    }
}
