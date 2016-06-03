using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace CygSoft.Xess.UI.WinForms
{
    public partial class MainForm : Form
    {
        private WorkSet workSet = new WorkSet();
        private bool loadingData = false;
        private bool selectAllInCell = true;

        public MainForm()
        {
            InitializeComponent();
            this.blueprintSyntaxBox.Document.SyntaxFile = "blueprint.syn";
            workSet.DataLoaded += new EventHandler(project_DataLoaded);
            dataGridView.DataSource = workSet.Table;
        }

        private void DisplayData()
        {
            dataGridView.DataSource = workSet.Table;
            this.blueprintSyntaxBox.Document.Text = workSet.BlueprintText;
        }

        private void GenerateText()
        {
            dataGridView.EndEdit();
            resultsSyntaxBox.Document.Text = workSet.GenerateText();
        }

        private void SaveProject()
        {
            DialogData dialogData = ApplicationDialogs.Save(this);
            if (dialogData.Result == System.Windows.Forms.DialogResult.OK)
                workSet.SaveData(dialogData.FilePath);
        }

        private void OpenProject()
        {
            DialogData dialogData = ApplicationDialogs.Open(this);
            if (dialogData.Result == System.Windows.Forms.DialogResult.OK)
            {
                loadingData = true;
                workSet.LoadData(dialogData.FilePath);
                loadingData = false;
            }
        }

        private void project_DataLoaded(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (loadingData)
                dataGridView.BeginEdit(true);
            else
                dataGridView.BeginEdit(selectAllInCell);
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabResults)
            {
                GenerateText();
            }
        }

        private void blueprintSyntaxBox_Leave(object sender, EventArgs e)
        {
            workSet.BlueprintText = blueprintSyntaxBox.Document.Text;
            dataGridView.DataSource = workSet.Table;
            GenerateText();
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Sure you want to exit?", "Xess Manual Generator", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void blueprintSyntaxBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Control && e.KeyCode == Keys.Alt && e.KeyCode == Keys.V)
            if (e.KeyCode == Keys.V && e.Alt)
            {
                //MessageBox.Show("Pressed");
                blueprintSyntaxBox.Selection.Text = "@{" + blueprintSyntaxBox.Selection.Text + "}";
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            // http://stackoverflow.com/questions/4077260/copy-and-paste-multiple-cells-within-datagridview
            // http://www.codeproject.com/Articles/36850/DataGridView-Copy-and-Paste

        }



        private void mnuCellSelectAll_Click(object sender, EventArgs e)
        {
            selectAllInCell = mnuCellSelectAll.Checked;
        }

        private void mnuGridClear_Click(object sender, EventArgs e)
        {
            workSet.Table.Rows.Clear();
        }

        private void mnuGridClearSelectedRows_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView.SelectedRows)
            {
                dataGridView.Rows.RemoveAt(item.Index);
            }  
        }

        private void mnuGridRemoveOrphanColumns_Click(object sender, EventArgs e)
        {
            workSet.RemoveOrphanedColumns();
        }
    }
}
