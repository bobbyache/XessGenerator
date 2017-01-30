using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure.DataSources.Base
{
    public class DataSourceFileRepository : IDataSourceFileRepository
    {
        public DataTable Read(string filePath, string tableName)
        {
            if (File.Exists(filePath))
            {
                DataSet dataSet = new DataSet();

                dataSet.ReadXml(filePath);
                return dataSet.Tables[tableName];
            }
            return null;
        }

        public void Write(DataTable dataTable, string filePath)
        {
            if (dataTable != null)
                dataTable.WriteXml(filePath);
        }
    }
}
