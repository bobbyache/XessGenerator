using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.App;
using CygX1.UI.WinForms.RecentFileMenu;
using CygSoft.Xess.UI.WinForms.GlobalSettings;
using CygSoft.Xess.Infrastructure.DataSources.Excel;

namespace CygSoft.Xess.UI.WinForms.Dialogs
{
    internal partial class ExcelSourceDialog : Form
    {
        private string connectionsFile;
        private string projectFilePath;
        private RecentFiles recentFiles = null;
        private IExcelDataSource excelDataSource;

        public ExcelSourceDialog(string projectFilePath, string connectionsFile, RegistrySettings registrySettings)
        {
            InitializeComponent();
            this.connectionsFile = connectionsFile;
            this.projectFilePath = projectFilePath;

            if (registrySettings != null)
            {
                this.recentFiles = new RecentFiles();
                this.recentFiles.MaxNoOfFiles = 4;
                this.recentFiles.RegistryPath = registrySettings.InitialDirectory;
                this.recentFiles.RegistrySubFolder = "RecentExcelFiles";
                this.recentFiles.LoadList();

                this.cboFilePath.Items.AddRange(recentFiles.FileList.ToArray());
            }
        }

        internal IExcelDataSource ExcelDataSource
        {
            get { return this.excelDataSource; }
        }

        public void AddNew()
        {
            excelDataSource = XessApplication.NewExcelDataSource(this.projectFilePath, string.Empty);
            cboFilePath.Text = string.Empty;
            txtTitle.Text = excelDataSource.Title;
            txtTopLeftCell.Text = string.Empty;
            txtBottomRightCell.Text = string.Empty;

            btnOk.Enabled = false;
        }

        public void EditExisting(IExcelDataSource excelDataSource, string connectionFile) // you're not using connectionFile parameter???
        {
            if (File.Exists(excelDataSource.FilePath))
            {
                this.excelDataSource = excelDataSource;

                txtTitle.Text = excelDataSource.Title;
                SetFilePath(excelDataSource.FilePath);

                if (SetActiveSheet(true))
                {
                    txtBottomRightCell.Text = excelDataSource.BottomRightCell;
                    txtTopLeftCell.Text = excelDataSource.TopLeftCell;
                }
            }
            else
                MessageBox.Show(this, string.Format("The source data file could not be found. \n{0}", excelDataSource.FilePath), 
                    ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Private Form Events

        private void cboFilePath_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.excelDataSource.FilePath = cboFilePath.Text;
                SetActiveSheet(true);
                LoadGrid();
            }
            catch (Exception ex)
            {
                cboSheets.SelectedItem = null;
                txtTopLeftCell.Text = string.Empty;
                txtBottomRightCell.Text = string.Empty;
                excelGridView.DataSource = null;
                tsStatusLabel.ForeColor = Color.Red;
                tsStatusLabel.Text = ex.Message.ToString();
            }
        }

        private void cboSheets_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.excelDataSource.ActivateSheet(cboSheets.SelectedItem as string);
            txtTopLeftCell.Text = string.Empty;
            txtBottomRightCell.Text = string.Empty;
            LoadGrid();
        }

        private void cboExcelConnectionList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                this.excelDataSource.Title = txtTitle.Text.Trim();
                this.excelDataSource.TopLeftCell = txtTopLeftCell.Text.Trim();
                this.excelDataSource.BottomRightCell = txtBottomRightCell.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Open Excel Spreadsheet";
            openFileDialog.Filter = "Excel 2007 Files (*.xslx)|*.xlsx|Older Excel Files (*.xls)|*.xls";
            openFileDialog.DefaultExt = "*.xmlx|*.xml";
            openFileDialog.AddExtension = true;
            openFileDialog.FilterIndex = 0;
            openFileDialog.CheckFileExists = true;
            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetFilePath(openFileDialog.FileName);
                LoadGrid();
            }
        }

        private void SetFilePath(string filePath)
        {
            OptionallyAddToCombo(filePath);
            cboFilePath.Text = filePath;
            if (recentFiles != null)
                recentFiles.Add(filePath);
        }

        private void txtTopLeftCell_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.excelDataSource.TopLeftCell = txtTopLeftCell.Text.Trim();
                LoadGrid();
            }
        }

        private void txtBottomRightCell_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.excelDataSource.BottomRightCell = txtBottomRightCell.Text.Trim();
                LoadGrid();
            }
        }

        #endregion

        #region Private Procedures

        private void OptionallyAddToCombo(string filePath)
        {
            bool found = false;

            foreach (object item in cboFilePath.Items)
            {
                if (item.ToString() == filePath)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
                cboFilePath.Items.Add(filePath);
        }

        private bool SetActiveSheet(bool refreshCombo)
        {
            if (excelDataSource.SourceIsValid())
            {
                if (refreshCombo || cboSheets.Items.Count == 0)
                    cboSheets.DataSource = this.excelDataSource.GetExcelSheets();

                if (string.IsNullOrEmpty(this.excelDataSource.ActiveSheet))
                {
                    cboSheets.SelectedIndex = 0;
                    this.excelDataSource.ActivateSheet(cboSheets.SelectedItem.ToString());
                }
                else
                {
                    foreach (string item in cboSheets.Items)
                    {
                        if (item.Equals(excelDataSource.ActiveSheet))
                        {
                            cboSheets.SelectedItem = item;
                            return true;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        private bool ValidateFields()
        {
            if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.NoInputValueForMandatoryField("Title"), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboFilePath.Text == "" || !File.Exists(cboFilePath.Text))
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.NoInputValueForMandatoryField("Excel File"), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cboSheets.SelectedItem == null)
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.NoInputValueForMandatoryField("Sheet"), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (excelGridView.DataSource == null)
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.NoInputValueForMandatoryField("Data Source"), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void LoadGrid()
        {
            try
            {
                excelDataSource.FetchData();
                excelGridView.DataSource = excelDataSource.CurrentData;
                tsStatusLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                tsStatusLabel.Text = "Data source fetched successfully.";
                btnOk.Enabled = true;
            }
            catch (Exception ex)
            {
                cboSheets.SelectedItem = null;
                txtTopLeftCell.Text = string.Empty;
                txtBottomRightCell.Text = string.Empty;
                cboSheets.DataSource = null;

                excelGridView.DataSource = null;
                tsStatusLabel.ForeColor = Color.Red;
                tsStatusLabel.Text = ex.Message.ToString();
                btnOk.Enabled = false;
            }
        }

        #endregion
    }
}



