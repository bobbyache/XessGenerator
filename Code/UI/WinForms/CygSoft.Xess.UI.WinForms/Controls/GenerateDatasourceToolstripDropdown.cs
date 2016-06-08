using CygSoft.Xess.App;
using CygSoft.Xess.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CygSoft.Xess.UI.WinForms.Controls
{
    public partial class GenerateDatasourceToolstripDropdown : ToolStripDropDownButton
    {
        public GenerateDatasourceToolstripDropdown()
        {
            InitializeComponent();
        }

        public GenerateDatasourceToolstripDropdown(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private string templateId;

        public void SelectTemplate(string templateId)
        {
            this.templateId = templateId;

            ClearDatasourceList();
            CreateDatasourceList();

            this.ToolTipText = this.DropDownItems.Count == 0 ? "No data source exists for this template." : "Generate template";
        }

        private void CreateDatasourceList()
        {
            if (!string.IsNullOrEmpty(templateId))
            {
                string[] dataSourceIds = XessApplication.GetTemplate(templateId).GetExistingDataSourceIds();

                foreach (string dataSourceId in dataSourceIds)
                {
                    CygSoft.Xess.Infrastructure.IDataSource dataSource = XessApplication.GetDataSourceById(dataSourceId);
                    if (dataSource != null)
                    {
                        ToolStripItem item = new ToolStripMenuItem(dataSource.Title, null, GenerateDataSource_Click, dataSource.Id);
                        if (dataSource.SourceTypeText == "Windows Folder")
                        {
                            item.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.DatasourceFolder);
                        }
                        if (dataSource.SourceTypeText == "Microsoft Excel")
                        {
                            item.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.DatasourceExcel);
                        }
                        if (dataSource.SourceTypeText == "Microsoft SQL Server")
                        {
                            item.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.DatasourceDatabase);
                        }
                        this.DropDownItems.Add(item);
                    }
                }
            }
        }

        private void ClearDatasourceList()
        {
            foreach (ToolStripMenuItem item in this.DropDownItems)
                item.Click -= GenerateDataSource_Click;
            this.DropDownItems.Clear();
        }

        private void GenerateDataSource_Click(object sender, EventArgs e)
        {
            if (!XessApplication.FileLoaded)
                return;
            if (string.IsNullOrEmpty(templateId))
                return;

            ITemplate template = XessApplication.GetTemplate(this.templateId);
            IDataSource dataSource = XessApplication.GetDataSourceById(((ToolStripMenuItem)sender).Name);

            bool success = XessApplication.GenerateDataFile(dataSource);
            if (success)
                XessApplication.GenerateTemplate(template);
        }
    }
}
