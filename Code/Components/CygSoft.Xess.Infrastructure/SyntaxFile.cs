using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure
{
    public class SyntaxFile
    {
        public string Language { get; private set; }
        public string FilePath { get; private set; }
        public string Extension { get; private set; }

        public SyntaxFile(string language, string filePath, string extension)
        {
            this.Language = language;
            this.FilePath = filePath;
            this.Extension = extension;
        }
    }
}
