
namespace CygSoft.Xess.Infrastructure
{
    public interface ICommonDbConnection
    {
        string DBMS { get; }
        string ConnectionString { get; }
        string Title { get; set; }
    }
}
