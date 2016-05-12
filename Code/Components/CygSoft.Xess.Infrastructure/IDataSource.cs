using System.Data;

namespace CygSoft.Xess.Infrastructure
{
    public interface IDataSource
    {
        string Id { get; set; }
        string SourceTypeText { get; }
        string TableName { get; }
        string ProjectFilePath { get; set; }
        string DatasetFilePath { get; }
        string Title { get; set; }
        bool SourceIsValid();
        DataTable CurrentData { get; }
        void FetchData();
        void LoadFileData();
        void DeleteFileData();
        void WriteFileData();
        void LoadFileData(bool selectableRows);

        bool DataExists();

    }
}
