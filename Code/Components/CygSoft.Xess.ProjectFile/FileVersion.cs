using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CygSoft.Xess.ProjectFile
{
    internal class FileVersion
    {
        public int ExpectedFileVersionNumber { get; private set; }
        public string ExpectedFileVersionFamily { get; private set; }

        public string FileVersionFamily { get; private set; }
        public int FileVersionNumber { get; private set; }

        public FileVersion(XmlDocument xmlDoc)
        {
            // -------------------------------------------
            // set the current version information here!
            // ---------------------------------------------
            ExpectedFileVersionFamily = "xess";
            ExpectedFileVersionNumber = 3;
            // -------------------------------------------
            XElement projectTag = XElement.Parse(xmlDoc.OuterXml, LoadOptions.None);
            string tagName = projectTag.Name.ToString();

            if (tagName == "Project")
            {
                object fileVersionFamily = projectTag.Attribute("Family");

                if (fileVersionFamily == null)
                {
                    this.FileVersionFamily = "xess";
                    this.FileVersionNumber = 1;

                }
                else
                {
                    this.FileVersionFamily = ((XAttribute)fileVersionFamily).Value.ToString();
                    object fileVersionNumber = projectTag.Attribute("Version");

                    if (fileVersionNumber == null)
                        this.FileVersionNumber = 1;
                    else
                        this.FileVersionNumber = Convert.ToInt32(((XAttribute)fileVersionNumber).Value);
                }
            }
            else
            {
                throw new ApplicationException("Project file format is not supported.");
            }

        }

        public bool IsCompatible(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (this.FileVersionFamily != this.ExpectedFileVersionFamily)
            {
                errorMessage = "Project file format must be based on the xess format specification.";
                return false;
            }

            if (this.FileVersionNumber != this.ExpectedFileVersionNumber)
            {
                string currentVersion = string.Format("Current file version is: {0} v{1}", 
                    this.ExpectedFileVersionFamily, this.ExpectedFileVersionNumber);

                string loadedVersion = string.Format("Loaded file version is: {0} v{1}", 
                    this.FileVersionFamily, this.FileVersionNumber);

                string version1 = "xess v1 = Xess Generator v1.3 and below";
                string version2 = "xess v2 = Xess Generator v1.5.0 and below";

                errorMessage = string.Format("Current version is incompatible with the loaded version.\n{0}\n{1}\n{2}\n{3}", 
                    currentVersion, loadedVersion, version1, version2);
                return false;
            }
            return true;
        }
    }
}
