using System.Collections.Generic;
using System.Xml;

namespace CygSoft.Xess.Infrastructure.DataSources.SqlServer
{
    public class SqlServerConnectionRepository
    {
        public ICommonDbConnection[] RetrieveAll(string filePath)
        {
            List<CommonSqlServerConnection> presetConnectionList = new List<CommonSqlServerConnection>();

            XmlDocument document = new XmlDocument();
            document.Load(filePath);
            XmlNodeList connectionList = document.GetElementsByTagName("SqlServerConnection");

            foreach (XmlNode xmlConnection in connectionList)
            {
                string connectionString = xmlConnection.Attributes["ConnectionString"].Value;
                CommonSqlServerConnection presetConnection = new CommonSqlServerConnection(connectionString);
                presetConnection.Title = xmlConnection.Attributes["FriendlyName"].Value;
                presetConnectionList.Add(presetConnection);
            }

            return presetConnectionList.ToArray();
        }
    }
}
