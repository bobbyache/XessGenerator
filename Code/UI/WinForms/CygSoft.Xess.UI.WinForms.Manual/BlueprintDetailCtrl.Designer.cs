namespace CygSoft.Xess.UI.WinForms
{
    partial class BlueprintDetailCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlueprintDetailCtrl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboParts = new System.Windows.Forms.ToolStripComboBox();
            this.btnOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.trimAndGenerateNewLineBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateNewLineAfterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerEditor = new System.Windows.Forms.SplitContainer();
            this.editorCtrl = new System.Windows.Forms.RichTextBox();
            this.variablesListView = new System.Windows.Forms.ListView();
            this.colVariable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.resultsEditor = new System.Windows.Forms.RichTextBox();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditor)).BeginInit();
            this.splitContainerEditor.Panel1.SuspendLayout();
            this.splitContainerEditor.Panel2.SuspendLayout();
            this.splitContainerEditor.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint,
            this.toolStripSeparator,
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cboParts,
            this.btnOptions});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(730, 25);
            this.toolStrip.TabIndex = 7;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 22);
            this.btnPrint.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCut
            // 
            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCut.Image = ((System.Drawing.Image)(resources.GetObject("btnCut.Image")));
            this.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(23, 22);
            this.btnCut.Text = "C&ut";
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(23, 22);
            this.btnCopy.Text = "&Copy";
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(23, 22);
            this.btnPaste.Text = "&Paste";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel1.Text = "Part:";
            // 
            // cboParts
            // 
            this.cboParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParts.Items.AddRange(new object[] {
            "Header",
            "Body",
            "Footer"});
            this.cboParts.Name = "cboParts";
            this.cboParts.Size = new System.Drawing.Size(121, 25);
            // 
            // btnOptions
            // 
            this.btnOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trimAndGenerateNewLineBeforeToolStripMenuItem,
            this.generateNewLineAfterToolStripMenuItem,
            this.trimTextToolStripMenuItem});
            this.btnOptions.Enabled = false;
            this.btnOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOptions.Image")));
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(78, 22);
            this.btnOptions.Text = "Options";
            // 
            // trimAndGenerateNewLineBeforeToolStripMenuItem
            // 
            this.trimAndGenerateNewLineBeforeToolStripMenuItem.Checked = true;
            this.trimAndGenerateNewLineBeforeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trimAndGenerateNewLineBeforeToolStripMenuItem.Name = "trimAndGenerateNewLineBeforeToolStripMenuItem";
            this.trimAndGenerateNewLineBeforeToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.trimAndGenerateNewLineBeforeToolStripMenuItem.Text = "Generate new line before";
            // 
            // generateNewLineAfterToolStripMenuItem
            // 
            this.generateNewLineAfterToolStripMenuItem.Checked = true;
            this.generateNewLineAfterToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.generateNewLineAfterToolStripMenuItem.Name = "generateNewLineAfterToolStripMenuItem";
            this.generateNewLineAfterToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.generateNewLineAfterToolStripMenuItem.Text = "Generate new line after";
            // 
            // trimTextToolStripMenuItem
            // 
            this.trimTextToolStripMenuItem.Checked = true;
            this.trimTextToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trimTextToolStripMenuItem.Name = "trimTextToolStripMenuItem";
            this.trimTextToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.trimTextToolStripMenuItem.Text = "Trim text";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 25);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerEditor);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControl1);
            this.splitContainerMain.Size = new System.Drawing.Size(730, 481);
            this.splitContainerMain.SplitterDistance = 295;
            this.splitContainerMain.TabIndex = 8;
            // 
            // splitContainerEditor
            // 
            this.splitContainerEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEditor.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEditor.Name = "splitContainerEditor";
            // 
            // splitContainerEditor.Panel1
            // 
            this.splitContainerEditor.Panel1.Controls.Add(this.editorCtrl);
            // 
            // splitContainerEditor.Panel2
            // 
            this.splitContainerEditor.Panel2.Controls.Add(this.variablesListView);
            this.splitContainerEditor.Size = new System.Drawing.Size(730, 295);
            this.splitContainerEditor.SplitterDistance = 533;
            this.splitContainerEditor.TabIndex = 5;
            // 
            // editorCtrl
            // 
            this.editorCtrl.AcceptsTab = true;
            this.editorCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorCtrl.Location = new System.Drawing.Point(0, 0);
            this.editorCtrl.Name = "editorCtrl";
            this.editorCtrl.Size = new System.Drawing.Size(533, 295);
            this.editorCtrl.TabIndex = 3;
            this.editorCtrl.Text = "";
            // 
            // variablesListView
            // 
            this.variablesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVariable});
            this.variablesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variablesListView.Location = new System.Drawing.Point(0, 0);
            this.variablesListView.Name = "variablesListView";
            this.variablesListView.Size = new System.Drawing.Size(193, 295);
            this.variablesListView.TabIndex = 0;
            this.variablesListView.UseCompatibleStateImageBehavior = false;
            this.variablesListView.View = System.Windows.Forms.View.Details;
            // 
            // colVariable
            // 
            this.colVariable.Text = "Variable";
            this.colVariable.Width = 172;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(730, 182);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(722, 156);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Grid";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(716, 150);
            this.dataGridView.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.resultsEditor);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(722, 156);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Generated Text";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // resultsEditor
            // 
            this.resultsEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsEditor.Location = new System.Drawing.Point(3, 3);
            this.resultsEditor.Name = "resultsEditor";
            this.resultsEditor.Size = new System.Drawing.Size(716, 105);
            this.resultsEditor.TabIndex = 0;
            this.resultsEditor.Text = "";
            // 
            // BlueprintDetailCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStrip);
            this.Name = "BlueprintDetailCtrl";
            this.Size = new System.Drawing.Size(730, 506);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerEditor.Panel1.ResumeLayout(false);
            this.splitContainerEditor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditor)).EndInit();
            this.splitContainerEditor.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton btnCut;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboParts;
        private System.Windows.Forms.ToolStripDropDownButton btnOptions;
        private System.Windows.Forms.ToolStripMenuItem trimAndGenerateNewLineBeforeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateNewLineAfterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trimTextToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerEditor;
        private System.Windows.Forms.RichTextBox editorCtrl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox resultsEditor;
        private System.Windows.Forms.ListView variablesListView;
        private System.Windows.Forms.ColumnHeader colVariable;

    }
}
