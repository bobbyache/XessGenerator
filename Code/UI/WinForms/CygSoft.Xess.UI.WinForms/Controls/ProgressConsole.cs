using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CygSoft.Xess.UI.WinForms.Controls
{
    public partial class ProgressConsole : UserControl
    {
        #region Delegates

        private delegate void SetConsoleTextHandler(string data, Color textColour, bool clearConsole);
        private delegate void SetProgressValueHandler(int value);
        private delegate void ClearConsoleHandler();

        #endregion

        #region Constructors

        public ProgressConsole()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Properties

        public int ProgressMaximum
        {
            get { return this.progressBar1.Maximum; }
            set 
            {
                SetProgressMaximum(value);
            }
        }

        public int Progress
        {
            get { return this.progressBar1.Value; }
            set 
            {
                SetProgress(value);
            }
        }

        #endregion

        #region Public Methods

        public void ClearConsoleText()
        {
            if (txtConsole.InvokeRequired)
            {
                ClearConsoleHandler del = new ClearConsoleHandler(ClearConsoleText);
                this.Invoke(del, new object[] { });
            }
            else
            {
                txtConsole.Clear();
            }
        }

        public void AppendConsoleText(string data, Color textColour, bool clearConsole)
        {
            if (data != null)
            {
                if (txtConsole.InvokeRequired)
                {
                    SetConsoleTextHandler del = new SetConsoleTextHandler(AppendConsoleText);
                    this.Invoke(del, new object[] { data, textColour, clearConsole });
                }
                else
                {
                    if (clearConsole)
                        txtConsole.Clear();

                    txtConsole.SelectionStart = txtConsole.TextLength;
                    txtConsole.SelectionLength = 0;
                    txtConsole.SelectionColor = textColour;
                    txtConsole.AppendText(data);
                    txtConsole.AppendText(Environment.NewLine);
                    txtConsole.SelectionColor = txtConsole.ForeColor;
                    txtConsole.ScrollToCaret();
                }
            }
        }

        #endregion

        #region Private Methods

        private void SetProgressMaximum(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                SetProgressValueHandler del = new SetProgressValueHandler(SetProgressMaximum);
                this.Invoke(del, new object[] { value });
            }
            else
            {
                progressBar1.Maximum = value;
            }
        }

        private void SetProgress(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                SetProgressValueHandler del = new SetProgressValueHandler(SetProgress);
                this.Invoke(del, new object[] { value });
            }
            else
            {
                progressBar1.Value = value;
            }
        }

        #endregion
    }
}
