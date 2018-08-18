using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMK_WebSiteDeveloperStudio.BusinessLogicLayer;
using CMK.Services;
using System.Windows.Controls;
using CMK_WebSiteDeveloperStudio.Services;
using CMK_WebSiteDeveloperStudio.DTOs;
using System.Xml.Linq;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class DataEditor_ViewModel : Editor_ViewModel
    {
        TreeViewManager treeViewManager;
        ProjectFile projectFile;

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

        public DataEditor_ViewModel(Core core, ProjectFile projectFile) : base(core)
        {
            com = new CommandMethodReflectionProvider(this);
            this.projectFile = projectFile;
        }

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
                OnPropertyChanged(nameof(ColumWidthTwoThird));
                OnPropertyChanged(nameof(ColumWidthSixth));
            }
        }

        public float ColumWidthTwoThird
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

        TreeView treeView;
        public TreeView TreeView
        {
            get
            {
                return treeView;
            }
            set
            {
                if(treeView == null)
                {

                    this.treeViewManager = new TreeViewManager(value);
                    var x = XmlLoader.Load(projectFile.FilePath);
                    treeViewManager.Set(x);
                }
                treeView = value;
                treeView.Items.Refresh();
                treeView.UpdateLayout();
                OnPropertyChanged(nameof(TreeView));
            }
        }


        public void DeleteClick()
        {
            if(treeView.SelectedItem!=null)
            {
                ((TreeViewItem)((TreeViewItem)treeView.SelectedItem).Parent).Items.Remove(treeView.SelectedItem);
            }
        }

        TreeViewItem clipboard;

        private TreeViewItem copy(TreeViewItem input)
        {
            var output = new TreeViewItem();
            output.Header = input.Header;
            if (input.HasItems)
            {
                foreach (TreeViewItem it in input.Items)
                {
                    var neu = copy(it);
                    output.Items.Add(neu);
                }
            }
            return output;
        }

        public void CopyClick()
        {
            if (treeView.SelectedItem != null)
            {
                clipboard = copy(treeView.SelectedItem as TreeViewItem);
            }
        }

        public void InsertClick()
        {
            if (treeView.SelectedItem != null && clipboard != null)
            {
                ((TreeViewItem)treeView.SelectedItem).Items.Add(copy(clipboard));
            }
        }

        public void SaveClick()
        {

        }

        public void EditClick()
        {
            if (treeView.SelectedItem != null)
            {

            }
        }

        public void AddClick()
        {

        }
    }
}
