using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CygSoft.Xess.UI.WinForms.Dialogs;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.UI.WinForms.GlobalSettings;
using CygSoft.Xess.Infrastructure.DataSources.SqlServer;
using CygSoft.Xess.Infrastructure.DataSources.Excel;
using CygSoft.Xess.Infrastructure.DataSources.WinFolder;
using CygSoft.Xess.App;
using CygSoft.Xess.UI.WinForms.FileBrowsing;

namespace CygSoft.Xess.UI.WinForms
{
    public class ApplicationDialogs
    {
        public static string ProjectFilter = "Project Files *.xess (*.xess)|*.xess";
        public static string ProjectExtension = "*.xess";
        //public static string ProjectDataExtension = "*.xdat";

        private static FileDialogBuilder projectDialogBuilder;

        static ApplicationDialogs()
        {
            projectDialogBuilder = new FileDialogBuilder();
            projectDialogBuilder.Title = "Xess Project";
            projectDialogBuilder.FilterIndex = 0;
            projectDialogBuilder.AllowAllFileTypes = false;
            projectDialogBuilder.DefaultExtension = "xess";
            projectDialogBuilder.InitialDirectory = Environment.CurrentDirectory;
            projectDialogBuilder.AddSupportedFileType("xess", "Xess Project Files", ".xess");
        }

        public static FileDialogResult SaveProject(IWin32Window owner, string initialDirectory)
        {
            projectDialogBuilder.Title = "Save Xess Project";
            projectDialogBuilder.InitialDirectory = initialDirectory;

            return WindowDialogs.SaveFileDialog(projectDialogBuilder);
        }

        public static FileDialogResult OpenProject(IWin32Window owner, string initialDirectory)
        {
            projectDialogBuilder.Title = "Open Xess Project";
            projectDialogBuilder.InitialDirectory = initialDirectory;

            return WindowDialogs.OpenFileDialog(projectDialogBuilder);
        }

        public static FileDialogResult SaveOutputFileAs(IWin32Window owner, string initialDirectory, string syntax = null)
        {
            SyntaxFile defaultSyntaxFile = XessApplication.GetSyntaxFile(ConfigSettings.DefaultSyntax);
            SyntaxFile[] allSyntaxFiles = XessApplication.GetSyntaxFiles();

            FileDialogBuilder builder = new FileDialogBuilder();
            builder.Title = "Save Output File";
            builder.FilterIndex = 0;
            builder.AllowAllFileTypes = true;
            builder.InitialDirectory = initialDirectory;

            foreach (SyntaxFile syntaxFile in allSyntaxFiles)
                builder.AddSupportedFileType(syntaxFile.Language.ToUpper(), syntaxFile.Language, syntaxFile.Extension);

            builder.FilterIdentity = syntax == null ? defaultSyntaxFile.Language : syntax;

            return WindowDialogs.SaveFileDialog(builder);
        }

        public static DialogResult NewSqlServerDataSource(string projectFilePath, string connectionsFile, out ISqlDatabaseDataSource dataSource, Form parentForm)
        {
            SqlServerSourceDialog sqlServerForm = new SqlServerSourceDialog(projectFilePath, connectionsFile);
            sqlServerForm.AddNew();
            DialogResult dialogResult = sqlServerForm.ShowDialog(parentForm);
            dataSource = sqlServerForm.SqlServerDataSource;

            return dialogResult;
        }

        public static DialogResult NewExcelDataSource(string projectFilePath, string connectionsFile, RegistrySettings registrySettings, out IExcelDataSource dataSource, Form parentForm)
        {
            ExcelSourceDialog excelConnectionForm = new ExcelSourceDialog(projectFilePath, connectionsFile, registrySettings);
            excelConnectionForm.AddNew();
            DialogResult dialogResult = excelConnectionForm.ShowDialog(parentForm);
            dataSource = excelConnectionForm.ExcelDataSource;

            return dialogResult;
        }

        /// <summary>
        /// Open a dialog to create a new file collection data source.
        /// </summary>
        /// <param name="projectFilePath">The path to the current project file</param>
        /// <param name="dataSource">Return a IWinFolderDataSource object</param>
        /// <param name="parentForm">The owner form for the dialog</param>
        /// <returns></returns>
        public static DialogResult NewWinFolderDataSource(string projectFilePath, out IWinFolderDataSource dataSource, Form parentForm)
        {
            WinFolderSourceDialog winFolderDialog = new WinFolderSourceDialog(projectFilePath);
            winFolderDialog.AddNew();
            DialogResult dialogResult = winFolderDialog.ShowDialog(parentForm);
            dataSource = winFolderDialog.WinFolderDataSource;

            return dialogResult;
        }

        public static DialogResult EditExcelDataSource(string projectFilePath, string connectionsFile, RegistrySettings registrySettings, ref IExcelDataSource dataSource, Form parentForm)
        {
            ExcelSourceDialog excelConnectionForm = new ExcelSourceDialog(projectFilePath, connectionsFile, registrySettings);
            excelConnectionForm.EditExisting(dataSource, connectionsFile);

            DialogResult dialogResult = excelConnectionForm.ShowDialog(parentForm);
            return dialogResult;
        }

        public static DialogResult EditSqlServerDataSource(string projectFilePath, string connectionsFile, ref ISqlDatabaseDataSource dataSource, Form parentForm)
        {
            SqlServerSourceDialog sqlServerConnectionForm = new SqlServerSourceDialog(projectFilePath, connectionsFile);
            sqlServerConnectionForm.EditExisting(dataSource);

            DialogResult dialogResult = sqlServerConnectionForm.ShowDialog(parentForm);
            return dialogResult;
        }

        public static DialogResult EditWinFolderDataSource(string projectFilePath, ref IWinFolderDataSource dataSource, Form parentForm)
        {
            WinFolderSourceDialog winFolderDialog = new WinFolderSourceDialog(projectFilePath);
            winFolderDialog.EditExisting(dataSource);

            DialogResult dialogResult = winFolderDialog.ShowDialog(parentForm);
            return dialogResult;
        }

    }
}
