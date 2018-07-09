using CMK_WebSiteDeveloperStudio.DTOs;
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

        public Core(
            ProjectLoader projectLoader,
            TranslationService translationService
            )
        {
            if (projectLoader == null)
                throw new NullReferenceException(projectLoader.GetType() + " was null.");
            if (translationService == null)
                throw new NullReferenceException(translationService.GetType() + " was null.");

            this.projectLoader = projectLoader;
            this.translationService = translationService;
        }

        public List<Project> GetProjects()
        {
            return projectLoader.GetProjects();
        }

        public string GetTranslation(int i)
        {
            return translationService.Get(i);
        }
    }
}
