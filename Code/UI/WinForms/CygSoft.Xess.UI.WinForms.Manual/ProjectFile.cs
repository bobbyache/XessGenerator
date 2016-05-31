using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Linq;

namespace CygSoft.Xess.UI.WinForms
{
    public class ProjectFile
    {
        public static void Save(DataTable datatable, string blueprint, string file)
        {
            XCData cDataElement = new XCData(blueprint);

            XElement document = new XElement("Project");
            XElement rowsElement = new XElement("Rows");
            XElement colsElement = new XElement("Columns");
            XElement textElement = new XElement("Text");
            textElement.Add(cDataElement);
            document.Add(textElement);
            document.Add(colsElement);
            document.Add(rowsElement);

            foreach (DataColumn col in datatable.Columns)
            {
                XElement element = new XElement("Column", col.ColumnName);
                colsElement.Add(element);
            }

            foreach (DataRow row in datatable.Rows)
            {
                XElement element = new XElement("Row");
                foreach (DataColumn column in datatable.Columns)
                {
                    element.Add(new XElement(column.ColumnName, row[column].ToString()));
                }
                rowsElement.Add(element);
            }
            document.Save(file);
        }

        public static void Load(string fileName, ref string blueprintText, ref DataTable dataTable)
        {
            dataTable.Clear();
            dataTable.Columns.Clear();

            XElement document = XElement.Load(fileName);

            blueprintText = document.Element("Text").Value;

            var columns = from colEl in document.Element("Columns").Elements("Column")
                          select new
                          {
                              Column = colEl.Value.ToString()
                          };

            foreach (var column in columns)
            {
                dataTable.Columns.Add(column.Column);
            }

            var rows = from colEl in document.Element("Rows").Elements("Row")
                       select new
                       {
                           Columns = colEl.Elements().Select(r => r.Name),
                           Values = colEl.Elements().Select(r => r.Value)
                       };

            foreach (var row in rows)
            {
                dataTable.Rows.Add(row.Values.ToArray());
            }
        }
    }
}
