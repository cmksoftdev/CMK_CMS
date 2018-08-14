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

        private TreeNode tn(XmlLoader.Element element)
        {
            var root = new TreeNode();
            if (element.Value.GetType() == typeof(List<XmlLoader.Element>))
            {
                foreach (var e in element.Value as List<XmlLoader.Element>)
                {
                    var treenode = new TreeNode();
                    treenode.Text = e.Value.GetType() != typeof(List<XmlLoader.Element>) ? e.Key + " " + e.Value : e.Key;
                    if (e.Value.GetType() == typeof(List<XmlLoader.Element>))
                    {
                        treenode.ChildNodes.Add(tn(e));
                    }
                    root.ChildNodes.Add(treenode);
                }
                root.Text = element.Key;
            }
            else
            {
                root.Text = element.Key + " " + element.Value;
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
