using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.App;
using CygSoft.Xess.UI.WinForms.GlobalSettings;
using System.Text;

namespace CygSoft.Xess.UI.WinForms.Forms
{
    public partial class TemplateForm : Form
    {
        private RegistrySettings registrySettings = null;
        private List<ITemplate> templatesList = null;
        private string connectionsFile;
        
        public TemplateForm(string connectionsFile, RegistrySettings registrySettings)
        {
            InitializeComponent();

            
            IDataSource[] dataSources;

            this.connectionsFile = connectionsFile;
            this.registrySettings = registrySettings;

            templateCtrl1.TemplateSaved += templateCtrl1_TemplateSaved;
            templateCtrl1.StateChanged += templateCtrl1_StateChanged;
            templateView1.ItemSelected += templateView1_ItemSelected;

            SetGraphics();

            dataSources = XessApplication.GetDataSources();
 
            this.templatesList = XessApplication.GetTemplates();
            templateView1.InitializeTemplates(this.templatesList);
        }

        private void SetGraphics()
        {
            btnAdd.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.Add);
            btnDelete.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.Delete);
            btnClone.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.Clone);
        }

        #region Form Events

        private void mnuCloneTemplate_Click(object sender, EventArgs e)
        {
            templateView1.CloneTemplate();
        }

        private void mnuCloneTemplateSection_Click(object sender, EventArgs e)
        {
            templateView1.CloneTemplateSection();
        }

        private void templateCtrl1_TemplateSaved(object sender, EventArgs e)
        {
            templateView1.RefreshSelectedTitle();
        }

        private void templateCtrl1_StateChanged(object sender, EventArgs e)
        {
            templateView1.Enabled = !templateCtrl1.Editing;
            btnOk.Enabled = !templateCtrl1.Editing;
            btnCancel.Enabled = !templateCtrl1.Editing;
            btnAdd.Enabled = !templateCtrl1.Editing;
            btnDelete.Enabled = !templateCtrl1.Editing;
            btnClone.Enabled = !templateCtrl1.Editing;
        }

        private void templateView1_ItemSelected(object sender, EventArgs e)
        {
            templateCtrl1.LoadData(templateView1.CurrentlySelectedItem);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            templateView1.DeleteFocusedItem();
        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            templateView1.AddTemplate();
        }

        private void mnuAddTemplateSection_Click(object sender, EventArgs e)
        {
            templateView1.AddTemplateSection();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            templateView1.MoveSectionUp();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            templateView1.MoveSectionDown();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateAllTemplates())
            {
                XessApplication.UpdateTemplates(this.templatesList);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private bool ValidateAllTemplates()
        {
            StringBuilder issueBuilder = new StringBuilder();

            //commented out code should be unreachable...

            foreach (ITemplate template in this.templatesList)
            {
                //if (string.IsNullOrEmpty(template.Title))
                //    issueBuilder.AppendLine(string.Format(" - Template: {0} - has not been supplied with a title.", template.Id));
                if (string.IsNullOrEmpty(template.Syntax))
                    issueBuilder.AppendLine(string.Format(" - Template: {0} - has not been supplied with a syntax.", template.Title));
                //foreach (ITemplateSection templateSection in template.TemplateSectionList)
                //{
                //    if (string.IsNullOrEmpty(templateSection.Title))
                //        issueBuilder.AppendLine(string.Format(" - Template {1} Section: {0} - has not been supplied with a title.", 
                //            string.IsNullOrEmpty(template.Title) ? "Unknown Template" : template.Title, templateSection.Id));
                //}
            }

            if (issueBuilder.Length > 0)
            {
                MessageBox.Show(this,
                    string.Format("Issues with the current template collection must be fixed before the user can save:\n{0}", issueBuilder.ToString()),
                    ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            return true;
        }

        private void TemplateManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (templateCtrl1.Editing)
                {
                    DialogResult result = MessageBox.Show(this, CommonConstants.DialogMessages.TemplateEditModeCloseWarning, ConfigSettings.ApplicationTitle, 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == System.Windows.Forms.DialogResult.No)
                        e.Cancel = true;
                }
            }
        }
    }
}
