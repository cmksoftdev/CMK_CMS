﻿using CMK_WebSiteDeveloperStudio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.Configs
{
    public class ProjectConfig
    {
        public int ProjectType { get; set; }
        public List<ProjectFile> ProjectFiles { get; set; }
        public int Version { get; set; }
    }
}
