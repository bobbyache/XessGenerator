using System.Collections.Generic;
using System.Linq;
using CygSoft.Xess.Infrastructure;
using System;

namespace CygSoft.Xess.Domain.Templates
{
    public class Template : PersistableObject, ITemplate
    {
        public event EventHandler<BeforeTemplateGenerateEventArgs> BeforeGenerate;
        public event EventHandler<ConsoleProgressTextEventArgs> ProgressMessage;
        public event EventHandler<PercentCompleteEventArgs> PercentComplete;
        public event EventHandler<AfterTemplateGenerateEventArgs> AfterGenerate;

        private PositionableList<ITemplateSection> templateSections = new PositionableList<ITemplateSection>();

        public List<ITemplateSection> TemplateSectionList
        {
            get { return templateSections.ItemsList.OrderBy(ts => ts.Ordinal).ToList(); }
        }

        public string Title { get; set; }

        private string description;
        public string Description
        {
            get { return this.description; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.description = string.Empty;
                else
                    this.description = value;
            }
        }

        public string FilePath { get; set; }
        public string Syntax { get; set; }

        public bool HasFile
        {
            get { return !string.IsNullOrEmpty(this.FilePath); }
        }

        public string LastOutput { get; private set; }

        public override string ToString()
        {
            return this.Title;
        }

        public Template()
        {
            this.LastOutput = string.Empty;
        }

        public Template(string id, string title)
            : base(id)
        {
            this.Title = title;
            this.LastOutput = string.Empty;
        }

        public void InitializeSections(List<ITemplateSection> templateSections)
        {
            this.templateSections.InitializeList(templateSections);
        }

        public ITemplateSection AddSection(string title)
        {
            ITemplateSection templateSection = new TemplateSection(this);
            templateSection.Title = title;
            templateSection.BodyText = string.Empty;

            templateSections.Insert(templateSection);

            return templateSection;
        }

        public void AddSection(ITemplateSection templateSection)
        {
            templateSections.Insert(templateSection);
        }

        /// <summary>
        /// Generates or re-generates all template data sources for this tempate.
        /// </summary>
        public void GenerateDataSources()
        {
            try
            {
                if (ProgressMessage != null)
                    ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("Generating data sources for template: {0}", this.Title), false));

                // stepping through each template section in the template.
                for (int x = 0; x < this.TemplateSectionList.Count; x++)
                {
                    ITemplateSection templateSection = this.TemplateSectionList[x];

                    templateSection.ProgressMessage += templateSection_ProgressMessage;
                    templateSection.GenerateDataSource();
                    templateSection.ProgressMessage -= templateSection_ProgressMessage;

                    if (PercentComplete != null)
                        PercentComplete(this, new PercentCompleteEventArgs(x + 1, this.TemplateSectionList.Count));
                }
            }
            catch (Exception ex)
            {
                if (ProgressMessage != null)
                    ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("...failure! Error: {0}{1}", Environment.NewLine, ex.Message), true));
            }
        }

        public string GenerateOutput(string placeholderPrefix, string placeholderPostfix)
        {
            string generatedText = string.Empty;

            if (BeforeGenerate != null)
                BeforeGenerate(this, new BeforeTemplateGenerateEventArgs(this));

            try
            {
                if (ProgressMessage != null)
                    ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("Generating template: {0}", this.Title), false));

                // stepping through each template section in the template.
                for (int x = 0; x < this.TemplateSectionList.Count; x++)
                {
                    ITemplateSection templateSection = this.TemplateSectionList[x];

                    templateSection.ProgressMessage += templateSection_ProgressMessage;
                    generatedText += templateSection.GenerateOutput(placeholderPrefix, placeholderPostfix);
                    templateSection.ProgressMessage -= templateSection_ProgressMessage;

                    if (PercentComplete != null)
                        PercentComplete(this, new PercentCompleteEventArgs(x + 1, this.TemplateSectionList.Count));
                }
            }
            catch (Exception ex)
            {
                if (ProgressMessage != null)
                    ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("...failure! Error: {0}{1}", Environment.NewLine, ex.Message), true));
            }

            if (AfterGenerate != null)
                AfterGenerate(this, new AfterTemplateGenerateEventArgs(this, generatedText));

            this.LastOutput = generatedText;
            return generatedText;

        }

        private void templateSection_ProgressMessage(object sender, ConsoleProgressTextEventArgs e)
        {
            if (ProgressMessage != null)
                ProgressMessage(this, e);
        }

        public ITemplate Clone()
        {
            Template cloneTemplate = new Template();
            cloneTemplate.Title = string.Format("Copy of {0}", this.Title);
            cloneTemplate.Description = this.Description;
            cloneTemplate.Syntax = this.Syntax;

            foreach (ITemplateSection templateSection in this.TemplateSectionList)
            {
                ITemplateSection clonedSection = templateSection.Clone(cloneTemplate, true);
                cloneTemplate.AddSection(clonedSection);
            }
            return cloneTemplate;
        }

        public void DeleteSection(string id)
        {

            ITemplateSection templateSection = (from ts in templateSections.ItemsList
                                               where ts.Id == id
                                               select ts).SingleOrDefault();

            templateSections.Remove(templateSection);
        }

        public bool CanMoveSectionUp(string id)
        {
            ITemplateSection templateSection = (from ts in templateSections.ItemsList
                                               where ts.Id == id
                                               select ts).SingleOrDefault();

            return templateSections.CanMoveUp(templateSection);
        }

        public bool CanMoveSectionUp(ITemplateSection templateSection)
        {
            return templateSections.CanMoveUp(templateSection);
        }

        public bool CanMoveSectionDown(string id)
        {
            ITemplateSection templateSection = (from ts in templateSections.ItemsList
                                                where ts.Id == id
                                                select ts).SingleOrDefault();
            return templateSections.CanMoveDown(templateSection);
        }

        public bool CanMoveSectionDown(ITemplateSection templateSection)
        {
            return templateSections.CanMoveDown(templateSection);
        }

        public void MoveSectionUp(string id)
        {
            ITemplateSection templateSection = (from ts in templateSections.ItemsList
                                    where ts.Id == id
                                    select ts).SingleOrDefault();

            if (templateSections.CanMoveUp(templateSection))
                templateSections.MoveUp(templateSection);
        }

        public void MoveSectionDown(string id)
        {
            ITemplateSection templateSection = (from ts in templateSections.ItemsList
                                                where ts.Id == id
                                                select ts).SingleOrDefault();

            if (templateSections.CanMoveDown(templateSection))
                templateSections.MoveDown(templateSection);
        }

        public string[] GetExistingDataSourceIds()
        {
            List<string> dataSources = new List<string>();

            foreach (ITemplateSection section in this.TemplateSectionList)
            {
                // if there are shared data sources, don't duplicate them in the returned array.
                if (!string.IsNullOrEmpty(section.DataSourceID) && !dataSources.Contains(section.DataSourceID))
                    dataSources.Add(section.DataSourceID);
            }
            return dataSources.ToArray();
        }
    }
}
