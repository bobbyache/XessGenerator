using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CygSoft.Xess.UI.WinForms
{
    public class Generator
    {
        public string GenerateText(DataTable dataTable, string blueprintText, Variable[] variables)
        {
            StringBuilder completeTxtBuilder = new StringBuilder();

            foreach (DataRow rw in dataTable.Rows)
            {
                string txt = blueprintText;
                foreach (DataColumn column in dataTable.Columns)
                {
                    Variable variable = variables.Where(v => v.Name == column.ColumnName).Single();
                    txt = txt.Replace(variable.Placeholder, Convert.ToString(rw[column]));
                }
                completeTxtBuilder.AppendLine(txt);
            }

            return completeTxtBuilder.ToString();
        }
    }
}
