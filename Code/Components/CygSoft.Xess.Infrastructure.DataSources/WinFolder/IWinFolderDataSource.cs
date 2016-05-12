using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure.DataSources.WinFolder
{
    public interface IWinFolderDataSource : IDataSource
    {
        string FolderPath { get; set; }
        bool IncludeSubFolders { get; set; }
        string FileFilterText { get; set; }
    }
}
