using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CygSoft.Xess.UI.WinForms
{
    public class DatasetFile
    {
        public static void WriteMatrix(DataSet dataSet, string dataFile) //, string schemaFile)
        {
            //dataSet.WriteXmlSchema(schemaFile);
            dataSet.WriteXml(dataFile);
        }

        public static DataSet ReadMatrix(string dataFile) //, string schemaFile)
        {
            DataSet dataSet = new DataSet();

            if (File.Exists(dataFile)) // && File.Exists(schemaFile))
            {
                //dataSet.ReadXmlSchema(schemaFile);
                dataSet.ReadXml(dataFile);
            }

            return dataSet;
        }
    }
}
