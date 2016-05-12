using System.IO;

namespace CygSoft.Xess.Infrastructure
{
    public class DataFiles
    {
        public DataFiles()
        {
        }
        public DataFiles(string projectFilePath)
        {
            this.ProjectFilePath = projectFilePath;
        }

        public string DataFileExtension { get { return "xessu"; } }

        public string ProjectFilePath { get; set; }

        public string DatasetFilePath
        {
            get { return Path.Combine(Path.GetDirectoryName(this.ProjectFilePath), Path.GetFileNameWithoutExtension(this.ProjectFilePath) + "." + DataFileExtension); }
        }

        public string GetDatasetFilePath(string dataSourceId)
        {
            return Path.Combine(Path.GetDirectoryName(this.ProjectFilePath), dataSourceId + "." + DataFileExtension);
        }
    }
}
