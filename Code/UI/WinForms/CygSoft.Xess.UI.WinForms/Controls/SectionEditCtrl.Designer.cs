namespace CygSoft.Xess.UI.WinForms.Controls
{
    partial class SectionEditCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SectionEditCtrl));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDataStatus = new System.Windows.Forms.Label();
            this.cboDataSource = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageBlueprint = new System.Windows.Forms.TabPage();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.horizSplitter = new System.Windows.Forms.SplitContainer();
            this.qikSyntaxEditor = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.qikSyntaxDocument = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.errorListView = new System.Windows.Forms.ListView();
            this.colLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStackRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSymbol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCompile = new System.Windows.Forms.ToolStripButton();
            this.blueprintEditor = new CygSoft.Xess.UI.WinForms.BlueprintEditorControl();
            this.templateDataCtrl1 = new CygSoft.Xess.UI.WinForms.Controls.TemplateDataCtrl();
            this.tabControl1.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageBlueprint.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.tabScript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horizSplitter)).BeginInit();
            this.horizSplitter.Panel1.SuspendLayout();
            this.horizSplitter.Panel2.SuspendLayout();
            this.horizSplitter.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(685, 33);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(685, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(685, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageProperties);
            this.tabControl1.Controls.Add(this.tabPageBlueprint);
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Controls.Add(this.tabScript);
            this.tabControl1.Location = new System.Drawing.Point(3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(676, 502);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.groupBox2);
            this.tabPageProperties.Controls.Add(this.groupBox1);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(668, 476);
            this.tabPageProperties.TabIndex = 0;
            this.tabPageProperties.Text = "Properties";
            this.tabPageProperties.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Location = new System.Drawing.Point(6, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(656, 166);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(10, 11);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDescription.Size = new System.Drawing.Size(639, 149);
            this.txtDescription.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblDataStatus);
            this.groupBox1.Controls.Add(this.cboDataSource);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 75);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // lblDataStatus
            // 
            this.lblDataStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataStatus.Location = new System.Drawing.Point(482, 48);
            this.lblDataStatus.Name = "lblDataStatus";
            this.lblDataStatus.Size = new System.Drawing.Size(167, 13);
            this.lblDataStatus.TabIndex = 13;
            this.lblDataStatus.Text = "Data Exists";
            // 
            // cboDataSource
            // 
            this.cboDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataSource.FormattingEnabled = true;
            this.cboDataSource.Location = new System.Drawing.Point(101, 45);
            this.cboDataSource.Name = "cboDataSource";
            this.cboDataSource.Size = new System.Drawing.Size(375, 21);
            this.cboDataSource.TabIndex = 12;
            this.cboDataSource.SelectedIndexChanged += new System.EventHandler(this.cboDataSource_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Data Source";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(101, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(549, 20);
            this.txtTitle.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Title";
            // 
            // tabPageBlueprint
            // 
            this.tabPageBlueprint.Controls.Add(this.blueprintEditor);
            this.tabPageBlueprint.Location = new System.Drawing.Point(4, 22);
            this.tabPageBlueprint.Name = "tabPageBlueprint";
            this.tabPageBlueprint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBlueprint.Size = new System.Drawing.Size(668, 476);
            this.tabPageBlueprint.TabIndex = 1;
            this.tabPageBlueprint.Text = "Blueprint";
            this.tabPageBlueprint.UseVisualStyleBackColor = true;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.templateDataCtrl1);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Size = new System.Drawing.Size(668, 476);
            this.tabPageData.TabIndex = 2;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // tabScript
            // 
            this.tabScript.Controls.Add(this.horizSplitter);
            this.tabScript.Controls.Add(this.toolStrip1);
            this.tabScript.Location = new System.Drawing.Point(4, 22);
            this.tabScript.Name = "tabScript";
            this.tabScript.Size = new System.Drawing.Size(668, 476);
            this.tabScript.TabIndex = 3;
            this.tabScript.Text = "Script";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // horizSplitter
            // 
            this.horizSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizSplitter.Location = new System.Drawing.Point(0, 25);
            this.horizSplitter.Name = "horizSplitter";
            this.horizSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // horizSplitter.Panel1
            // 
            this.horizSplitter.Panel1.Controls.Add(this.qikSyntaxEditor);
            // 
            // horizSplitter.Panel2
            // 
            this.horizSplitter.Panel2.Controls.Add(this.errorListView);
            this.horizSplitter.Size = new System.Drawing.Size(668, 451);
            this.horizSplitter.SplitterDistance = 336;
            this.horizSplitter.TabIndex = 5;
            // 
            // qikSyntaxEditor
            // 
            this.qikSyntaxEditor.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.qikSyntaxEditor.AutoListPosition = null;
            this.qikSyntaxEditor.AutoListSelectedText = "a123";
            this.qikSyntaxEditor.AutoListVisible = false;
            this.qikSyntaxEditor.BackColor = System.Drawing.Color.White;
            this.qikSyntaxEditor.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.qikSyntaxEditor.CopyAsRTF = false;
            this.qikSyntaxEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qikSyntaxEditor.Document = this.qikSyntaxDocument;
            this.qikSyntaxEditor.FontName = "Courier new";
            this.qikSyntaxEditor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.qikSyntaxEditor.InfoTipCount = 1;
            this.qikSyntaxEditor.InfoTipPosition = null;
            this.qikSyntaxEditor.InfoTipSelectedIndex = 1;
            this.qikSyntaxEditor.InfoTipVisible = false;
            this.qikSyntaxEditor.Location = new System.Drawing.Point(0, 0);
            this.qikSyntaxEditor.LockCursorUpdate = false;
            this.qikSyntaxEditor.Name = "qikSyntaxEditor";
            this.qikSyntaxEditor.ShowScopeIndicator = false;
            this.qikSyntaxEditor.Size = new System.Drawing.Size(668, 336);
            this.qikSyntaxEditor.SmoothScroll = false;
            this.qikSyntaxEditor.SplitviewH = -4;
            this.qikSyntaxEditor.SplitviewV = -4;
            this.qikSyntaxEditor.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.qikSyntaxEditor.TabIndex = 0;
            this.qikSyntaxEditor.Text = "syntaxBoxControl1";
            this.qikSyntaxEditor.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            this.qikSyntaxEditor.RowClick += new Alsing.Windows.Forms.SyntaxBox.RowMouseHandler(this.qikSyntaxEditor_RowClick);
            // 
            // qikSyntaxDocument
            // 
            this.qikSyntaxDocument.Lines = new string[] {
        ""};
            this.qikSyntaxDocument.MaxUndoBufferSize = 1000;
            this.qikSyntaxDocument.Modified = false;
            this.qikSyntaxDocument.UndoStep = 0;
            // 
            // errorListView
            // 
            this.errorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLine,
            this.colCol,
            this.colMsg,
            this.colStackRule,
            this.colSymbol});
            this.errorListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorListView.FullRowSelect = true;
            this.errorListView.Location = new System.Drawing.Point(0, 0);
            this.errorListView.Name = "errorListView";
            this.errorListView.Size = new System.Drawing.Size(668, 111);
            this.errorListView.TabIndex = 4;
            this.errorListView.UseCompatibleStateImageBehavior = false;
            this.errorListView.View = System.Windows.Forms.View.Details;
            this.errorListView.SelectedIndexChanged += new System.EventHandler(this.errorListView_SelectedIndexChanged);
            this.errorListView.Leave += new System.EventHandler(this.errorListView_Leave);
            // 
            // colLine
            // 
            this.colLine.Text = "Line";
            // 
            // colCol
            // 
            this.colCol.Text = "Column";
            // 
            // colMsg
            // 
            this.colMsg.Text = "Error";
            this.colMsg.Width = 251;
            // 
            // colStackRule
            // 
            this.colStackRule.Text = "Location";
            this.colStackRule.Width = 134;
            // 
            // colSymbol
            // 
            this.colSymbol.Text = "Symbol";
            this.colSymbol.Width = 75;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCompile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(668, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCompile
            // 
            this.btnCompile.Image = ((System.Drawing.Image)(resources.GetObject("btnCompile.Image")));
            this.btnCompile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(72, 22);
            this.btnCompile.Text = "Compile";
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // blueprintEditor
            // 
            this.blueprintEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blueprintEditor.BodyText = null;
            this.blueprintEditor.FooterText = null;
            this.blueprintEditor.HeaderText = null;
            this.blueprintEditor.Location = new System.Drawing.Point(3, 6);
            this.blueprintEditor.Name = "blueprintEditor";
            this.blueprintEditor.NewLineAfterText = false;
            this.blueprintEditor.NewLineBeforeText = false;
            this.blueprintEditor.ReadOnly = false;
            this.blueprintEditor.Size = new System.Drawing.Size(659, 464);
            this.blueprintEditor.TabIndex = 11;
            this.blueprintEditor.TrimText = false;
            // 
            // templateDataCtrl1
            // 
            this.templateDataCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateDataCtrl1.Location = new System.Drawing.Point(3, 7);
            this.templateDataCtrl1.Name = "templateDataCtrl1";
            this.templateDataCtrl1.Size = new System.Drawing.Size(662, 466);
            this.templateDataCtrl1.TabIndex = 0;
            // 
            // SectionEditCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "SectionEditCtrl";
            this.Size = new System.Drawing.Size(763, 509);
            this.tabControl1.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageBlueprint.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.tabScript.ResumeLayout(false);
            this.tabScript.PerformLayout();
            this.horizSplitter.Panel1.ResumeLayout(false);
            this.horizSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.horizSplitter)).EndInit();
            this.horizSplitter.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageProperties;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDataSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageBlueprint;
        private BlueprintEditorControl blueprintEditor;
        private System.Windows.Forms.TabPage tabPageData;
        private TemplateDataCtrl templateDataCtrl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDataStatus;
        private System.Windows.Forms.TabPage tabScript;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCompile;
        private Alsing.SourceCode.SyntaxDocument qikSyntaxDocument;
        private System.Windows.Forms.SplitContainer horizSplitter;
        private Alsing.Windows.Forms.SyntaxBoxControl qikSyntaxEditor;
        private System.Windows.Forms.ListView errorListView;
        private System.Windows.Forms.ColumnHeader colLine;
        private System.Windows.Forms.ColumnHeader colCol;
        private System.Windows.Forms.ColumnHeader colMsg;
        private System.Windows.Forms.ColumnHeader colStackRule;
        private System.Windows.Forms.ColumnHeader colSymbol;
    }
}
