using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.App;
using CygSoft.Xess.UI.WinForms.GlobalSettings;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using Alsing.SourceCode;
using System.Collections.Generic;

namespace CygSoft.Xess.UI.WinForms.Controls
{
    public partial class SectionEditCtrl : UserControl
    {
        private Row selectedRow;

        public event EventHandler SectionSaved;
        public event EventHandler StateChanged;

        public SectionEditCtrl()
        {
            InitializeComponent();
            qikSyntaxDocument.SyntaxFile = ConfigSettings.QikScriptSyntaxFile;
            blueprintEditor.SyntaxFilePath = ConfigSettings.QikTemplateSyntaxFile;

            ChangeState(TemplateEditorStateEnum.Disabled);
        }

        private ITemplateSection currentSection;
        public ITemplateSection CurrentSection
        {
            get { return this.currentSection; }
            set 
            { 
                this.currentSection = value;
                AssignSection();
                tabControl1.SelectedTab = tabPageProperties;
            }
        }

        private TemplateEditorStateEnum currentState;
        public TemplateEditorStateEnum CurrentState
        {
            get { return this.currentState; }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeState(TemplateEditorStateEnum.Editing);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                this.currentSection.Title = txtTitle.Text;
                this.currentSection.Description = txtDescription.Text;
                if (cboDataSource.SelectedItem != null)
                {
                    IDataSource dataSource = XessApplication.GetDataSourceById((cboDataSource.SelectedItem as IDataSource).Id);
                    this.currentSection.ChangeDataSource(dataSource);
                }
                else
                {
                    this.currentSection.ChangeDataSource(null);
                }
                this.currentSection.BodyText = blueprintEditor.BodyText;
                this.currentSection.FooterText = blueprintEditor.FooterText;
                this.currentSection.HeaderText = blueprintEditor.HeaderText;
                this.currentSection.Script = qikSyntaxDocument.Text;

                ChangeState(TemplateEditorStateEnum.ReadOnly);

                if (SectionSaved != null)
                    SectionSaved(this, new EventArgs());
            }
        }

        private bool ValidateFields()
        {
            
            if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.NoInputValueForMandatoryField("Title"), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!Compile(templateDataCtrl1.ColumnList, qikSyntaxDocument.Text))
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.ScriptCompilationError(), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AssignSection();
            ChangeState(TemplateEditorStateEnum.ReadOnly);
        }

        private void cboDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDataStatus();
            DisplayDataTab();
            DisplayAvailableRecords();
            Compile(templateDataCtrl1.ColumnList, qikSyntaxDocument.Text);
        }

        public void AssignSection()
        {
            if (this.currentSection == null)
            {
                ClearData();
                ChangeState(TemplateEditorStateEnum.Disabled);
            }
            else
            {
                RefreshDataSourceList();
                AssignData();
                ChangeState(TemplateEditorStateEnum.ReadOnly);
            }
        }

        private void RefreshDataSourceList()
        {
            cboDataSource.Items.Clear();
            cboDataSource.Items.AddRange(XessApplication.GetDataSources());
            blueprintEditor.ClearPlaceholders();
            DisplayDataStatus();
        }

        private void AssignData()
        {
            txtTitle.Text = this.currentSection.Title;
            txtDescription.Text = this.currentSection.Description;

            blueprintEditor.FooterText = this.currentSection.FooterText;
            blueprintEditor.BodyText = this.currentSection.BodyText;
            blueprintEditor.HeaderText = this.currentSection.HeaderText;
            qikSyntaxDocument.Text = this.currentSection.Script;

            if (!string.IsNullOrEmpty(qikSyntaxDocument.Text))
                Compile(templateDataCtrl1.ColumnList, qikSyntaxDocument.Text);

            cboDataSource.SelectedItem = CurrentSectionDataSource(this.currentSection.DataSourceID);
        }

        private IDataSource CurrentSectionDataSource(string dataSourceId)
        {
            foreach (IDataSource dataSource in cboDataSource.Items)
            {
                if (dataSource.Id == dataSourceId)
                    return dataSource;
            }
            return null;
        }

        private void ClearData()
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cboDataSource.SelectedItem = null;
            blueprintEditor.FooterText = string.Empty;
            blueprintEditor.HeaderText = string.Empty;
            blueprintEditor.BodyText = string.Empty;
            qikSyntaxDocument.Text = string.Empty;
        }

        private void ChangeState(TemplateEditorStateEnum state)
        {
            this.currentState = state;
            EnableControls(state);
            DisplayDataTab();
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void EnableControls(TemplateEditorStateEnum state)
        {
            switch (state)
            {
                case TemplateEditorStateEnum.Disabled:
                    btnEdit.Enabled = false;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    txtTitle.Enabled = false;
                    txtDescription.Enabled = false;
                    cboDataSource.Enabled = false;
                    blueprintEditor.Enabled = false;
                    blueprintEditor.ReadOnly = true;
                    qikSyntaxEditor.ReadOnly = true;
                    break;
                case TemplateEditorStateEnum.Editing:
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    txtTitle.Enabled = true;
                    txtDescription.Enabled = true;
                    cboDataSource.Enabled = true;
                    blueprintEditor.Enabled = true;
                    blueprintEditor.ReadOnly = false;
                    qikSyntaxEditor.ReadOnly = false;
                    break;
                case TemplateEditorStateEnum.ReadOnly:
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    txtTitle.Enabled = false;
                    txtDescription.Enabled = false;
                    cboDataSource.Enabled = false;
                    blueprintEditor.Enabled = true;
                    blueprintEditor.ReadOnly = true;
                    qikSyntaxEditor.ReadOnly = true;
                    break;
            }
        }

        private void DisplayDataStatus()
        {
            if (cboDataSource.SelectedItem == null)
            {
                lblDataStatus.Text = String.Empty;
                lblDataStatus.ForeColor = Color.Red;
            }

            else if ((cboDataSource.SelectedItem as IDataSource).DataExists())
            {
                lblDataStatus.Text = CommonConstants.StatusMessages.DataRecordsGenerated;
                lblDataStatus.ForeColor = Color.DarkBlue;
            }
            else
            {
                lblDataStatus.Text = CommonConstants.StatusMessages.DataRecordsNotGenerated;
                lblDataStatus.ForeColor = Color.Red;
            }
        }

        private void DisplayAvailableRecords()
        {
            IDataSource selectedDataSource = cboDataSource.SelectedItem as IDataSource;
            templateDataCtrl1.DisplayTable(cboDataSource.SelectedItem as IDataSource);
        }

        private bool DisplayDataTab()
        {
            if (cboDataSource.SelectedItem != null)
            {
                if (!tabControl1.TabPages.Contains(tabPageData))
                    tabControl1.TabPages.Add(tabPageData);
                return true;
            }
            else
            {
                if (tabControl1.TabPages.Contains(tabPageData))
                    tabControl1.TabPages.Remove(tabPageData);
                return false;
            }
        }

        private bool Compile(string[] columnList, string scriptText)
        {
            bool hasErrors = false;

            if (columnList.Length != 0 && !string.IsNullOrEmpty(scriptText))
            {
                ICompiler compiler = XessApplication.GetNewCompiler();
                
                compiler.AfterCompile += Compiler_AfterCompile;
                compiler.BeforeCompile += Compiler_BeforeCompile;
                compiler.AfterInput += Compiler_AfterInput;
                compiler.CompileError += Compiler_CompileError;

                compiler.Compile(scriptText);
                hasErrors = compiler.HasErrors;

                foreach (string column in columnList)
                {
                    string symbol = compiler.TextToSymbol(column);
                    compiler.CreateAutoInput(symbol, column, "Column: " + column);
                }

                compiler.AfterCompile -= Compiler_AfterCompile;
                compiler.BeforeCompile -= Compiler_BeforeCompile;
                compiler.AfterInput -= Compiler_AfterInput;
                compiler.CompileError -= Compiler_CompileError;

                blueprintEditor.SetPlaceholders(compiler.GetSymbolInfoSet(columnList.Select(c => "@" + c).ToArray()));
            }
            return !hasErrors;
        }


        private void btnCompile_Click(object sender, EventArgs e)
        {
            Compile(templateDataCtrl1.ColumnList, qikSyntaxDocument.Text);
        }

        private void Compiler_BeforeCompile(object sender, EventArgs e)
        {
            DeselectRow();
            errorListView.Items.Clear();
        }

        private void Compiler_CompileError(object sender, CompileErrorEventArgs e)
        {
            AddErrorLine(e.Line, e.Column, e.Message, e.Location, e.OffendingSymbol);
        }

        private void Compiler_AfterInput(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Compiler_AfterCompile(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void AddErrorLine(int line, int column, string message, string ruleStack, string symbol)
        {
            ListViewItem item = new ListViewItem();
            item.Text = line.ToString();
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, column.ToString()));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, message));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ruleStack));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, symbol));

            errorListView.Items.Add(item);
        }

        private Row RowFromLine(int line)
        {
            int index = line > 1 ? line - 1 : line;
            Row row = qikSyntaxEditor.Document[index];
            return row;
        }

        private void SelectRow(int line)
        {
            Row row = RowFromLine(line);
            if (row != null)
            {
                qikSyntaxEditor.GotoLine(line);
                row.BackColor = Color.Gray;
                selectedRow = row;
            }
            else
                selectedRow = null;
        }

        private void DeselectRow()
        {
            if (selectedRow != null)
            {
                selectedRow.BackColor = Color.White;
                this.selectedRow = null;
            }
        }

        private void errorListView_Leave(object sender, EventArgs e)
        {
            DeselectRow();
        }

        private void errorListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedRow != null)
                selectedRow.BackColor = Color.White;

            if (errorListView.SelectedItems.Count > 0)
            {
                ListViewItem item = errorListView.SelectedItems[0];
                int lineNumber = int.Parse(item.Text);
                SelectRow(lineNumber);
            }
        }

        private void qikSyntaxEditor_RowClick(object sender, Alsing.Windows.Forms.SyntaxBox.RowMouseEventArgs e)
        {
            DeselectRow();
        }
    }
}
