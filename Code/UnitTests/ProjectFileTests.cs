using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CygSoft.Xess.ProjectFile;
using System.IO;

namespace UnitTests
{
    [TestClass]
    [DeploymentItem(@"ProjectFileManager\Files\created_file.xess")]
    public class ProjectFileTests
    {
        [TestMethod]
        public void ProjectFileTests_CreateNewFile_CheckVersion()
        {
            IXessFileManager fileManager = FileFactory.CreateXessProjectFile("created_file.xess");

            Assert.AreEqual(fileManager.VersionFamily, "xess");
            Assert.AreEqual(fileManager.VersionNumber, 3);

            File.Delete("created_file.xess");
        }

        //[TestMethod]
        //public void ProjectFileTests_CreateNewFile_CheckVersion()
        //{
        //    //IXessFileManager fileManager = FileFactory.CreateXessProjectFile("created_file.xess");

        //    //fileManager.
        //}
    }
}
