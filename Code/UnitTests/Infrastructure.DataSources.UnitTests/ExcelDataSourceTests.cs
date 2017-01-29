using CygSoft.Xess.Infrastructure.DataSources.Excel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Infrastructure.DataSources.UnitTests
{
    [TestFixture]
    public class ExcelDataSourceTests
    {
        [Test]
        [Category("Data Source")]
        public void ExcelDataSource_WhenInitialized_HasXLSConnectionString()
        {
            // Arrange
            StubExcelConnectionRepository stubRepository = new StubExcelConnectionRepository();
            stubRepository.FileExtensionType = ExcelFileExtensionType.XLS;
            IExcelDataSource dataSource = new ExcelDataSource(stubRepository, "excel_data.xls");

            // Act

            // Assert
            Assert.AreEqual("excel_data.xls", dataSource.FilePath);
            Assert.AreEqual(dataSource.ConnectionString, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=excel_data.xls;Extended Properties=\"Excel 8.0; HDR = YesIMEX = 2\";");
        }

        [Test]
        [Category("Data Source")]
        public void ExcelDataSource_WhenInitialized_HasXLSXConnectionString()
        {
            // Arrange
            StubExcelConnectionRepository stubRepository = new StubExcelConnectionRepository();
            stubRepository.FileExtensionType = ExcelFileExtensionType.XLSX;
            IExcelDataSource dataSource = new ExcelDataSource(stubRepository, "excel_data.xlsx");

            // Act

            // Assert
            Assert.AreEqual("excel_data.xlsx", dataSource.FilePath);
            Assert.AreEqual(dataSource.ConnectionString, "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = excel_data.xlsx; Extended Properties =\"Excel 12.0;HDR=YesIMEX=1\";");
        }

        [Test]
        public void ExcelDataSource_WhenInitialized_HasSheets()
        {
            // Arrange
            StubExcelConnectionRepository stubRepository = new StubExcelConnectionRepository();
            StubExcelDataRepository dataRepository = new StubExcelDataRepository();
            stubRepository.FileExtensionType = ExcelFileExtensionType.XLSX;
            IExcelDataSource dataSource = new ExcelDataSource(dataRepository, stubRepository, "excel_data.xlsx");

            // Act
            dataSource.FetchData();
            string[] sheets = dataSource.GetExcelSheets();

            // Assert
            Assert.AreEqual(3, sheets.Length);
        }

        [Test]
        public void ExcelDataSource_WhenInitialized_ActivatesFirstSheet()
        {
            // Arrange
            StubExcelConnectionRepository stubRepository = new StubExcelConnectionRepository();
            StubExcelDataRepository dataRepository = new StubExcelDataRepository();
            stubRepository.FileExtensionType = ExcelFileExtensionType.XLSX;
            IExcelDataSource dataSource = new ExcelDataSource(dataRepository, stubRepository, "excel_data.xlsx");

            // Act
            dataSource.FetchData();       

            // Assert
            Assert.IsNotNull(dataSource.ActiveSheet);
            Assert.AreEqual("Sheet1", dataSource.ActiveSheet);
        }

        [Test]
        public void ExcelDataSource_ActivateSheet_LoadsCorrectSheet()
        {
            // Arrange
            StubExcelConnectionRepository stubRepository = new StubExcelConnectionRepository();
            StubExcelDataRepository dataRepository = new StubExcelDataRepository();
            stubRepository.FileExtensionType = ExcelFileExtensionType.XLSX;
            IExcelDataSource dataSource = new ExcelDataSource(dataRepository, stubRepository, "excel_data.xlsx");

            // Act
            dataSource.FetchData();
            dataSource.ActivateSheet("Sheet2");

            // Assert
            Assert.AreEqual("Sheet2", dataSource.ActiveSheet);
            Assert.IsNotNull(dataSource.ActiveSheet);
        }

        [Test]
        public void ExcelDataSource_WhenLoaded_HasCurrentData()
        {
            // Arrange
            StubExcelConnectionRepository stubRepository = new StubExcelConnectionRepository();
            StubExcelDataRepository dataRepository = new StubExcelDataRepository();
            stubRepository.FileExtensionType = ExcelFileExtensionType.XLSX;
            IExcelDataSource dataSource = new ExcelDataSource(dataRepository, stubRepository, "excel_data.xlsx");

            // Act
            dataSource.FetchData();
            
            // Assert
            Assert.IsNotNull(dataSource.CurrentData);
        }

        public class StubExcelConnectionRepository : IExcelConnectionRepository
        {
            public ExcelFileExtensionType FileExtensionType;

            public StubExcelConnectionRepository()
            {
                FileExtensionType = ExcelFileExtensionType.XLSX;
            }

            public string GetTemplate(CygSoft.Xess.Infrastructure.DataSources.Excel.ExcelFileExtensionType extensionType)
            {
                return FileExtensionType ==
                    ExcelFileExtensionType.XLS ?
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0; HDR = YesIMEX = 2\";" :
                    "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties =\"Excel 12.0;HDR=YesIMEX=1\";";
            }
        }

        public class StubExcelDataRepository : IExcelDataRepository
        {
            public bool OpenSuccess = false;
            public bool TargetFileExists = true;

            public bool FileExists(string filePath)
            {
                return TargetFileExists;
            }

            public string[] GetSheetNames(string connectionString)
            {
                return new string[] { "Sheet1", "Sheet2", "Sheet3" };
            }

            public DataSet LoadExcel(string connectonString, string activeSheet, string topLeftCell, string bottomRightCell)
            {
                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(new DataTable("TableName"));
                return dataSet;
            }

            public bool OpenExcelFile(string filePath)
            {
                return OpenSuccess;
            }
        }

    }
}
