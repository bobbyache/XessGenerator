﻿
namespace CygSoft.Xess.Infrastructure.DataSources.Excel
{
    public interface IExcelDataSource : IDataSource
    {
        string BottomRightCell { get; set; }
        string ConnectionString { get; }
        string FilePath { get; set; }
        string Provider { get; }
        string ActiveSheet { get; }
        string TopLeftCell { get; set; }

        void ActivateSheet(string sheet);
        void ClearActiveSheet();

        bool OpenDocument();
        string[] GetExcelSheets();
    }
}
