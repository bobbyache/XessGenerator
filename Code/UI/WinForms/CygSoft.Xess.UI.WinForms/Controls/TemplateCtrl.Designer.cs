namespace CygSoft.Xess.UI.WinForms.Controls
{
    partial class TemplateCtrl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTemplate = new System.Windows.Forms.TabPage();
            this.templateEdit = new TemplateEditCtrl();
            this.tabPageSection = new System.Windows.Forms.TabPage();
            this.sectionEdit = new SectionEditCtrl();
            this.tabControl1.SuspendLayout();
            this.tabPageTemplate.SuspendLayout();
            this.tabPageSection.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTemplate);
            this.tabControl1.Controls.Add(this.tabPageSection);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(653, 290);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageTemplate
            // 
            this.tabPageTemplate.Controls.Add(this.templateEdit);
            this.tabPageTemplate.Location = new System.Drawing.Point(4, 22);
            this.tabPageTemplate.Name = "tabPageTemplate";
            this.tabPageTemplate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTemplate.Size = new System.Drawing.Size(645, 264);
            this.tabPageTemplate.TabIndex = 0;
            this.tabPageTemplate.Text = "Template";
            this.tabPageTemplate.UseVisualStyleBackColor = true;
            // 
            // templateEdit
            // 
            this.templateEdit.CurrentTemplate = null;
            this.templateEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateEdit.Location = new System.Drawing.Point(3, 3);
            this.templateEdit.Name = "templateEdit";
            this.templateEdit.Size = new System.Drawing.Size(639, 258);
            this.templateEdit.TabIndex = 1;
            // 
            // tabPageSection
            // 
            this.tabPageSection.Controls.Add(this.sectionEdit);
            this.tabPageSection.Location = new System.Drawing.Point(4, 22);
            this.tabPageSection.Name = "tabPageSection";
            this.tabPageSection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSection.Size = new System.Drawing.Size(645, 339);
            this.tabPageSection.TabIndex = 1;
            this.tabPageSection.Text = "Section";
            this.tabPageSection.UseVisualStyleBackColor = true;
            // 
            // sectionEdit
            // 
            this.sectionEdit.CurrentSection = null;
            this.sectionEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectionEdit.Location = new System.Drawing.Point(3, 3);
            this.sectionEdit.Name = "sectionEdit";
            this.sectionEdit.Size = new System.Drawing.Size(639, 333);
            this.sectionEdit.TabIndex = 2;
            // 
            // TemplateCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TemplateCtrl";
            this.Size = new System.Drawing.Size(653, 290);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTemplate.ResumeLayout(false);
            this.tabPageSection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTemplate;
        private System.Windows.Forms.TabPage tabPageSection;
        private TemplateEditCtrl templateEdit;
        private SectionEditCtrl sectionEdit;
    }
}
