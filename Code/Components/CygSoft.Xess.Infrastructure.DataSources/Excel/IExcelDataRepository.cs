using System.Data;

namespace CygSoft.Xess.Infrastructure.DataSources.Excel
{
    public interface IExcelDataRepository
    {
        string[] GetSheetNames(string connectionString);
        bool FileExists(string filePath);
        //TODO: Consider TryLoadExcel with bool and out DataSet.
        DataSet LoadExcel(string connectonString, string activeSheet, string topLeftCell, string bottomRightCell);
        bool OpenExcelFile(string filePath);
    }
}