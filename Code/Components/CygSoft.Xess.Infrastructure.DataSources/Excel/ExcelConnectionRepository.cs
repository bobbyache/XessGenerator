using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure.DataSources.Excel
{
    public class ExcelConnectionRepository : IExcelConnectionRepository
    {
        public string GetTemplate(ExcelFileExtensionType extensionType)
        {
            return extensionType ==
                ExcelFileExtensionType.XLS ?
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0; HDR = YesIMEX = 2\";" :
                "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties =\"Excel 12.0;HDR=YesIMEX=1\";";

        }
    }
}
