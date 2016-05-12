namespace CygSoft.Xess.UI.WinForms.Dialogs
{
    partial class ExcelSourceDialog
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
            this.groupBoxFile = new System.Windows.Forms.GroupBox();
            this.txtBottomRightCell = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTopLeftCell = new System.Windows.Forms.TextBox();
            this.lblTopLeft = new System.Windows.Forms.Label();
            this.cboFilePath = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cboSheets = new System.Windows.Forms.ComboBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.excelGridView = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFile
            // 
            this.groupBoxFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFile.Controls.Add(this.txtBottomRightCell);
            this.groupBoxFile.Controls.Add(this.label5);
            this.groupBoxFile.Controls.Add(this.txtTopLeftCell);
            this.groupBoxFile.Controls.Add(this.lblTopLeft);
            this.groupBoxFile.Controls.Add(this.cboFilePath);
            this.groupBoxFile.Controls.Add(this.txtTitle);
            this.groupBoxFile.Controls.Add(this.lblTitle);
            this.groupBoxFile.Controls.Add(this.cboSheets);
            this.groupBoxFile.Controls.Add(this.btnChooseFile);
            this.groupBoxFile.Controls.Add(this.label2);
            this.groupBoxFile.Controls.Add(this.label1);
            this.groupBoxFile.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(673, 91);
            this.groupBoxFile.TabIndex = 6;
            this.groupBoxFile.TabStop = false;
            // 
            // txtBottomRightCell
            // 
            this.txtBottomRightCell.Location = new System.Drawing.Point(521, 63);
            this.txtBottomRightCell.Name = "txtBottomRightCell";
            this.txtBottomRightCell.Size = new System.Drawing.Size(42, 20);
            this.txtBottomRightCell.TabIndex = 17;
            this.txtBottomRightCell.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBottomRightCell_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Bottom Right Cell";
            // 
            // txtTopLeftCell
            // 
            this.txtTopLeftCell.Location = new System.Drawing.Point(375, 63);
            this.txtTopLeftCell.Name = "txtTopLeftCell";
            this.txtTopLeftCell.Size = new System.Drawing.Size(42, 20);
            this.txtTopLeftCell.TabIndex = 15;
            this.txtTopLeftCell.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTopLeftCell_KeyUp);
            // 
            // lblTopLeft
            // 
            this.lblTopLeft.AutoSize = true;
            this.lblTopLeft.Location = new System.Drawing.Point(302, 67);
            this.lblTopLeft.Name = "lblTopLeft";
            this.lblTopLeft.Size = new System.Drawing.Size(67, 13);
            this.lblTopLeft.TabIndex = 14;
            this.lblTopLeft.Text = "Top Left Cell";
            // 
            // cboFilePath
            // 
            this.cboFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilePath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilePath.FormattingEnabled = true;
            this.cboFilePath.Location = new System.Drawing.Point(84, 37);
            this.cboFilePath.Name = "cboFilePath";
            this.cboFilePath.Size = new System.Drawing.Size(542, 21);
            this.cboFilePath.TabIndex = 13;
            this.cboFilePath.SelectedIndexChanged += new System.EventHandler(this.cboFilePath_SelectedIndexChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(84, 13);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(351, 20);
            this.txtTitle.TabIndex = 10;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(7, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Title";
            // 
            // cboSheets
            // 
            this.cboSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSheets.FormattingEnabled = true;
            this.cboSheets.Location = new System.Drawing.Point(84, 63);
            this.cboSheets.Name = "cboSheets";
            this.cboSheets.Size = new System.Drawing.Size(190, 21);
            this.cboSheets.TabIndex = 6;
            this.cboSheets.SelectionChangeCommitted += new System.EventHandler(this.cboSheets_SelectionChangeCommitted);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseFile.Location = new System.Drawing.Point(631, 36);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(37, 23);
            this.btnChooseFile.TabIndex = 5;
            this.btnChooseFile.Text = "...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sheet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File Path";
            // 
            // excelGridView
            // 
            this.excelGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.excelGridView.Location = new System.Drawing.Point(12, 109);
            this.excelGridView.Name = "excelGridView";
            this.excelGridView.ReadOnly = true;
            this.excelGridView.Size = new System.Drawing.Size(673, 334);
            this.excelGridView.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(610, 448);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(529, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(697, 22);
            this.statusStrip1.TabIndex = 10;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tsStatusLabel
            // 
            this.tsStatusLabel.AutoSize = false;
            this.tsStatusLabel.Name = "tsStatusLabel";
            this.tsStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsStatusLabel.Size = new System.Drawing.Size(682, 17);
            this.tsStatusLabel.Spring = true;
            this.tsStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ExcelSourceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 497);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.excelGridView);
            this.Controls.Add(this.groupBoxFile);
            this.Name = "ExcelSourceDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Excel Source Data";
            this.groupBoxFile.ResumeLayout(false);
            this.groupBoxFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.ComboBox cboSheets;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView excelGridView;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboFilePath;
        private System.Windows.Forms.TextBox txtBottomRightCell;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTopLeftCell;
        private System.Windows.Forms.Label lblTopLeft;
    }
}