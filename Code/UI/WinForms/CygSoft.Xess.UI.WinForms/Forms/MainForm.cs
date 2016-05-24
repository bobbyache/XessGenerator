using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CygSoft.Xess.UI.WinForms.Dialogs;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.App;
using CygX1.UI.WinForms.RecentFileMenu;
using CygSoft.Xess.UI.WinForms.GlobalSettings;
using System.Diagnostics;
using CygSoft.Xess.UI.WinForms.FileBrowsing;


namespace CygSoft.Xess.UI.WinForms.Forms
{
    public partial class MainForm : Form
    {
        // Possible Outlook Navigation Panel Control solution: http://www.codeproject.com/Articles/43181/A-Serious-Outlook-Style-Navigation-Pane-Control
        
        RecentProjectMenu recentProjectMenu;
        RegistrySettings registrySettings;

        public MainForm()
        {
            InitializeComponent();

            /*
             * These settings must come before we start loading stuff, otherwise the
             * syntax (for example) won't be picked up in time.
             * */
            XessApplication.PlaceholderPrefix = ConfigSettings.PlaceholderPrefix;
            XessApplication.PlaceholderPostfix = ConfigSettings.PlaceholderPostfix;
            XessApplication.SyntaxFilePath = ConfigSettings.SyntaxFilePath;

            progressConsole.ProgressMaximum = 100;
            SetGraphics();
            InitializeSettings();
            InitializeRecentProjectMenu();
            InitializeApplicationEvents();
            LoadLastProject();
            EnableControls();
        }

        #region Private Methods

        private void SetGraphics()
        {
            btnGetDifference.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.FileDiff);
            btnGenerateData.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.GenerateData);
            btnSaveDefaultFile.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.SaveOutputFile);
        }

        private void SaveProjectAs()
        {
            FileDialogResult result = ApplicationDialogs.SaveProject(this, registrySettings.InitialDirectory);
            if (result.DialogResult == DialogResult.OK)
            {
                XessApplication.SaveProjectAs(result.FullPath);
                RecordCurrentProject(result.FullPath);
                DisplayCurrentProject();
                EnableControls();
            }
        }

        private void RecordCurrentProject(string fileName)
        {
            recentProjectMenu.Notify(fileName);
            ConfigSettings.LastProject = fileName;
            registrySettings.InitialDirectory = Path.GetDirectoryName(fileName);
        }

        private void LoadLastProject()
        {
            try
            {
                string lastProject = ConfigSettings.LastProject;
                if (!string.IsNullOrEmpty(lastProject))
                {
                    OpenProject(lastProject);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeApplicationEvents()
        {
            XessApplication.BeforeGenerateTemplate += XessApplication_BeforeGenerateTemplate;
            XessApplication.GeneratingTemplateProgressMessage += XessApplication_GeneratingTemplateProgressMessage;
            XessApplication.GeneratingTemplatePercentComplete += XessApplication_GeneratingTemplatePercentComplete;
            XessApplication.AfterGenerateTemplate += XessApplication_AfterGenerateTemplate;

            XessApplication.BeforeGenerateDataSource += XessApplication_BeforeGenerateDataSource;
            XessApplication.GeneratingDataSourceProgressMessage += XessApplication_GeneratingDataSourceProgressMessage;
            XessApplication.GeneratingDataSourceProgressPercent += XessApplication_GeneratingDataSourceProgressPercent;
            XessApplication.AfterGenerateDataSource += XessApplication_AfterGenerateDataSource;
            
            tstripTemplateList.BeforeRefresh += tstripTemplateList_BeforeRefresh;
            tstripTemplateList.AfterRefresh += tstripTemplateList_AfterRefresh;
            tstripTemplateList.SelectionChanged += tstripTemplateList_SelectionChanged;
        }

        private void EnableControls()
        {
            bool fileLoaded = FileLoaded();

            mnuSaveProjectAs.Enabled = fileLoaded;
            btnSaveProjectAs.Enabled = fileLoaded;
            mnuGenerateData.Enabled = fileLoaded;
            mnuManageTemplates.Enabled = fileLoaded;
            mnuExportToFile.Enabled = fileLoaded;

            tstripTemplateList.Enabled = fileLoaded && tstripTemplateList.Items.Count > 0;
            btnGetDifference.Enabled = fileLoaded && tstripTemplateList.Items.Count > 0;
            btnSaveDefaultFile.Enabled = fileLoaded && tstripTemplateList.Items.Count > 0;
            btnGenerateData.Enabled = fileLoaded && tstripTemplateList.Items.Count > 0;
        }

        private void OpenProject(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    XessApplication.OpenProject(filePath);
                    RecordCurrentProject(filePath);
                }
                else
                {
                    DialogResult result = MessageBox.Show(this, CommonConstants.DialogMessages.QueryRemoveNonExistentFileFromRecentList(filePath),
                        ConfigSettings.ApplicationTitle, MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                        recentProjectMenu.Remove(filePath);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DisplayCurrentProject();
                EnableControls();
            }
        }

        private void InitializeSettings()
        {
            registrySettings = new RegistrySettings(ConfigSettings.RegistryPath);
        }

        private void InitializeRecentProjectMenu()
        {
            RecentFiles recentFiles = new RecentFiles();
            recentFiles.MaxNoOfFiles = 15;
            recentFiles.RegistryPath = ConfigSettings.RegistryPath;
            recentFiles.RegistrySubFolder = RegistrySettings.RecentFilesFolder;
            recentFiles.MaxDisplayNameLength = 80;

            recentProjectMenu = new RecentProjectMenu(mnuOpenRecentProject, recentFiles);
            recentProjectMenu.RecentProjectOpened += recentProjectMenu_RecentProjectOpened;
        }

        private void DisplayCurrentProject()
        {
            recentProjectMenu.CurrentlyOpenedFile = "";
            this.Text = string.Format("{0} [{1}]", ConfigSettings.ApplicationTitle, "no project loaded");
            tssFullPath.Text = "no project loaded";

            if (XessApplication.FileLoaded)
            {
                recentProjectMenu.CurrentlyOpenedFile = XessApplication.FilePath;
                this.Text = string.Format("{0} [{1}]", ConfigSettings.ApplicationTitle, Path.GetFileName(XessApplication.FilePath));
                tssFullPath.Text = XessApplication.FilePath;
                outputTextbox.Document.Clear();
                tstripTemplateList.RefreshTemplateList();
                DisplayTemplateInfo();
            }
        }

        private void DisplayTemplateInfo()
        {
            // Display Template Info.
            templateInfoCtrl1.LoadTemplates();
        }

        private void CreateProject()
        {
            FileDialogResult result = ApplicationDialogs.SaveProject(this, registrySettings.InitialDirectory);
            if (result.DialogResult == DialogResult.OK)
            {
                XessApplication.CreateProject(result.FullPath);
                RecordCurrentProject(result.FullPath);
                DisplayCurrentProject();
                EnableControls();
            }
        }

        private bool FileLoaded()
        {
            return XessApplication.FileLoaded;
        }

        private void WriteToDestinationFile(ITemplate template)
        {
            if (template.HasFile)
            {
                XessApplication.SaveGeneratedOutputToDefaultFile(template);

                progressConsole.AppendConsoleText("Updating target file...", Color.Green, false);
                progressConsole.AppendConsoleText(string.Format("Template: {0} written to file \"{1}\"", 
                    template.Title, template.FilePath), Color.White, false);
                progressConsole.AppendConsoleText("", Color.Black, false);

                MessageBox.Show(this, "The default file has been updated.", 
                    ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(this, "No default file exists for this project yet.", 
                    ConfigSettings.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void GenerateTemplate(TemplateListItem templateListItem)
        {
            if (tstripTemplateList.SelectedIndex == -1)
                outputTextbox.Document.Text = "";

            else if (XessApplication.FileLoaded)
            {
                ITemplate template = XessApplication.GetTemplate(templateListItem.ID);
                txtDestinationFilePath.Text = template.FilePath;
                txtDestinationFilePath.ToolTipText = template.FilePath;

                XessApplication.GenerateTemplate(template);
            }
        }

        #endregion

        #region Private Events

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            CreateProject();
        }

        private void mnuCreateProject_Click(object sender, EventArgs e)
        {
            CreateProject();
        }

        private void btnSaveProjectAs_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }

        private void mnuSaveProjectAs_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }

        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            mnuOpenProject_Click(sender, e);
        }

        private void mnuOpenProject_Click(object sender, EventArgs e)
        {
            FileDialogResult result = ApplicationDialogs.OpenProject(this, registrySettings.InitialDirectory);
            if (result.DialogResult == DialogResult.OK)
            {
                OpenProject(result.FullPath);
            }
        }

        private void recentProjectMenu_RecentProjectOpened(object sender, RecentProjectEventArgs e)
        {
            OpenProject(e.RecentFile.FullPath);
        }

        private void tstripTemplateList_SelectionChanged(object sender, Controls.SelectionChangedEventArgs e)
        {
            GenerateTemplate(e.TemplateListItem);
            btnGenerateData.SelectTemplate(e.TemplateListItem.ID);
        }

        private void tstripTemplateList_AfterRefresh(object sender, Controls.AfterRefreshEventArgs e)
        {
            string path = e.Template != null ? e.Template.FilePath : string.Empty;
            txtDestinationFilePath.Text = path;
            txtDestinationFilePath.ToolTipText = path;
        }

        private void tstripTemplateList_BeforeRefresh(object sender, Controls.BeforeRefreshEventArgs e)
        {
        }

        private void XessApplication_BeforeGenerateTemplate(object sender, BeforeTemplateGenerateEventArgs e)
        {
            progressConsole.AppendConsoleText("Generating template...", Color.Green, false);
        }

        private void XessApplication_GeneratingTemplatePercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressConsole.Progress = (int)e.Percentage;
        }

        private void XessApplication_GeneratingTemplateProgressMessage(object sender, ConsoleProgressTextEventArgs e)
        {
            
            progressConsole.AppendConsoleText(e.StatusText, e.IsError ? Color.Red : Color.White, false);
        }

        private void XessApplication_AfterGenerateTemplate(object sender, AfterTemplateGenerateEventArgs e)
        {
            DisplayOutput(e.Text, e.Template.Syntax);
        }

        private void DisplayOutput(string text, string syntax)
        {
            SyntaxFile syntaxFile = XessApplication.GetSyntaxFile(syntax);
            if (syntaxFile == null || string.IsNullOrEmpty(syntaxFile.FilePath))
            {
                SyntaxFile defaultFile = XessApplication.GetSyntaxFile(ConfigSettings.DefaultSyntax);
                if (defaultFile != null)
                    outputTextbox.Document.SyntaxFile = defaultFile == null ? "" : defaultFile.FilePath;
            }
            else
            {
                outputTextbox.Document.SyntaxFile = syntaxFile.FilePath;
            }

            outputTextbox.Document.Text = text;
            progressConsole.AppendConsoleText("", Color.Black, false);
        }

        private void XessApplication_BeforeGenerateDataSource(object sender, BeforeDatasourceGenerateEventArgs e)
        {
            progressConsole.AppendConsoleText("Generating datasource...", Color.Green, false);
        }

        private void XessApplication_GeneratingDataSourceProgressPercent(object sender, PercentCompleteEventArgs e)
        {
            progressConsole.Progress = (int)e.Percentage;
        }

        private void XessApplication_GeneratingDataSourceProgressMessage(object sender, ConsoleProgressTextEventArgs e)
        {
            
            progressConsole.AppendConsoleText(e.StatusText, e.IsError ? Color.Red : Color.White, false);
        }

        private void XessApplication_AfterGenerateDataSource(object sender, AfterDatasourceGenerateEventArgs e)
        {
            progressConsole.AppendConsoleText("", Color.Black, false);
        }

        private void mnuGenerateData_Click(object sender, EventArgs e)
        {
            DataSourceForm dataGenerateForm = new DataSourceForm(ConfigSettings.DataConnectionsFile, this.registrySettings);
            dataGenerateForm.ShowDialog(this);
            tstripTemplateList.RefreshTemplateList();
            DisplayTemplateInfo();
            EnableControls();
        }

        private void mnuManageTemplates_Click(object sender, EventArgs e)
        {
            TemplateForm templateManagement = new TemplateForm(ConfigSettings.DataConnectionsFile, this.registrySettings);
            DialogResult dialogResult = templateManagement.ShowDialog(this);

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                tstripTemplateList.RefreshTemplateList();
                DisplayTemplateInfo();
                EnableControls();
            }
        }

        private void mnuExportToFile_Click(object sender, EventArgs e)
        {
            ITemplate template = XessApplication.GetTemplate((tstripTemplateList.SelectedItem as TemplateListItem).ID);
            if (template == null)
                return;

            FileDialogResult result = ApplicationDialogs.SaveOutputFileAs(this, registrySettings.InitialDirectory, template.Syntax);

            if (result.DialogResult == DialogResult.OK)
            {
                XessApplication.SaveGeneratedOutputToFile(template, result.FullPath);
                MessageBox.Show(this, CommonConstants.DialogMessages.FileSavedNotification, ConfigSettings.ApplicationTitle);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnSaveDefaultFile_Click(object sender, EventArgs e)
        {
            ITemplate template = XessApplication.GetTemplate(tstripTemplateList.SelectedTemplateId);
            WriteToDestinationFile(template);
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            AboutBoxDialog dialog = new AboutBoxDialog();
            dialog.ShowDialog(this);
        }

        private void btnGetDifference_Click(object sender, EventArgs e)
        {
            ITemplate template = XessApplication.GetTemplate((tstripTemplateList.SelectedItem as TemplateListItem).ID);
            if (template == null)
                return;

            string tempFile = XessApplication.CreateTemporaryFile();

            File.WriteAllText(tempFile, outputTextbox.Document.Text);

            Process.Start(ConfigSettings.WinMergePath,
                string.Format("/u \"{0}\" \"{1}\"",
                template.FilePath, tempFile));
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            XessApplication.CleanOutTemporaryFiles();
        }
    }
}
