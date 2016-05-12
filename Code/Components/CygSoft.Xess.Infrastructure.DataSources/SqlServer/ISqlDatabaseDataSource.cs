
namespace CygSoft.Xess.Infrastructure.DataSources.SqlServer
{
    public interface ISqlDatabaseDataSource : IDataSource
    {
        string ConnectionString { get; set; }
        string DBMS { get; set; }
        string CommandText { get; set; }
    }
}
