using System;
using System.Collections.Generic;

namespace CygSoft.Xess.Infrastructure
{
    public interface ITemplate
    {
        event EventHandler<BeforeTemplateGenerateEventArgs> BeforeGenerate;
        event EventHandler<ConsoleProgressTextEventArgs> ProgressMessage;
        event EventHandler<PercentCompleteEventArgs> PercentComplete;
        event EventHandler<AfterTemplateGenerateEventArgs> AfterGenerate;

        string Id { get; set; }
        ITemplateSection AddSection(string title);
        void AddSection(ITemplateSection templateSection);
        void GenerateDataSources();
        string GenerateOutput(string placeholderPrefix, string placeholderPostfix);
        ITemplate Clone();
        bool CanMoveSectionDown(ITemplateSection templateSection);
        bool CanMoveSectionDown(string id);
        bool CanMoveSectionUp(ITemplateSection templateSection);
        bool CanMoveSectionUp(string id);
        void DeleteSection(string id);
        void MoveSectionDown(string id);
        void MoveSectionUp(string id);
        List<ITemplateSection> TemplateSectionList { get; }
        string[] GetExistingDataSourceIds();
        string Title { get; set; }
        bool HasFile { get; }
        string LastOutput { get; }
        string FilePath { get; set; }
        string Syntax { get; set; }
        string Description { get; set; }
    }
}
