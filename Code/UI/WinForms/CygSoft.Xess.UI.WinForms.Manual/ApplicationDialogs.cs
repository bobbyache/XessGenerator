using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace CygSoft.Xess.UI.WinForms
{
    public class DialogData
    {
        public DialogResult Result { get; private set; }
        public string FilePath { get; private set; }

        public DialogData(DialogResult result, string filePath)
        {
            this.Result = result;
            this.FilePath = filePath;
        }
    }

    public class ApplicationDialogs
    {
        private static string ProjectFilter = "Project Files *.blue (*.blue)|*.blue";
        private static string ProjectExtension = "*.blue";

        public static DialogData Save(Form parentForm)
        {
            //dataTable.AcceptChanges();

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = string.Format("{0} {1}", "regex_variables", ProjectFilter);
            dialog.Title = string.Format("Save {0} file", "regex_variables");
            dialog.DefaultExt = ProjectExtension;
            dialog.OverwritePrompt = true;
            dialog.FileName = "";
            dialog.AddExtension = true;
            dialog.FilterIndex = 0;

            DialogResult result = dialog.ShowDialog(parentForm);
            DialogData data = new DialogData(result, dialog.FileName);
            return data;
        }

        public static DialogData Open(Form parentForm)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = string.Format("{0} {1}", "regex_variables", ProjectFilter);
            dialog.Title = string.Format("Save {0} file", "regex_variables");
            dialog.DefaultExt = ProjectExtension;
            dialog.FileName = "";
            dialog.AddExtension = true;
            dialog.FilterIndex = 0;

            DialogResult result = dialog.ShowDialog(parentForm);
            DialogData data = new DialogData(result, dialog.FileName);
            return data;
        }
    }
}
