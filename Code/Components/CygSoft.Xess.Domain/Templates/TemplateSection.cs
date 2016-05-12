using System;
using System.Collections.Generic;
using System.Linq;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.Domain.Generators;

namespace CygSoft.Xess.Domain.Templates
{
    public class TemplateSection : PersistableObject, ITemplateSection
    {
        public event EventHandler<ConsoleProgressTextEventArgs> ProgressMessage;

        private List<int> selectedRows = new List<int>();
        private Blueprint blueprint = new Blueprint();
        private IDataSource dataSource;
        public ITemplate ParentTemplate { get; private set; }

        /// <summary>
        /// Empty constructor means that the datasource will be null
        /// </summary>
        public TemplateSection(ITemplate parentTemplate) 
        { 
            this.dataSource = null;
            this.ParentTemplate = parentTemplate;
        }

        public TemplateSection(ITemplate parentTemplate, IDataSource dataSource)
        {
            this.dataSource = dataSource;
            this.ParentTemplate = parentTemplate;
        }

        public string Title { get; set; }

        public bool HasDataSource
        {
            get { return this.dataSource != null; }
        }

        public bool HasData
        {
            get 
            {
                if (this.dataSource != null)
                    return this.dataSource.DataExists() && this.dataSource.SourceIsValid();
                return false;
            }
        }

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

        public int Ordinal { get; set; }

        public string HeaderText
        {
            get { return this.blueprint.HeaderText; }
            set { this.blueprint.HeaderText = value; }
        }

        public string BodyText
        {
            get { return this.blueprint.BodyText; }
            set { this.blueprint.BodyText = value; }
        }

        public string FooterText
        {
            get { return this.blueprint.FooterText; }
            set { this.blueprint.FooterText = value; }
        }

        private string dataSourceId = string.Empty;
        public string DataSourceID
        {
            get
            {
                if (this.dataSource == null)
                    return string.Empty;
                return this.dataSource.Id;
            }
        }

        public void ChangeDataSource(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        /// <summary>
        /// Retrieves data from the data file (xessu) and returns it as a DataTable.
        /// </summary>
        public System.Data.DataTable GetData()
        {
            if (!this.dataSource.DataExists())
                this.dataSource.FetchData();

            if (this.dataSource.DataExists())
                return this.dataSource.CurrentData;
            return null;
        }


        /// <summary>
        /// Attempts to fetch data from the data source and update the data file (xessu) with the
        /// new data.
        /// </summary>
        public void GenerateDataSource()
        {
            if (this.dataSource != null)
            {
                if (ProgressMessage != null)
                    ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("...processing section data source: {0}", this.dataSource.Title), false));

                DataSourceGenerator generator = new DataSourceGenerator();
                generator.ProgressMessage += generator_ProgressMessage;
                generator.Generate(this.dataSource);
                generator.ProgressMessage -= generator_ProgressMessage;
            }
            else
            {
                if (ProgressMessage != null)
                    ProgressMessage(this, new ConsoleProgressTextEventArgs("...no data source", false));
            }
        }

        /// <summary>
        /// Generate this template's output.
        /// </summary>
        /// <param name="placeholderPrefix">Enclosing prefix pattern</param>
        /// <param name="placeholderPostfix">Enclosing postfix pattern</param>
        /// <param name="updateFirst">Update the data source before generating existing data.</param>
        /// <returns></returns>
        public string GenerateOutput(string placeholderPrefix, string placeholderPostfix)
        {
            string output = string.Empty;
            try
            {
                if (ProgressMessage != null)
                    ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("...processing section: {0}", this.Title), false));

                SectionGenerator sectionGenerator = new SectionGenerator(this, placeholderPrefix, placeholderPostfix);
                output = sectionGenerator.Generate();

                if (this.HasData)
                {
                    if (ProgressMessage != null)
                        ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("...success! No. selected records: {0}.", this.dataSource.CurrentData.Rows.Count), false));
                }
                else if (!string.IsNullOrEmpty(this.DataSourceID))
                {
                    if (ProgressMessage != null)
                        ProgressMessage(this, new ConsoleProgressTextEventArgs("...failure! No data file found or data not generated.", true));
                }
                else
                {
                    if (ProgressMessage != null)
                        ProgressMessage(this, new ConsoleProgressTextEventArgs("...success! No data source is attached.", false));
                }
            }
            catch (Exception ex)
            {
                if (ProgressMessage != null)
                    ProgressMessage(this, new ConsoleProgressTextEventArgs(string.Format("...failure! Error: {0}{1}", Environment.NewLine, ex.Message), true));
            }

            return output;
        }

        public ITemplateSection Clone(ITemplate parentTemplate, bool preserveTitle)
        {
            ITemplateSection cloneSection = new TemplateSection(parentTemplate, this.dataSource);

            if (preserveTitle)
                cloneSection.Title = this.Title;
            else
                cloneSection.Title = string.Format("Copy of {0}", this.Title);
            cloneSection.FooterText = this.FooterText;
            cloneSection.HeaderText = this.HeaderText;
            cloneSection.BodyText = this.BodyText;
            cloneSection.Ordinal = this.Ordinal;
            cloneSection.Description = this.Description;

            return cloneSection;
        }

        private void generator_ProgressMessage(object sender, ConsoleProgressTextEventArgs e)
        {
            if (ProgressMessage != null)
                ProgressMessage(this, e);
        }

    }
}
