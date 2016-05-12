using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
using CygSoft.Xess.Domain.Templates;
using System.Xml.Linq;
using CygSoft.Xess.Infrastructure;

namespace CygSoft.Xess.ProjectFile
{
    internal class TemplateReader
    {
        private XmlDocument xmlDoc;
        private string filePath;
        private DataSourceReader dataSourceReader;

        public TemplateReader(string filePath)
        {
            this.filePath = filePath;
            this.xmlDoc = FileFactory.GetXmlDoc(filePath);
            this.dataSourceReader = new DataSourceReader(xmlDoc, filePath);
        }

        public List<TemplateListItem> GetTemplateListing()
        {
            XElement el = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);
            IEnumerable<TemplateListItem> items = from e in el.Elements(Elements_V1.Template.CollectionTag).Elements(Elements_V1.Template.SingleTag)
                                                  select new TemplateListItem
                                                  {
                                                      ID = (string)e.Attribute(Elements_V1.Template.ID),
                                                      Title = (string)e.Attribute(Elements_V1.Template.Title),
                                                      FilePath = (string)e.Element(Elements_V1.Template.FilePath)
                                                  };
            return items.ToList();
        }

        public ITemplate GetTemplate(string id)
        {
            Template template = null;

            XElement el = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);

            XElement templateElement = el.XPathSelectElements(Elements_V1.Template.XPathToCollection)
                .Where(x => x.Attribute(Elements_V1.Template.ID).Value == id).FirstOrDefault();

            template = new Template((string)templateElement.Attribute(Elements_V1.Template.ID), (string)templateElement.Attribute(Elements_V1.Template.Title));
            template.FilePath = (string)templateElement.Element(Elements_V1.Template.FilePath);
            template.Syntax = GetSyntax(templateElement);
            template.Description = (string)templateElement.Element(Elements_V1.Template.Description);

            List<ITemplateSection> templateSections = (from e in templateElement.Elements(Elements_V1.TemplateSection.SingleTag)
                                                       select new TemplateSection(template, dataSourceReader.GetDataSource((string)e.Attribute(Elements_V1.TemplateSection.DataSourceID)))
                                                       {
                                                           Id = (string)e.Attribute(Elements_V1.TemplateSection.ID),
                                                           Title = (string)e.Attribute(Elements_V1.Template.Title),
                                                           Description = (string)e.Element(Elements_V1.Template.Description),
                                                           Ordinal = (int)e.Attribute(Elements_V1.TemplateSection.Ordinal),
                                                           HeaderText = (string)e.Element(Elements_V1.TemplateSection.HeaderBlueprint),
                                                           BodyText = (string)e.Element(Elements_V1.TemplateSection.Blueprint),
                                                           FooterText = (string)e.Element(Elements_V1.TemplateSection.FooterBlueprint)
                                                       }).ToList<ITemplateSection>();

            template.InitializeSections(templateSections);

            return template;
        }

        private string GetSyntax(XElement templateElement)
        {
            XElement element = templateElement.Element(Elements_V1.Template.Syntax);

            if (element == null)
                return null;

            if ((string)element == string.Empty)
                return null;

            return (string)element;
        }
    }
}
