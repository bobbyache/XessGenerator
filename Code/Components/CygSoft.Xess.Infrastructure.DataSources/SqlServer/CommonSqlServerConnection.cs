using System.Data.SqlClient;

namespace CygSoft.Xess.Infrastructure.DataSources.SqlServer
{
    internal class CommonSqlServerConnection : ICommonDbConnection
    {
        private SqlConnectionStringBuilder sqlConnectionBuilder;

        public CommonSqlServerConnection(string connectionString)
        {
            sqlConnectionBuilder = new SqlConnectionStringBuilder(connectionString);
        }

        public string ConnectionString { get { return sqlConnectionBuilder.ConnectionString; } }

        public string Title { get; set; }

        public string DBMS
        {
            get { return "Microsoft SQL Server"; }
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
