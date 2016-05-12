using System.Text;

namespace CygSoft.Xess.Infrastructure.DataSources.Excel
{
    internal class ExcelDriver
    {
        public ExcelDriver(string uniqueName, string provider, string platform, string hdr, string imex)
        {
            this.platform = platform;
            this.uniqueName = uniqueName;
            this.provider = provider;
            this.hdr = hdr;
            this.imex = imex;
        }

        private string uniqueName;
        public string UniqueName
        {
            get { return uniqueName; }
            set { uniqueName = value; }
        }

        private string hdr;
        public string HDR
        {
            get { return hdr; }
        }

        private string imex;
        public string Imex
        {
            get { return imex; }
        }

        private string provider;
        public string Provider
        {
            get { return provider; }
        }

        private string platform;
        public string Platform
        {
            get { return platform; }
            set { platform = value; }
        }

        public string CreateConnectionString(string filePath)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Provider=");
            builder.Append(this.Provider);
            builder.Append(";Data Source=");
            builder.Append(filePath);
            builder.Append(";Extended Properties=\"");
            builder.Append(this.Platform);
            builder.Append(";HDR=");
            builder.Append(this.HDR);
            builder.Append("IMEX=");
            builder.Append(this.Imex);
            builder.Append("\";");

            return builder.ToString();
        }
    }
}
