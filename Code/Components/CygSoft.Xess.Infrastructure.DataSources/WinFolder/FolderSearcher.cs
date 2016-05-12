using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure.DataSources.WinFolder
{
    // Derived from: D:\Sandbox\My Code\NatTreasury\trunk\Horizontal\FileSearcher
    public class FolderSearcher
    {
        public event EventHandler<FoundInfoEventArgs> FoundInfo;
        public bool IncludeSubFolders { get; set; }

        private bool Stopping { get; set; }

        private List<string> foundFilesList = new List<string>();
        public string[] FoundFiles { get { return this.foundFilesList.ToArray(); } }


        private string[] fileFilters;
        public string FileFilterText
        {
            get
            {
                return string.Join(";", fileFilters);
            }
            set
            {
                string[] fileNames = value.Split(new Char[] { ';' });
                List<String> validFileNames = new List<String>();
                foreach (String fileName in fileNames)
                {
                    String trimmedFileName = fileName.Trim();
                    if (trimmedFileName != "")
                    {
                        validFileNames.Add(trimmedFileName);
                    }
                }
                this.fileFilters = validFileNames.ToArray();
            }
        }

        public FolderSearcher()
        {
            this.Stopping = false;
            this.IncludeSubFolders = false;
            this.fileFilters = new string[0];
        }

        public void Search(string folderPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            this.foundFilesList.Clear();

            SearchFolder(directoryInfo);
            if (this.Stopping)
                this.Stopping = false;
        }

        private void SearchFolder(DirectoryInfo directoryInfo)
        {
            if (!this.Stopping)
            {
                try
                {
                    foreach (String fileName in this.fileFilters)
                    {
                        FileSystemInfo[] infos = directoryInfo.GetFileSystemInfos(fileName);

                        foreach (FileSystemInfo info in infos)
                        {
                            if (this.Stopping)
                                break;

                            if (info is FileInfo)
                            {
                                this.foundFilesList.Add(info.FullName);
                                // We have found a matching FileSystemInfo, so let's raise an event:
                                if (FoundInfo != null)
                                {
                                    
                                    FoundInfoEventArgs args = new FoundInfoEventArgs(info);
                                    FoundInfo(this, args);
                                    this.Stopping = args.Stopping;
                                }
                            }
                        }
                    }

                    if (this.IncludeSubFolders)
                    {
                        DirectoryInfo[] subDirInfos = directoryInfo.GetDirectories();
                        foreach (DirectoryInfo subDirInfo in subDirInfos)
                        {
                            if (this.Stopping)
                                break;

                            // Recursion:
                            SearchFolder(subDirInfo);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
