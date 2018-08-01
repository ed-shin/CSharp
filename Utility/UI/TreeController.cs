using System.Linq;
using System.Windows.Forms;

namespace Utiltiy.UI
{
    /// <summary>
    /// 부모 노드와 자식 노드간의 동기를 위한 트리뷰 컨트롤러
    /// </summary>
    public class TreeController
    {
        private TreeView _tv;

        public TreeController()
        {
            _tv.ShowLines = true;
            _tv.BorderStyle = BorderStyle.None;
            _tv.Dock = DockStyle.Fill;
        }

        public void AddNode(string text, object tag = null)
        {
            TreeNode node = new TreeNode();
            node.Text = text;
            node.Tag = tag;

            _tv.Nodes.Add(node);
        }
        #region Operator Checkstate

        public void Check(TreeNode node, bool check)
        {
            node.Checked = check;

            foreach (TreeNode child in node.Nodes)
                Check(child, check);

            if (node.Parent != null)
            {
                setStateOnChildState(node.Parent);

                if (check)
                {
                    if (node.Parent.Checked != check)
                    {
                        node.Parent.Checked = check;

                        foreach (TreeNode child in node.Parent.Nodes)
                        {
                            if (child == node)
                                continue;

                            child.Checked = false;
                        }
                    }
                }
            }
        }

        private void setStateOnChildState(TreeNode node)
        {
            int cnt = 0;

            foreach (TreeNode child in node.Nodes)
                cnt += child.Checked ? 1: 0;

            if (cnt == 0)
            {
                node.Checked = false;
                return;
            }

            if (cnt == node.Nodes.Count)
            {
                node.Checked = true;
                return;
            }
        }
        #endregion
    }
}
