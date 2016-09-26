using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace CygSoft.Xess.UI.WinForms.GlobalSettings
{
    public static class ConfigSettings
    {
        private static string registryFolder;
        public static string RegistryPath
        {
            get
            {
                if (string.IsNullOrEmpty(registryFolder))
                    registryFolder = ConfigurationManager.AppSettings["RegistryPath"];

                return registryFolder;
            }
            set
            {
                ConfigurationManager.AppSettings["RegistryPath"] = value;
            }
        }

        private static string applicationTitle;
        public static string ApplicationTitle
        {
            // retrieve this value from AssemblyInfo
            get
            {
                if (string.IsNullOrEmpty(applicationTitle))
                {
                    object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                    if (attributes.Length > 0)
                    {
                        AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                        if (titleAttribute.Title != "")
                        {
                            applicationTitle = titleAttribute.Title;
                            return applicationTitle;
                        }
                    }
                    applicationTitle = System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
                    return applicationTitle;
                }
                return applicationTitle;
            }
        }

        private static string lastProject;
        public static string LastProject
        {
            get
            {
                if (string.IsNullOrEmpty(lastProject))
                    lastProject = ConfigurationManager.AppSettings["LastProject"];

                return lastProject;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["LastProject"].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string dataConnectionsFile;
        public static string DataConnectionsFile
        {
            get
            {
                if (string.IsNullOrEmpty(dataConnectionsFile))
                    dataConnectionsFile = ConfigurationManager.AppSettings["ConnectionFile"];

                return dataConnectionsFile;
            }
        }

        private static string placeholderPrefix;
        public static string PlaceholderPrefix
        {
            get
            {
                if (string.IsNullOrEmpty(placeholderPrefix))
                    placeholderPrefix = ConfigurationManager.AppSettings["PlaceholderPrefix"];

                return placeholderPrefix;
            }
        }


        private static string placeholderPostfix;
        public  static string PlaceholderPostfix
        {
            get
            {
                if (string.IsNullOrEmpty(placeholderPostfix))
                    placeholderPostfix = ConfigurationManager.AppSettings["PlaceholderPostfix"];

                return placeholderPostfix;
            }
        }

        private static string winMergePath;
        public static string WinMergePath
        {
            get
            {
                if (string.IsNullOrEmpty(winMergePath))
                    winMergePath = ConfigurationManager.AppSettings["WinMergePath"];

                return winMergePath;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["WinMergePath"].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string syntaxFilePath;
        public static string SyntaxFilePath
        {
            get
            {
                if (string.IsNullOrEmpty(syntaxFilePath))
                    syntaxFilePath = ConfigurationManager.AppSettings["SyntaxFilePath"];

                return syntaxFilePath;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["SyntaxFilePath"].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string qikScriptSyntaxFile;
        public static string QikScriptSyntaxFile
        {
            get
            {
                if (string.IsNullOrEmpty(qikScriptSyntaxFile))
                    qikScriptSyntaxFile = ConfigurationManager.AppSettings["QikScriptSyntaxFile"];

                return qikScriptSyntaxFile;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["QikScriptSyntaxFile"].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string qikTemplateSyntaxFile;
        public static string QikTemplateSyntaxFile
        {
            get
            {
                if (string.IsNullOrEmpty(qikTemplateSyntaxFile))
                    qikTemplateSyntaxFile = ConfigurationManager.AppSettings["QikTemplateSyntaxFile"];

                return qikTemplateSyntaxFile;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["QikTemplateSyntaxFile"].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string defaultSyntax;
        public static string DefaultSyntax
        {
            get
            {
                if (string.IsNullOrEmpty(defaultSyntax))
                    defaultSyntax = ConfigurationManager.AppSettings["DefaultSyntax"];

                return defaultSyntax;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["DefaultSyntax"].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string sqlServerSyntax;
        public static string SQLServerSyntax
        {
            get
            {
                if (string.IsNullOrEmpty(defaultSyntax))
                    defaultSyntax = ConfigurationManager.AppSettings["SQLServerSyntax"];

                return defaultSyntax;
            }
            set
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["SQLServerSyntax"].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public static void Refresh()
        {
            registryFolder = ConfigurationManager.AppSettings["RegistryPath"];
            dataConnectionsFile = ConfigurationManager.AppSettings["ConnectionFile"];
            applicationTitle = ConfigurationManager.AppSettings["ApplicationTitle"];
            placeholderPostfix = ConfigurationManager.AppSettings["PlaceholderPostfix"];
            placeholderPrefix = ConfigurationManager.AppSettings["PlaceholderPrefix"];
            lastProject = ConfigurationManager.AppSettings["LastProject"];
            winMergePath = ConfigurationManager.AppSettings["WinMergePath"];
            syntaxFilePath = ConfigurationManager.AppSettings["SyntaxFilePath"];
            qikScriptSyntaxFile = ConfigurationManager.AppSettings["QikScriptSyntaxFile"];
            qikTemplateSyntaxFile = ConfigurationManager.AppSettings["QikTemplateSyntaxFile"];
            defaultSyntax = ConfigurationManager.AppSettings["DefaultSyntax"];
            sqlServerSyntax = ConfigurationManager.AppSettings["SQLServerSyntax"];
        }

    }
}
