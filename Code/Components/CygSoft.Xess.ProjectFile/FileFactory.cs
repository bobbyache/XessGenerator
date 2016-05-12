using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace CygSoft.Xess.ProjectFile
{
    public static class FileFactory
    {
        public static IXessFileManager CreateXessProjectFile(string filePath)
        {
            // Always create the latest version of the xess project file.
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement root = xmlDocument.CreateElement("Project");

            XmlAttribute familyAttr = xmlDocument.CreateAttribute("Family");
            familyAttr.Value = "xess";

            XmlAttribute versionAttr = xmlDocument.CreateAttribute("Version");
            versionAttr.Value = "3";

            root.Attributes.Append(familyAttr);
            root.Attributes.Append(versionAttr);

            xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.DocumentElement);
            xmlDocument.AppendChild(root);
            root.AppendChild(xmlDocument.CreateElement("Settings"));
            root.AppendChild(xmlDocument.CreateElement("DataSources"));
            root.AppendChild(xmlDocument.CreateElement("DataMatrixList"));
            root.AppendChild(xmlDocument.CreateElement("Templates"));
            xmlDocument.Save(filePath);

            return new XessFileManager(filePath);
        }

        internal static XmlDocument GetXmlDoc(string filePath)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                string xml = reader.ReadToEnd();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                return xmlDoc;
            }
        }
    }
}
