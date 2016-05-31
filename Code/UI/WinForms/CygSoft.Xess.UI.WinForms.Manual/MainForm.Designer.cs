namespace CygSoft.Xess.UI.WinForms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdateVariables = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGenerate = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerEditor = new System.Windows.Forms.SplitContainer();
            this.editorCtrl = new System.Windows.Forms.RichTextBox();
            this.variablesListCtrl = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.resultsEditor = new System.Windows.Forms.RichTextBox();
            this.columnMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dateGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAIDGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nULLGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numericGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.columnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.operationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(919, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.toolStripMenuItem3,
            this.mnuQuit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project...";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project...";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuQuit
            // 
            this.mnuQuit.Name = "mnuQuit";
            this.mnuQuit.Size = new System.Drawing.Size(152, 22);
            this.mnuQuit.Text = "Quit";
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUpdateVariables,
            this.menuGenerate});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // menuUpdateVariables
            // 
            this.menuUpdateVariables.Name = "menuUpdateVariables";
            this.menuUpdateVariables.Size = new System.Drawing.Size(162, 22);
            this.menuUpdateVariables.Text = "Update Variables";
            this.menuUpdateVariables.Click += new System.EventHandler(this.menuUpdateVariables_Click);
            // 
            // menuGenerate
            // 
            this.menuGenerate.Name = "menuGenerate";
            this.menuGenerate.Size = new System.Drawing.Size(162, 22);
            this.menuGenerate.Text = "Generate";
            this.menuGenerate.Click += new System.EventHandler(this.menuGenerate_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
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
            this.splitContainerMain.Size = new System.Drawing.Size(919, 506);
            this.splitContainerMain.SplitterDistance = 311;
            this.splitContainerMain.TabIndex = 5;
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
            this.splitContainerEditor.Panel2.Controls.Add(this.variablesListCtrl);
            this.splitContainerEditor.Size = new System.Drawing.Size(919, 311);
            this.splitContainerEditor.SplitterDistance = 671;
            this.splitContainerEditor.TabIndex = 5;
            // 
            // editorCtrl
            // 
            this.editorCtrl.AcceptsTab = true;
            this.editorCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorCtrl.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editorCtrl.Location = new System.Drawing.Point(0, 0);
            this.editorCtrl.Name = "editorCtrl";
            this.editorCtrl.Size = new System.Drawing.Size(671, 311);
            this.editorCtrl.TabIndex = 3;
            this.editorCtrl.Text = "";
            this.editorCtrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editorCtrl_KeyDown);
            // 
            // variablesListCtrl
            // 
            this.variablesListCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variablesListCtrl.FormattingEnabled = true;
            this.variablesListCtrl.Location = new System.Drawing.Point(0, 0);
            this.variablesListCtrl.Name = "variablesListCtrl";
            this.variablesListCtrl.Size = new System.Drawing.Size(244, 311);
            this.variablesListCtrl.TabIndex = 4;
            this.variablesListCtrl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.variablesListCtrl_MouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(919, 191);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(911, 165);
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
            this.dataGridView.Size = new System.Drawing.Size(905, 159);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEnter);
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.resultsEditor);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(911, 165);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Generated Text";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // resultsEditor
            // 
            this.resultsEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsEditor.Location = new System.Drawing.Point(3, 3);
            this.resultsEditor.Name = "resultsEditor";
            this.resultsEditor.Size = new System.Drawing.Size(905, 159);
            this.resultsEditor.TabIndex = 0;
            this.resultsEditor.Text = "";
            // 
            // columnMenu
            // 
            this.columnMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateGeneratorToolStripMenuItem,
            this.sAIDGeneratorToolStripMenuItem,
            this.nULLGeneratorToolStripMenuItem,
            this.numericGeneratorToolStripMenuItem});
            this.columnMenu.Name = "columnMenu";
            this.columnMenu.Size = new System.Drawing.Size(185, 92);
            // 
            // dateGeneratorToolStripMenuItem
            // 
            this.dateGeneratorToolStripMenuItem.Name = "dateGeneratorToolStripMenuItem";
            this.dateGeneratorToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.dateGeneratorToolStripMenuItem.Text = "Date Generator...";
            // 
            // sAIDGeneratorToolStripMenuItem
            // 
            this.sAIDGeneratorToolStripMenuItem.Name = "sAIDGeneratorToolStripMenuItem";
            this.sAIDGeneratorToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.sAIDGeneratorToolStripMenuItem.Text = "SA ID Generator";
            // 
            // nULLGeneratorToolStripMenuItem
            // 
            this.nULLGeneratorToolStripMenuItem.Name = "nULLGeneratorToolStripMenuItem";
            this.nULLGeneratorToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.nULLGeneratorToolStripMenuItem.Text = "NULL Generator";
            // 
            // numericGeneratorToolStripMenuItem
            // 
            this.numericGeneratorToolStripMenuItem.Name = "numericGeneratorToolStripMenuItem";
            this.numericGeneratorToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.numericGeneratorToolStripMenuItem.Text = "Numeric Generator...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 530);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Xess Generator - Manual Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
            this.columnMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerEditor;
        private System.Windows.Forms.RichTextBox editorCtrl;
        private System.Windows.Forms.ListBox variablesListCtrl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox resultsEditor;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuUpdateVariables;
        private System.Windows.Forms.ToolStripMenuItem menuGenerate;
        private System.Windows.Forms.ContextMenuStrip columnMenu;
        private System.Windows.Forms.ToolStripMenuItem dateGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAIDGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nULLGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numericGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuQuit;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
    }
}

