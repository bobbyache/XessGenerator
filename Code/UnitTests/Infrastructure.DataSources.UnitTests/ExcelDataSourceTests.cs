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
        /// <summary>
        /// *************************************************************************
        /// Unit of Work:           ExcelDataSource
        /// State Under Test:       Initialized
        /// Expected Behaviour:     Has a valid excel connection string for xls
        ///                         Excel file extension.
        /// *************************************************************************
        /// </summary>
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
            Assert.AreEqual("excel_data.xls", dataSource.FilePath, "When initialized with a valid Excel data source, should always expose the correct file path.");
            Assert.AreEqual(dataSource.ConnectionString, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=excel_data.xls;Extended Properties=\"Excel 8.0; HDR = YesIMEX = 2\";",
                "When initialized with a valid Excel data source, should always expose the connection string.");
        }

        /// <summary>
        /// *************************************************************************
        /// Unit of Work:           ExcelDataSource
        /// State Under Test:       Initialized
        /// Expected Behaviour:     Has a valid excel connection string for xlsx
        ///                         Excel file extension.
        /// *************************************************************************
        /// </summary>
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
            Assert.AreEqual("excel_data.xlsx", dataSource.FilePath, "When initialized with a valid Excel data source, should always expose the correct file path.");
            Assert.AreEqual(dataSource.ConnectionString, "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = excel_data.xlsx; Extended Properties =\"Excel 12.0;HDR=YesIMEX=1\";",
                "When initialized with a valid Excel data source, should always expose the connection string.");
        }

        /// <summary>
        /// *************************************************************************
        /// Unit of Work:           ExcelDataSource
        /// State Under Test:       Initialized
        /// Expected Behaviour:     Has picked up the sheets within the excel file.
        /// *************************************************************************
        /// </summary>
        [Test]
        [Category("Data Source")]
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
            Assert.AreEqual(3, sheets.Length, "When initialized with a valid Excel data source, should always make available any existing sheets.");
        }

        /// <summary>
        /// *************************************************************************
        /// Unit of Work:           ExcelDataSource
        /// State Under Test:       Initialized
        /// Expected Behaviour:     Activates the first sheet
        /// *************************************************************************
        /// </summary>
        [Test]
        [Category("Data Source")]
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
            Assert.IsNotNull(dataSource.ActiveSheet, "When initialized with a valid Excel data source containing sheets, should always activate the first sheet.");
            Assert.AreEqual("Sheet1", dataSource.ActiveSheet, "When initialized with a valid Excel data source containing sheets, should always activate the first sheet.");
        }

        /// <summary>
        /// *************************************************************************
        /// Unit of Work:           ExcelDataSource
        /// State Under Test:       Activate a Sheet
        /// Expected Behaviour:     Activates the correct sheet.
        /// *************************************************************************
        /// </summary>
        [Test]
        [Category("Data Source")]
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

        /// <summary>
        /// *************************************************************************
        /// Unit of Work:           ExcelDataSource
        /// State Under Test:       Fetch Data (from Excel Spreadsheet)
        /// Expected Behaviour:     Contains current data
        /// *************************************************************************
        /// </summary>
        [Test]
        [Category("Data Source")]
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
            Assert.IsTrue(dataSource.DataExists());

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

        public class StubExcelDataRepository : IExcelFileRepository
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
                DataTable table = new DataTable("TableName");
                dataSet.Tables.Add(table);
                table.Rows.Add(table.NewRow());
                return dataSet;
            }

            public bool OpenExcelFile(string filePath)
            {
                return OpenSuccess;
            }
        }

    }
}
