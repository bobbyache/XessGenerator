using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using CygSoft.Xess.Infrastructure;
using System.Linq;
using System.Xml.Linq;
using CygSoft.Xess.Infrastructure.DataSources.SqlServer;
using CygSoft.Xess.Infrastructure.DataSources.Excel;
using CygSoft.Xess.Infrastructure.DataSources.WinFolder;
using System.Text;
using System;

namespace CygSoft.Xess.ProjectFile
{
    internal class DataSourceReader
    {
        private XmlDocument xmlDoc;
        private DataFiles dataFiles;

        public DataSourceReader(XmlDocument xmlDoc, string projectFilePath)
        {
            this.xmlDoc = xmlDoc;
            this.dataFiles = new DataFiles(projectFilePath);
        }

        public IDataSource GetDataSource(string id)
        {
            XElement el = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);

            XElement datasourceElement = el.XPathSelectElements(Elements_V1.DataSource.XPathToCollection)
                .Where(x => x.Attribute(Elements_V1.DataSource.ID).Value == id).FirstOrDefault();

            if (datasourceElement != null)
            {
                string type = (string)datasourceElement.Attribute(Elements_V1.DataSource.Type);

                if (type == "Microsoft Excel")
                {
                    IExcelDataSource dataSource = new ExcelDataSource(string.Empty, (string)datasourceElement.Attribute(Elements_V1.DataSource.ID));
                    dataSource.Title = (string)datasourceElement.Attribute(Elements_V1.DataSource.Title);
                    dataSource.FilePath = (string)datasourceElement.Element(Elements_V1.DataSource.FilePath);
                    dataSource.ProjectFilePath = this.dataFiles.ProjectFilePath;
                    dataSource.ActivateSheet((string)datasourceElement.Element(Elements_V1.DataSource.Sheet));
                    dataSource.TopLeftCell = (string)datasourceElement.Element(Elements_V1.DataSource.TopLeftCell);
                    dataSource.BottomRightCell = (string)datasourceElement.Element(Elements_V1.DataSource.BottomRightCell);

                    return dataSource;
                }
                else if (type == "Microsoft SQL Server")
                {
                    ISqlDatabaseDataSource dataSource = new SqlServerDataSource((string)datasourceElement.Attribute(Elements_V1.DataSource.ID));
                    dataSource.Title = (string)datasourceElement.Attribute(Elements_V1.DataSource.Title);
                    dataSource.ProjectFilePath = this.dataFiles.ProjectFilePath;
                    dataSource.ConnectionString = (string)datasourceElement.Element(Elements_V1.DataSource.Connection);
                    dataSource.DBMS = (string)datasourceElement.Element(Elements_V1.DataSource.DBMS);
                    dataSource.CommandText = (string)datasourceElement.Element(Elements_V1.DataSource.SQLQuery);

                    return dataSource;
                }
                else if (type == "Windows Folder")
                {
                    IWinFolderDataSource dataSource = new WinFolderDataSource((string)datasourceElement.Attribute(Elements_V1.DataSource.ID));
                    dataSource.Title = (string)datasourceElement.Attribute(Elements_V1.DataSource.Title);
                    dataSource.ProjectFilePath = this.dataFiles.ProjectFilePath;
                    dataSource.FolderPath = (string)datasourceElement.Element(Elements_V1.DataSource.FolderPath);
                    dataSource.FileFilterText = (string)datasourceElement.Element(Elements_V1.DataSource.FileFilter);
                    dataSource.IncludeSubFolders = (bool)datasourceElement.Element(Elements_V1.DataSource.IncludeSubFolders);

                    return dataSource;
                }
            }
            return null;
        }

        private DateTime OptionalDateFromText(string text, DateTime emptyDateRepresentation)
        {
            if (string.IsNullOrEmpty(text))
                return emptyDateRepresentation;
            
            DateTime dateTime;
            if (DateTime.TryParse(text, out dateTime))
                return dateTime;
            else
                return emptyDateRepresentation;
        }

        private Encoding EncodingFromText(string text)
        {
            if (text == "ASCII")
                return Encoding.ASCII;
            else
                return Encoding.UTF8;
        }

        public IDataSource[] GetDataSources()
        {
            List<IDataSource> dataSources = new List<IDataSource>();
            XPathNavigator navigator = xmlDoc.CreateNavigator();
            XPathNodeIterator iterator = navigator.Select(Elements_V1.DataSource.XPathToCollection);

            while (iterator.MoveNext())
            {
                string type = iterator.Current.GetAttribute(Elements_V1.DataSource.Type, "");

                if (type == "Microsoft Excel")
                {
                    ExcelDataSource excelDataSource = new ExcelDataSource(string.Empty, iterator.Current.GetAttribute(Elements_V1.DataSource.ID, ""));
                    excelDataSource.Title = iterator.Current.GetAttribute(Elements_V1.DataSource.Title, "");

                    if (iterator.Current.HasChildren)
                    {
                        XPathNodeIterator excelSourceIterator = iterator.Current.SelectChildren(XPathNodeType.Element);

                        string filePath = string.Empty;
                        string activeSheet = string.Empty;
                        string topLeftCell = string.Empty;
                        string bottomRightCell = string.Empty;

                        while (excelSourceIterator.MoveNext())
                        {
                            switch (excelSourceIterator.Current.Name)
                            {
                                case Elements_V1.DataSource.FilePath:
                                    filePath = excelSourceIterator.Current.Value;
                                    break;
                                case Elements_V1.DataSource.Sheet:
                                    activeSheet = excelSourceIterator.Current.Value;
                                    break;
                                case Elements_V1.DataSource.TopLeftCell:
                                    topLeftCell = excelSourceIterator.Current.Value;
                                    break;
                                case Elements_V1.DataSource.BottomRightCell:
                                    bottomRightCell = excelSourceIterator.Current.Value;
                                    break;
                            }
                        }

                        excelDataSource.FilePath = filePath;
                        excelDataSource.ProjectFilePath = this.dataFiles.ProjectFilePath;
                        excelDataSource.ActivateSheet(activeSheet);
                        excelDataSource.TopLeftCell = topLeftCell;
                        excelDataSource.BottomRightCell = bottomRightCell;
                    }

                    dataSources.Add(excelDataSource);
                }

                else if (type == "Microsoft SQL Server")
                {
                    ISqlDatabaseDataSource sqlDataSource = new SqlServerDataSource(iterator.Current.GetAttribute(Elements_V1.DataSource.ID, ""));
                    sqlDataSource.Title = iterator.Current.GetAttribute(Elements_V1.DataSource.Title, "");

                    if (iterator.Current.HasChildren)
                    {
                        XPathNodeIterator sqlSourceSourceIterator = iterator.Current.SelectChildren(XPathNodeType.Element);

                        while (sqlSourceSourceIterator.MoveNext())
                        {
                            switch (sqlSourceSourceIterator.Current.Name)
                            {
                                case Elements_V1.DataSource.Connection:
                                    sqlDataSource.ConnectionString = sqlSourceSourceIterator.Current.Value;
                                    break;
                                case Elements_V1.DataSource.DBMS:
                                    sqlDataSource.DBMS = sqlSourceSourceIterator.Current.Value;
                                    break;
                                case Elements_V1.DataSource.SQLQuery:
                                    sqlDataSource.CommandText = sqlSourceSourceIterator.Current.Value.Trim();
                                    break;
                            }
                        }
                    }

                    sqlDataSource.ProjectFilePath = this.dataFiles.ProjectFilePath;

                    dataSources.Add(sqlDataSource);
                }
                else if (type == "Windows Folder")
                {
                    IWinFolderDataSource folderDataSource = new WinFolderDataSource(iterator.Current.GetAttribute(Elements_V1.DataSource.ID, ""));
                    folderDataSource.Title = iterator.Current.GetAttribute(Elements_V1.DataSource.Title, "");

                    if (iterator.Current.HasChildren)
                    {
                        XPathNodeIterator folderSourceInterator = iterator.Current.SelectChildren(XPathNodeType.Element);

                        while (folderSourceInterator.MoveNext())
                        {
                            switch (folderSourceInterator.Current.Name)
                            {
                                case Elements_V1.DataSource.FolderPath:
                                    folderDataSource.FolderPath = folderSourceInterator.Current.Value;
                                    break;
                                case Elements_V1.DataSource.FileFilter:
                                    folderDataSource.FileFilterText = folderSourceInterator.Current.Value;
                                    break;
                                case Elements_V1.DataSource.IncludeSubFolders:
                                    folderDataSource.IncludeSubFolders = bool.Parse(folderSourceInterator.Current.Value);
                                    break;
                            }
                        }
                    }

                    folderDataSource.ProjectFilePath = this.dataFiles.ProjectFilePath;

                    dataSources.Add(folderDataSource);
                }
            }

            return dataSources.ToArray();
        }
    }
}
