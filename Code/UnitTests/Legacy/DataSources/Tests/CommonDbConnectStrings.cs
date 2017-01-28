using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.Infrastructure.DataSources.SqlServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.DataSources.Tests
{
    [TestClass]
    [DeploymentItem(@"Files\connections.xml")]
    public class CommonDbConnectStrings
    {
        //[TestMethod]
        //public void CommonConnectionStringsTest()
        //{
        //    ISqlDatabaseDataSource sqlDataSource = new SqlServerSourceData();
        //    SqlServerPresetConnection[] presetConnections = sqlDataSource.GetPresetConnections("connections.xml");
        //    Assert.IsTrue(presetConnections.Length == 9);
        //}

        [TestMethod]
        public void DbConnectionRepository_RetrieveAll()
        {
            // At some point, you're going to want to remove all this and put it in its own dll so that you can reuse this functionality
            // across the board. It might be better to have this all as a CygSoft registry entry rather than an xml file.
            SqlServerConnectionRepository repository = new SqlServerConnectionRepository();
            ICommonDbConnection[] connections = repository.RetrieveAll("connections.xml");
            Assert.IsTrue(connections.Length == 9);
        }
    }
}
