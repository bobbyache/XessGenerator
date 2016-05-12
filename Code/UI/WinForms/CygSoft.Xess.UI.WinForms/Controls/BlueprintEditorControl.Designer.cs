namespace CygSoft.Xess.UI.WinForms
{
    partial class BlueprintEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlueprintEditorControl));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblRow = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCol = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboParts = new System.Windows.Forms.ToolStripComboBox();
            this.btnOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuGenerateNewLineBefore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGenerateNewLineAfter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrimText = new System.Windows.Forms.ToolStripMenuItem();
            this.syntaxBoxControl1 = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRow,
            this.lblCol,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 499);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(766, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblRow
            // 
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(42, 17);
            this.lblRow.Text = "Row: 0";
            // 
            // lblCol
            // 
            this.lblCol.Name = "lblCol";
            this.lblCol.Size = new System.Drawing.Size(37, 17);
            this.lblCol.Text = "Col: 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(333, 17);
            this.toolStripStatusLabel1.Text = "Shift + F8 or just F8 for drop down menu (press Escape to exit)";
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 22);
            this.btnPrint.Text = "&Print";
            this.btnPrint.Visible = false;
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
            this.btnCut.Visible = false;
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(23, 22);
            this.btnCopy.Text = "&Copy";
            this.btnCopy.Visible = false;
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(23, 22);
            this.btnPaste.Text = "&Paste";
            this.btnPaste.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.toolStrip.Size = new System.Drawing.Size(766, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
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
            this.cboParts.SelectedIndexChanged += new System.EventHandler(this.cboParts_SelectedIndexChanged);
            // 
            // btnOptions
            // 
            this.btnOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGenerateNewLineBefore,
            this.mnuGenerateNewLineAfter,
            this.mnuTrimText});
            this.btnOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOptions.Image")));
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(78, 22);
            this.btnOptions.Text = "Options";
            // 
            // mnuGenerateNewLineBefore
            // 
            this.mnuGenerateNewLineBefore.Name = "mnuGenerateNewLineBefore";
            this.mnuGenerateNewLineBefore.Size = new System.Drawing.Size(205, 22);
            this.mnuGenerateNewLineBefore.Text = "Generate new line before";
            this.mnuGenerateNewLineBefore.Click += new System.EventHandler(this.mnuGenerateNewLineBefore_Click);
            // 
            // mnuGenerateNewLineAfter
            // 
            this.mnuGenerateNewLineAfter.Name = "mnuGenerateNewLineAfter";
            this.mnuGenerateNewLineAfter.Size = new System.Drawing.Size(205, 22);
            this.mnuGenerateNewLineAfter.Text = "Generate new line after";
            this.mnuGenerateNewLineAfter.Click += new System.EventHandler(this.mnuGenerateNewLineAfter_Click);
            // 
            // mnuTrimText
            // 
            this.mnuTrimText.Name = "mnuTrimText";
            this.mnuTrimText.Size = new System.Drawing.Size(205, 22);
            this.mnuTrimText.Text = "Trim text";
            this.mnuTrimText.Click += new System.EventHandler(this.mnuTrimText_Click);
            // 
            // syntaxBoxControl1
            // 
            this.syntaxBoxControl1.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.syntaxBoxControl1.AutoListPosition = null;
            this.syntaxBoxControl1.AutoListSelectedText = "a123";
            this.syntaxBoxControl1.AutoListVisible = false;
            this.syntaxBoxControl1.BackColor = System.Drawing.Color.White;
            this.syntaxBoxControl1.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.syntaxBoxControl1.CopyAsRTF = false;
            this.syntaxBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.syntaxBoxControl1.Document = this.syntaxDocument1;
            this.syntaxBoxControl1.FontName = "Courier new";
            this.syntaxBoxControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.syntaxBoxControl1.InfoTipCount = 1;
            this.syntaxBoxControl1.InfoTipPosition = null;
            this.syntaxBoxControl1.InfoTipSelectedIndex = 1;
            this.syntaxBoxControl1.InfoTipVisible = false;
            this.syntaxBoxControl1.Location = new System.Drawing.Point(0, 25);
            this.syntaxBoxControl1.LockCursorUpdate = false;
            this.syntaxBoxControl1.Name = "syntaxBoxControl1";
            this.syntaxBoxControl1.ShowScopeIndicator = false;
            this.syntaxBoxControl1.Size = new System.Drawing.Size(766, 474);
            this.syntaxBoxControl1.SmoothScroll = false;
            this.syntaxBoxControl1.SplitviewH = -4;
            this.syntaxBoxControl1.SplitviewV = -4;
            this.syntaxBoxControl1.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.syntaxBoxControl1.TabIndex = 3;
            this.syntaxBoxControl1.Text = "syntaxBoxControl1";
            this.syntaxBoxControl1.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            this.syntaxBoxControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.syntaxBoxControl1_KeyDown);
            this.syntaxBoxControl1.Leave += new System.EventHandler(this.syntaxBoxControl1_Leave);
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // BlueprintEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.syntaxBoxControl1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip1);
            this.Name = "BlueprintEditorControl";
            this.Size = new System.Drawing.Size(766, 521);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblRow;
        private System.Windows.Forms.ToolStripStatusLabel lblCol;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton btnCut;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboParts;
        private System.Windows.Forms.ToolStripDropDownButton btnOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuGenerateNewLineBefore;
        private System.Windows.Forms.ToolStripMenuItem mnuGenerateNewLineAfter;
        private System.Windows.Forms.ToolStripMenuItem mnuTrimText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Alsing.Windows.Forms.SyntaxBoxControl syntaxBoxControl1;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
    }
}
