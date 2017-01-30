using CygSoft.Xess.Infrastructure.DataSources.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure.DataSources.WinFolder
{
    public class WinFolderDataSource : AbstractDataSource, IWinFolderDataSource
    {
        public string FolderPath { get; set; }

        public bool IncludeSubFolders { get; set; }

        public string FileFilterText { get; set; }

        public WinFolderDataSource()
        {
            this.SourceTypeText = "Windows Folder";
        }

        public WinFolderDataSource(string guidString)
            : base(guidString) 
        {
            this.SourceTypeText = "Windows Folder";
        }

        public override void FetchData()
        {
            DataTable dataTable = new DataTable();
            
            dataTable.Columns.Add(new DataColumn("FullPath", typeof(System.String)));
            dataTable.Columns.Add(new DataColumn("FileTitle", typeof(System.String)));
            dataTable.Columns.Add(new DataColumn("FileName", typeof(System.String)));
            dataTable.Columns.Add(new DataColumn("Extension", typeof(System.String)));

            FolderSearcher folderSearcher = new FolderSearcher();
            folderSearcher.FileFilterText = this.FileFilterText;
            folderSearcher.IncludeSubFolders = this.IncludeSubFolders;

            folderSearcher.Search(this.FolderPath);

            string[] files = folderSearcher.FoundFiles;

            foreach (string file in files)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["FullPath"] = file;
                dataRow["FileTitle"] = Path.GetFileNameWithoutExtension(file);
                dataRow["FileName"] = Path.GetFileName(file);
                dataRow["Extension"] = Path.GetExtension(file);

                dataTable.Rows.Add(dataRow);
            }

            dataTable.TableName = this.TableName;
            base.SetFileData(dataTable);
        }

        public override bool SourceIsValid()
        {
            return Directory.Exists(this.FolderPath);
        }

        public override string ToString()
        {
            return base.Title;
        }
    }
}
