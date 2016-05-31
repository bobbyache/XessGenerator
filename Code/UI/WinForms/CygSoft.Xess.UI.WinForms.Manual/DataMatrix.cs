using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CygSoft.Xess.UI.WinForms
{
    public class DataMatrix
    {
        
        private DataTable dataTable = new DataTable();
        private Variables variables = new Variables();

        public DataTable Table { get { return this.dataTable; } }

        private string blueprintText;
        public string BlueprintText 
        {
            get { return this.blueprintText; }
            set
            {
                this.blueprintText = value;
                UpdateVariables();
            }
        }

        public string[] Placeholders
        {
            get { return variables.Placeholders; }
        }

        public string[] Columns
        {
            get { return variables.Columns; }
        }

        public Variable[] Variables
        {
            get { return variables.VariableList; }
        }

        private void RefreshColumns(string[] columns)
        {
            foreach (string column in columns)
            {
                if (!dataTable.Columns.Contains(column))
                    dataTable.Columns.Add(new DataColumn(column, typeof(System.String)));
            }
        }

        public void LoadData(string filePath)
        {
            Empty();
            Load(filePath);
        }

        private void UpdateVariables()
        {
            this.variables.Update(this.BlueprintText);
            RefreshColumns(this.Columns);
        }

        private void Load(string filePath)
        {
            string blueprintText = string.Empty;
            ProjectFile.Load(filePath, ref blueprintText, ref this.dataTable);
            this.BlueprintText = blueprintText;
        }

        public void Save(string filePath)
        {
            ProjectFile.Save(this.Table, this.BlueprintText, filePath);
        }

        public void Empty()
        {
            this.dataTable.Clear();
            this.dataTable.Columns.Clear();
        }
    }
}
