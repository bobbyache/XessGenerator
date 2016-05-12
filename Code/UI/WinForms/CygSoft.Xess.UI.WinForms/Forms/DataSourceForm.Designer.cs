using CygSoft.Xess.UI.WinForms.Controls;
namespace CygSoft.Xess.UI.WinForms.Forms
{
    partial class DataSourceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataSourceForm));
            this.lvwDataSources = new System.Windows.Forms.ListView();
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAddExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSqlServer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddWindowsFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.btnClearSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGenerateSelection = new System.Windows.Forms.ToolStripButton();
            this.btnOpenDatasourceFile = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.ToolStripButton();
            this.progressConsole1 = new CygSoft.Xess.UI.WinForms.Controls.ProgressConsole();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwDataSources
            // 
            this.lvwDataSources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDataSources.CheckBoxes = true;
            this.lvwDataSources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle,
            this.colType});
            this.lvwDataSources.Location = new System.Drawing.Point(12, 34);
            this.lvwDataSources.Name = "lvwDataSources";
            this.lvwDataSources.Size = new System.Drawing.Size(834, 255);
            this.lvwDataSources.TabIndex = 0;
            this.lvwDataSources.UseCompatibleStateImageBehavior = false;
            this.lvwDataSources.View = System.Windows.Forms.View.Details;
            // 
            // colTitle
            // 
            this.colTitle.Width = 300;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 100;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnClone,
            this.toolStripSeparator1,
            this.btnSelectAll,
            this.btnClearSelection,
            this.toolStripSeparator2,
            this.btnGenerateSelection,
            this.btnOpenDatasourceFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(858, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddExcel,
            this.btnAddSqlServer,
            this.btnAddWindowsFolder});
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 22);
            this.btnAdd.Text = "Add";
            // 
            // btnAddExcel
            // 
            this.btnAddExcel.Name = "btnAddExcel";
            this.btnAddExcel.Size = new System.Drawing.Size(169, 22);
            this.btnAddExcel.Text = "Excel Source";
            this.btnAddExcel.Click += new System.EventHandler(this.btnAddExcel_Click);
            // 
            // btnAddSqlServer
            // 
            this.btnAddSqlServer.Name = "btnAddSqlServer";
            this.btnAddSqlServer.Size = new System.Drawing.Size(169, 22);
            this.btnAddSqlServer.Text = "SQL Server Source";
            this.btnAddSqlServer.Click += new System.EventHandler(this.btnAddSqlServer_Click);
            // 
            // btnAddWindowsFolder
            // 
            this.btnAddWindowsFolder.Name = "btnAddWindowsFolder";
            this.btnAddWindowsFolder.Size = new System.Drawing.Size(169, 22);
            this.btnAddWindowsFolder.Text = "Windows Folder";
            this.btnAddWindowsFolder.Click += new System.EventHandler(this.btnAddWindowsFolder_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(47, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(23, 22);
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearSelection.Image = ((System.Drawing.Image)(resources.GetObject("btnClearSelection.Image")));
            this.btnClearSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(23, 22);
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGenerateSelection
            // 
            this.btnGenerateSelection.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateSelection.Image")));
            this.btnGenerateSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerateSelection.Name = "btnGenerateSelection";
            this.btnGenerateSelection.Size = new System.Drawing.Size(125, 22);
            this.btnGenerateSelection.Text = "Generate Selection";
            this.btnGenerateSelection.Click += new System.EventHandler(this.btnGenerateSelection_Click);
            // 
            // btnOpenDatasourceFile
            // 
            this.btnOpenDatasourceFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenDatasourceFile.Image")));
            this.btnOpenDatasourceFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenDatasourceFile.Name = "btnOpenDatasourceFile";
            this.btnOpenDatasourceFile.Size = new System.Drawing.Size(139, 22);
            this.btnOpenDatasourceFile.Text = "Open Datasource File";
            this.btnOpenDatasourceFile.Click += new System.EventHandler(this.btnOpenDatasourceFile_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(771, 494);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClone
            // 
            this.btnClone.Image = ((System.Drawing.Image)(resources.GetObject("btnClone.Image")));
            this.btnClone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(58, 22);
            this.btnClone.Text = "Clone";
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // progressConsole1
            // 
            this.progressConsole1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressConsole1.Location = new System.Drawing.Point(12, 295);
            this.progressConsole1.Name = "progressConsole1";
            this.progressConsole1.Progress = 0;
            this.progressConsole1.ProgressMaximum = 100;
            this.progressConsole1.Size = new System.Drawing.Size(834, 193);
            this.progressConsole1.TabIndex = 5;
            // 
            // DataSourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 529);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.progressConsole1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lvwDataSources);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataSourceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate\\Refresh Data";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDataSources;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSelectAll;
        private System.Windows.Forms.ToolStripButton btnClearSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ProgressConsole progressConsole1;
        private System.Windows.Forms.ToolStripDropDownButton btnAdd;
        private System.Windows.Forms.ToolStripMenuItem btnAddExcel;
        private System.Windows.Forms.ToolStripMenuItem btnAddSqlServer;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnGenerateSelection;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripButton btnOpenDatasourceFile;
        private System.Windows.Forms.ToolStripMenuItem btnAddWindowsFolder;
        private System.Windows.Forms.ToolStripButton btnClone;

    }
}