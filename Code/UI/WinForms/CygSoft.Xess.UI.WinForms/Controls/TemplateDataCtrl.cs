using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.App;

namespace CygSoft.Xess.UI.WinForms.Controls
{
    public partial class TemplateDataCtrl : UserControl
    {
        public TemplateDataCtrl()
        {
            InitializeComponent();

            dataGrid.AutoGenerateColumns = true;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToOrderColumns = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.ReadOnly = true;
        }

        public string[] ColumnList
        {
            get
            {
                List<string> columnList = new List<string>();

                if (this.dataGrid.DataSource != null)
                {
                    DataTable dataTable = this.dataGrid.DataSource as DataTable;
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        columnList.Add(column.ColumnName);
                    }
                }
                return columnList.ToArray();
            }
        }

        public void DisplayTable(IDataSource dataSource)
        {
            if (dataSource != null)
            {
                if (dataSource.DataExists())
                {
                    dataSource.LoadFileData();
                    dataGrid.DataSource = dataSource.CurrentData;
                }
                else
                    dataGrid.DataSource = null;
            }
            else
                dataGrid.DataSource = null;
        }

        private void OnlyAllowCheckEdit()
        {
            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                column.ReadOnly = true;
            }
        }
    }
}
