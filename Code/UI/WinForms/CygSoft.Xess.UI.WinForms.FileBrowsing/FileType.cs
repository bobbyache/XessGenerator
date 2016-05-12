using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.UI.WinForms.FileBrowsing
{
    internal class FileType : IComparable, IComparable<FileType>
    {
        private string id;
        private string title;
        private List<string> extensions = new List<string>();

        public FileType(string id, string title, string extension)
        {
            this.id = id;
            this.title = title;
            AddExtension(extension);
        }

        public FileType(string id, string title, string[] extensions)
        {
            this.id = id;
            this.title = title;

            foreach (string extension in extensions)
                AddExtension(extension);
        }

        public string Identity { get { return this.id; } }
        public string Title { get { return this.title; } }

        public string[] Extensions { get { return this.extensions.ToArray(); } }

        public void ClearExtensions()
        {
            this.extensions.Clear();
        }

        public void AddExtension(string extension)
        {
            string ext = extension.Trim();
            if (!string.IsNullOrEmpty(ext))
            {
                if (!ext.StartsWith("."))
                    ext = "." + ext;
                extensions.Add(ext);
            }
        }

        public string[] GetAsteriskExtensions()
        {
            string[] exts = this.extensions.ToArray();
            for (int k = 0; k < exts.Length; k++)
            {
                exts[k] = "*" + exts[k];
            }
            return exts;
        }

        public string[] GetDotlessExtensions()
        {
            string[] exts = this.extensions.ToArray();
            for (int k = 0; k < exts.Length; k++)
            {
                exts[k] = exts[k].Substring(1, exts[k].Length - 1);
            }
            return exts;
        }

        public override string ToString()
        {
            return title;
        }

        public int CompareTo(object obj)
        {
            return this.id.CompareTo(((FileType)obj).id);
        }

        public int CompareTo(FileType other)
        {
            return this.id.CompareTo(other.id);
        }
    }
}
