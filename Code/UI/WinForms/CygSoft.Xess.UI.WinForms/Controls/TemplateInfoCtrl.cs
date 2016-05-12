using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.App;
using CygSoft.Xess.Infrastructure.DataSources.Excel;

namespace CygSoft.Xess.UI.WinForms.Controls
{
    public partial class TemplateInfoCtrl : UserControl
    {
        private List<ITemplate> templatesList = null;

        public TemplateInfoCtrl()
        {
            InitializeComponent();
        }

        public ITemplateSection SelectedTemplateSection
        {
            get; 
            private set;
        }

        public ITemplate SelectedTemplate
        {
            get;
            private set;
        }

        public IDataSource SelectedDataSource
        {
            get;
            private set;
        }

        public void LoadTemplates()
        {
            this.templatesList = XessApplication.GetTemplates();
            templateView1.InitializeTemplates(this.templatesList);
        }

        private void templateView1_ItemSelected(object sender, EventArgs e)
        {
            SelectedTemplate = (templateView1.CurrentlySelectedItem as ITemplate);
            SelectedTemplateSection = (templateView1.CurrentlySelectedItem as ITemplateSection);

            // currently have a section selected.
            if (SelectedTemplateSection != null)
            {
                if (SelectedTemplateSection.DataSourceID != string.Empty)
                    SelectedDataSource = XessApplication.GetDataSourceById(SelectedTemplateSection.DataSourceID);
                else
                    SelectedDataSource = null;
            }

            DisplayTabInformation();
            DisplayDescriptionInformation();
        }

        private void DisplayDescriptionInformation()
        {
            
            if (templateView1.TypeOfSelectedItem == ItemTypeEnum.TemplateSection)
            {
                textboxDescription.Text = SelectedTemplateSection.Description;
            }
            else if (templateView1.TypeOfSelectedItem == ItemTypeEnum.Template)
            {
                ITemplate template = (templateView1.CurrentlySelectedItem as ITemplate);
                textboxDescription.Text = template.Description;
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            DisplayTabInformation();
        }

        private void DisplayTabInformation()
        {
            if (tabControl1.SelectedTab.Name == "tabpageDataMatrix")
                ManageDataMatrix();
        }

        private void ManageDataMatrix()
        {
            if (tabControl1.SelectedTab.Name == "tabpageDataMatrix")
            {
                if (SelectedTemplateSection != null && SelectedDataSource != null)
                {
                    templateDataCtrl1.DisplayTable(SelectedDataSource);
                    return;
                }
            }
            templateDataCtrl1.DisplayTable(null);
        }
    }
}
