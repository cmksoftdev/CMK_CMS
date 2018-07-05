using CMK.Services;
using CMK_WebSiteDeveloperStudio.Configs;
using CMK_WebSiteDeveloperStudio.Services;
using CMK_WebSiteDeveloperStudio.ViewModels;
using CMK_WebSiteDeveloperStudio.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace CMK_WebSiteDeveloperStudio
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public void StartUp(object sender, StartupEventArgs e)
        {
            const string CONFIG_PATH_NAME = "\\CMK WSDS Configs\\";
            const string CONFIG_FILE_NAME = "config.xml";
            const string DEFAULT_CONFIG = "<Config><Language>DE</Language><ProjectPath>E:\\CMK WSDS Projects\\</ProjectPath></Config>";



            try
            {
                var tempPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + CONFIG_PATH_NAME;
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                XmlSerializer serializer = new XmlSerializer(typeof(Config));
                var configFilePath = tempPath + CONFIG_FILE_NAME;
                if (!File.Exists(configFilePath))
                {
                    File.WriteAllText(configFilePath, DEFAULT_CONFIG);
                }
                Config config;
                using (var stream = File.Open(configFilePath, FileMode.Open))
                {
                    config = serializer.Deserialize(stream) as Config;                    
                }
                var translationService = new TranslationService();
                translationService.Initialize(config.Language);

                var startWindow_vm = new StartWindow_ViewModel(translationService);
                var mainWindow = new StartWindow(startWindow_vm);
                mainWindow.Show();
                throw new Exception("test");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex);
            }
        }
    }
}
