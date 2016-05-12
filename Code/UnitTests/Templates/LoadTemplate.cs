using System;
using System.Collections.Generic;
using CygSoft.Xess.Domain.Templates;
using CygSoft.Xess.ProjectFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CygSoft.Xess.Infrastructure;

namespace UnitTests.Templates
{
    [TestClass]
    [DeploymentItem(@"Files\bankrecon.xess")]
    public class LoadTemplate
    {
        [TestMethod]
        public void LoadTemplateListing()
        {
            // ---------------------------------------------------------------------------------------------------------------------------------------------------------
            // Notes: The FilePath is included in the TemplateListItem for the FE to be able to pick up the file path when a template is selected on the main screen.
            // Probably would want to move this away from the TemplateListItem. It doesn't really need to know the detail. Should just act as a visible "index card".
            // ---------------------------------------------------------------------------------------------------------------------------------------------------------

            TemplateReader reader = new TemplateReader("bankrecon.xess");

            // test that you can get a list of templates...
            List<TemplateListItem> templateListItems = reader.GetTemplateListing();
            TemplateListItem templateListItem = templateListItems[0];

            Assert.AreEqual(6, templateListItems.Count);
            Assert.IsNotNull(templateListItem);

            // Saved to an output file specified by this location. This PATH DOES NOT specify the location of the template or template file.
            Assert.AreEqual(@"\\ctfs\Bigdisk\Rob\Nat Treasury\Work Items\2013 - Bank Recon (Cleaned)\Scripts\2013-09\Scripts\Insert Data - XESS - All Tables (SLIM).sql", 
                templateListItem.FilePath);
            Assert.AreEqual("2e6f0eab-d063-441c-b788-7153344c901d", templateListItem.ID);
            Assert.AreEqual("BankRecon Data Inserts (SLIM)", templateListItem.Title);
        }

        [TestMethod]
        public void LoadTheTemplateCheckProperties()
        {
            // ---------------------------------------------------------------------------------------------------------------------------------------------------------
            // Notes: 
            // 
            //
            //
            //
            // ---------------------------------------------------------------------------------------------------------------------------------------------------------
            TemplateReader reader = new TemplateReader("bankrecon.xess");

            ITemplate template = reader.GetTemplate("2e6f0eab-d063-441c-b788-7153344c901d");

            ITemplateSection staticTemplateSection = template.TemplateSectionList[0];
            ITemplateSection dynamicTemplateSection = template.TemplateSectionList[2];

            // A template's properties.
            Assert.AreEqual("", template.Description);
            //Assert.AreEqual("Structured Query Language File *.sql (*.sql)|*.sql", template.DialogFilter);
            Assert.AreEqual(@"\\ctfs\Bigdisk\Rob\Nat Treasury\Work Items\2013 - Bank Recon (Cleaned)\Scripts\2013-09\Scripts\Insert Data - XESS - All Tables (SLIM).sql", template.FilePath);
            //Assert.AreEqual("Structured Query Language File", template.FileTypeDescription);
            Assert.AreEqual(true, template.HasFile);
            Assert.AreEqual("2e6f0eab-d063-441c-b788-7153344c901d", template.Id);
            Assert.AreEqual(11, template.TemplateSectionList.Count);
            //Assert.AreEqual("SQL", template.TypeOfFile);

            //Assert.AreEqual("*.sql", template.WildCardPrefixedExtension);
            // A Template Section without a data source.
            Assert.AreEqual("5d68a826-2894-4cf3-8329-582ad748c9e1", staticTemplateSection.Id);
            Assert.AreEqual("", staticTemplateSection.DataSourceID);
            Assert.AreEqual("", staticTemplateSection.Description);
            Assert.AreEqual("", staticTemplateSection.FooterText);
            Assert.AreNotEqual("", staticTemplateSection.BodyText);
            Assert.AreEqual("", staticTemplateSection.HeaderText);
            Assert.AreEqual(1, staticTemplateSection.Ordinal);
            Assert.AreEqual("Introduction", staticTemplateSection.Title);

            // A template section with a data source...
            Assert.AreEqual("a998d7e6-9d89-4038-b229-18c6470dd084", dynamicTemplateSection.Id);
            Assert.AreEqual("fdda5fc9-53c8-4fff-bd76-f0a13c03f48d", dynamicTemplateSection.DataSourceID);
            Assert.AreEqual("", dynamicTemplateSection.Description);
            Assert.AreNotEqual("", dynamicTemplateSection.FooterText);
            Assert.AreNotEqual("", dynamicTemplateSection.HeaderText);
            Assert.AreNotEqual("", dynamicTemplateSection.BodyText);
            Assert.AreEqual(3, dynamicTemplateSection.Ordinal);
            Assert.AreEqual("Insert BankDepositStatementItem Recs", dynamicTemplateSection.Title);
        }
    }
}
