
namespace CygSoft.Xess.Infrastructure
{
    public class TemplateListItem
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public override string ToString()
        {
            return this.Title;
        }
    }
}
