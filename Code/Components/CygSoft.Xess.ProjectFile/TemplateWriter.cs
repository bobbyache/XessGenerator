using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CygSoft.Xess.Domain.Templates;
using CygSoft.Xess.Infrastructure;

namespace CygSoft.Xess.ProjectFile
{
    internal class TemplateWriter
    {
        XElement projectFile = null;
        private string filePath;

        public TemplateWriter(string filePath)
        {
            this.filePath = filePath;
            projectFile = XElement.Load(filePath);
        }

        private bool TemplateExists(string id)
        {
            if (projectFile != null)
            {
                int count = projectFile.Element(Elements_V1.Template.CollectionTag).Elements(Elements_V1.Template.SingleTag)
                    .Where(xh => (string)xh.Attribute(Elements_V1.Template.ID).Value == id).Count();

                return (count == 1);
            }
            return false;
        }

        public void UpdateTemplates(List<ITemplate> templatesList)
        {
            projectFile.Elements(Elements_V1.Template.CollectionTag).Elements(Elements_V1.Template.SingleTag).Remove();

            foreach (ITemplate template in templatesList)
            {
                XElement templateElement = new XElement(Elements_V1.Template.SingleTag);

                templateElement.Add(new XAttribute(Elements_V1.Template.Title, template.Title));
                templateElement.Add(new XAttribute(Elements_V1.Template.ID, template.Id));
                templateElement.Add(new XElement(Elements_V1.Template.FilePath, template.FilePath));
                templateElement.Add(new XElement(Elements_V1.Template.Syntax, template.Syntax == null ? "" : template.Syntax));
                templateElement.Add(new XElement(Elements_V1.Template.Description, new XCData(template.Description == null ? string.Empty : template.Description)));

                foreach (ITemplateSection section in template.TemplateSectionList)
                {
                    XElement templateSectionElement = new XElement(Elements_V1.TemplateSection.SingleTag);
                    templateSectionElement.Add(new XAttribute(Elements_V1.TemplateSection.ID, section.Id));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.Description, new XCData(section.Description == null ? string.Empty : section.Description)));
                    templateSectionElement.Add(new XAttribute(Elements_V1.TemplateSection.Ordinal, section.Ordinal));
                    templateSectionElement.Add(new XAttribute(Elements_V1.TemplateSection.DataSourceID, section.DataSourceID));
                    templateSectionElement.Add(new XAttribute(Elements_V1.TemplateSection.Title, section.Title));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.HeaderBlueprint, new XCData(section.HeaderText)));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.Blueprint, new XCData(section.BodyText)));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.FooterBlueprint, new XCData(section.FooterText)));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.Script, new XCData(section.Script)));

                    templateElement.Add(templateSectionElement);
                }
                projectFile.Element(Elements_V1.Template.CollectionTag).Add(templateElement);
            }
            projectFile.Save(this.filePath);
        }

        public void UpdateTemplate(Template template)
        {
            if (TemplateExists(template.Id))
            {
                XElement templateElement = projectFile.Elements(Elements_V1.Template.CollectionTag).Elements(Elements_V1.Template.SingleTag)
                    .Where(xh => (string)xh.Attribute(Elements_V1.Template.ID).Value == template.Id).FirstOrDefault();

                templateElement.Attribute(Elements_V1.Template.Title).Value = template.Title;
                templateElement.Element(Elements_V1.Template.FilePath).Value = template.FilePath;
                templateElement.Element(Elements_V1.Template.Syntax).Value = template.Syntax == null ? "" : template.Syntax;
                templateElement.Element(Elements_V1.Template.Description).Value = template.Description;

                templateElement.RemoveNodes();

                foreach (TemplateSection section in template.TemplateSectionList)
                {
                    XElement templateSectionElement = new XElement(Elements_V1.TemplateSection.SingleTag);
                    templateSectionElement.Add(new XAttribute(Elements_V1.TemplateSection.Ordinal, section.Ordinal));
                    templateSectionElement.Add(new XAttribute(Elements_V1.TemplateSection.DataSourceID, section.DataSourceID));
                    templateSectionElement.Add(new XAttribute(Elements_V1.TemplateSection.Title, section.Title));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.Description, new XCData(section.Description)));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.HeaderBlueprint, new XCData(section.HeaderText)));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.Blueprint, new XCData(section.BodyText)));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.FooterBlueprint, new XCData(section.FooterText)));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.Script, new XCData(section.Script)));

                    templateElement.Add(templateSectionElement);
                }
            }
            else
            {
                XElement templateElement = new XElement(Elements_V1.Template.SingleTag);

                templateElement.Add(new XAttribute(Elements_V1.Template.Title, template.Title));
                templateElement.Add(new XAttribute(Elements_V1.Template.ID, template.Id));
                templateElement.Add(new XElement(Elements_V1.Template.FilePath, template.FilePath));
                templateElement.Add(new XElement(Elements_V1.Template.Syntax, template.Syntax == null ? "" : template.Syntax));
                templateElement.Add(new XElement(Elements_V1.Template.Description, new XCData(template.Description)));

                foreach (TemplateSection section in template.TemplateSectionList)
                {
                    XElement templateSectionElement = new XElement(Elements_V1.TemplateSection.SingleTag);
                    templateSectionElement.Add(new XAttribute(Elements_V1.TemplateSection.ID, section.Id));
                    templateSectionElement.Add(new XAttribute(Elements_V1.TemplateSection.Ordinal, section.Ordinal));
                    templateSectionElement.Add(new XAttribute(Elements_V1.TemplateSection.DataSourceID, section.DataSourceID));
                    templateSectionElement.Add(new XAttribute(Elements_V1.TemplateSection.Title, section.Title));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.Description, new XCData(section.Description)));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.HeaderBlueprint, new XCData(section.HeaderText)));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.Blueprint, new XCData(section.BodyText)));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.FooterBlueprint, new XCData(section.FooterText)));
                    templateSectionElement.Add(new XElement(Elements_V1.TemplateSection.Script, new XCData(section.Script)));

                    templateElement.Add(templateSectionElement);
                }

                projectFile.Element(Elements_V1.Template.CollectionTag).Add(templateElement);
                projectFile.Save(this.filePath);
            }
        }
    }
}
