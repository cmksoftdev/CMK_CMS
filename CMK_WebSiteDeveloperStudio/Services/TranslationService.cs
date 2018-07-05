﻿using CMK_WebSiteDeveloperStudio.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class TranslationService
    {
        private Languages languages;
        private string localLanguage;

        public void Initialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Languages));
            using (var stream = File.Open("Languages.xml", FileMode.Open))
            {
                languages = serializer.Deserialize(stream) as Languages;
            }
            localLanguage = "EN";
        }

        public void Initialize(string language)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Languages));
            using (var stream = File.Open("Languages.xml", FileMode.Open))
            {
                languages = serializer.Deserialize(stream) as Languages;
            }
            localLanguage = language;
        }

        public string Get(string language, int i)
        {
            return languages.L.First(x => x.Symbol == language).Translations.ElementAt(i);
        }

        public string Get(int i)
        {
            return languages.L.First(x => x.Symbol == localLanguage).Translations.ElementAt(i);
        }
    }
}
