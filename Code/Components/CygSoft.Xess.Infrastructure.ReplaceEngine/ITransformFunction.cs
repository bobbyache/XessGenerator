
namespace CygSoft.Xess.Infrastructure.ReplaceEngine
{
    public interface ITransformFunction
    {
        int Ordinal { get; set; }
        string OriginalData { get; set; }
        string Transform();
    }
}
