using Newtonsoft.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TreeCode
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var code = tbCode.Text;
            var description = tbDescription.Text;

            TreeNode newNode = new TreeNode($"{code}: {description}");
            TreeNode selectedNode = treeView1.SelectedNode;
            if (rbRoot.Checked)
            {
                treeView1.Nodes.Add(newNode);
            }
            else if (rbSelectedAddChild.Checked)
            {
                if (selectedNode != null)
                {
                    selectedNode.Nodes.Add(newNode);
                    selectedNode.Expand();
                }
            }
            else
            {
                if (selectedNode != null)
                {
                    selectedNode.Text = $"{code}: {description}";
                }
            }

            tbCode.Clear();
            tbDescription.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            if (selectedNode != null)
            {
                string[] nodeTextParts = selectedNode.Text.Split(':');

                string code = nodeTextParts[0].Trim();
                string description = nodeTextParts[1].Trim();

                tbCode.Text = code;
                tbDescription.Text = description;

                rbSelectedUpdate.Checked = true;
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için bir düğüm seçin.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            if (selectedNode != null)
            {
                if (selectedNode.Parent != null)
                {
                    selectedNode.Parent.Nodes.Remove(selectedNode);
                }
                else
                {
                    treeView1.Nodes.Remove(selectedNode);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir düğüm seçin.");
            }
        }

        private void btnCreateList_Click(object sender, EventArgs e)
        {
            GetTreeView(treeView1.Nodes, "", "");
        }

        //private void GetTreeView(TreeNodeCollection nodes, string parentCode, string parentDescription)
        //{
        //    foreach (TreeNode node in nodes)
        //    {
        //        string code = $"{TraverseTreeNodes(node, true)}";
        //        string description = $"{TraverseTreeNodes(node, false)}";
        //        if (node.Nodes.Count == 0)
        //        {
        //            tbList.AppendText($"{parentCode}{code};{parentDescription} {description}");
        //            tbList.AppendText(Environment.NewLine);
        //        }
        //        else
        //        {
        //            parentCode = $"{parentCode}{code}";
        //            parentDescription = $"{parentDescription} {description}";
        //            GetTreeView(node.Nodes, parentCode, parentDescription);
        //        }
        //    }
        //}

        private void GetTreeView(TreeNodeCollection nodes, string parentCode, string parentDescription)
        {
            foreach (TreeNode node in nodes)
            {
                string code = TraverseTreeNodes(node, true);
                string description = TraverseTreeNodes(node, false);

                if (node.Nodes.Count == 0)
                {
                    tbList.AppendText($"{parentCode.Trim()}{code.Trim()};{parentDescription.Trim()} {description.Trim()}");
                    tbList.AppendText(Environment.NewLine);
                }
                else
                {
                    string childCode = $"{parentCode}{code}";
                    string childDescription = $"{parentDescription} {description}";

                    GetTreeView(node.Nodes, childCode, childDescription);
                }
            }
        }


        private string TraverseTreeNodes(TreeNode node, bool isCode)
        {
            string nodeText = isCode ? node.Text.Split(':')[0].Trim() : node.Text.Split(':')[1].Trim();

            return nodeText.Trim();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json";
            saveFileDialog.Title = "Save TreeView Data";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<TreeViewData> treeViewDataList = new List<TreeViewData>();
                foreach (TreeNode node in treeView1.Nodes)
                {
                    TreeViewData treeViewData = TreeNodeToTreeViewData(node);
                    treeViewDataList.Add(treeViewData);
                }

                string jsonData = JsonConvert.SerializeObject(treeViewDataList, Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, jsonData);
            }
        }

        private TreeViewData TreeNodeToTreeViewData(TreeNode node)
        {
            TreeViewData treeViewData = new TreeViewData
            {
                Code = node.Text.Split(':')[0].Trim(),
                Description = node.Text.Split(':')[1].Trim(),
                Children = new List<TreeViewData>()
            };

            foreach (TreeNode childNode in node.Nodes)
            {
                treeViewData.Children.Add(TreeNodeToTreeViewData(childNode));
            }

            return treeViewData;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";
            openFileDialog.Title = "Open TreeView Data";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string jsonData = File.ReadAllText(openFileDialog.FileName);
                var treeViewDataList = JsonConvert.DeserializeObject<List<TreeViewData>>(jsonData);

                treeView1.Nodes.Clear();
                foreach (var treeViewData in treeViewDataList)
                {
                    TreeNode rootNode = TreeViewDataToTreeNode(treeViewData);
                    treeView1.Nodes.Add(rootNode);
                }
            }
            treeView1.ExpandAll();
        }

        private TreeNode TreeViewDataToTreeNode(TreeViewData treeViewData)
        {
            TreeNode rootNode = new TreeNode($"{treeViewData.Code}: {treeViewData.Description}");

            if (treeViewData.Children != null)
            {
                foreach (var child in treeViewData.Children)
                {
                    TreeNode childNode = TreeViewDataToTreeNode(child);
                    rootNode.Nodes.Add(childNode);
                }
            }

            return rootNode;
        }
    }
}
