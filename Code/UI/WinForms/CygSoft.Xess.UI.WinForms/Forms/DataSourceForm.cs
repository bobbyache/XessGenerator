using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.App;
using CygSoft.Xess.UI.WinForms.GlobalSettings;
using CygSoft.Xess.Infrastructure.DataSources.Excel;
using CygSoft.Xess.Infrastructure.DataSources;
using CygSoft.Xess.Infrastructure.DataSources.SqlServer;
using CygSoft.Xess.Infrastructure.DataSources.WinFolder;

namespace CygSoft.Xess.UI.WinForms.Forms
{
    public partial class DataSourceForm : Form
    {
        private RegistrySettings registrySettings = null;
        private string connectionsFile;

        public DataSourceForm(string connectionsFile, RegistrySettings registrySettings)
        {
            InitializeComponent();
            progressConsole1.ProgressMaximum = 100;

            SetControlImages();

            this.connectionsFile = connectionsFile;
            this.registrySettings = registrySettings;

            PopulateList();
        }

        private void SetControlImages()
        {
            btnDelete.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.Delete);
            btnAdd.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.Add);
            btnEdit.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.Edit);
            btnGenerateSelection.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.Generate);
            btnAddExcel.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.AddExcelSource);
            btnAddSqlServer.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.AddSqlServerSource);
            btnAddWindowsFolder.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.AddWindowsFolder);
            btnClearSelection.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.ClearSelectedRecords);
            btnSelectAll.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.SelectAllRecords);
        }

        private void PopulateList()
        {
            lvwDataSources.Items.Clear();
            foreach (IDataSource dataSource in XessApplication.GetDataSources())
                lvwDataSources.Items.Add(AddListItem(dataSource));
        }

        private ListViewItem AddListItem(IDataSource dataSource)
        {
            ListViewItem item = new ListViewItem(dataSource.Title);
            item.Tag = dataSource;
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, dataSource.SourceTypeText));
            return item;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwDataSources.Items)
                item.Checked = true;
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwDataSources.Items)
                item.Checked = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwDataSources.SelectedItems.Count == 1)
            {
                if (lvwDataSources.SelectedItems[0].Tag is IExcelDataSource)
                {
                    IExcelDataSource excelDataSource = lvwDataSources.SelectedItems[0].Tag as IExcelDataSource;
                    DialogResult result = ApplicationDialogs.EditExcelDataSource(XessApplication.FilePath, 
                        ConfigSettings.DataConnectionsFile, this.registrySettings, ref excelDataSource, this);

                    if (result == DialogResult.OK)
                    {
                        XessApplication.UpdateDataSource(excelDataSource);
                        PopulateList();
                    }
                }
                else if (lvwDataSources.SelectedItems[0].Tag is ISqlDatabaseDataSource)
                {
                    ISqlDatabaseDataSource sqlDataSource = lvwDataSources.SelectedItems[0].Tag as ISqlDatabaseDataSource;

                    DialogResult result = ApplicationDialogs.EditSqlServerDataSource(XessApplication.FilePath, 
                        ConfigSettings.DataConnectionsFile, ref sqlDataSource, this);

                    if (result == DialogResult.OK)
                    {
                        XessApplication.UpdateDataSource(sqlDataSource);
                        PopulateList();
                    }
                }
                else if (lvwDataSources.SelectedItems[0].Tag is IWinFolderDataSource)
                {
                    IWinFolderDataSource winFolderDataSource = lvwDataSources.SelectedItems[0].Tag as IWinFolderDataSource;

                    DialogResult result = ApplicationDialogs.EditWinFolderDataSource(XessApplication.FilePath, ref winFolderDataSource, this);
                    if (result == DialogResult.OK)
                    {
                        XessApplication.UpdateDataSource(winFolderDataSource);
                        PopulateList();
                    }
                }
            }
        }

        private IExcelDataSource AddExcelDataSource()
        {
            IExcelDataSource excelDataSource;
            DialogResult result = ApplicationDialogs.NewExcelDataSource(XessApplication.FilePath, ConfigSettings.DataConnectionsFile, this.registrySettings, out excelDataSource, this);

            if (result == DialogResult.OK)
            {
                if (XessApplication.AddDataSource(excelDataSource))
                {
                    PopulateList();
                    return excelDataSource;
                }
            }
            return null;
        }

        private ISqlDatabaseDataSource AddSqlServerDataSource()
        {
            ISqlDatabaseDataSource sqlDataSource;
            DialogResult result = ApplicationDialogs.NewSqlServerDataSource(XessApplication.FilePath, ConfigSettings.DataConnectionsFile, out sqlDataSource, this);

            if (result == DialogResult.OK)
            {
                if (XessApplication.AddDataSource(sqlDataSource))
                    PopulateList();
                return sqlDataSource;
            }
            return null;
        }

        private IWinFolderDataSource AddWindowsFolderDataSource()
        {
            IWinFolderDataSource folderDataSource;
            DialogResult result = ApplicationDialogs.NewWinFolderDataSource(XessApplication.FilePath, out folderDataSource, this);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (XessApplication.AddDataSource(folderDataSource))
                    PopulateList();
                return folderDataSource;
            }
            return null;
        }

        private IDataSource CloneDataSource()
        {
            if (lvwDataSources.SelectedItems.Count == 1)
            {
                if (MessageBox.Show(this, CommonConstants.DialogMessages.CloneDataSourcePrompt, ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    IDataSource dataSource = XessApplication.CloneDataSource(lvwDataSources.SelectedItems[0].Tag as IDataSource);
                    if (XessApplication.AddDataSource(dataSource))
                        PopulateList();
                    return dataSource;
                }
            }
            return null;
        }

        private void btnAddExcel_Click(object sender, EventArgs e)
        {
            IDataSource dataSource = AddExcelDataSource();
            if (dataSource != null)
                GenerateDatasources(new List<IDataSource> { dataSource });
        }

        private void btnAddSqlServer_Click(object sender, EventArgs e)
        {
            IDataSource dataSource = AddSqlServerDataSource();
            if (dataSource != null)
                GenerateDatasources(new List<IDataSource> { dataSource });
        }

        private void btnAddWindowsFolder_Click(object sender, EventArgs e)
        {
            IDataSource dataSource = AddWindowsFolderDataSource();
            if (dataSource != null)
                GenerateDatasources(new List<IDataSource> { dataSource });
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            CloneDataSource();
        }

        private void btnOpenDatasourceFile_Click(object sender, EventArgs e)
        {
            if (lvwDataSources.SelectedItems.Count == 1)
            {
                IExcelDataSource dataSource = lvwDataSources.SelectedItems[0].Tag as IExcelDataSource;

                if (dataSource != null)
                {
                    if (!dataSource.OpenDocument())
                        MessageBox.Show(this, CommonConstants.DialogMessages.ExcelFileNotFound, 
                            ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnGenerateSelection_Click(object sender, EventArgs e)
        {
            if (lvwDataSources.CheckedItems.Count > 0)
                GenerateDatasources(CollectCheckedSources());
        }

        private List<IDataSource> CollectCheckedSources()
        {
            List<IDataSource> checkedDataSourceList = new List<IDataSource>();
            foreach (ListViewItem item in lvwDataSources.Items)
            {
                if (item.Checked)
                    checkedDataSourceList.Add(item.Tag as IDataSource);
            }
            return checkedDataSourceList;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, CommonConstants.DialogMessages.QueryDeletingDataSource,
                ConfigSettings.ApplicationTitle, MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                List<IDataSource> dataSourceList = new List<IDataSource>();

                foreach (ListViewItem item in lvwDataSources.SelectedItems)
                    dataSourceList.Add(item.Tag as IDataSource);

                XessApplication.RemoveDataSources(dataSourceList.ToArray());
                PopulateList();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool GenerateDatasources(List<IDataSource> dataSourceList)
        {
            progressConsole1.AppendConsoleText("Generating selected datasources...", Color.Green, true);

            XessApplication.GeneratingDataSourceProgressMessage += XessApplication_GeneratingDataSourceProgressMessage;
            XessApplication.GeneratingDataSourceProgressPercent += XessApplication_GeneratingDataSourceProgressPercent;
            bool success = XessApplication.GenerateDataFiles(dataSourceList.ToArray());
            XessApplication.GeneratingDataSourceProgressMessage -= XessApplication_GeneratingDataSourceProgressMessage;
            XessApplication.GeneratingDataSourceProgressPercent -= XessApplication_GeneratingDataSourceProgressPercent;

            return success;
        }

        private void XessApplication_GeneratingDataSourceProgressPercent(object sender, PercentCompleteEventArgs e)
        {
            progressConsole1.Progress = (int)e.Percentage;
        }

        private void XessApplication_GeneratingDataSourceProgressMessage(object sender, ConsoleProgressTextEventArgs e)
        {
            progressConsole1.AppendConsoleText(e.StatusText, e.IsError ? Color.Red : Color.White, false);
        }
    }
}
