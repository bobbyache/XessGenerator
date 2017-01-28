//using System;
//using System.Collections.Generic;
//using System.IO;
//using CygSoft.Xess.Domain.DataSources.Excel;
//using CygSoft.Xess.Infrastructure;
//using CygSoft.Xess.ProjectFile;
//using CygSoft.Xess.ProjectFile.Xess;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace UnitTests.DataSources.Tests
//{
//    [TestClass]
//    //[DeploymentItem(@"Files\connections.xml")]
//    [DeploymentItem(@"Files\excel_data.xlsx")]
//    [DeploymentItem(@"Files\bankrecon.xess")]
//    [DeploymentItem(@"Files\projFile_ExcelDataSources.xess")]
//    public class ExcelDataSourceTests
//    {
//        [TestMethod]
//        public void ExcelDataSourceTests_CreateExcelDataSource_NewXLSX()
//        {
//            // YOU STILL NEED TO CREATE AND TEST AN Old XLS !!!!

//            // Create the excel datasource without a "connections.xml" parameter. Keep it backward compatible with
//            // the old version at first. Try and keep the interface the same but instantiate Excel Driver from within.

//            IExcelDataSource excelDataSource = new ExcelDataSource(@"excel_data.xlsx");

//            string id = excelDataSource.Id;
//            Guid IdGuid = Guid.Parse(id);

//            Assert.IsTrue(IdGuid.ToString() != string.Empty);
//            Assert.IsTrue(excelDataSource.FilePath == "excel_data.xlsx");
//            Assert.IsTrue(excelDataSource.TableName == IdGuid.ToString());
//            //Assert.IsTrue((excelDataSource as AbstractSourceData).UniqueName == IdGuid.ToString());
            
//            Assert.IsTrue(excelDataSource.ConnectionString == "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=excel_data.xlsx;Extended Properties=\"Excel 12.0;HDR=YesIMEX=1\";");
//            Assert.IsTrue(excelDataSource.SourceTypeText == "Microsoft Excel");

//            // since provider is now read-only, you can remove this from the project file.
//            Assert.IsTrue(excelDataSource.Provider == "Excel 2010 (32/64 bit) ACE Driver");
//        }

//        [TestMethod]
//        public void ExcelDataSourceTests_CreateExcelDataSource_NoTarget()
//        {
//            // consider adding a FileLoaded property or something like that...

//            IExcelDataSource excelDataSource = new ExcelDataSource();

//            string id = excelDataSource.Id;
//            Guid IdGuid = Guid.Parse(id);
//            Assert.IsTrue(IdGuid.ToString() != string.Empty);
//            Assert.IsTrue(excelDataSource.FilePath == null);
//            Assert.IsTrue(excelDataSource.TableName == IdGuid.ToString());

//            Assert.IsTrue(excelDataSource.ConnectionString == string.Empty);
//            Assert.IsTrue(excelDataSource.SourceTypeText == "Microsoft Excel");
//        }


//        [TestMethod]
//        public void ExcelDataSourceTests_CreateExcelDataSource_InitiallyNoTargetSetFilePath()
//        {
//            IExcelDataSource excelDataSource = new ExcelDataSource();

//            excelDataSource.FilePath = "excel_data.xlsx";

//            Assert.IsTrue(excelDataSource.FilePath == "excel_data.xlsx");
//            Assert.IsTrue(excelDataSource.TableName == excelDataSource.Id);
            
//            Assert.IsTrue(excelDataSource.ConnectionString == "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=excel_data.xlsx;Extended Properties=\"Excel 12.0;HDR=YesIMEX=1\";");
//            Assert.IsTrue(excelDataSource.SourceTypeText == "Microsoft Excel");

//            // since provider is now read-only, you can remove this from the project file.
//            Assert.IsTrue(excelDataSource.Provider == "Excel 2010 (32/64 bit) ACE Driver");
//        }

//        [TestMethod]
//        public void ExcelDataSourceTests_CreateExcelDataSource_CheckActiveSheet()
//        {
//            IExcelDataSource excelDataSource = new ExcelDataSource(@"excel_data.xlsx");
//            string[] sheets = excelDataSource.GetExcelSheets();
//            if (sheets.Length > 0)
//            {
//                Assert.AreEqual(sheets[0], excelDataSource.ActiveSheet);
//            }
//            else
//                Assert.AreEqual(null, excelDataSource.ActiveSheet);
//        }



//        [TestMethod]
//        public void ExcelDataSourceTests_CreateReadEditReadExcelDataSource()
//        {
//            // create the data source...
//            IXessFileManager createdFile = FileFactory.CreateXessProjectFile("projFile_ExcelDataSources.xess");
//            IExcelDataSource excelDataSource = new ExcelDataSource(@"excel_data.xlsx");

//            string title1 = "Excel Source - Sheet 1";
//            string id = excelDataSource.Id;
//            string tableName = excelDataSource.TableName;
//            string[] sheets = excelDataSource.GetExcelSheets();

//            excelDataSource.Title = title1;

//            excelDataSource.ActivateSheet(sheets[0]);
//            Assert.AreEqual(excelDataSource.ActiveSheet, sheets[0]);

//            // persist the data source...
//            createdFile.UpdateDatasource(excelDataSource);

//            Assert.AreEqual(1, createdFile.GetDataSources().Count);

//            // retrieve the data source from the file and check its properties.
//            IExcelDataSource retrievedDataSource = createdFile.GetDataSources()[id] as IExcelDataSource;
//            Assert.IsTrue(retrievedDataSource != null);
//            Assert.AreEqual(title1, retrievedDataSource.Title);
//            Assert.AreEqual(tableName, retrievedDataSource.TableName);
//            Assert.AreEqual(sheets[0], retrievedDataSource.ActiveSheet);

//            string title2 = "Excel Source - Sheet 2";
//            retrievedDataSource.Title = title2;
//            retrievedDataSource.ActivateSheet(sheets[1]);

//            createdFile.UpdateDatasource(retrievedDataSource);

//            IExcelDataSource retrievedDataSource2 = createdFile.GetDataSources()[id] as IExcelDataSource;
//            Assert.IsTrue(retrievedDataSource2 != null);
//            Assert.AreEqual(title2, retrievedDataSource2.Title);
//            Assert.AreEqual(tableName, retrievedDataSource2.TableName);
//            Assert.AreEqual(sheets[1], retrievedDataSource2.ActiveSheet);
            
//        }

//        [TestMethod]
//        public void ExcelDataSourceTests_Read_Excel_DataSource()
//        {
//            IXessFileManager existingFile = new XessFileManager("bankrecon.xess");
//            Dictionary<string, IDataSource> dataSources = existingFile.GetDataSources();

//            Assert.AreEqual(15, dataSources.Count);

//            IDataSource dataSource = dataSources["ffbb648d-eedf-44a5-90fe-f54169f321fc"];
//            Assert.IsNotNull(dataSource);
//            Assert.AreEqual("ffbb648d-eedf-44a5-90fe-f54169f321fc", dataSource.Id);
//            Assert.AreEqual("Inserts_BankStatementMaster_Table", dataSource.TableName);
//            Assert.AreEqual("Microsoft Excel", dataSource.SourceTypeText);
//            Assert.AreEqual("Insert BankStatementMaster", dataSource.Title);


//            // You might think of renaming this interface to "ISqlServerDataSource". DON'T !!!. That will make the
//            // "DBMS" redundant. Most of your properties are here so that you can take a query + connection string.
//            // Probably leave it as is !!!
//            IExcelDataSource excelDataSource = dataSource as IExcelDataSource;
//            Assert.IsNotNull(excelDataSource);

//            Assert.AreEqual("ffbb648d-eedf-44a5-90fe-f54169f321fc", excelDataSource.Id);
//            Assert.AreEqual("Inserts_BankStatementMaster_Table", excelDataSource.TableName);
//            Assert.AreEqual("Microsoft Excel", excelDataSource.SourceTypeText);
//            Assert.AreEqual("Insert BankStatementMaster", excelDataSource.Title);
//            Assert.AreEqual("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\\\ctfs\\Bigdisk\\Rob\\Nat Treasury\\Work Items\\2013 - Bank Recon (Cleaned)\\Scripts\\2013-09\\Excel\\TestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YesIMEX=1\";", excelDataSource.ConnectionString);
//            Assert.AreEqual(@"\\ctfs\Bigdisk\Rob\Nat Treasury\Work Items\2013 - Bank Recon (Cleaned)\Scripts\2013-09\Excel\TestData.xlsx", excelDataSource.FilePath);

//            if (File.Exists(excelDataSource.FilePath))
//                Assert.AreEqual("Inserts_BankStatementMaster", excelDataSource.ActiveSheet);
//            else
//                Assert.IsNull(excelDataSource.ActiveSheet);

//            Assert.AreEqual("Excel 2010 (32/64 bit) ACE Driver", excelDataSource.Provider);
//            Assert.AreEqual("", excelDataSource.TopLeftCell);
//            Assert.AreEqual("", excelDataSource.BottomRightCell);
            
            
//        }

//        [TestMethod]
//        public void ExcelDataSourceTests_TestDataFiles_Object()
//        {
//            DataFiles dataFiles1 = new DataFiles(@"C:\TestDirectory\TestSubDirectory\projectfile.xess");
//            Assert.AreEqual(@"C:\TestDirectory\TestSubDirectory\projectfile.xess", dataFiles1.ProjectFilePath);
//            Assert.AreEqual(@"C:\TestDirectory\TestSubDirectory\projectfile.xessu", dataFiles1.DatasetFilePath);
//            Assert.AreEqual(@"C:\TestDirectory\TestSubDirectory\projectfile.xesst", dataFiles1.DatasetSchemaFilePath);

//            dataFiles1.ProjectFilePath = @"C:\TestDirectory\TestSubDirectory\projectfile2.xess";
//            Assert.AreEqual(@"C:\TestDirectory\TestSubDirectory\projectfile2.xess", dataFiles1.ProjectFilePath);
//            Assert.AreEqual(@"C:\TestDirectory\TestSubDirectory\projectfile2.xessu", dataFiles1.DatasetFilePath);
//            Assert.AreEqual(@"C:\TestDirectory\TestSubDirectory\projectfile2.xesst", dataFiles1.DatasetSchemaFilePath);
//        }


//        [TestMethod]
//        public void ExcelDataSourceTests_Create_NewExcelDataSource()
//        {
//            string projectFilePath = @"C:\TestFolder\TestSubFolder\project.xess";
//            IExcelDataSource excelDataSource = new ExcelDataSource();

//            string projectFolder = Path.GetDirectoryName(projectFilePath);
//            string datasetFile = excelDataSource.Id + ".xessu";
//            string datasetFilePath = Path.Combine(projectFolder, datasetFile);
//            string datasetSchemaFile = excelDataSource.Id + ".xesst";
//            string datasetSchemaFilePath = Path.Combine(projectFolder, datasetSchemaFile);

//            // no project file set... so no files available.
//            Assert.AreEqual(string.Empty, excelDataSource.ProjectFilePath);
//            Assert.AreEqual(string.Empty, excelDataSource.DatasetFilePath);
//            Assert.AreEqual(string.Empty, excelDataSource.DatasetFileSchemaPath);

//            // All file paths will only be available once the project file path is set !!!
//            excelDataSource.ProjectFilePath = projectFilePath;

//            // project file is known, so all files availab.e
//            Assert.AreEqual(projectFilePath, excelDataSource.ProjectFilePath);
//            Assert.AreEqual(datasetFilePath, excelDataSource.DatasetFilePath);
//            Assert.AreEqual(datasetSchemaFilePath, excelDataSource.DatasetFileSchemaPath);
//        }
//    }
//}
