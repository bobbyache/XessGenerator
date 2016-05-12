using CygSoft.Xess.Infrastructure.DataSources.Excel;
using CygSoft.Xess.Infrastructure.DataSources.SqlServer;
using CygSoft.Xess.Infrastructure.DataSources.WinFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure.DataSources
{
    public class DataSourceFactory
    {
        /// <summary>
        /// Factory method creates a new excel data source.
        /// </summary>
        /// <param name="projectFilePath"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IExcelDataSource NewExcelDataSource(string projectFilePath, string filePath)
        {
            IExcelDataSource dataSource = new ExcelDataSource(string.Empty);
            dataSource.Title = "New Excel Data Source";
            dataSource.ProjectFilePath = projectFilePath;
            dataSource.FilePath = filePath;
            dataSource.TopLeftCell = string.Empty;
            dataSource.BottomRightCell = string.Empty;
            return dataSource;
        }

        /// <summary>
        /// Factory method used to create a new Sql Server data source.
        /// </summary>
        /// <param name="projectFilePath"></param>
        /// <returns></returns>
        public static ISqlDatabaseDataSource NewSqlServerDataSource(string projectFilePath)
        {
            ISqlDatabaseDataSource sqlServerDataSource = new SqlServerDataSource();
            sqlServerDataSource.Title = string.Empty;
            sqlServerDataSource.ProjectFilePath = projectFilePath;
            sqlServerDataSource.CommandText = string.Empty;
            return sqlServerDataSource;
        }

        /// <summary>
        /// Factory method used to create a new Win Folder data source.
        /// </summary>
        /// <param name="projectFilePath"></param>
        /// <returns></returns>
        public static IWinFolderDataSource NewWinFolderDataSource(string projectFilePath)
        {
            IWinFolderDataSource winFolderDataSource = new WinFolderDataSource();
            winFolderDataSource.Title = string.Empty;
            winFolderDataSource.ProjectFilePath = projectFilePath;
            return winFolderDataSource;
        }





        /// <summary>
        /// Factory method used to clone a new excel data source.
        /// </summary>
        /// <param name="projectFilePath"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IExcelDataSource CloneExcelDataSource(IExcelDataSource originalDataSource)
        {
            IExcelDataSource dataSource = new ExcelDataSource(string.Empty);
            dataSource.Title = originalDataSource.Title + " (Copy)";
            dataSource.ProjectFilePath = originalDataSource.ProjectFilePath;
            dataSource.FilePath = originalDataSource.FilePath;
            dataSource.TopLeftCell = originalDataSource.TopLeftCell;
            dataSource.BottomRightCell = originalDataSource.BottomRightCell;
            dataSource.ActivateSheet(originalDataSource.ActiveSheet);
            
            return dataSource;
        }

        /// <summary>
        /// Factory method used to clone a new Sql Server data source.
        /// </summary>
        /// <param name="projectFilePath"></param>
        /// <returns></returns>
        public static ISqlDatabaseDataSource CloneSqlServerDataSource(ISqlDatabaseDataSource originalDataSource)
        {
            ISqlDatabaseDataSource dataSource = new SqlServerDataSource();
            dataSource.Title = originalDataSource.Title + " (Copy)";
            dataSource.ProjectFilePath = originalDataSource.ProjectFilePath;
            dataSource.CommandText = originalDataSource.CommandText;
            dataSource.ConnectionString = originalDataSource.ConnectionString;
            dataSource.DBMS = originalDataSource.DBMS;

            return dataSource;
        }

        /// <summary>
        /// Factory method used to clone a new Win Folder data source.
        /// </summary>
        /// <param name="projectFilePath"></param>
        /// <returns></returns>
        public static IWinFolderDataSource CloneWinFolderDataSource(IWinFolderDataSource originalDataSource)
        {
            IWinFolderDataSource dataSource = new WinFolderDataSource();
            dataSource.Title = originalDataSource.Title + " (Copy)";
            dataSource.ProjectFilePath = originalDataSource.ProjectFilePath;
            dataSource.FileFilterText = originalDataSource.FileFilterText;
            dataSource.FolderPath = originalDataSource.FolderPath;
            dataSource.IncludeSubFolders = originalDataSource.IncludeSubFolders;
            
            return dataSource;
        }
    }
}
