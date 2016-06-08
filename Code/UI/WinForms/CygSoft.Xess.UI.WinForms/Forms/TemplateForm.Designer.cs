using CygSoft.Xess.UI.WinForms.Controls;
namespace CygSoft.Xess.UI.WinForms.Forms
{
    partial class TemplateForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.templateView1 = new CygSoft.Xess.UI.WinForms.Controls.TemplateView();
            this.templateCtrl1 = new CygSoft.Xess.UI.WinForms.Controls.TemplateCtrl();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuAddTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddTemplateSection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnClone = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuCloneTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloneTemplateSection = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(805, 421);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(724, 421);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.templateCtrl1);
            this.splitContainer1.Size = new System.Drawing.Size(877, 387);
            this.splitContainer1.SplitterDistance = 286;
            this.splitContainer1.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.templateView1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 387);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Templates and Sections";
            // 
            // templateView1
            // 
            this.templateView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateView1.Location = new System.Drawing.Point(6, 19);
            this.templateView1.Name = "templateView1";
            this.templateView1.Size = new System.Drawing.Size(274, 361);
            this.templateView1.TabIndex = 0;
            this.templateView1.UserEditable = true;
            // 
            // templateCtrl1
            // 
            this.templateCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateCtrl1.Location = new System.Drawing.Point(0, 0);
            this.templateCtrl1.Name = "templateCtrl1";
            this.templateCtrl1.Size = new System.Drawing.Size(587, 387);
            this.templateCtrl1.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDelete,
            this.btnClone});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(884, 25);
            this.toolStrip2.TabIndex = 17;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            this.btnAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddTemplate,
            this.mnuAddTemplateSection});
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 22);
            this.btnAdd.Text = "Add";
            this.btnAdd.ToolTipText = "Add";
            // 
            // mnuAddTemplate
            // 
            this.mnuAddTemplate.Name = "mnuAddTemplate";
            this.mnuAddTemplate.Size = new System.Drawing.Size(191, 22);
            this.mnuAddTemplate.Text = "Add Template";
            this.mnuAddTemplate.Click += new System.EventHandler(this.btnAddTemplate_Click);
            // 
            // mnuAddTemplateSection
            // 
            this.mnuAddTemplateSection.Name = "mnuAddTemplateSection";
            this.mnuAddTemplateSection.Size = new System.Drawing.Size(191, 22);
            this.mnuAddTemplateSection.Text = "Add Template Section";
            this.mnuAddTemplateSection.Click += new System.EventHandler(this.mnuAddTemplateSection_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.ToolTipText = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClone
            // 
            this.btnClone.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCloneTemplate,
            this.mnuCloneTemplateSection});
            this.btnClone.Image = ((System.Drawing.Image)(resources.GetObject("btnClone.Image")));
            this.btnClone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(67, 22);
            this.btnClone.Text = "Clone";
            // 
            // mnuCloneTemplate
            // 
            this.mnuCloneTemplate.Name = "mnuCloneTemplate";
            this.mnuCloneTemplate.Size = new System.Drawing.Size(200, 22);
            this.mnuCloneTemplate.Text = "Clone Template";
            this.mnuCloneTemplate.Click += new System.EventHandler(this.mnuCloneTemplate_Click);
            // 
            // mnuCloneTemplateSection
            // 
            this.mnuCloneTemplateSection.Name = "mnuCloneTemplateSection";
            this.mnuCloneTemplateSection.Size = new System.Drawing.Size(200, 22);
            this.mnuCloneTemplateSection.Text = "Clone Template Section";
            this.mnuCloneTemplateSection.Click += new System.EventHandler(this.mnuCloneTemplateSection_Click);
            // 
            // TemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 449);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "TemplateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Template Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemplateManager_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton btnAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuAddTemplate;
        private System.Windows.Forms.ToolStripMenuItem mnuAddTemplateSection;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private TemplateView templateView1;
        private TemplateCtrl templateCtrl1;
        private System.Windows.Forms.ToolStripDropDownButton btnClone;
        private System.Windows.Forms.ToolStripMenuItem mnuCloneTemplate;
        private System.Windows.Forms.ToolStripMenuItem mnuCloneTemplateSection;

    }
}