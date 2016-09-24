using System;

namespace CygSoft.Xess.Infrastructure
{
    public interface ITemplateSection : IPositionedItem
    {
        event EventHandler<ConsoleProgressTextEventArgs> ProgressMessage;

        string Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string DataSourceID { get; }
        string HeaderText { get; set; }
        string BodyText { get; set; }
        string FooterText { get; set; }
        string Script { get; set; }
        bool HasDataSource { get; }
        bool HasData { get; }
        ITemplate ParentTemplate { get; }

        void GenerateDataSource();
        System.Data.DataTable GetData();
        string GenerateOutput(string placeholderPrefix, string placeholderPostfix);
        void ChangeDataSource(IDataSource dataSource);
        ITemplateSection Clone(ITemplate parentTemplate, bool preserveTitle);
    }
}
