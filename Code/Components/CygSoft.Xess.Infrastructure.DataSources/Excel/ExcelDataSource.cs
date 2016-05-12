using System.Data;
using System.IO;
using System.Linq;

namespace CygSoft.Xess.Infrastructure.DataSources.Excel
{
    public class ExcelDataSource : AbstractDataSource, IExcelDataSource
    {
        private string filePath;
        private string activeSheet;
        private ExcelDriver currentDriver;

        public ExcelDataSource()
        {
            Initialize(null);
            this.SourceTypeText = "Microsoft Excel";
        }

        public ExcelDataSource(string filePath)
        {
            Initialize(filePath);
            this.SourceTypeText = "Microsoft Excel";
        }

        public ExcelDataSource(string filePath, string guidString) : base(guidString) 
        {
            Initialize(filePath);
            this.SourceTypeText = "Microsoft Excel";
        }

        public string FilePath
        {
            get { return this.filePath; }
            set { Initialize(value);    }
        }

        public string ConnectionString
        {
            get 
            {
                if (string.IsNullOrEmpty(this.FilePath))
                    return string.Empty;
                return this.currentDriver.CreateConnectionString(this.FilePath); 
            }
        }

        public string ActiveSheet
        {
            get { return this.activeSheet; }
        }

        public string TopLeftCell { get; set; }

        public string BottomRightCell { get; set; }

        public string Provider
        {
            get 
            {
                if (this.currentDriver == null)
                    return string.Empty;
                return this.currentDriver.UniqueName; 
            }
        }

        public void ActivateSheet(string sheet)
        {
            foreach (string sheetItem in GetExcelSheets())
            {
                if (sheet == sheetItem)
                {
                    this.activeSheet = sheet;
                    return;
                }
            }
        }

        public void ClearActiveSheet()
        {
            this.activeSheet = null;
        }

        public string[] GetExcelSheets()
        {
            ExcelDataRepository excelDataRepository = new ExcelDataRepository();

            if (SourceIsValid())
                return excelDataRepository.GetSheetNames(this.ConnectionString);
            else
                return new string[0];
        }

        public bool OpenDocument()
        {
            ExcelDataRepository excelDataRepository = new ExcelDataRepository();
            return excelDataRepository.OpenExcelFile(this.FilePath);
        }

        public override void FetchData()
        {
            ExcelDataRepository excelDataRepository = new ExcelDataRepository();
            DataTable dataTable = excelDataRepository.LoadExcel(this.ConnectionString, this.ActiveSheet,
                this.TopLeftCell, this.BottomRightCell).Tables[0].Copy();
            dataTable.TableName = this.TableName;
            base.SetFileData(dataTable);
        }

        public override bool SourceIsValid()
        {
            return (this.currentDriver != null && File.Exists(this.FilePath));
        }

        public override string ToString()
        {
            return this.Title;
        }

        private void Initialize(string filePath)
        {
            this.filePath = filePath;

            InitializeExcelDriver(filePath);
            InitializeActiveSheet(filePath);
        }

        private void InitializeActiveSheet(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                this.activeSheet = null;
                return;
            }

            if (SourceIsValid())
            {
                string[] sheets = GetExcelSheets(this.filePath);
                if (sheets.Length > 0)
                {
                    if (string.IsNullOrEmpty(this.ActiveSheet) || !sheets.Contains(this.ActiveSheet))
                    {
                        this.activeSheet = sheets[0];
                    }
                    // else just keep the current active sheet.
                }
                else
                    this.activeSheet = null;
            }
            else
                this.activeSheet = null;
        }

        private string[] GetExcelSheets(string filePath)
        {
            ExcelDataRepository excelDataRepository = new ExcelDataRepository();
            return excelDataRepository.GetSheetNames(this.currentDriver.CreateConnectionString(this.FilePath));
        }

        private void InitializeExcelDriver(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                this.currentDriver = null;
                return;
            }

            string extension = Path.GetExtension(filePath);
            if (extension == "xls")
                currentDriver = new ExcelDriver("Excel 2007 (32 bit) JET Driver", "Microsoft.Jet.OLEDB.4.0", "Excel 8.0", "Yes", "2");
            else // xlsx
                currentDriver = new ExcelDriver("Excel 2010 (32/64 bit) ACE Driver", "Microsoft.ACE.OLEDB.12.0", "Excel 12.0", "Yes", "1");
        }
    }
}
