using System;
using CygSoft.Xess.ProjectFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.ProjectFileManager.Tests
{
    [TestClass]
    [DeploymentItem(@"ProjectFileManager\Files\XESS_Unversioned.xess")]
    [DeploymentItem(@"ProjectFileManager\Files\XESS_Version_1.xess")]
    [DeploymentItem(@"ProjectFileManager\Files\created_file.xess")]
    public class ProjectFileVersion
    {
        //[TestMethod]
        //public void RetrieveVersioningForUnversionedFile()
        //{
        //    IXessFileManager unversionedFile = new XessFileManager("XESS_Unversioned.xess");
        //    Assert.AreEqual("xess", unversionedFile.VersionFamily);
        //    Assert.AreEqual(1, unversionedFile.VersionNumber);

        //    // so need constructor with 
        //    //unversionedFile.Load("XESS_Unversioned.xess");
        //}

        //[TestMethod]
        //public void RetrieveVersioningVersionedFile()
        //{
        //    IXessFileManager versionedFile = new XessFileManager("XESS_Version_1.xess");
        //    Assert.AreEqual("xess", versionedFile.VersionFamily);
        //    Assert.AreEqual(1, versionedFile.VersionNumber);
        //}

        //[TestMethod]
        //public void CreateXessVersion1()
        //{
        //    IXessFileManager createdFile = FileFactory.CreateXessProjectFile("created_file.xess");
        //    IXessFileManager version1File = new XessFileManager("XESS_Version_1.xess");

        //    Assert.AreEqual(version1File.VersionFamily, createdFile.VersionFamily);
        //    Assert.AreEqual(version1File.VersionNumber, createdFile.VersionNumber);
        //}
    }
}
