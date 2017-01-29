using System.Data;
using System.IO;
using System.Linq;

namespace CygSoft.Xess.Infrastructure.DataSources.Excel
{
    public class ExcelDataSource : AbstractDataSource, IExcelDataSource
    {
        private string filePath;
        private string activeSheet;
        private IExcelConnectionRepository excelConnectionRepository = null;
        private IExcelDataRepository excelDataRepository = null;

        public ExcelDataSource()
        {
            this.SourceTypeText = "Microsoft Excel";
            this.excelDataRepository = new ExcelDataRepository();
            this.excelConnectionRepository = new ExcelConnectionRepository();
        }

        public ExcelDataSource(string filePath)
        {
            this.SourceTypeText = "Microsoft Excel";
            this.FilePath = filePath;
            this.excelDataRepository = new ExcelDataRepository();
            this.excelConnectionRepository = new ExcelConnectionRepository();
        }

        public ExcelDataSource(string filePath, string guidString) : base(guidString) 
        {
            this.SourceTypeText = "Microsoft Excel";
            this.FilePath = filePath;
            this.excelDataRepository = new ExcelDataRepository();
            this.excelConnectionRepository = new ExcelConnectionRepository();
        }

        public ExcelDataSource(IExcelConnectionRepository excelConnectionRepository, string filePath) : this(new ExcelDataRepository(), excelConnectionRepository, filePath) { }

        public ExcelDataSource(IExcelDataRepository excelDataRepository, IExcelConnectionRepository excelConnectionRepository, string filePath)
        {
            this.SourceTypeText = "Microsoft Excel";
            this.FilePath = filePath;
            this.excelDataRepository = excelDataRepository;
            this.excelConnectionRepository = excelConnectionRepository;
        }

        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value;    }
        }

        public string ConnectionString
        {
            get 
            {
                if (string.IsNullOrEmpty(this.FilePath))
                    return string.Empty;

                return InferConnectionStringFromFileExtension();
            }
        }

        public string ActiveSheet { get { return this.activeSheet; } }

        public string TopLeftCell { get; set; }

        public string BottomRightCell { get; set; }

        public void ActivateSheet(string sheet)
        {
            this.activeSheet = GetExcelSheets().Where(sh => sh == sheet).Single();
        }

        public string[] GetExcelSheets()
        {
            if (excelDataRepository.FileExists(this.FilePath))
                return excelDataRepository.GetSheetNames(this.ConnectionString);
            else
                return new string[0];
        }

        /// <summary>
        /// Open the Excel document into an Excel application for viewing and editing.
        /// </summary>
        /// <returns></returns>
        public bool OpenDocument()
        {
            return excelDataRepository.OpenExcelFile(this.FilePath);
        }

        /// <summary>
        /// Load the Excel document into memory for this instance.
        /// </summary>
        public override void FetchData()
        {
            DataTable dataTable = excelDataRepository.LoadExcel(this.ConnectionString, this.ActiveSheet,
                this.TopLeftCell, this.BottomRightCell).Tables[0].Copy();
            dataTable.TableName = this.TableName;
            base.SetFileData(dataTable);

            string[] sheets = excelDataRepository.GetSheetNames(this.ConnectionString);
            ActivateSheet(sheets[0]);
        }

        public override bool SourceIsValid()
        {
            return excelDataRepository.FileExists(this.FilePath);
        }

        public override string ToString()
        {
            return this.Title;
        }

        private string[] GetExcelSheets(string filePath)
        {
            return excelDataRepository.GetSheetNames(this.ConnectionString);
        }

        private string InferConnectionStringFromFileExtension()
        {
            string connectionTemplate = string.Empty;

            if (Path.GetExtension(this.filePath).ToUpper() == ".XLS")
                connectionTemplate = this.excelConnectionRepository.GetTemplate(ExcelFileExtensionType.XLS);
            else
                connectionTemplate = this.excelConnectionRepository.GetTemplate(ExcelFileExtensionType.XLSX);

            return string.Format(connectionTemplate, FilePath);
        }
    }
}
