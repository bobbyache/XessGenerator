namespace CygSoft.Xess.UI.WinForms.Controls
{
    partial class TemplateInfoCtrl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textboxDescription = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpageDataMatrix = new System.Windows.Forms.TabPage();
            this.templateView1 = new CygSoft.Xess.UI.WinForms.Controls.TemplateView();
            this.templateDataCtrl1 = new CygSoft.Xess.UI.WinForms.Controls.TemplateDataCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabpageDataMatrix.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.templateView1);
            this.splitContainer1.Panel1.Controls.Add(this.textboxDescription);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(705, 241);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 0;
            // 
            // textboxDescription
            // 
            this.textboxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxDescription.Location = new System.Drawing.Point(0, 176);
            this.textboxDescription.Multiline = true;
            this.textboxDescription.Name = "textboxDescription";
            this.textboxDescription.ReadOnly = true;
            this.textboxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxDescription.Size = new System.Drawing.Size(233, 65);
            this.textboxDescription.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabpageDataMatrix);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(466, 241);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabpageDataMatrix
            // 
            this.tabpageDataMatrix.Controls.Add(this.templateDataCtrl1);
            this.tabpageDataMatrix.Location = new System.Drawing.Point(4, 22);
            this.tabpageDataMatrix.Name = "tabpageDataMatrix";
            this.tabpageDataMatrix.Size = new System.Drawing.Size(458, 215);
            this.tabpageDataMatrix.TabIndex = 1;
            this.tabpageDataMatrix.Text = "Data Matrix";
            this.tabpageDataMatrix.UseVisualStyleBackColor = true;
            // 
            // templateView1
            // 
            this.templateView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateView1.Location = new System.Drawing.Point(3, 3);
            this.templateView1.Name = "templateView1";
            this.templateView1.Size = new System.Drawing.Size(229, 167);
            this.templateView1.TabIndex = 2;
            this.templateView1.UserEditable = false;
            this.templateView1.ItemSelected += new System.EventHandler(this.templateView1_ItemSelected);
            // 
            // templateDataCtrl1
            // 
            this.templateDataCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.templateDataCtrl1.Name = "templateDataCtrl1";
            this.templateDataCtrl1.Size = new System.Drawing.Size(458, 215);
            this.templateDataCtrl1.TabIndex = 0;
            // 
            // TemplateInfoCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TemplateInfoCtrl";
            this.Size = new System.Drawing.Size(705, 241);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabpageDataMatrix.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textboxDescription;
        private TemplateView templateView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabpageDataMatrix;
        private TemplateDataCtrl templateDataCtrl1;
    }
}
