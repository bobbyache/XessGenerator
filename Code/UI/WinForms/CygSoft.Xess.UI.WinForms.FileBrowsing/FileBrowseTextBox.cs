using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CygSoft.Xess.UI.WinForms.FileBrowsing
{
    public partial class FileBrowseTextBox : UserControl
    {
        public event EventHandler BeforeFileChanged;
        public event EventHandler FileChanged;

        private FileDialogBuilder fileDialogBuilder = new FileDialogBuilder();

        public bool AsSaveDialog { get; set; }

        public string FilePath
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public bool FileExists
        {
            get { return File.Exists(this.textBox1.Text); }
        }

        public bool AllowAllFileTypes
        {
            get { return this.fileDialogBuilder.AllowAllFileTypes; }
            set { this.fileDialogBuilder.AllowAllFileTypes = value; } 
        }

        public string DialogTitle 
        { 
            get { return this.fileDialogBuilder.Title; }
            set { this.fileDialogBuilder.Title = value; }
        }

        public int DialogFilterIndex
        {
            get { return this.fileDialogBuilder.FilterIndex; }
            set { this.fileDialogBuilder.FilterIndex = value; }
        }

        public string DialogInitialDirectory
        {
            get { return this.fileDialogBuilder.InitialDirectory; }
            set { this.fileDialogBuilder.InitialDirectory = value; }
        }

        public FileBrowseTextBox()
        {
            InitializeComponent();

            AsSaveDialog = false;
            fileDialogBuilder.AllowAllFileTypes = true;
            fileDialogBuilder.DefaultExtension = "txt";
            fileDialogBuilder.DialogOwner = this;
            fileDialogBuilder.FilterIndex = 0;
            fileDialogBuilder.Title = "Default Title";
            fileDialogBuilder.InitialDirectory = Environment.CurrentDirectory;
            fileDialogBuilder.AddSupportedFileType("txt", "Text Files", "txt");
        }

        public void ClearSupportedFileTypes()
        {
            fileDialogBuilder.ClearSupportedFileTypes();
        }

        public void AddSupportedFileType(string id, string title, string extension)
        {
            fileDialogBuilder.AddSupportedFileType(id, title, extension);
        }

        public void AddSupportedFileType(string id, string title, string[] extensions)
        {
            fileDialogBuilder.AddSupportedFileType(id, title, extensions);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (AsSaveDialog)
            {
                FileDialogResult result = WindowDialogs.SaveFileDialog(this.fileDialogBuilder);

                if (result.DialogResult == DialogResult.OK)
                {
                    if (BeforeFileChanged != null)
                        BeforeFileChanged(this, new EventArgs());

                    this.textBox1.Text = result.FullPath;

                    if (FileChanged != null)
                        FileChanged(this, new EventArgs());
                }
            }
            else
            {
                FileDialogResult result = WindowDialogs.OpenFileDialog(this.fileDialogBuilder);

                if (result.DialogResult == DialogResult.OK)
                {
                    if (BeforeFileChanged != null)
                        BeforeFileChanged(this, new EventArgs());

                    this.textBox1.Text = result.FullPath;

                    if (FileChanged != null)
                        FileChanged(this, new EventArgs());
                }
            }
        }
    }
}
