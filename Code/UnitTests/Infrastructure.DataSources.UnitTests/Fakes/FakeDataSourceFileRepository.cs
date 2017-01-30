using CygSoft.Xess.Infrastructure.DataSources.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSources.UnitTests.Fakes
{
    public class FakeDataSourceFileRepository : IDataSourceFileRepository
    {
        public DataTable Read(string filePath, string tableName)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable("TableName");
            dataSet.Tables.Add(table);
            table.Rows.Add(table.NewRow());
            return table;
        }

        public void Write(DataTable dataTable, string filePath)
        {
            // don't do anything for now...
        }
    }
}
