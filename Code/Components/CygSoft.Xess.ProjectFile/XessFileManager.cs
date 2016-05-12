using System.Collections.Generic;
using System.Data;
using CygSoft.Xess.Domain.Templates;
using CygSoft.Xess.Infrastructure;
using System.IO;
using System;

namespace CygSoft.Xess.ProjectFile
{
    public class XessFileManager : IXessFileManager
    {
        private FileVersion fileVersion;
        private DataFiles dataFiles;

        public string FilePath
        {
            get { return this.dataFiles.ProjectFilePath; }
            set { this.dataFiles.ProjectFilePath = value; }
        }

        public string DataMatrixFilePath
        {
            get { return Path.Combine(Path.GetDirectoryName(this.FilePath), Path.GetFileNameWithoutExtension(this.FilePath) + ".xessu"); }
        }

        public bool FileLoaded
        {
            get
            {
                if (string.IsNullOrEmpty(this.FilePath))
                    return false;
                else
                    return true;
            }
        }

        public string VersionFamily
        {
            get { return this.fileVersion.FileVersionFamily; }
        }

        public int VersionNumber
        {
            get { return this.fileVersion.FileVersionNumber; }
        }

        public bool DataMatrixFilePathExists()
        {
            return File.Exists(DataMatrixFilePath);
        }

        public XessFileManager(string filePath)
        {
            string errorMessage;
            this.dataFiles = new DataFiles(filePath);
            this.fileVersion = new FileVersion(FileFactory.GetXmlDoc(filePath));

            if (!this.fileVersion.IsCompatible(out errorMessage))
                throw new ApplicationException(errorMessage);
        }

        public void SaveProjectAs(string destinationFilePath)
        {
            File.Copy(this.FilePath, destinationFilePath, true);
            string fromDataFile = this.DataMatrixFilePath;
            this.FilePath = destinationFilePath;

            File.Copy(fromDataFile, this.DataMatrixFilePath, true);
        }

        public void UpdateDataSource(IDataSource dataSource)
        {
            DataSourceWriter dataSourceWriter = new DataSourceWriter(this.dataFiles.ProjectFilePath);
            dataSourceWriter.UpdateDataSource(dataSource);
        }

        public void DeleteDataSource(IDataSource dataSource)
        {
            DataSourceWriter dataSourceWriter = new DataSourceWriter(this.dataFiles.ProjectFilePath);
            dataSourceWriter.DeleteDataSource(dataSource);
        }

        public void DeleteDataSources(IDataSource[] dataSources)
        {
            DataSourceWriter dataSourceWriter = new DataSourceWriter(this.dataFiles.ProjectFilePath);
            dataSourceWriter.DeleteDataSources(dataSources);
        }

        public IDataSource[] GetDataSources()
        {
            DataSourceReader dataSourceReader = new DataSourceReader(FileFactory.GetXmlDoc(this.dataFiles.ProjectFilePath), this.dataFiles.ProjectFilePath);
            return dataSourceReader.GetDataSources();
        }

        public IDataSource GetDataSource(string id)
        {
            DataSourceReader dataSourceReader = new DataSourceReader(FileFactory.GetXmlDoc(this.dataFiles.ProjectFilePath), this.dataFiles.ProjectFilePath);
            return dataSourceReader.GetDataSource(id);
        }

        public void UpdateDataSources(List<IDataSource> dataSourceList)
        {
            DataSourceWriter dataSourceWriter = new DataSourceWriter(this.dataFiles.ProjectFilePath);
            dataSourceWriter.UpdateDatasources(dataSourceList);
        }

        public List<TemplateListItem> GetTemplateList()
        {
            TemplateReader templateReader = new TemplateReader(this.dataFiles.ProjectFilePath);
            return templateReader.GetTemplateListing();
        }

        public ITemplate GetTemplate(string id)
        {
            TemplateReader templateReader = new TemplateReader(this.dataFiles.ProjectFilePath);
            return templateReader.GetTemplate(id);
        }

        public List<ITemplate> GetTemplates()
        {
            TemplateReader templateReader = new TemplateReader(this.dataFiles.ProjectFilePath);
            List<TemplateListItem> templateListItems = templateReader.GetTemplateListing();

            List<ITemplate> templatesList = new List<ITemplate>();

            foreach (TemplateListItem item in templateListItems)
                templatesList.Add(templateReader.GetTemplate(item.ID));
            return templatesList;
        }

        public void UpdateTemplate(Template template)
        {
            TemplateWriter templateWriter = new TemplateWriter(this.dataFiles.ProjectFilePath);
            templateWriter.UpdateTemplate(template);
        }

        public void UpdateTemplates(List<ITemplate> templateList)
        {
            TemplateWriter templateWriter = new TemplateWriter(this.dataFiles.ProjectFilePath);
            templateWriter.UpdateTemplates(templateList);
        }
    }
}
