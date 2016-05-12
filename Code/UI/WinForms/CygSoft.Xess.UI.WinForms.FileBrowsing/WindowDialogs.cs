using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CygSoft.Xess.UI.WinForms.FileBrowsing
{
    public class WindowDialogs
    {
        public static FileDialogResult SaveFileDialog(FileDialogBuilder dialogBuilder)
        {
            FileDialog fileDialog = new FileDialog();
            fileDialog.Title = dialogBuilder.Title;
            fileDialog.InitialDirectory = dialogBuilder.InitialDirectory;
            fileDialog.DefaultExtension = dialogBuilder.DefaultExtension;
            fileDialog.AllowAllFileTypes = dialogBuilder.AllowAllFileTypes;
            fileDialog.FilterIndex = dialogBuilder.DefaultSelectionIndex();
            fileDialog.AddSupportedFileTypes(dialogBuilder.SupportedFileTypes);

            string fullPath = string.Empty;
            DialogResult result = fileDialog.Save(dialogBuilder.DialogOwner, out fullPath);
            FileDialogResult fileDialogResult = new FileDialogResult(fullPath, result);

            return fileDialogResult;
        }

        public static FileDialogResult OpenFileDialog(FileDialogBuilder dialogBuilder)
        {
            FileDialog fileDialog = new FileDialog();
            fileDialog.Title = dialogBuilder.Title;
            fileDialog.InitialDirectory = dialogBuilder.InitialDirectory;
            fileDialog.DefaultExtension = dialogBuilder.DefaultExtension;
            fileDialog.AllowAllFileTypes = dialogBuilder.AllowAllFileTypes;
            fileDialog.FilterIndex = dialogBuilder.DefaultSelectionIndex();
            fileDialog.AddSupportedFileTypes(dialogBuilder.SupportedFileTypes);

            string fullPath = string.Empty;
            DialogResult result = fileDialog.Open(dialogBuilder.DialogOwner, out fullPath);
            FileDialogResult fileDialogResult = new FileDialogResult(fullPath, result);

            return fileDialogResult;
        }
    }
}
