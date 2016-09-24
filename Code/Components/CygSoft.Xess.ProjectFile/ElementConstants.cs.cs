using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CygSoft.Xess.Domain.Templates;

namespace CygSoft.Xess.ProjectFile
{
    internal class Elements_V1
    {
        internal class Template
        {
            public const string ID = "ID";
            public const string Title = "Title";
            public const string FilePath = "FilePath";
            public const string Syntax = "Syntax";
            public const string Description = "Description";
            public const string SingleTag = "Template";
            public const string CollectionTag = "Templates";

            public static string XPathToCollection { get { return string.Format("//{0}/{1}", Template.CollectionTag, Template.SingleTag); } }
        }

        internal class TemplateSection
        {
            public const string ID = "ID";
            public const string Title = "Title";
            public const string Description = "Description";
            public const string SingleTag = "TemplateSection";
            public const string CollectionTag = "TemplateSections";

            public const string DataSourceID = "DataSourceID";
            public const string Ordinal = "Ordinal";
            public const string HeaderBlueprint = "HeaderBlueprint";
            public const string Blueprint = "Blueprint";
            public const string FooterBlueprint = "FooterBlueprint";
            public const string Script = "Script";

            public static string XPathToCollection { get { return string.Format("//{0}/{1}", TemplateSection.CollectionTag, TemplateSection.SingleTag); } }
        }

        internal class DataSource
        {
            public const string ID = "ID";
            public const string Title = "Title";
            public const string SingleTag = "DataSource";
            public const string CollectionTag = "DataSources";

            public const string Type = "Type";
            public const string Connection = "Connection";
            public const string FilePath = "FilePath";
            public const string Sheet = "Sheet";
            public const string TopLeftCell = "TopLeftCell";
            public const string BottomRightCell = "BottomRightCell";
            public const string Provider = "Provider";
            public const string DBMS = "DBMS";
            public const string SQLQuery = "SQL";
            public const string FolderPath = "FolderPath";

            public const string FileFilter = "FileFilter";
            public const string IncludeSubFolders = "IncludeSubFolders";

            public static string XPathToCollection { get { return string.Format("//{0}/{1}", DataSource.CollectionTag, DataSource.SingleTag); } }
        }
    }
}
