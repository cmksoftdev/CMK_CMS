using CMK_WebSiteDeveloperStudio.Configs;
using CMK_WebSiteDeveloperStudio.DTOs;
using CMK_WebSiteDeveloperStudio.Enums;
using CMK_WebSiteDeveloperStudio.Factories;
using CMK_WebSiteDeveloperStudio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.BusinessLogicLayer
{
    public class Core
    {
        private ProjectLoader projectLoader;
        private TranslationService translationService;
        private WindowFactory windowFactory;
        public Config Config { get; }

        public Core(
            Config config,
            ProjectLoader projectLoader,
            TranslationService translationService
            )
        {
            if (projectLoader == null)
                throw new NullReferenceException(projectLoader.GetType() + " was null.");
            if (translationService == null)
                throw new NullReferenceException(translationService.GetType() + " was null.");

            this.Config = config;
            this.projectLoader = projectLoader;
            this.translationService = translationService;
            windowFactory = new WindowFactory(this);
        }

        public List<Project> GetProjects()
        {
            return projectLoader.GetProjects();
        }

        public string GetTranslation(int i)
        {
            return translationService.Get(i);
        }

        public void CreateWindow(WindowEnum winEnum)
        {
            windowFactory.CreateWindow(winEnum).Show();
        }
    }
}
