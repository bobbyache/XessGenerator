using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using CygSoft.Xess.Infrastructure.DataSources.WinFolder;
using CygSoft.Xess.App;
using CygSoft.Xess.UI.WinForms.GlobalSettings;



namespace CygSoft.Xess.UI.WinForms.Dialogs
{
    public partial class WinFolderSourceDialog : Form
    {
        private string projectFilePath;
        private IWinFolderDataSource winFolderDataSource;
        private FolderSearcher folderSearcher = new FolderSearcher();

        public IWinFolderDataSource WinFolderDataSource
        {
            get { return this.winFolderDataSource; }
        }

        public WinFolderSourceDialog(string projectFilePath)
        {
            InitializeComponent();
            this.projectFilePath = projectFilePath;
        }

        public void AddNew()
        {
            winFolderDataSource = XessApplication.NewWinFolderDataSource(this.projectFilePath);
            txtTitle.Text = this.winFolderDataSource.Title;
        }

        public void EditExisting(IWinFolderDataSource winFolderDataSource)
        {
            this.winFolderDataSource = winFolderDataSource;

            txtTitle.Text = this.winFolderDataSource.Title;
            searchDirTextBox.Text = this.winFolderDataSource.FolderPath;
            includeSubDirsCheckBox.Checked = this.winFolderDataSource.IncludeSubFolders;
            fileNameTextBox.Text = this.winFolderDataSource.FileFilterText;
        }

        private void selectSearchDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = searchDirTextBox.Text;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                searchDirTextBox.Text = dlg.SelectedPath;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            resultsList.Items.Clear();
            DisableButtons();

            folderSearcher.IncludeSubFolders = includeSubDirsCheckBox.Checked;
            folderSearcher.FileFilterText = fileNameTextBox.Text.Trim();
            folderSearcher.Search(searchDirTextBox.Text.Trim());

            foreach (string file in folderSearcher.FoundFiles)
                CreateResultsListItem(file);

            EnableButtons();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // Don't open the context menu strip, if there are no items selected:
            if (resultsList.SelectedItems.Count == 0)
                e.Cancel = true;
        }

        private void openContainingFolderContextMenuItem_Click(object sender, EventArgs e)
        {
            // Get the path from the selected item:
            if (resultsList.SelectedItems.Count > 0)
            {
                String path = resultsList.SelectedItems[0].Text;

                // Open its containing folder in Windows Explorer:
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "explorer.exe";
                    startInfo.Arguments = Path.GetDirectoryName(path);
                    Process process = new Process();
                    process.StartInfo = startInfo;
                    process.Start();
                }
                catch (Exception)
                {
                }
            }
        }

        private void resultsList_Resize(object sender, EventArgs e)
        {
            resultsList.Columns[0].Width = resultsList.Width - 230;
        }

        private void EnableButtons()
        {
            searchDirTextBox.Enabled = true;
            selectSearchDirButton.Enabled = true;
            includeSubDirsCheckBox.Enabled = true;
            fileNameTextBox.Enabled = true;
            startButton.Enabled = true;
        }

        private void DisableButtons()
        {
            searchDirTextBox.Enabled = false;
            selectSearchDirButton.Enabled = false;
            includeSubDirsCheckBox.Enabled = false;
            fileNameTextBox.Enabled = false;
            startButton.Enabled = false;
        }



        private void CreateResultsListItem(string filename)
        {
            FileInfo fileSystemInfo = new FileInfo(filename);
            // Create a new item and set its text:
            ListViewItem lvi = new ListViewItem();
            lvi.Text = fileSystemInfo.FullName;

            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
            if (fileSystemInfo is FileInfo)
                lvsi.Text = FileFuncs.GetBytesStringKB(((FileInfo)fileSystemInfo).Length);
            else
                lvsi.Text = "";

            lvi.SubItems.Add(lvsi);

            lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = fileSystemInfo.LastWriteTime.ToShortDateString() + " " + fileSystemInfo.LastWriteTime.ToShortTimeString();
            lvi.SubItems.Add(lvsi);
            lvi.ToolTipText = fileSystemInfo.FullName;
            resultsList.Items.Add(lvi);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                this.winFolderDataSource.Title = txtTitle.Text.Trim();
                this.winFolderDataSource.FolderPath = searchDirTextBox.Text.Trim();
                this.winFolderDataSource.IncludeSubFolders = includeSubDirsCheckBox.Checked;
                this.winFolderDataSource.FileFilterText = fileNameTextBox.Text.Trim();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateFields()
        {
            if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.NoInputValueForMandatoryField("Title"), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (searchDirTextBox.Text.Trim() == "")
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.NoInputValueForMandatoryField("Search Directory"), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (fileNameTextBox.Text.Trim() == "")
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.NoInputValueForMandatoryField("Filename (filter)"), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}
