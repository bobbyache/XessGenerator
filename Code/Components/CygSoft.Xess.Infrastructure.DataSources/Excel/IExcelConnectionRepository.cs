using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure.DataSources.Excel
{
    public enum ExcelFileExtensionType
    {
        XLS,
        XLSX
    }
    public interface IExcelConnectionRepository
    {
        //string GetConnection(string filePath);
        string GetTemplate(ExcelFileExtensionType extensionType);
    }
}
