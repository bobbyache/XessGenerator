using CygSoft.Qik.LanguageEngine;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Xess.Infrastructure;
using System;
using System.Data;

namespace CygSoft.Xess.Domain.Generators
{
    /// <summary>
    /// Generates template section data given a ITemplateSection.
    /// </summary>
    internal class SectionGenerator
    {
        private ITemplateSection templateSection;

        private ICompiler compiler = new CygSoft.Qik.LanguageEngine.Compiler();
        private IGenerator generator = new Generator();
        
        public SectionGenerator(ITemplateSection templateSection, string placeholderPrefix, string placeholderPostfix)
        {
            this.templateSection = templateSection;
        }

        public string Generate()
        {
            SetupCompiler();

            // generate header, body, and footer text.
            string bodyText = string.Empty;
            string headerText = templateSection.HeaderText;
            if (templateSection.HasData)
                bodyText = GenerateData();
            else
                bodyText = templateSection.BodyText;
            string footerText = templateSection.FooterText;

            return headerText + bodyText + footerText;
        }

        private void SetupCompiler()
        {
            string scriptText = "";

            if (!string.IsNullOrEmpty(scriptText))
                compiler.Compile(scriptText);
        }

        private string GenerateData()
        {
            string generatedText = string.Empty;

            DataTable dataTable = templateSection.GetData();

            foreach (DataColumn column in dataTable.Columns)
            {
                compiler.CreateAutoInput("@" + column.ColumnName);
            }

            // for each row in the table...
            for (int y = 0; y < dataTable.Rows.Count; y++)
            {
                string blueprintCopy = templateSection.BodyText;

                foreach (DataColumn column in dataTable.Columns)
                {
                    compiler.Input("@" + column.ColumnName, Convert.ToString(dataTable.Rows[y][column]));
                }

                generatedText += generator.Generate(compiler, blueprintCopy);
            }

            return generatedText;
        }
    }
}
