using System.Collections.Generic;
using System.IO;
using System.Linq;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.ProjectFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CygSoft.Xess.Infrastructure.DataSources.SqlServer;

namespace UnitTests.DataSources.Tests
{
    [TestClass]
    [DeploymentItem(@"Files\excel_data.xlsx")]
    [DeploymentItem(@"Files\bankrecon.xess")]
    [DeploymentItem(@"Files\projFile_ExcelDataSources.xess")]
    public class SqlDataSourceTests
    {
        //[TestMethod]
        //public void SqlDataSourceTests_Read_SQLServer_DataSource()
        //{
        //    IXessFileManager existingFile = new XessFileManager("bankrecon.xess");
        //    IDataSource[] dataSources = existingFile.GetDataSources();

        //    Assert.AreEqual(15, dataSources.Length);
            
        //    IDataSource dataSource = dataSources.Where(d => d.Id == "dd1fef13-d6ad-425e-9a9d-6a1fa27d2bf7").Single();
        //    Assert.IsNotNull(dataSource);
        //    Assert.AreEqual("dd1fef13-d6ad-425e-9a9d-6a1fa27d2bf7", dataSource.Id);
        //    Assert.AreEqual("Redundant_Verify_Fields", dataSource.TableName);
        //    Assert.AreEqual("Microsoft SQL Server", dataSource.SourceTypeText);
        //    Assert.AreEqual("Redundant Verify Fields", dataSource.Title);

        //    // You might think of renaming this interface to "ISqlServerDataSource". DON'T !!!. That will make the
        //    // "DBMS" redundant. Most of your properties are here so that you can take a query + connection string.
        //    // Probably leave it as is !!!
        //    ISqlDatabaseDataSource sqlDataSource = dataSource as ISqlDatabaseDataSource;
        //    Assert.IsNotNull(sqlDataSource);

        //    Assert.AreEqual("dd1fef13-d6ad-425e-9a9d-6a1fa27d2bf7", sqlDataSource.Id);
        //    Assert.AreEqual("Redundant_Verify_Fields", sqlDataSource.TableName);
        //    Assert.AreEqual("Microsoft SQL Server", sqlDataSource.SourceTypeText);
        //    Assert.AreEqual("Microsoft SQL Server", sqlDataSource.DBMS);
        //    Assert.AreEqual("Redundant Verify Fields", sqlDataSource.Title);
        //    Assert.AreEqual("Data Source=(local);Initial Catalog=alm;Integrated Security=True", sqlDataSource.ConnectionString);
        //    Assert.IsTrue(sqlDataSource.CommandText != string.Empty);

        //}

        // Ensure the object is created with a default tablename and uniquename set to its id...
        [TestMethod]
        public void SqlDataSourceTests_Create_DataSource()
        {
            IXessFileManager createdFile = FileFactory.CreateXessProjectFile("projFile_ExcelDataSources.xess");
            ISqlDatabaseDataSource sqlDataSource = new SqlServerDataSource();

            Assert.IsTrue(sqlDataSource.TableName == sqlDataSource.Id);
            //Assert.IsTrue(sqlDataSource.Id == ((AbstractSourceData)sqlDataSource).UniqueName);

            // DBMS is written to the file using "SourceTypeText" value. The two properties always have the same value.
            // So here, when the data source is instantiated, should set both properties for now... look to remove one of them
            // later.
            Assert.IsTrue(sqlDataSource.SourceTypeText == "Microsoft SQL Server");
            Assert.IsTrue(sqlDataSource.DBMS == "Microsoft SQL Server");
            Assert.IsTrue(sqlDataSource.Title == null);
            Assert.IsTrue(sqlDataSource.CommandText == null);
            Assert.IsTrue(sqlDataSource.ConnectionString == "");
            
            //sqlDataSource.ConnectionValid;
            //sqlDataSource.DBMS;
            //sqlDataSource.FetchData();
            
            // => Would be better to use the property to set the connection, or better yet, treat this as a value object
            // which it is !!! So set the connection string through the constructor and make the property values for connection
            // string etc. read-only.
            //sqlDataSource.SetConnection("connectionString");
        }

        [TestMethod]
        public void SqlDataSourceTests_Create_NewSqlServerDataSource()
        {
            string projectFilePath = @"C:\TestFolder\TestSubFolder\project.xess";
            ISqlDatabaseDataSource sqlDataSource = new SqlServerDataSource();

            string projectFolder = Path.GetDirectoryName(projectFilePath);
            string datasetFile = sqlDataSource.Id + ".xessu";
            string datasetFilePath = Path.Combine(projectFolder, datasetFile);
            string datasetSchemaFile = sqlDataSource.Id + ".xesst";
            string datasetSchemaFilePath = Path.Combine(projectFolder, datasetSchemaFile);

            // no project file set... so no files available.
            Assert.AreEqual(string.Empty, sqlDataSource.ProjectFilePath);
            Assert.AreEqual(string.Empty, sqlDataSource.DatasetFilePath);

            // All file paths will only be available once the project file path is set !!!
            sqlDataSource.ProjectFilePath = projectFilePath;

            // project file is known, so all files availab.e
            Assert.AreEqual(projectFilePath, sqlDataSource.ProjectFilePath);
            Assert.AreEqual(datasetFilePath, sqlDataSource.DatasetFilePath);
        }
    }
}
