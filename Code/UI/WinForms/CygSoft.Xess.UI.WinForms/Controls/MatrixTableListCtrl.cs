using System;
using System.Windows.Forms;
using CygSoft.Xess.UI.WinForms.EventParams;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.App;

namespace CygSoft.Xess.UI.WinForms.Controls
{
    public partial class MatrixTableListCtrl : UserControl
    {
        public event EventHandler<DataSourceSelectionEventArgs> DataSourceSelectionChanged;
        public event EventHandler RemoveMenuItemClick;
        public event EventHandler EditMenuItemClick;

        public MatrixTableListCtrl()
        {
            InitializeComponent();
        }

        public IDataSource SelectedItem
        {
            get
            {
                if (ItemAvailableForEdit())
                    return listView1.SelectedItems[0].Tag as IDataSource;
                else
                    return null;
            }
        }

        public void LoadDataSourceList()
        {
            RefreshList();
            btnRefresh.Enabled = false;
            btnDisplay.Enabled = false;
            btnRemove.Enabled = ItemAvailableForEdit();
            btnEdit.Enabled = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                if (DataSourceSelectionChanged != null)
                    DataSourceSelectionChanged(this, new DataSourceSelectionEventArgs(listView1.SelectedItems[0].Tag as IDataSource));
            }
            else
            {
                if (DataSourceSelectionChanged != null)
                    DataSourceSelectionChanged(this, new DataSourceSelectionEventArgs(null));
            }
        }

        private void mnuFromExcel_Click(object sender, EventArgs e)
        {
            btnRemove.Enabled = ItemAvailableForEdit();
        }

        private void mnuFromSqlServer_Click(object sender, EventArgs e)
        {
            btnRemove.Enabled = ItemAvailableForEdit();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                IDataSource dataSource = listView1.SelectedItems[0].Tag as IDataSource;
                XessApplication.RemoveDataSource(dataSource);

                RefreshList();
                if (listView1.Items.Count > 0)
                {
                    listView1.Items[0].Selected = true;
                }
                else
                {
                    if (DataSourceSelectionChanged != null)
                        DataSourceSelectionChanged(this, new DataSourceSelectionEventArgs(null));
                }
                if (RemoveMenuItemClick != null)
                    RemoveMenuItemClick(this, new EventArgs());
            }
            btnRemove.Enabled = ItemAvailableForEdit();
        }

        private void RefreshList()
        {
            listView1.Items.Clear();

            foreach (IDataSource dataSource in XessApplication.GetDataSources())
            {
                ListViewItem item = new ListViewItem(dataSource.Title);
                item.Tag = dataSource;
                item.SubItems.Add(dataSource.TableName);
                listView1.Items.Add(item);
            }
        }

        private bool ItemAvailableForEdit()
        {
            return listView1.Items.Count > 0 && listView1.SelectedItems.Count == 1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (EditMenuItemClick != null)
                EditMenuItemClick(this, new EventArgs());
        }
    }
}
