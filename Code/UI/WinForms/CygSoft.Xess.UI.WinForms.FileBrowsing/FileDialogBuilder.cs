using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CygSoft.Xess.UI.WinForms.FileBrowsing
{
    public class FileDialogBuilder
    {
        private List<FileType> fileTypes = new List<FileType>();
        public IWin32Window DialogOwner { get; set; }
        public string Title { get; set; }
        public string InitialDirectory { get; set; }
        public bool AllowAllFileTypes { get; set; }
        public string DefaultExtension { get; set; }
        public int FilterIndex { get; set; }
        public string FilterIdentity { get; set; }  // overrides FilterIndex if set with a file type string identifier.

        public FileDialogBuilder()
        {
            this.FilterIdentity = null;
        }

        internal FileType[] SupportedFileTypes { get { return this.fileTypes.ToArray(); } }

        public void ClearSupportedFileTypes()
        {
            this.fileTypes.Clear();
        }

        public int DefaultSelectionIndex()
        {
            // can select by the FileType.Identity property !!!
            if (FilterIdentity != null)
            {
                int foundIndex = this.fileTypes.FindIndex(ft => ft.Identity == FilterIdentity);
                if (foundIndex >= 0)
                {
                    foundIndex += 1;
                    return foundIndex;
                }
            }
            // fallback ok, use the FilterIndex
            return this.FilterIndex;
        }

        public void AddSupportedFileType(string id, string title, string[] extensions)
        {
            fileTypes.Add(new FileType(id, title, extensions));
        }

        public void AddSupportedFileType(string id, string title, string extension)
        {
            fileTypes.Add(new FileType(id, title, extension));
        }
    }
}
