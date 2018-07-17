﻿using CMK_WebSiteDeveloperStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CMK_WebSiteDeveloperStudio.Views
{
    /// <summary>
    /// Interaktionslogik für Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        public Editor(Editor_ViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
