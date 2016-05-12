using CygSoft.Xess.Infrastructure;
namespace CygSoft.Xess.ProjectFile
{
    public interface IXessFileManager
    {
        string DataMatrixFilePath { get; }
        bool DataMatrixFilePathExists();
        bool FileLoaded { get; }
        string FilePath { get; set; }

        string VersionFamily { get; }
        int VersionNumber { get; }
        
        void SaveProjectAs(string destinationFilePath);

        IDataSource GetDataSource(string id);
        IDataSource[] GetDataSources();
        void DeleteDataSource(IDataSource dataSource);
        void DeleteDataSources(IDataSource[] dataSources);
        void UpdateDataSource(IDataSource dataSource);
        void UpdateDataSources(System.Collections.Generic.List<IDataSource> dataSourceList);

        ITemplate GetTemplate(string id);
        System.Collections.Generic.List<TemplateListItem> GetTemplateList();
        System.Collections.Generic.List<ITemplate> GetTemplates();
        void UpdateTemplate(CygSoft.Xess.Domain.Templates.Template template);
        void UpdateTemplates(System.Collections.Generic.List<ITemplate> templateList);
    }
}
