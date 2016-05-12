using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CygSoft.Xess.App;
using System.Threading;
using System.IO;
using CygSoft.Xess.Infrastructure;

namespace UnitTests
{
    [TestClass]
    [DeploymentItem(@"ProjectFileManager\Files\created_projectfile1.xess")]
    [DeploymentItem(@"ProjectFileManager\Files\created_projectfile2.xess")]
    public class XessMediatorTests
    {
        //// http://www.philosophicalgeek.com/2007/12/27/easily-unit-testing-event-handlers/
        //// http://stackoverflow.com/questions/248989/unit-testing-that-an-event-is-raised-in-c-sharp
        //// http://jason.agostoni.net/2006/07/14/visual-studio-unit-testing-an-asynchronous-event-callback/

        //[TestInitialize]
        //public void InitializeTests()
        //{
        //}

        //[TestCleanup]
        //public void CleanupTests()
        //{
        //    if (File.Exists("created_projectfile1.xess"))
        //    {
        //        File.Delete("created_projectfile1.xess");
        //    }
        //    if (File.Exists("created_projectfile2.xess"))
        //    {
        //        File.Delete("created_projectfile2.xess");
        //    }
        //}

        //[TestMethod]
        //public void Mediator_Initialize()
        //{
        //    XessMediator mediator = new XessMediator();

        //    Assert.IsFalse(mediator.FileLoaded);
        //    Assert.IsFalse(mediator.FileExists);
        //    Assert.AreEqual("", mediator.FilePath);
        //}

        //[TestMethod]
        //public void Mediator_CreateFile()
        //{
        //    bool fileLoadedEventFired = false;
        //    XessMediator mediator = new XessMediator();

        //    ManualResetEvent fileLoadedResetEvent = new ManualResetEvent(false);
        //    mediator.FileSuccessfullyLoaded += (s, e) => 
        //    {
        //        fileLoadedEventFired = true;
        //        fileLoadedResetEvent.Set();
        //    };

        //    mediator.CreateProject("created_projectfile1.xess");
            
        //    fileLoadedResetEvent.WaitOne(5000, false);
        //    Assert.IsTrue(fileLoadedEventFired);
        //    Assert.IsTrue(mediator.FileLoaded);
        //    Assert.IsTrue(mediator.FileExists);
        //    Assert.AreEqual("created_projectfile1.xess", mediator.FilePath);
        //}

        ////[TestMethod]
        ////public void Mediator_CreateFileWithTemplates()
        ////{
        ////    XessMediator mediator = new XessMediator();
        ////    mediator.CreateProject("created_projectfile2.xess");
        ////    ITemplate template = mediator.NewTemplate();
        ////    template.

            
        ////}
    }
}
