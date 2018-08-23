using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TreeNode = System.Web.UI.WebControls.TreeNode;

namespace CMK_WebSiteDeveloperStudio.Services
{
    public class TreeViewManager
    {
        TreeView treeView;

        public TreeViewManager(TreeView treeView)
        {
            this.treeView = treeView;
        }

        private TreeViewItem tn(XmlLoader.Element element)
        {
            var root = new TreeViewItem();
            if (element.Value.GetType() == typeof(List<XmlLoader.Element>))
            {
                foreach (var e in element.Value as List<XmlLoader.Element>)
                {
                    var treenode = new TreeViewItem();
                    treenode.Header = e.Value.GetType() != typeof(List<XmlLoader.Element>) ? e.Key + " " + e.Value : e.Key;
                    if (e.Value.GetType() == typeof(List<XmlLoader.Element>))
                    {
                        treenode.Items.Add(tn(e));
                    }
                    root.Items.Add(treenode);
                }
                root.Header = element.Key;
            }
            else
            {
                root.Header = element.Key + " " + element.Value;
            }
            return root;
        }

        public void Set(List<XmlLoader.Element> list)
        {
            foreach (var item in list)
            {
                var treenode = tn(item);
                treeView.Items.Add(treenode);
            }
        }
    }
}
