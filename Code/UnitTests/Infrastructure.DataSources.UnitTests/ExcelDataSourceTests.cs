using CygSoft.Xess.Infrastructure.DataSources.Excel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSources.UnitTests
{
    [TestFixture]
    public class ExcelDataSourceTests
    {
        [Test]
        public void TestItWorks()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void ExcelDataSource_WhenInitializing_HasConnectionString()
        {
            //IExcelDataSource dataSource = new ExcelDataSource("C:\MyPath\MyFile.xlsx");
            //dataSource.
        }
    }
}
