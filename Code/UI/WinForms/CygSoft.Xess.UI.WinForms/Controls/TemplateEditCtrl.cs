using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.UI.WinForms.GlobalSettings;
using CygSoft.Xess.App;

namespace CygSoft.Xess.UI.WinForms.Controls
{
    public partial class TemplateEditCtrl : UserControl
    {
        public event EventHandler TemplateSaved;
        public event EventHandler StateChanged;

        public TemplateEditCtrl()
        {
            InitializeComponent();
            cboSyntax.Items.AddRange(XessApplication.GetSyntaxes());
            ChangeState(TemplateEditorStateEnum.Disabled);
        }

        private ITemplate currentTemplate;
        public ITemplate CurrentTemplate
        {
            get { return this.currentTemplate; }
            set
            {
                this.currentTemplate = value;
                AssignTemplate();
            }
        }

        private TemplateEditorStateEnum currentState;
        public TemplateEditorStateEnum CurrentState
        {
            get { return this.currentState; }
        }

        private void AssignTemplate()
        {
            if (this.currentTemplate == null)
            {
                ClearData();
                ChangeState(TemplateEditorStateEnum.Disabled);
            }
            else
            {
                AssignData();
                ChangeState(TemplateEditorStateEnum.ReadOnly);
            }
        }

        private void AssignData()
        {
            txtTitle.Text = this.currentTemplate.Title;
            fileBrowseBox.AsSaveDialog = true;
            fileBrowseBox.FilePath = this.currentTemplate.FilePath;
            SelectSyntax(this.currentTemplate.Syntax);
            fileBrowseBox.ClearSupportedFileTypes();
            fileBrowseBox.AddSupportedFileType("TXT", "Text File", new string[] { ".txt", "TXT" });
            fileBrowseBox.AddSupportedFileType("SQL", "SQL File", new string[] { ".sql", ".SQL" });
            fileBrowseBox.AddSupportedFileType("JS", "Javascript File", new string[] { ".js", ".JS" });
            fileBrowseBox.AddSupportedFileType("CS", "C# Source File", new string[] { ".js", ".JS" });
            txtDescription.Text = this.currentTemplate.Description;
        }

        private void ClearData()
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void ChangeState(TemplateEditorStateEnum state)
        {
            this.currentState = state;
            EnableControls(state);
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
                    fileBrowseBox.Enabled = false;
                    cboSyntax.Enabled = false;
                    break;
                case TemplateEditorStateEnum.Editing:
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    txtTitle.Enabled = true;
                    txtDescription.Enabled = true;
                    fileBrowseBox.Enabled = true;
                    cboSyntax.Enabled = true;
                    break;
                case TemplateEditorStateEnum.ReadOnly:
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    txtTitle.Enabled = false;
                    txtDescription.Enabled = false;
                    fileBrowseBox.Enabled = false;
                    cboSyntax.Enabled = false;
                    break;
            }
        }

        private void SelectSyntax(string language)
        {
            cboSyntax.SelectedItem = null;

            if (cboSyntax.Items.Count > 0)
            {
                foreach (object item in cboSyntax.Items)
                {
                    if (item.ToString() == language)
                    {
                        cboSyntax.SelectedItem = item;
                    }
                }
            }
        }

        private void SetSyntaxList(string[] syntaxList)
        {
            cboSyntax.Items.Clear();
            cboSyntax.Items.AddRange(syntaxList);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeState(TemplateEditorStateEnum.Editing);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.currentTemplate.Title = txtTitle.Text;
            this.currentTemplate.FilePath = fileBrowseBox.FilePath;
            this.currentTemplate.Description = txtDescription.Text;
            this.currentTemplate.Syntax = cboSyntax.SelectedItem.ToString();

            ChangeState(TemplateEditorStateEnum.ReadOnly);

            if (TemplateSaved != null)
                TemplateSaved(this, new EventArgs());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AssignTemplate();
            ChangeState(TemplateEditorStateEnum.ReadOnly);
        }
    }
}
