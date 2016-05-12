using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.Infrastructure.ReplaceEngine;
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
        private SubstitutionMask substitutionMask;

        public SectionGenerator(ITemplateSection templateSection, string placeholderPrefix, string placeholderPostfix)
        {
            this.templateSection = templateSection;
            this.substitutionMask = new SubstitutionMask(placeholderPrefix, placeholderPostfix);
        }

        public string Generate()
        {
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

        private string GenerateData()
        {
            string generatedText = string.Empty;
            ReplaceEngine replaceEngine = new ReplaceEngine(this.substitutionMask);

            DataTable dataTable = templateSection.GetData();
            replaceEngine.GenerateDefaultActions(dataTable);

            // for each row in the table...
            for (int y = 0; y < dataTable.Rows.Count; y++)
            {
                string blueprintCopy = templateSection.BodyText;

                foreach (DataColumn column in dataTable.Columns)
                {
                    // create the sustitution data + placeholder data.
                    SubstitutionExpression[] exps = replaceEngine.CreateSubstitutions(column.ColumnName, 
                        Convert.ToString(dataTable.Rows[y][column]));

                    // subsitute... replace...
                    foreach (SubstitutionExpression exp in exps)
                        blueprintCopy = blueprintCopy.Replace(exp.OutputPlaceholder, exp.OutputData);

                }

                generatedText += blueprintCopy;
            }

            return generatedText;
        }
    }
}
