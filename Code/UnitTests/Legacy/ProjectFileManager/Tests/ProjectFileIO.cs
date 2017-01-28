using CygSoft.Xess.ProjectFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * To Do:
 * 
 * Add an open method to IXessFileManager so that we can open a file from an existing instance. Then we'd use a parameterless constructor
 * to open the XessFileManager class. The idea is so that we can take "create" out of the factory class.
 * 
 * Consider adding a "Create" in the IXessFileManager so that we don't use the factory class to create an instance. But is this right? Perhaps these
 * two points are a NICE TO HAVE? But maybe its better the way it is anyway.
 */

namespace UnitTests.ProjectFileManager.Tests
{
    [TestClass]
    [DeploymentItem(@"ProjectFileManager\Files\created_file.xess")]
    [DeploymentItem(@"ProjectFileManager\Files\XESS_Version_1.xess")]
    public class ProjectFileIO
    {
        //[TestMethod]
        //public void OpenXessVersion1()
        //{
        //}
    }
}
