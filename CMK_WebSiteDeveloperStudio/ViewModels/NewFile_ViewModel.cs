﻿using CMK.Services;
using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK_WebSiteDeveloperStudio.DTOs;
using CMK_WebSiteDeveloperStudio.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class NewFile_ViewModel : ViewModelBase
    {
        Core core;

        float columnWidth;
        public float ColumWidth
        {
            get
            {
                return columnWidth;
            }
            set
            {
                columnWidth = value - 30f;
                ColumWidthThird = (columnWidth) / 3f;
            }
        }
        float columnWidthThird;
        public float ColumWidthThird
        {
            get
            {
                return columnWidthThird;
            }
            set
            {
                columnWidthThird = value;
                OnPropertyChanged(nameof(ColumWidthThird));
                OnPropertyChanged(nameof(ColumWidthHalf));
                OnPropertyChanged(nameof(ColumWidthSixth));
            }
        }

        public float ColumWidthHalf
        {
            get
            {
                return ColumWidth / 2f;
            }
        }

        public float ColumWidthSixth
        {
            get
            {
                return ColumWidth / 4f;
            }
        }

        public List<Template> Templates
        {
            get
            {
                return core.GetFileTemplates();
            }
        }

        public ObservableCollection<PlaceHolder> PlaceHolders
        {
            get
            {
                if(SelectedItem != null)
                    return new ObservableCollection<PlaceHolder>(SelectedItem?.PlaceHolders);
                else
                    return new ObservableCollection<PlaceHolder>();
            }
            set
            {
                SelectedItem.PlaceHolders = value.ToList();
            }
        }

        Template selectedItem;
        public Template SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(PlaceHolders));
            }
        }

        public string Filename { get; set; }

        public NewFile_ViewModel(Core core)
        {
            this.core = core;
            this.com = new CommandMethodReflectionProvider(this);
        }

        public void HandleNewFileClick()
        {
            if (!String.IsNullOrEmpty(Filename) && SelectedItem != null)
            {
                core.CreateFileFromTemplate(Filename, SelectedItem);                
            }
        }
    }
}
