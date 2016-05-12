using System;
using System.Data;
using System.Data.SqlClient;

namespace CygSoft.Xess.Infrastructure.DataSources.SqlServer
{
    public class SqlServerDataSource : AbstractDataSource, ISqlDatabaseDataSource
    {
        SqlConnectionStringBuilder sqlConnectionBuilder = new SqlConnectionStringBuilder();

        public SqlServerDataSource()
        {
            this.SourceTypeText = "Microsoft SQL Server";
            this.DBMS = this.SourceTypeText;
        }

        public SqlServerDataSource(string guidString) : base(guidString) 
        {
            this.SourceTypeText = "Microsoft SQL Server";
            this.DBMS = this.SourceTypeText;
        }

        public string ConnectionString
        {
            get { return sqlConnectionBuilder.ConnectionString; }
            set { this.sqlConnectionBuilder.ConnectionString = value; }
        }

        public string CommandText
        {
            get;
            set;
        }

        public string DBMS
        {
            get;
            set;
        }

        public override void FetchData()
        {
            DataSet dataset = new DataSet();

            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionBuilder.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(this.CommandText, sqlConnection))
                {
                    sqlCommand.CommandTimeout = sqlConnection.ConnectionTimeout;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        int result = sqlDataAdapter.Fill(dataset, this.TableName);
                    }
                }
            }

            DataTable dataTable = dataset.Tables[0].Copy();
            dataTable.TableName = this.TableName;
            base.SetFileData(dataTable);
        }

        public override bool SourceIsValid()
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
