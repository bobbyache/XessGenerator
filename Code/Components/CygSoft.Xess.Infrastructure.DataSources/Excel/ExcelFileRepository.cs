using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using System.Diagnostics;
using System;

namespace CygSoft.Xess.Infrastructure.DataSources.Excel
{
    internal class ExcelFileRepository : IExcelFileRepository
    {
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public DataSet LoadExcel(string connectonString, string activeSheet, string topLeftCell, string bottomRightCell)
        {
            DataSet ds = new DataSet();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbConnection conn = new OleDbConnection(connectonString);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            cmd = new OleDbCommand(GetSelectQuery(activeSheet, topLeftCell, bottomRightCell), conn);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            da.Dispose();
            conn.Close();
            conn.Dispose();

            return ds;
        }

        public string[] GetSheetNames(string connectionString)
        {

            List<string> sheets = new List<string>();
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            DbConnection connection = factory.CreateConnection();

            connection.ConnectionString = connectionString;
            connection.Open();

            DataTable tbl = connection.GetSchema("Tables");
            connection.Close();

            foreach (DataRow row in tbl.Rows)
            {
                string sheetName = (string)row["TABLE_NAME"];
                if (sheetName.EndsWith("$"))
                    sheetName = sheetName.Substring(0, sheetName.Length - 1);
                sheets.Add(sheetName);
            }
            return sheets.ToArray();
        }

        private string GetSelectQuery(string sheet, string topLeftCell, string bottomRightCell)
        {

            if ((string.IsNullOrEmpty(topLeftCell) && string.IsNullOrEmpty(bottomRightCell)) || string.IsNullOrEmpty(topLeftCell))
                return "SELECT * FROM [" + sheet + "$]";

            else if (string.IsNullOrEmpty(bottomRightCell))
                return string.Format("SELECT * FROM [{0}${1}:BA65000]", sheet, topLeftCell);

            else
            {
                //string query = String.Format("select * from [{0}${1}]", "Sheet1","A2:ZZ");
                return string.Format("SELECT * FROM [{0}${1}:{2}]", sheet, topLeftCell, bottomRightCell);
            }
        }

        public bool OpenExcelFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("excel.exe", string.Format("\"{0}\"", filePath));
                processStartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                Process.Start(processStartInfo);
                return true;
            }
            return false;
        }
    }
}
