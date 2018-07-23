using CMK_WebSiteDeveloperStudio.Configs;
using CMK_WebSiteDeveloperStudio.DTOs;
using CMK_WebSiteDeveloperStudio.Enums;
using CMK_WebSiteDeveloperStudio.Factories;
using CMK_WebSiteDeveloperStudio.Services;
using CMK_WebSiteDeveloperStudio.ViewModels;
using CMK_WebSiteDeveloperStudio.Views;
using CMK_WebSiteDeveloperStudio.Workers;
using System;
using System.Collections.Generic;

namespace CMK_WebSiteDeveloperStudio.BusinessLogicLayer
{
    public class Core
    {
        private ProjectLoader projectLoader;
        private TranslationService translationService;
        private WindowFactory windowFactory;
        private ProjectFactory projectFactory;
        private FileManager fileManager;
        private ProjectManager projectManager;
        private TemplateFunnel templateFunnel;

        public Config Config { get; }

        Project selectedProject;
        public Project SelectedProject
        {
            get
            {
                return selectedProject;
            }
            set
            {
                this.fileManager = new FileManager(value.Config.ProjectFiles, this);
                projectManager.Set(value);
                selectedProject = value;
            }
        }

        public Core(
            Config config,
            ProjectLoader projectLoader,
            TranslationService translationService,
            TemplateFunnel templateFunnel
            )
        {
            Config = config;
            this.projectLoader = projectLoader ?? throw new NullReferenceException(projectLoader.GetType() + " was null.");
            this.translationService = translationService ?? throw new NullReferenceException(translationService.GetType() + " was null.");
            this.templateFunnel = templateFunnel ?? throw new NullReferenceException(templateFunnel.GetType() + " was null.");
            projectFactory = new ProjectFactory(this);
            projectManager = new ProjectManager(this);
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

        public Editor ReturnFileWindow()
        {
            return windowFactory.CreateWindow(WindowEnum.Editor) as Editor;
        }

        public AdvancedEditor ReturnFileWindow(ProjectFile file)
        {
            var win = new AdvancedEditor(new AdvancedEditor_ViewModel(this));
            ((AdvancedEditor_ViewModel)win.DataContext).MyProperty = GetFileWorker(file);
            return win;
        }

        public AdvancedEditor GetEditorForFile(ProjectFile file)
        {
            var win = fileManager.GetEditorForFile(file);
            return win; 
        }

        public bool? CreateWindowDialog(WindowEnum winEnum)
        {
            return windowFactory.CreateWindow(winEnum).ShowDialog();
        }

        public void CreateProject(string name)
        {
            projectFactory.Create(name);
        }

        public void CreateFile(string name)
        {
            if (selectedProject != null)
            {
                var file = new ProjectFile { FilePath = SelectedProject.Name + "\\" + name };
                fileManager.Add(file);
                SelectedProject.Config.ProjectFiles.Add(file);
                projectManager.Save();
            }
        }

        public void CreateFileFromTemplate(string name, Template template)
        {
            if (selectedProject != null)
            {
                var file = new ProjectFile { FilePath = SelectedProject.Name + "\\" + name };
                fileManager.Add(file);
                var worker = fileManager.GetWorker(file);
                worker.Content = templateFunnel.Fill(template);
                worker.Save();
                SelectedProject.Config.ProjectFiles.Add(file);
                projectManager.Save();
            }
        }

        public void DeleteFile(ProjectFile file)
        {
            if (file != null)
            {
                fileManager.Remove(file);
                SelectedProject.Config.ProjectFiles.Remove(file);
                projectManager.Save();
            }
        }

        public List<Template> GetFileTemplates()
        {
            return templateFunnel.GetFileTemplates();
        }

        public List<Template> GetCodeTemplates()
        {
            return templateFunnel.GetCodeTemplates();
        }

        public ProjectFileWorker GetFileWorker(ProjectFile file)
        {
            return fileManager.GetWorker(file);
        }

        public string FillTemplate(Template template)
        {
            return templateFunnel.Fill(template);
        }

        public void StartBrowser(string filePath)
        {
            System.Diagnostics.Process.Start("file://" + filePath);
        }
    }
}
