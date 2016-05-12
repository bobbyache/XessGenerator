using CygSoft.Xess.Domain.Generators;
using CygSoft.Xess.Domain.Templates;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.Infrastructure.DataSources;
using CygSoft.Xess.Infrastructure.DataSources.Excel;
using CygSoft.Xess.Infrastructure.DataSources.SqlServer;
using CygSoft.Xess.Infrastructure.DataSources.WinFolder;
using CygSoft.Xess.Infrastructure.ReplaceEngine;
using CygSoft.Xess.ProjectFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CygSoft.Xess.App
{
    public static class XessApplication
    {
        public static event EventHandler<ConsoleProgressTextEventArgs> GeneratingDataSourceProgressMessage;
        public static event EventHandler<PercentCompleteEventArgs> GeneratingDataSourceProgressPercent;

        public static event EventHandler<ConsoleProgressTextEventArgs> GeneratingTemplateProgressMessage;
        public static event EventHandler<PercentCompleteEventArgs> GeneratingTemplatePercentComplete;

        public static event EventHandler<BeforeDatasourceGenerateEventArgs> BeforeGenerateDataSource;
        public static event EventHandler<AfterDatasourceGenerateEventArgs> AfterGenerateDataSource;

        public static event EventHandler<BeforeTemplateGenerateEventArgs> BeforeGenerateTemplate;
        public static event EventHandler<AfterTemplateGenerateEventArgs> AfterGenerateTemplate;

        private static IXessFileManager fileManager;
        private static DataSourceGenerator dataSourceGenerator = new DataSourceGenerator();

        private static SyntaxRepository syntaxRepository = null;

        static XessApplication()
        {
            PlaceholderPrefix = "@{";
            PlaceholderPostfix = "}";
        }

        public static string PlaceholderPrefix { get; set; }
        public static string PlaceholderPostfix { get; set; }

        public static string SyntaxFilePath { get; set; }

        public static string FilePath
        {
            get
            {
                if (fileManager != null)
                    return fileManager.FilePath;
                return string.Empty;
            }
        }

        public static bool FileExists
        {
            get 
            {
                if (fileManager != null)
                    return File.Exists(fileManager.FilePath);
                return false;
            }
        }

        public static bool FileLoaded 
        { 
            get 
            { 
                if (fileManager != null)
                    return fileManager.FileLoaded && FileExists;
                return false;
            } 
        }

        public static void CreateProject(string filePath)
        {
            fileManager = FileFactory.CreateXessProjectFile(filePath);
        }

        public static void OpenProject(string filePath)
        {
            fileManager = new XessFileManager(filePath);
        }

        public static void SaveProjectAs(string filePath)
        {
            fileManager.SaveProjectAs(filePath);
        }

        public static ICommonDbConnection[] GetCommonDatabaseConnections(string filePath)
        {
            SqlServerConnectionRepository repository = new SqlServerConnectionRepository();
            return repository.RetrieveAll(filePath);
        }

        public static List<ITemplate> GetTemplates()
        {
            List<ITemplate> templates = fileManager.GetTemplates();
            templates.Sort(new TemplateTitleComparer());
            return templates;
        }

        public static List<TemplateListItem> GetTemplateList()
        {
            List<TemplateListItem> templateListing = fileManager.GetTemplateList();
            templateListing.Sort(new TemplateListItemTitleComparer());
            return templateListing;
        }

        public static ITemplate GetTemplate(string templateId)
        {
            return fileManager.GetTemplate(templateId);
        }

        public static void UpdateTemplates(List<ITemplate> templates)
        {
            fileManager.UpdateTemplates(templates);
        }

        public static SubstitutionExpression[] GeneratePlaceholders(string[] columnList)
        {
            ReplaceEngine engine = new ReplaceEngine(new SubstitutionMask(PlaceholderPrefix, PlaceholderPostfix));
            engine.GenerateDefaultActions(columnList);
            return engine.GetSubstitutionPlaceholders();
        }

        /// <summary>
        /// Given a template, this method generates the template output as text. This is the main generation method
        /// to process templates and their respective template items into generated output text.
        /// </summary>
        /// <param name="template">A template to generate</param>
        /// <returns></returns>
        public static string GenerateTemplate(ITemplate template, bool updateFromDatasources = false)
        {
            string output = string.Empty;

            template.BeforeGenerate += template_BeforeGenerate;
            template.ProgressMessage += template_ProgressMessage;
            template.PercentComplete += template_PercentComplete;
            template.AfterGenerate += template_AfterGenerate;

            if (template != null)
            {
                if (updateFromDatasources)
                    template.GenerateDataSources();
                output = template.GenerateOutput(PlaceholderPrefix, PlaceholderPostfix);
            }

            template.BeforeGenerate -= template_BeforeGenerate;
            template.ProgressMessage -= template_ProgressMessage;
            template.PercentComplete -= template_PercentComplete;
            template.AfterGenerate -= template_AfterGenerate;

            return output;
        }

        /// <summary>
        /// Generates the template content and writes to a file specified by the path provided.
        /// </summary>
        public static void SaveGeneratedOutputToFile(ITemplate template, string filePath)
        {
            string outputFileData = GenerateTemplate(template);

            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }
            File.WriteAllText(filePath, outputFileData);
        }

        /// <summary>
        /// Generates the template content and writes to the default file specified by the ITemplate.FilePath.
        /// </summary>
        /// <param name="template"></param>
        public static void SaveGeneratedOutputToDefaultFile(ITemplate template)
        {
            SaveGeneratedOutputToFile(template, template.FilePath);
        }

        static void template_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            if (GeneratingTemplatePercentComplete != null)
                GeneratingTemplatePercentComplete(sender, e);
        }

        static void template_ProgressMessage(object sender, ConsoleProgressTextEventArgs e)
        {
            if (GeneratingTemplateProgressMessage != null)
                GeneratingTemplateProgressMessage(sender, e);
        }

        public static ITemplate NewTemplate()
        {
            ITemplate newTemplate = new Template();
            newTemplate.Title = "New Template";
            return newTemplate;
        }

        private static void dataSourceGenerator_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            if (GeneratingDataSourceProgressPercent != null)
                GeneratingDataSourceProgressPercent(sender, e);
        }

        private static void dataSourceGenerator_ProgressMessage(object sender, ConsoleProgressTextEventArgs e)
        {
            if (GeneratingDataSourceProgressMessage != null)
                GeneratingDataSourceProgressMessage(sender, e);
        }

        private static void dataSourceGenerator_AfterGenerate(object sender, AfterDatasourceGenerateEventArgs e)
        {
            if (AfterGenerateDataSource != null)
                AfterGenerateDataSource(sender, e);
        }

        private static void dataSourceGenerator_BeforeGenerate(object sender, BeforeDatasourceGenerateEventArgs e)
        {
            if (BeforeGenerateDataSource != null)
                BeforeGenerateDataSource(sender, e);
        }

        private static void template_AfterGenerate(object sender, AfterTemplateGenerateEventArgs e)
        {
            if (AfterGenerateTemplate != null)
                AfterGenerateTemplate(sender, e);
        }

        private static void template_BeforeGenerate(object sender, BeforeTemplateGenerateEventArgs e)
        {
            if (BeforeGenerateTemplate != null)
                BeforeGenerateTemplate(sender, e);
        }

        /// <summary>
        /// Generates a single data file from the original source.
        /// </summary>
        /// <param name="dataSourceList"></param>
        public static bool GenerateDataFile(string dataSourceId)
        {
            dataSourceGenerator.BeforeGenerate += dataSourceGenerator_BeforeGenerate;
            dataSourceGenerator.ProgressMessage += dataSourceGenerator_ProgressMessage;
            dataSourceGenerator.PercentComplete += dataSourceGenerator_PercentComplete;
            dataSourceGenerator.AfterGenerate += dataSourceGenerator_AfterGenerate;
            IDataSource dataSource = GetDataSourceById(dataSourceId);
            bool success = dataSourceGenerator.Generate(new IDataSource[] { dataSource });
            dataSourceGenerator.BeforeGenerate -= dataSourceGenerator_BeforeGenerate;
            dataSourceGenerator.ProgressMessage -= dataSourceGenerator_ProgressMessage;
            dataSourceGenerator.PercentComplete -= dataSourceGenerator_PercentComplete;
            dataSourceGenerator.AfterGenerate -= dataSourceGenerator_AfterGenerate;

            return success;
        }

        /// <summary>
        /// Generates a single data file from the original source.
        /// </summary>
        public static bool GenerateDataFile(IDataSource dataSource)
        {
            dataSourceGenerator.BeforeGenerate += dataSourceGenerator_BeforeGenerate;
            dataSourceGenerator.ProgressMessage += dataSourceGenerator_ProgressMessage;
            dataSourceGenerator.PercentComplete += dataSourceGenerator_PercentComplete;
            dataSourceGenerator.AfterGenerate += dataSourceGenerator_AfterGenerate;
            bool success = dataSourceGenerator.Generate(new IDataSource[] { dataSource });
            dataSourceGenerator.BeforeGenerate -= dataSourceGenerator_BeforeGenerate;
            dataSourceGenerator.ProgressMessage -= dataSourceGenerator_ProgressMessage;
            dataSourceGenerator.PercentComplete -= dataSourceGenerator_PercentComplete;
            dataSourceGenerator.AfterGenerate -= dataSourceGenerator_AfterGenerate;

            return success;
        }

        /// <summary>
        /// Generates the data files for all original data sources that exist within the
        /// open project.
        /// </summary>
        public static bool GenerateDataFiles()
        {
            dataSourceGenerator.BeforeGenerate += dataSourceGenerator_BeforeGenerate;
            dataSourceGenerator.ProgressMessage += dataSourceGenerator_ProgressMessage;
            dataSourceGenerator.PercentComplete += dataSourceGenerator_PercentComplete;
            dataSourceGenerator.AfterGenerate += dataSourceGenerator_AfterGenerate;
            bool success = dataSourceGenerator.Generate(fileManager.GetDataSources());
            dataSourceGenerator.BeforeGenerate -= dataSourceGenerator_BeforeGenerate;
            dataSourceGenerator.ProgressMessage -= dataSourceGenerator_ProgressMessage;
            dataSourceGenerator.PercentComplete -= dataSourceGenerator_PercentComplete;
            dataSourceGenerator.AfterGenerate -= dataSourceGenerator_AfterGenerate;

            return success;
        }

        /// <summary>
        /// Generates the data files for all original data sources in the list.
        /// </summary>
        /// <param name="dataSourceList"></param>
        public static bool GenerateDataFiles(IDataSource[] dataSources)
        {
            dataSourceGenerator.BeforeGenerate += dataSourceGenerator_BeforeGenerate;
            dataSourceGenerator.ProgressMessage += dataSourceGenerator_ProgressMessage;
            dataSourceGenerator.PercentComplete += dataSourceGenerator_PercentComplete;
            dataSourceGenerator.AfterGenerate += dataSourceGenerator_AfterGenerate;
            bool success = dataSourceGenerator.Generate(dataSources);
            dataSourceGenerator.BeforeGenerate -= dataSourceGenerator_BeforeGenerate;
            dataSourceGenerator.ProgressMessage -= dataSourceGenerator_ProgressMessage;
            dataSourceGenerator.PercentComplete -= dataSourceGenerator_PercentComplete;
            dataSourceGenerator.AfterGenerate -= dataSourceGenerator_AfterGenerate;

            return success;
        }

        /// <summary>
        /// Factory method creates a new excel data source.
        /// </summary>
        /// <param name="projectFilePath"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IExcelDataSource NewExcelDataSource(string projectFilePath, string filePath)
        {
            return DataSourceFactory.NewExcelDataSource(projectFilePath, filePath);
        }

        /// <summary>
        /// Factory method used to create a new Sql Server data source.
        /// </summary>
        /// <param name="projectFilePath"></param>
        /// <returns></returns>
        public static ISqlDatabaseDataSource NewSqlServerDataSource(string projectFilePath)
        {
            return DataSourceFactory.NewSqlServerDataSource(projectFilePath);
        }

        /// <summary>
        /// Factory method used to create a new Win Folder data source.
        /// </summary>
        /// <param name="projectFilePath"></param>
        /// <returns></returns>
        public static IWinFolderDataSource NewWinFolderDataSource(string projectFilePath)
        {
            return DataSourceFactory.NewWinFolderDataSource(projectFilePath);
        }


        public static IDataSource CloneDataSource(IDataSource originalDataSource)
        {
            if (originalDataSource is IExcelDataSource)
                return CloneExcelDataSource(originalDataSource as IExcelDataSource);
            else if (originalDataSource is ISqlDatabaseDataSource)
                return CloneSqlServerDataSource(originalDataSource as ISqlDatabaseDataSource);
            else if (originalDataSource is IWinFolderDataSource)
                return CloneWinFolderDataSource(originalDataSource as IWinFolderDataSource);

            return null;
        }

        /// <summary>
        /// Factory method used to clone a new excel data source from an existing one.
        /// </summary>
        public static IExcelDataSource CloneExcelDataSource(IExcelDataSource originalDataSource)
        {
            return DataSourceFactory.CloneExcelDataSource(originalDataSource);
        }

        /// <summary>
        /// Factory method used to clone a new sql server data source from an existing one.
        /// </summary>
        public static ISqlDatabaseDataSource CloneSqlServerDataSource(ISqlDatabaseDataSource originalDataSource)
        {
            return DataSourceFactory.CloneSqlServerDataSource(originalDataSource);
        }

        /// <summary>
        /// Factory method used to clone a new windows folder data source from an existing one.
        /// </summary>
        public static IWinFolderDataSource CloneWinFolderDataSource(IWinFolderDataSource originalDataSource)
        {
            return DataSourceFactory.CloneWinFolderDataSource(originalDataSource);
        }

        /// <summary>
        /// Method inserts/updates the details of a single data source to the project file.
        /// </summary>
        /// <param name="dataSource"></param>
        public static void UpdateDataSource(IDataSource dataSource)
        {
            fileManager.UpdateDataSource(dataSource);
        }

        /// <summary>
        /// Method deletes/removes a single datasource from the project and the project file.
        /// </summary>
        /// <param name="dataSource"></param>
        public static void DeleteDataSource(IDataSource dataSource)
        {
            fileManager.DeleteDataSource(dataSource);
        }

        /// <summary>
        /// Adds a new data source to the project's data source collection. All data 
        /// sources are then saved back to the persistence store.
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns>returns true if a data source is successfully added and the
        /// data sources are succesfully saved.</returns>
        public static bool AddDataSource(IDataSource dataSource)
        {
            fileManager.UpdateDataSource(dataSource);
            return true;
        }

        /// <summary>
        /// Retrieves an array of data sources from the persistence store or
        /// project file.
        /// </summary>
        /// <returns></returns>
        public static IDataSource[] GetDataSources()
        {
            IDataSource[] dataSources = fileManager.GetDataSources();
            return dataSources;
        }

        /// <summary>
        /// Removes the list of data sources in the list from the persistence store and
        /// the open project. The data sources are completely deleted.
        /// </summary>
        /// <param name="dataSources"></param>
        public static void RemoveDataSources(IDataSource[] dataSources)
        {
            foreach (IDataSource dataSource in dataSources)
                dataSource.DeleteFileData();    // remove any files...

            fileManager.DeleteDataSources(dataSources);
        }

        /// <summary>
        /// Removes a single data source from the persistence store and the open project.
        /// The data source is completely removed.
        /// </summary>
        public static void RemoveDataSource(IDataSource dataSource)
        {
            dataSource.DeleteFileData();
            fileManager.DeleteDataSource(dataSource);
        }

        /// <summary>
        /// Retrieves a datasource by it's id from the memory resident collection.
        /// Not retrieved from the persistence store!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IDataSource GetDataSourceById(string id)
        {
            return fileManager.GetDataSource(id);
        }

        public static string CreateTemporaryFile()
        {
            string directory = Path.Combine(Path.GetTempPath(), "XESS");
            string fullPath = Path.Combine(directory, Path.GetRandomFileName());

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return fullPath;
        }

        public static bool CleanOutTemporaryFiles()
        {
            string directory = Path.Combine(Path.GetTempPath(), "XESS");
            if (Directory.Exists(directory))
                Directory.Delete(directory, true);

            if (!Directory.Exists(directory))
                return true;
            return false;
            
        }

        public static string[] GetSyntaxes()
        {
            if (!string.IsNullOrEmpty(SyntaxFilePath))
            {
                if (syntaxRepository == null)
                    syntaxRepository = new SyntaxRepository(SyntaxFilePath);
                return syntaxRepository.Languages;
            }
            return new string[0];
        }

        public static SyntaxFile[] GetSyntaxFiles()
        {
            if (!string.IsNullOrEmpty(SyntaxFilePath))
            {
                if (syntaxRepository == null)
                    syntaxRepository = new SyntaxRepository(SyntaxFilePath);
                return syntaxRepository.SyntaxFiles;
            }
            return new SyntaxFile[0];
        }

        public static string[] GetSyntaxFileExtensions()
        {
            if (!string.IsNullOrEmpty(SyntaxFilePath))
            {
                if (syntaxRepository == null)
                    syntaxRepository = new SyntaxRepository(SyntaxFilePath);
                return syntaxRepository.FileExtensions;
            }
            return new string[0];
        }

        public static SyntaxFile GetSyntaxFile(string language)
        {
            string fpath = string.Empty;

            if (!string.IsNullOrEmpty(language) && !string.IsNullOrEmpty(SyntaxFilePath))
            {
                if (syntaxRepository == null)
                    syntaxRepository = new SyntaxRepository(SyntaxFilePath);
                return syntaxRepository[language];
            }
            return null;
        }

        public static string GetSyntaxFileExtension(string language)
        {
            string fpath = string.Empty;

            if (!string.IsNullOrEmpty(language) && !string.IsNullOrEmpty(SyntaxFilePath))
            {
                if (syntaxRepository == null)
                    syntaxRepository = new SyntaxRepository(SyntaxFilePath);
                fpath = syntaxRepository[language].Extension;
            }
            return fpath;
        }
    }
}
