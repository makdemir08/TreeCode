namespace TreeCode
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            treeView1 = new TreeView();
            btnSave = new Button();
            tbCode = new TextBox();
            tbDescription = new TextBox();
            lblCode = new Label();
            lblDescription = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreateList = new Button();
            rbRoot = new RadioButton();
            rbSelectedAddChild = new RadioButton();
            rbSelectedUpdate = new RadioButton();
            tbList = new TextBox();
            btnImport = new Button();
            btnExport = new Button();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeView1.Location = new Point(12, 35);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(392, 403);
            treeView1.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Location = new Point(713, 122);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tbCode
            // 
            tbCode.Location = new Point(484, 64);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(100, 23);
            tbCode.TabIndex = 2;
            // 
            // tbDescription
            // 
            tbDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDescription.Location = new Point(484, 93);
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(304, 23);
            tbDescription.TabIndex = 3;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(410, 72);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(35, 15);
            lblCode.TabIndex = 4;
            lblCode.Text = "Code";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(410, 101);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 5;
            lblDescription.Text = "Description";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(491, 37);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(410, 37);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCreateList
            // 
            btnCreateList.Location = new Point(572, 35);
            btnCreateList.Name = "btnCreateList";
            btnCreateList.Size = new Size(75, 23);
            btnCreateList.TabIndex = 8;
            btnCreateList.Text = "Create List";
            btnCreateList.UseVisualStyleBackColor = true;
            btnCreateList.Click += btnCreateList_Click;
            // 
            // rbRoot
            // 
            rbRoot.AutoSize = true;
            rbRoot.Checked = true;
            rbRoot.Location = new Point(410, 12);
            rbRoot.Name = "rbRoot";
            rbRoot.Size = new Size(75, 19);
            rbRoot.TabIndex = 9;
            rbRoot.TabStop = true;
            rbRoot.Text = "Add Root";
            rbRoot.UseVisualStyleBackColor = true;
            // 
            // rbSelectedAddChild
            // 
            rbSelectedAddChild.AutoSize = true;
            rbSelectedAddChild.Location = new Point(491, 12);
            rbSelectedAddChild.Name = "rbSelectedAddChild";
            rbSelectedAddChild.Size = new Size(136, 19);
            rbSelectedAddChild.TabIndex = 10;
            rbSelectedAddChild.Text = "Add child to selected";
            rbSelectedAddChild.UseVisualStyleBackColor = true;
            // 
            // rbSelectedUpdate
            // 
            rbSelectedUpdate.AutoSize = true;
            rbSelectedUpdate.Location = new Point(633, 12);
            rbSelectedUpdate.Name = "rbSelectedUpdate";
            rbSelectedUpdate.Size = new Size(110, 19);
            rbSelectedUpdate.TabIndex = 11;
            rbSelectedUpdate.Text = "Selected Update";
            rbSelectedUpdate.UseVisualStyleBackColor = true;
            // 
            // tbList
            // 
            tbList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbList.Location = new Point(410, 158);
            tbList.Multiline = true;
            tbList.Name = "tbList";
            tbList.Size = new Size(378, 280);
            tbList.TabIndex = 12;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(12, 6);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(75, 23);
            btnImport.TabIndex = 13;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(93, 6);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 23);
            btnExport.TabIndex = 14;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExport);
            Controls.Add(btnImport);
            Controls.Add(tbList);
            Controls.Add(rbSelectedUpdate);
            Controls.Add(rbSelectedAddChild);
            Controls.Add(rbRoot);
            Controls.Add(btnCreateList);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(lblDescription);
            Controls.Add(lblCode);
            Controls.Add(tbDescription);
            Controls.Add(tbCode);
            Controls.Add(btnSave);
            Controls.Add(treeView1);
            Name = "Form1";
            Text = "Tree Code Generator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Button btnSave;
        private TextBox tbCode;
        private TextBox tbDescription;
        private Label lblCode;
        private Label lblDescription;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCreateList;
        private RadioButton rbRoot;
        private RadioButton rbSelectedAddChild;
        private RadioButton rbSelectedUpdate;
        private TextBox tbList;
        private Button btnImport;
        private Button btnExport;
    }
}
