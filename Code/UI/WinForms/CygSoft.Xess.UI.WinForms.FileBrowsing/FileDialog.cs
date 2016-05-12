using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CygSoft.Xess.UI.WinForms.FileBrowsing
{
    internal class FileDialog
    {
        private List<FileType> fileTypes = new List<FileType>();

        public string Title { get; set; }
        public string DefaultExtension { get; set; }
        public string InitialDirectory { get; set; }
        public bool AllowAllFileTypes { get; set; }
        public int FilterIndex { get; set; }


        public void ClearSupportedFileTypes()
        {
            this.fileTypes.Clear();
        }

        public void AddSupportedFileTypes(IEnumerable<FileType> fileTypes)
        {
            this.fileTypes.AddRange(fileTypes);
        }

        public DialogResult Save(IWin32Window owner, out string fullPath)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Title = this.Title;
            if (!string.IsNullOrEmpty(this.DefaultExtension)) dialog.DefaultExt = this.DefaultExtension;
            dialog.Filter = DialogFilterList();

            dialog.FilterIndex = this.FilterIndex;
            if (!string.IsNullOrEmpty(this.InitialDirectory)) dialog.InitialDirectory = this.InitialDirectory;
            dialog.AddExtension = true;
            dialog.OverwritePrompt = true;
            DialogResult result = dialog.ShowDialog(owner);
            fullPath = dialog.FileName;

            return result;
        }

        public DialogResult Open(IWin32Window owner, out string fullPath)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = this.Title;
            if (!string.IsNullOrEmpty(this.DefaultExtension)) dialog.DefaultExt = this.DefaultExtension;
            dialog.Filter = DialogFilterList();

            dialog.FilterIndex = this.FilterIndex;
            if (!string.IsNullOrEmpty(this.InitialDirectory)) dialog.InitialDirectory = this.InitialDirectory;
            dialog.AddExtension = true;
            DialogResult result = dialog.ShowDialog(owner);
            fullPath = dialog.FileName;

            return result;
        }

        private string DialogFilterList()
        {
            // "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|"
            // + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff"
            StringBuilder filterBuilder = new StringBuilder();

            foreach (FileType fileType in this.fileTypes)
            {
                string filterList = fileType + " " + delimitedDetails(fileType.GetAsteriskExtensions()) + "|" + 
                    delimitedFilters(fileType.GetAsteriskExtensions());

                filterBuilder.Append(filterList + "|");
            }
            string output = filterBuilder.ToString();

            if (AllowAllFileTypes)
                output = output + "All File Types (*.*)|*.*";
            else
            {
                if (output.Last() == '|')
                    output = output.Substring(0, output.Length - 1);
            }
                

            return output;
        }

        private string delimitedFilters(string[] asteriskExtensions)
        {
            string output = string.Join(";", asteriskExtensions);
            return output;
        }

        private string delimitedDetails(string[] asteriskExtensions)
        {
            string output = "(" + string.Join(", ", asteriskExtensions) + ")";
            return output;
        }
    }
}
