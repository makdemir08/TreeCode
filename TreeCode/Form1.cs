using Newtonsoft.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TreeCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string code = System.String.Empty;
        string description = System.String.Empty;
        TreeViewData treeViewData = new();
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
            foreach (TreeNode node in treeView1.Nodes)
            {
                code = $"{TraverseTreeNodes(node, true)}";
                description = $"{TraverseTreeNodes(node, false)}";
                GetTreeView(node.Nodes);
                tbList.AppendText($"{code} {description}");
                tbList.AppendText(Environment.NewLine);
            }

        }


        private void GetTreeView(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                code = $"{code}{TraverseTreeNodes(node, true)}";
                description = $"{description} {TraverseTreeNodes(node, false)}";
                GetTreeView(node.Nodes);
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
            saveFileDialog.Filter = "Json Files (*.json)|*.json";
            saveFileDialog.Title = "Save TreeView Data";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadTreeViewData();
                SaveTreeViewData(treeViewData, saveFileDialog.FileName);
            }
        }
        private void SaveTreeViewData(TreeViewData data, string filePath)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, jsonData);
        }
        private class TreeViewData
        {
            public string Code { get; set; }
            public string Description { get; set; }
            public TreeViewData? Child { get; set; }
        }

        private void LoadTreeViewData()
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                code = $"{TraverseTreeNodes(node, true)}";
                description = $"{TraverseTreeNodes(node, false)}";
                treeViewData = new TreeViewData()
                {
                    Code = code,
                    Description = description,
                    Child = GetChildView(node.Nodes)
                };
            }
        }

        private TreeViewData? GetChildView(TreeNodeCollection nodes)
        {
            TreeViewData? data = null;
            foreach (TreeNode node in nodes)
            {
                code = $"{TraverseTreeNodes(node, true)}";
                description = $"{TraverseTreeNodes(node, false)}";
                data = new TreeViewData()
                {
                    Code = code,
                    Description = description,
                    Child = GetChildView(node.Nodes)
                };
            }
            return data;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";
            openFileDialog.Title = "Open TreeView Data";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // JSON dosyasını oku
                string jsonData = File.ReadAllText(openFileDialog.FileName);

                // JSON verilerini TreeViewData nesnesine dönüştür
                TreeViewData treeViewData = JsonConvert.DeserializeObject<TreeViewData>(jsonData);

                // TreeView'e verileri ekle
                treeView1.Nodes.Clear();
                TreeNode rootNode = new TreeNode($"{treeViewData.Code}: {treeViewData.Description}");
                AddNodesToTreeView(treeViewData.Child, rootNode);
                treeView1.Nodes.Add(rootNode);
            }
            treeView1.ExpandAll();
        }

        private void AddNodesToTreeView(TreeViewData data, TreeNode parentNode)
        {
            if (data == null)
            {
                return;
            }

            TreeNode newNode = new TreeNode($"{data.Code}: {data.Description}");
            parentNode.Nodes.Add(newNode);

            AddNodesToTreeView(data.Child, newNode);
        }
    }
}
