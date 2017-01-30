using System.Data;
using System.IO;

namespace CygSoft.Xess.Infrastructure.DataSources.Base
{
    public abstract class AbstractDataSource : PersistableObject, IDataSource
    {

        private DataFiles dataFiles;
        private DataTable currentDataTable = null;
        private IDataSourceFileRepository dataSourceFileRepository;

        public AbstractDataSource()
        {
            this.dataSourceFileRepository = new DataSourceFileRepository();
        }
        public AbstractDataSource(string guidString) : base(guidString)
        {
            this.dataSourceFileRepository = new DataSourceFileRepository();
        }

        public AbstractDataSource(IDataSourceFileRepository dataSourceFileRepository)
        {
            this.dataSourceFileRepository = dataSourceFileRepository;
        }
        public AbstractDataSource(IDataSourceFileRepository dataSourceFileRepository, string guidString) : base(guidString)
        {
            this.dataSourceFileRepository = dataSourceFileRepository;
        }

        public string Title { get; set; }
        public string SourceTypeText { get; protected set; }
        public string TableName { get { return this.Id; } }

        public string ProjectFilePath
        {
            get
            {
                if (this.dataFiles != null)
                    return this.dataFiles.ProjectFilePath;
                return string.Empty;
            }
            set
            {
                this.dataFiles = new DataFiles(value);
            }
        }

        public string DatasetFilePath
        {
            get
            {
                if (this.dataFiles != null)
                    return this.dataFiles.GetDatasetFilePath(this.Id);
                return string.Empty;
            }
        }

        public DataTable CurrentData { get { return this.currentDataTable; } }

        public abstract bool SourceIsValid();
        public abstract void FetchData();

        public void LoadFileData()
        {
            LoadFileData(false);
        }

        //TODO: This is a problem, since this is also an external dependency.
        public void LoadFileData(bool selectableRows)
        {
            DataTable table = dataSourceFileRepository.Read(this.DatasetFilePath, this.TableName);

            if (table != null)
            {
                // If selectableRows = true, then another column is generated to
                // record whether a row is selected or not.
                if (selectableRows)
                {
                    DataColumn column = new DataColumn("Generate", typeof(bool));
                    column.Caption = "Generate";
                    column.AllowDBNull = false;
                    column.DefaultValue = false;
                    table.Columns.Add(column);
                    column.SetOrdinal(0);
                }
            }
            this.currentDataTable = table;
        }

        //TODO: This is a problem, since this is also an external dependency.
        public void DeleteFileData()
        {
            if (File.Exists(this.DatasetFilePath))
                File.Delete(this.DatasetFilePath);
        }

        //TODO: This is a problem, since this is also an external dependency.
        public void WriteFileData()
        {
            dataSourceFileRepository.Write(this.currentDataTable, this.DatasetFilePath);
        }

        public bool DataExists()
        {
            //TODO: 
            if (currentDataTable == null)
            {
                LoadFileData();
            }

            if (currentDataTable != null)
            {
                if (currentDataTable.Rows.Count > 0)
                    return true;
            }
            return false;
        }

        protected void SetFileData(DataTable dataTable)
        {
            this.currentDataTable = dataTable;
        }
    }
}
