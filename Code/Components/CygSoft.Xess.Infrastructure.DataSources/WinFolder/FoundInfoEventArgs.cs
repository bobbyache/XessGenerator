using System;
using System.Collections.Generic;
using System.IO;



namespace CygSoft.Xess.Infrastructure.DataSources.WinFolder
{
    public class FoundInfoEventArgs
    {
        public FoundInfoEventArgs(FileSystemInfo info)
        {
            this.Info = info;
            this.Stopping = false;
        }

        public FileSystemInfo Info { get; private set; }
        public bool Stopping { get; set; }
    }
}
