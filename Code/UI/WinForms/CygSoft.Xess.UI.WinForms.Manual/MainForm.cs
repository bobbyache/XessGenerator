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
                workSet.LoadData(dialogData.FilePath);
            }
        }

        private void project_DataLoaded(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.BeginEdit(false);
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                columnMenu.Show(dataGridView, new Point(e.X, e.Y));
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
    }
}
