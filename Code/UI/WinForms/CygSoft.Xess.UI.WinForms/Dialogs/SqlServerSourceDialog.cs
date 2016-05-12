using System;
using System.Windows.Forms;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.App;
using CygSoft.Xess.UI.WinForms.GlobalSettings;
using CygSoft.Xess.Infrastructure.DataSources.SqlServer;

namespace CygSoft.Xess.UI.WinForms.Dialogs
{
    internal partial class SqlServerSourceDialog : Form
    {
        private string connectionsFile;
        private ISqlDatabaseDataSource sqlServerDataSource;
        private string projectFilePath;

        public SqlServerSourceDialog(string projectFilePath, string connectionsFile)
        {
            InitializeComponent();
            this.syntaxBox.SplitView = false;
            this.connectionsFile = connectionsFile;
            this.projectFilePath = projectFilePath;
        }

        public ISqlDatabaseDataSource SqlServerDataSource
        {
            get { return this.sqlServerDataSource; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                sqlServerDataSource.Title = txtTitle.Text;
                sqlServerDataSource.ConnectionString = (cboSqlServerList.SelectedItem as ICommonDbConnection).ConnectionString;
                sqlServerDataSource.CommandText = syntaxBox.Document.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTestDbConnection_Click(object sender, EventArgs e)
        {
            sqlServerDataSource.ConnectionString = (cboSqlServerList.SelectedItem as ICommonDbConnection).ConnectionString;
            if (sqlServerDataSource.SourceIsValid())
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.SuccessTestingConnection, ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.FailureTestingConnection, ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                sqlServerDataSource.ConnectionString = (cboSqlServerList.SelectedItem as ICommonDbConnection).ConnectionString;
                sqlServerDataSource.CommandText = syntaxBox.Document.Text;

                sqlServerDataSource.FetchData();
                gridView.DataSource = sqlServerDataSource.CurrentData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace, ConfigSettings.ApplicationTitle);
            }
        }

        public void AddNew()
        {
            sqlServerDataSource = XessApplication.NewSqlServerDataSource(this.projectFilePath);
            txtTitle.Text = string.Empty;
            syntaxBox.Document.Text = string.Empty;
            PopulatePresetConnections();
        }

        public void EditExisting(ISqlDatabaseDataSource sqlServerDataSource)
        {
            this.sqlServerDataSource = sqlServerDataSource;
            txtTitle.Text = this.sqlServerDataSource.Title;
            syntaxBox.Document.Text = this.sqlServerDataSource.CommandText;

            PopulatePresetConnections();
            SetCurrentPreset(this.sqlServerDataSource.ConnectionString);
        }

        private bool ValidateFields()
        {
            if (cboSqlServerList.SelectedItem == null)
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.NoInputValueForMandatoryField("Target Server"), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTitle.Text == "")
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.NoInputValueForMandatoryField("Title"), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (syntaxBox.Document.Text == "")
            {
                MessageBox.Show(this, CommonConstants.DialogMessages.NoInputValueForMandatoryField("SQL Query"), ConfigSettings.ApplicationTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void SetCurrentPreset(string connectionString)
        {
            foreach (ICommonDbConnection connection in cboSqlServerList.Items)
            {
                if (connection.ConnectionString == connectionString)
                    cboSqlServerList.SelectedItem = connection;
                break;
            }
        }

        private void PopulatePresetConnections()
        {
            cboSqlServerList.Items.Clear();
            cboSqlServerList.DisplayMember = "FriendlyName";

            cboSqlServerList.DataSource = XessApplication.GetCommonDatabaseConnections(this.connectionsFile);
            cboSqlServerList.SelectedIndex = 0;
        }
    }
}
