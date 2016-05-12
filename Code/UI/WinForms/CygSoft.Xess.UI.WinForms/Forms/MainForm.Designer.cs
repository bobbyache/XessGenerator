using CygSoft.Xess.UI.WinForms.Controls;
namespace CygSoft.Xess.UI.WinForms.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenRecentProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveProjectAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExportToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGenerateData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssFullPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstripTemplateList = new CygSoft.Xess.UI.WinForms.Controls.TemplateDropdownCtrl(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCreateProject = new System.Windows.Forms.ToolStripButton();
            this.btnOpenProject = new System.Windows.Forms.ToolStripButton();
            this.btnSaveProjectAs = new System.Windows.Forms.ToolStripButton();
            this.btnGenerateData = new CygSoft.Xess.UI.WinForms.Controls.GenerateDatasourceToolstripDropdown(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtDestinationFilePath = new System.Windows.Forms.ToolStripTextBox();
            this.btnSaveDefaultFile = new System.Windows.Forms.ToolStripButton();
            this.btnGetDifference = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.richTextOutput = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.progressConsole = new CygSoft.Xess.UI.WinForms.Controls.ProgressConsole();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.templateInfoCtrl1 = new CygSoft.Xess.UI.WinForms.Controls.TemplateInfoCtrl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuProject,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1229, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateProject,
            this.mnuOpenProject,
            this.mnuOpenRecentProject,
            this.toolStripMenuItem1,
            this.mnuSaveProjectAs,
            this.toolStripMenuItem5,
            this.mnuExportToFile,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuCreateProject
            // 
            this.mnuCreateProject.Name = "mnuCreateProject";
            this.mnuCreateProject.Size = new System.Drawing.Size(182, 22);
            this.mnuCreateProject.Text = "Create Project...";
            this.mnuCreateProject.Click += new System.EventHandler(this.mnuCreateProject_Click);
            // 
            // mnuOpenProject
            // 
            this.mnuOpenProject.Name = "mnuOpenProject";
            this.mnuOpenProject.Size = new System.Drawing.Size(182, 22);
            this.mnuOpenProject.Text = "Open Project...";
            this.mnuOpenProject.Click += new System.EventHandler(this.mnuOpenProject_Click);
            // 
            // mnuOpenRecentProject
            // 
            this.mnuOpenRecentProject.Name = "mnuOpenRecentProject";
            this.mnuOpenRecentProject.Size = new System.Drawing.Size(182, 22);
            this.mnuOpenRecentProject.Text = "Open Recent Project";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuSaveProjectAs
            // 
            this.mnuSaveProjectAs.Name = "mnuSaveProjectAs";
            this.mnuSaveProjectAs.Size = new System.Drawing.Size(182, 22);
            this.mnuSaveProjectAs.Text = "Save Project As...";
            this.mnuSaveProjectAs.Click += new System.EventHandler(this.mnuSaveProjectAs_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuExportToFile
            // 
            this.mnuExportToFile.Name = "mnuExportToFile";
            this.mnuExportToFile.Size = new System.Drawing.Size(182, 22);
            this.mnuExportToFile.Text = "Export to File";
            this.mnuExportToFile.Click += new System.EventHandler(this.mnuExportToFile_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(179, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mnuProject
            // 
            this.mnuProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGenerateData,
            this.mnuManageTemplates});
            this.mnuProject.Name = "mnuProject";
            this.mnuProject.Size = new System.Drawing.Size(56, 20);
            this.mnuProject.Text = "Project";
            // 
            // mnuGenerateData
            // 
            this.mnuGenerateData.Name = "mnuGenerateData";
            this.mnuGenerateData.Size = new System.Drawing.Size(193, 22);
            this.mnuGenerateData.Text = "Manage Datasources...";
            this.mnuGenerateData.Click += new System.EventHandler(this.mnuGenerateData_Click);
            // 
            // mnuManageTemplates
            // 
            this.mnuManageTemplates.Name = "mnuManageTemplates";
            this.mnuManageTemplates.Size = new System.Drawing.Size(193, 22);
            this.mnuManageTemplates.Text = "Manage Templates...";
            this.mnuManageTemplates.Click += new System.EventHandler(this.mnuManageTemplates_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(188, 22);
            this.mnuAbout.Text = "About Xess Generator";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssFullPath});
            this.statusStrip1.Location = new System.Drawing.Point(0, 769);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1229, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssFullPath
            // 
            this.tssFullPath.Name = "tssFullPath";
            this.tssFullPath.Size = new System.Drawing.Size(51, 17);
            this.tssFullPath.Text = "full path";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(57, 22);
            this.toolStripLabel1.Text = "Template";
            // 
            // tstripTemplateList
            // 
            this.tstripTemplateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tstripTemplateList.Name = "tstripTemplateList";
            this.tstripTemplateList.Size = new System.Drawing.Size(400, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateProject,
            this.btnOpenProject,
            this.btnSaveProjectAs,
            this.toolStripSeparator,
            this.toolStripLabel1,
            this.tstripTemplateList,
            this.btnGenerateData,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.txtDestinationFilePath,
            this.btnSaveDefaultFile,
            this.btnGetDifference,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1229, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCreateProject
            // 
            this.btnCreateProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreateProject.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateProject.Image")));
            this.btnCreateProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateProject.Name = "btnCreateProject";
            this.btnCreateProject.Size = new System.Drawing.Size(23, 22);
            this.btnCreateProject.Text = "&Create Project";
            this.btnCreateProject.Click += new System.EventHandler(this.btnCreateProject_Click);
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenProject.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenProject.Image")));
            this.btnOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(23, 22);
            this.btnOpenProject.Text = "&Open Project";
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // btnSaveProjectAs
            // 
            this.btnSaveProjectAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveProjectAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveProjectAs.Image")));
            this.btnSaveProjectAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveProjectAs.Name = "btnSaveProjectAs";
            this.btnSaveProjectAs.Size = new System.Drawing.Size(23, 22);
            this.btnSaveProjectAs.Text = "&Save Project As";
            this.btnSaveProjectAs.Click += new System.EventHandler(this.btnSaveProjectAs_Click);
            // 
            // btnGenerateData
            // 
            this.btnGenerateData.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateData.Image")));
            this.btnGenerateData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerateData.Name = "btnGenerateData";
            this.btnGenerateData.Size = new System.Drawing.Size(145, 22);
            this.btnGenerateData.Text = "Generate Datasource";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel2.Text = "Output:";
            // 
            // txtDestinationFilePath
            // 
            this.txtDestinationFilePath.Name = "txtDestinationFilePath";
            this.txtDestinationFilePath.ReadOnly = true;
            this.txtDestinationFilePath.Size = new System.Drawing.Size(200, 25);
            // 
            // btnSaveDefaultFile
            // 
            this.btnSaveDefaultFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveDefaultFile.Image")));
            this.btnSaveDefaultFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveDefaultFile.Name = "btnSaveDefaultFile";
            this.btnSaveDefaultFile.Size = new System.Drawing.Size(51, 22);
            this.btnSaveDefaultFile.Text = "Save";
            this.btnSaveDefaultFile.Click += new System.EventHandler(this.btnSaveDefaultFile_Click);
            // 
            // btnGetDifference
            // 
            this.btnGetDifference.Image = ((System.Drawing.Image)(resources.GetObject("btnGetDifference.Image")));
            this.btnGetDifference.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetDifference.Name = "btnGetDifference";
            this.btnGetDifference.Size = new System.Drawing.Size(46, 22);
            this.btnGetDifference.Text = "Diff";
            this.btnGetDifference.Click += new System.EventHandler(this.btnGetDifference_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 49);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.richTextOutput);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer.Size = new System.Drawing.Size(1229, 720);
            this.splitContainer.SplitterDistance = 358;
            this.splitContainer.TabIndex = 12;
            // 
            // richTextOutput
            // 
            this.richTextOutput.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.richTextOutput.AutoListPosition = null;
            this.richTextOutput.AutoListSelectedText = "a123";
            this.richTextOutput.AutoListVisible = false;
            this.richTextOutput.BackColor = System.Drawing.Color.White;
            this.richTextOutput.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.richTextOutput.CopyAsRTF = false;
            this.richTextOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextOutput.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextOutput.FontName = "Courier new";
            this.richTextOutput.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTextOutput.InfoTipCount = 1;
            this.richTextOutput.InfoTipPosition = null;
            this.richTextOutput.InfoTipSelectedIndex = 1;
            this.richTextOutput.InfoTipVisible = false;
            this.richTextOutput.Location = new System.Drawing.Point(0, 0);
            this.richTextOutput.LockCursorUpdate = false;
            this.richTextOutput.Name = "richTextOutput";
            this.richTextOutput.ReadOnly = true;
            this.richTextOutput.ShowScopeIndicator = false;
            this.richTextOutput.Size = new System.Drawing.Size(1229, 358);
            this.richTextOutput.SmoothScroll = false;
            this.richTextOutput.SplitView = false;
            this.richTextOutput.SplitviewH = -4;
            this.richTextOutput.SplitviewV = -4;
            this.richTextOutput.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.richTextOutput.TabIndex = 9;
            this.richTextOutput.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1229, 358);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.progressConsole);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1221, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generate Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // progressConsole
            // 
            this.progressConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressConsole.Location = new System.Drawing.Point(3, 3);
            this.progressConsole.Name = "progressConsole";
            this.progressConsole.Progress = 0;
            this.progressConsole.ProgressMaximum = 100;
            this.progressConsole.Size = new System.Drawing.Size(1215, 326);
            this.progressConsole.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.templateInfoCtrl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1221, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Template Information";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // templateInfoCtrl1
            // 
            this.templateInfoCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateInfoCtrl1.Location = new System.Drawing.Point(3, 3);
            this.templateInfoCtrl1.Name = "templateInfoCtrl1";
            this.templateInfoCtrl1.Size = new System.Drawing.Size(1215, 326);
            this.templateInfoCtrl1.TabIndex = 0;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 791);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "FileManagement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateProject;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenProject;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenRecentProject;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveProjectAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssFullPath;
        private System.Windows.Forms.ToolStripMenuItem mnuProject;
        private System.Windows.Forms.ToolStripMenuItem mnuGenerateData;
        private System.Windows.Forms.ToolStripMenuItem mnuManageTemplates;
        private System.Windows.Forms.ToolStripMenuItem mnuExportToFile;
        private System.Windows.Forms.ToolStripButton btnCreateProject;
        private System.Windows.Forms.ToolStripButton btnOpenProject;
        private System.Windows.Forms.ToolStripButton btnSaveProjectAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private TemplateDropdownCtrl tstripTemplateList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripButton btnSaveDefaultFile;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Alsing.Windows.Forms.SyntaxBoxControl richTextOutput;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ProgressConsole progressConsole;
        private System.Windows.Forms.TabPage tabPage2;
        private TemplateInfoCtrl templateInfoCtrl1;
        private GenerateDatasourceToolstripDropdown btnGenerateData;
        private System.Windows.Forms.ToolStripButton btnGetDifference;
        private System.Windows.Forms.ToolStripTextBox txtDestinationFilePath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}