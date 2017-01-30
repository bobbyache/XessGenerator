using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure.DataSources.Base
{
    public interface IDataSourceFileRepository
    {
        DataTable Read(string filePath, string tableName);
        void Write(DataTable dataTable, string filePath);
    }
}
