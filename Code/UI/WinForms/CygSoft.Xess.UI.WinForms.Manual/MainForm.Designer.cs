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
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCellSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.blueprintSyntaxBox = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.resultsSyntaxDoc = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGrid = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.resultsSyntaxBox = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.mnuGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGridClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGridClearSelectedRows = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGridRemoveOrphanColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuGrid,
            this.mnuSettings});
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
            this.mnuQuit.Click += new System.EventHandler(this.mnuQuit_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCellSelectAll});
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(61, 20);
            this.mnuSettings.Text = "Settings";
            // 
            // mnuCellSelectAll
            // 
            this.mnuCellSelectAll.Checked = true;
            this.mnuCellSelectAll.CheckOnClick = true;
            this.mnuCellSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuCellSelectAll.Name = "mnuCellSelectAll";
            this.mnuCellSelectAll.Size = new System.Drawing.Size(161, 22);
            this.mnuCellSelectAll.Text = "Select Entire Cell";
            this.mnuCellSelectAll.Click += new System.EventHandler(this.mnuCellSelectAll_Click);
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
            this.splitContainerMain.Panel1.Controls.Add(this.blueprintSyntaxBox);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControl);
            this.splitContainerMain.Size = new System.Drawing.Size(919, 506);
            this.splitContainerMain.SplitterDistance = 191;
            this.splitContainerMain.TabIndex = 5;
            // 
            // blueprintSyntaxBox
            // 
            this.blueprintSyntaxBox.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.blueprintSyntaxBox.AutoListPosition = null;
            this.blueprintSyntaxBox.AutoListSelectedText = "a123";
            this.blueprintSyntaxBox.AutoListVisible = false;
            this.blueprintSyntaxBox.BackColor = System.Drawing.Color.White;
            this.blueprintSyntaxBox.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.blueprintSyntaxBox.CopyAsRTF = false;
            this.blueprintSyntaxBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blueprintSyntaxBox.Document = this.resultsSyntaxDoc;
            this.blueprintSyntaxBox.FontName = "Courier new";
            this.blueprintSyntaxBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.blueprintSyntaxBox.InfoTipCount = 1;
            this.blueprintSyntaxBox.InfoTipPosition = null;
            this.blueprintSyntaxBox.InfoTipSelectedIndex = 1;
            this.blueprintSyntaxBox.InfoTipVisible = false;
            this.blueprintSyntaxBox.Location = new System.Drawing.Point(0, 0);
            this.blueprintSyntaxBox.LockCursorUpdate = false;
            this.blueprintSyntaxBox.Name = "blueprintSyntaxBox";
            this.blueprintSyntaxBox.ShowScopeIndicator = false;
            this.blueprintSyntaxBox.Size = new System.Drawing.Size(919, 191);
            this.blueprintSyntaxBox.SmoothScroll = false;
            this.blueprintSyntaxBox.SplitView = false;
            this.blueprintSyntaxBox.SplitviewH = -4;
            this.blueprintSyntaxBox.SplitviewV = -4;
            this.blueprintSyntaxBox.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.blueprintSyntaxBox.TabIndex = 1;
            this.blueprintSyntaxBox.Text = "syntaxBoxControl1";
            this.blueprintSyntaxBox.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            this.blueprintSyntaxBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.blueprintSyntaxBox_KeyDown);
            this.blueprintSyntaxBox.Leave += new System.EventHandler(this.blueprintSyntaxBox_Leave);
            // 
            // resultsSyntaxDoc
            // 
            this.resultsSyntaxDoc.Lines = new string[] {
        ""};
            this.resultsSyntaxDoc.MaxUndoBufferSize = 1000;
            this.resultsSyntaxDoc.Modified = false;
            this.resultsSyntaxDoc.UndoStep = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGrid);
            this.tabControl.Controls.Add(this.tabResults);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(919, 311);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.dataGridView);
            this.tabGrid.Location = new System.Drawing.Point(4, 22);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrid.Size = new System.Drawing.Size(911, 285);
            this.tabGrid.TabIndex = 0;
            this.tabGrid.Text = "Data Grid";
            this.tabGrid.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(905, 279);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEnter);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.resultsSyntaxBox);
            this.tabResults.Location = new System.Drawing.Point(4, 22);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(911, 285);
            this.tabResults.TabIndex = 1;
            this.tabResults.Text = "Generated Text";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // resultsSyntaxBox
            // 
            this.resultsSyntaxBox.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.resultsSyntaxBox.AutoListPosition = null;
            this.resultsSyntaxBox.AutoListSelectedText = "a123";
            this.resultsSyntaxBox.AutoListVisible = false;
            this.resultsSyntaxBox.BackColor = System.Drawing.Color.White;
            this.resultsSyntaxBox.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.resultsSyntaxBox.CopyAsRTF = false;
            this.resultsSyntaxBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsSyntaxBox.Document = this.syntaxDocument1;
            this.resultsSyntaxBox.FontName = "Courier new";
            this.resultsSyntaxBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.resultsSyntaxBox.InfoTipCount = 1;
            this.resultsSyntaxBox.InfoTipPosition = null;
            this.resultsSyntaxBox.InfoTipSelectedIndex = 1;
            this.resultsSyntaxBox.InfoTipVisible = false;
            this.resultsSyntaxBox.Location = new System.Drawing.Point(3, 3);
            this.resultsSyntaxBox.LockCursorUpdate = false;
            this.resultsSyntaxBox.Name = "resultsSyntaxBox";
            this.resultsSyntaxBox.ShowScopeIndicator = false;
            this.resultsSyntaxBox.Size = new System.Drawing.Size(905, 279);
            this.resultsSyntaxBox.SmoothScroll = false;
            this.resultsSyntaxBox.SplitView = false;
            this.resultsSyntaxBox.SplitviewH = -4;
            this.resultsSyntaxBox.SplitviewV = -4;
            this.resultsSyntaxBox.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.resultsSyntaxBox.TabIndex = 0;
            this.resultsSyntaxBox.Text = "syntaxBoxControl1";
            this.resultsSyntaxBox.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // mnuGrid
            // 
            this.mnuGrid.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGridClear,
            this.mnuGridClearSelectedRows,
            this.toolStripMenuItem1,
            this.mnuGridRemoveOrphanColumns});
            this.mnuGrid.Name = "mnuGrid";
            this.mnuGrid.Size = new System.Drawing.Size(41, 20);
            this.mnuGrid.Text = "Grid";
            // 
            // mnuGridClear
            // 
            this.mnuGridClear.Name = "mnuGridClear";
            this.mnuGridClear.Size = new System.Drawing.Size(220, 22);
            this.mnuGridClear.Text = "Clear";
            this.mnuGridClear.Click += new System.EventHandler(this.mnuGridClear_Click);
            // 
            // mnuGridClearSelectedRows
            // 
            this.mnuGridClearSelectedRows.Name = "mnuGridClearSelectedRows";
            this.mnuGridClearSelectedRows.Size = new System.Drawing.Size(220, 22);
            this.mnuGridClearSelectedRows.Text = "Clear Selected Rows";
            this.mnuGridClearSelectedRows.Click += new System.EventHandler(this.mnuGridClearSelectedRows_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 6);
            // 
            // mnuGridRemoveOrphanColumns
            // 
            this.mnuGridRemoveOrphanColumns.Name = "mnuGridRemoveOrphanColumns";
            this.mnuGridRemoveOrphanColumns.Size = new System.Drawing.Size(220, 22);
            this.mnuGridRemoveOrphanColumns.Text = "Remove orphaned columns";
            this.mnuGridRemoveOrphanColumns.Click += new System.EventHandler(this.mnuGridRemoveOrphanColumns_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 530);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Xess Generator - Manual Tool (ALT + V to convert to Variable)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabResults.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGrid;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuQuit;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private Alsing.SourceCode.SyntaxDocument resultsSyntaxDoc;
        private Alsing.Windows.Forms.SyntaxBoxControl resultsSyntaxBox;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private Alsing.Windows.Forms.SyntaxBoxControl blueprintSyntaxBox;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuCellSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuGridClear;
        private System.Windows.Forms.ToolStripMenuItem mnuGridClearSelectedRows;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuGridRemoveOrphanColumns;
    }
}

