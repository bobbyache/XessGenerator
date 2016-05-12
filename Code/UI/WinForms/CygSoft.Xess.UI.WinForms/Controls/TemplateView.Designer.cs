namespace CygSoft.Xess.UI.WinForms.Controls
{
    partial class TemplateView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Script Header");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Actual Inserts");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Script Footer");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Template: Insert Deposit Rows", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Script Header");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Actual Inserts");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Script Footer");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Template: Insert Reimbursement Rows", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Script Header");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Actual Updates");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Script Footer");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Template: Update NTBankAccountRows", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateView));
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnUp = new System.Windows.Forms.ToolStripButton();
            this.btnDown = new System.Windows.Forms.ToolStripButton();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGenerate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList1;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Script Header";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Actual Inserts";
            treeNode3.Name = "Node5";
            treeNode3.Text = "Script Footer";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Template: Insert Deposit Rows";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Script Header";
            treeNode6.Name = "Node7";
            treeNode6.Text = "Actual Inserts";
            treeNode7.Name = "Node8";
            treeNode7.Text = "Script Footer";
            treeNode8.Name = "blah4";
            treeNode8.Text = "Template: Insert Reimbursement Rows";
            treeNode9.Name = "Node9";
            treeNode9.Text = "Script Header";
            treeNode10.Name = "Node10";
            treeNode10.Text = "Actual Updates";
            treeNode11.Name = "Node11";
            treeNode11.Text = "Script Footer";
            treeNode12.Name = "balh";
            treeNode12.Text = "Template: Update NTBankAccountRows";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8,
            treeNode12});
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(429, 516);
            this.treeView.TabIndex = 13;
            this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Section");
            this.imageList1.Images.SetKeyName(1, "Template");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUp,
            this.btnDown});
            this.toolStrip1.Location = new System.Drawing.Point(432, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 516);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnUp
            // 
            this.btnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(21, 20);
            this.btnUp.Text = "Move Up";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(21, 20);
            this.btnDown.Text = "Move Down";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit,
            this.menuGenerate});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(152, 22);
            this.menuEdit.Text = "Edit...";
            // 
            // menuGenerate
            // 
            this.menuGenerate.Name = "menuGenerate";
            this.menuGenerate.Size = new System.Drawing.Size(152, 22);
            this.menuGenerate.Text = "Generate...";
            // 
            // TemplateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.treeView);
            this.Name = "TemplateView";
            this.Size = new System.Drawing.Size(456, 516);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnUp;
        private System.Windows.Forms.ToolStripButton btnDown;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuGenerate;
    }
}
