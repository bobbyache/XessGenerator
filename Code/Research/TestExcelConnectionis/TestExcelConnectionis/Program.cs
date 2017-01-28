using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Diagnostics;

namespace TestExcelConnectionis
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        // To do an integration test to test whether the connection string works on this computer.
        // Type the connection string into context.txt and test the connection...
        // Remember:
        // Error: Microsoft.ACE.OLEDB.12.0 is not registered
        // Download and install the Redistributable, Set your build "Platform Target" to x64 for your component.,
        // You can still use the old connection string for Excel 2013: 
        // Microsoft Access Database Engine 2010 Redistributable *** <----- download it. https://www.microsoft.com/en-za/download/details.aspx?id=13255

        private static void Test()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");

            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = File.ReadAllText("connect.txt");
                connection.Open();
                DataTable tbl = connection.GetSchema("Tables");
            }
        }
    }
}
