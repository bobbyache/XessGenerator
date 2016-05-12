using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.Infrastructure.DataSources.SqlServer;
using CygSoft.Xess.Infrastructure.DataSources.Excel;
using CygSoft.Xess.Infrastructure.DataSources.WinFolder;

namespace CygSoft.Xess.ProjectFile
{
    internal class DataSourceWriter
    {
        XElement projectFile = null;
        private string filePath;

        public DataSourceWriter(string filePath)
        {
            this.filePath = filePath;
            projectFile = XElement.Load(filePath);
        }

        private bool DataSourceExists(string id)
        {
            if (projectFile != null)
            {
                int count = projectFile.Elements(Elements_V1.DataSource.CollectionTag).Elements(Elements_V1.DataSource.SingleTag)
                    .Where(xh => (string)xh.Attribute(Elements_V1.DataSource.ID).Value == id).Count();

                return (count == 1);
            }
            return false;
        }

        /// <summary>
        /// Remove the data source from the project file.
        /// </summary>
        public void DeleteDataSource(IDataSource dataSource)
        {
            DeleteSingleDataSource(dataSource);
            projectFile.Save(this.filePath);
        }

        /// <summary>
        /// Remove data sources from the project file.
        /// </summary>
        public void DeleteDataSources(IDataSource[] dataSources)
        {
            foreach (IDataSource dataSource in dataSources)
                DeleteSingleDataSource(dataSource);
            projectFile.Save(this.filePath);
        }

        /// <summary>
        /// Update/Insert an existing or new data source to the project file.
        /// </summary>
        /// <param name="dataSource"></param>
        public void UpdateDataSource(IDataSource dataSource)
        {
            WriteSingleDataSource(dataSource);
            projectFile.Save(this.filePath);
        }

        /// <summary>
        /// Given a datasource list, the list is persisted to the the current file.
        /// </summary>
        /// <param name="dataSourceList"></param>
        public void UpdateDatasources(List<IDataSource> dataSourceList)
        {
            projectFile.Elements(Elements_V1.DataSource.CollectionTag).Elements(Elements_V1.DataSource.SingleTag).Remove();

            foreach (IDataSource dataSource in dataSourceList)
                WriteSingleDataSource(dataSource);

            projectFile.Save(this.filePath);
        }

        private void DeleteSingleDataSource(IDataSource dataSource)
        {
            XElement dataSourceElement = projectFile.Elements(Elements_V1.DataSource.CollectionTag).Elements(Elements_V1.DataSource.SingleTag)
                .Where(xh => (string)xh.Attribute(Elements_V1.DataSource.ID).Value == dataSource.Id).FirstOrDefault();
            dataSourceElement.Remove();
        }

        private void WriteSingleDataSource(IDataSource dataSource)
        {
            if (DataSourceExists(dataSource.Id))
            {
                // update the data source.
                XElement dataSourceElement = projectFile.Elements(Elements_V1.DataSource.CollectionTag).Elements(Elements_V1.DataSource.SingleTag)
                    .Where(xh => (string)xh.Attribute(Elements_V1.DataSource.ID).Value == dataSource.Id).FirstOrDefault();

                dataSourceElement.Attribute(Elements_V1.DataSource.Title).Value = dataSource.Title;
                dataSourceElement.Attribute(Elements_V1.DataSource.Type).Value = dataSource.SourceTypeText;

                if (dataSource is IExcelDataSource)
                {
                    IExcelDataSource excelDataSource = dataSource as IExcelDataSource;
                    dataSourceElement.Element(Elements_V1.DataSource.Connection).Value = excelDataSource.ConnectionString;
                    dataSourceElement.Element(Elements_V1.DataSource.FilePath).Value = excelDataSource.FilePath;
                    dataSourceElement.Element(Elements_V1.DataSource.Sheet).Value = excelDataSource.ActiveSheet;
                    dataSourceElement.Element(Elements_V1.DataSource.TopLeftCell).Value = excelDataSource.TopLeftCell;
                    dataSourceElement.Element(Elements_V1.DataSource.BottomRightCell).Value = excelDataSource.BottomRightCell;
                    dataSourceElement.Element(Elements_V1.DataSource.Provider).Value = excelDataSource.Provider;
                }
                else if (dataSource is ISqlDatabaseDataSource)
                {
                    ISqlDatabaseDataSource sqlDataSource = dataSource as ISqlDatabaseDataSource;
                    dataSourceElement.Element(Elements_V1.DataSource.DBMS).Value = dataSource.SourceTypeText;
                    dataSourceElement.Element(Elements_V1.DataSource.Connection).Value = sqlDataSource.ConnectionString;
                    dataSourceElement.Element(Elements_V1.DataSource.SQLQuery).ReplaceNodes(new XCData(sqlDataSource.CommandText));
                }
                else if (dataSource is IWinFolderDataSource)
                {
                    IWinFolderDataSource folderDataSource = dataSource as IWinFolderDataSource;
                    dataSourceElement.Element(Elements_V1.DataSource.FolderPath).Value = folderDataSource.FolderPath;
                    dataSourceElement.Element(Elements_V1.DataSource.FileFilter).Value = folderDataSource.FileFilterText;
                    dataSourceElement.Element(Elements_V1.DataSource.IncludeSubFolders).Value = folderDataSource.IncludeSubFolders.ToString();
                }
            }
            else
            {
                // create a new data source
                XElement dataSourceElement = new XElement(Elements_V1.DataSource.SingleTag);

                dataSourceElement.Add(new XAttribute(Elements_V1.DataSource.ID, dataSource.Id));
                dataSourceElement.Add(new XAttribute(Elements_V1.DataSource.Title, dataSource.Title));
                dataSourceElement.Add(new XAttribute(Elements_V1.DataSource.Type, dataSource.SourceTypeText));

                if (dataSource is IExcelDataSource)
                {
                    IExcelDataSource excelDataSource = dataSource as IExcelDataSource;

                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.Connection, excelDataSource.ConnectionString));
                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.FilePath, excelDataSource.FilePath));
                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.Sheet, excelDataSource.ActiveSheet));
                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.TopLeftCell, excelDataSource.TopLeftCell));
                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.BottomRightCell, excelDataSource.BottomRightCell));
                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.Provider, excelDataSource.Provider));
                }
                else if (dataSource is ISqlDatabaseDataSource)
                {
                    ISqlDatabaseDataSource sqlDataSource = dataSource as ISqlDatabaseDataSource;

                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.DBMS, dataSource.SourceTypeText));
                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.Connection, sqlDataSource.ConnectionString));
                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.SQLQuery, new XCData(sqlDataSource.CommandText)));
                }
                else if (dataSource is IWinFolderDataSource)
                {
                    IWinFolderDataSource folderDataSource = dataSource as IWinFolderDataSource;
                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.FolderPath, folderDataSource.FolderPath));
                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.FileFilter, folderDataSource.FileFilterText));
                    dataSourceElement.Add(new XElement(Elements_V1.DataSource.IncludeSubFolders, folderDataSource.IncludeSubFolders.ToString()));
                }

                projectFile.Element(Elements_V1.DataSource.CollectionTag).Add(dataSourceElement);
            }
        }
    }
}
