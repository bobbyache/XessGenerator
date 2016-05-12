using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CygSoft.Xess.UI.WinForms.FileBrowsing
{
    public class FileDialogResult
    {
        public string FullPath { get; private set; }
        public DialogResult DialogResult { get; private set; }

        public FileDialogResult(string fullPath, DialogResult result)
        {
            this.FullPath = fullPath;
            this.DialogResult = result;
        }
    }
}
