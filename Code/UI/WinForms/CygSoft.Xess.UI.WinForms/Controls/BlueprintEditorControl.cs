using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Alsing.SourceCode;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.Infrastructure.ReplaceEngine;
using CygSoft.Xess.App;
using CygSoft.Xess.UI.WinForms.GlobalSettings;

namespace CygSoft.Xess.UI.WinForms
{
    public partial class BlueprintEditorControl : UserControl
    {
        private class Parts
        {
            public const string Header = "Header";
            public const string Footer = "Footer";
            public const string Body = "Body";
        }

        private SubstitutionExpression[] placeHolders;
        private string selectedPart;

        public BlueprintEditorControl()
        {
            InitializeComponent();
            this.syntaxBoxControl1.SplitView = false;
            this.cboParts.SelectedItem = Parts.Body;
            btnOptions.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.Options);
        }

        public void SetPlaceholders(SubstitutionExpression[] placeHolders)
        {
            this.placeHolders = placeHolders;
            SetPlaceholderMenus();
        }

        public void ClearPlaceholders()
        {
            this.placeHolders = null;
            SetPlaceholderMenus();
        }

        private void SetPlaceholderMenus()
        {
            syntaxBoxControl1.AutoListClear();
            if (this.placeHolders != null)
            {
                // set up syntax box placeholders.
                foreach (SubstitutionExpression expression in this.placeHolders)
                {
                    syntaxBoxControl1.AutoListAdd(expression.ActionIdentifier, expression.ActionIdentifier, expression.ActionIdentifier, 0);
                    syntaxBoxControl1.AutoListAdd(string.Format("{0} ({1})", expression.ActionIdentifier, expression.OutputPlaceholder), 
                        expression.OutputPlaceholder, expression.OutputPlaceholder, 4);
                }
            }
        }

        private bool readOnly;
        public bool ReadOnly
        {
            get { return this.readOnly; }
            set 
            { 
                this.readOnly = value;
                syntaxBoxControl1.ReadOnly = value;
                btnCut.Enabled = !value;
                btnPaste.Enabled = !value;
            }
        }

        private string headerText;
        public string HeaderText
        {
            get { return this.headerText; }
            set 
            { 
                this.headerText = value;
                if (cboParts.SelectedItem.Equals(Parts.Header))
                    syntaxBoxControl1.Document.Text = this.headerText;
            }
        }

        private string bodyText;
        public string BodyText
        {
            get { return this.bodyText; }
            set 
            { 
                this.bodyText = value;
                if (cboParts.SelectedItem.Equals(Parts.Body))
                    syntaxBoxControl1.Document.Text = this.bodyText;
            }
        }

        private string footerText;
        public string FooterText
        {
            get { return this.footerText; }
            set 
            { 
                this.footerText = value;
                if (cboParts.SelectedItem.Equals(Parts.Footer))
                    syntaxBoxControl1.Document.Text = this.footerText;
            }
        }

        public string SyntaxFilePath
        {
            set 
            {
                if (System.IO.File.Exists(value))
                {
                    this.syntaxBoxControl1.Document.SyntaxFile = value;
                }
                else
                {
                    this.syntaxBoxControl1.Document.SyntaxFile = ConfigSettings.DefaultSyntax;
                }
            }
        }

        public bool NewLineBeforeText
        {
            get { return this.mnuGenerateNewLineBefore.Checked; }
            set { this.mnuGenerateNewLineBefore.Checked = value; }
        }

        public bool NewLineAfterText
        {
            get { return this.mnuGenerateNewLineAfter.Checked; }
            set { this.mnuGenerateNewLineAfter.Checked = value; }
        }
        public bool TrimText
        {
            get { return this.mnuTrimText.Checked; }
            set { this.mnuTrimText.Checked = value; }
        }

        private void cboParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPart = cboParts.SelectedItem.ToString();

            switch (cboParts.SelectedItem.ToString())
            {
                case Parts.Header:
                    this.syntaxBoxControl1.Document.Text = this.headerText;
                    break;
                case Parts.Footer:
                    this.syntaxBoxControl1.Document.Text = this.footerText;
                    break;
                case Parts.Body:
                    this.syntaxBoxControl1.Document.Text = this.bodyText;
                    break;
            }
            SetPlaceholderMenus();
        }

        private void syntaxBoxControl1_Leave(object sender, EventArgs e)
        {
            switch (selectedPart)
            {
                case Parts.Header:
                    this.headerText = this.syntaxBoxControl1.Document.Text;
                    break;
                case Parts.Footer:
                    this.footerText = this.syntaxBoxControl1.Document.Text;
                    break;
                case Parts.Body:
                    this.bodyText = this.syntaxBoxControl1.Document.Text;
                    break;
            }
            syntaxBoxControl1.AutoListVisible = false;
        }

        private void syntaxBoxControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.placeHolders == null)
                return;

            if (!this.syntaxBoxControl1.ReadOnly && this.placeHolders.Length > 0)
            {
                if (e.KeyData == (Keys.Shift | Keys.F8) || e.KeyData == Keys.OemPeriod || e.KeyData == Keys.F8)
                {
                    this.syntaxBoxControl1.AutoListPosition = new TextPoint(syntaxBoxControl1.Caret.Position.X, syntaxBoxControl1.Caret.Position.Y);
                    this.syntaxBoxControl1.AutoListVisible = true;
                }
            }
        }

        private void mnuGenerateNewLineBefore_Click(object sender, EventArgs e)
        {
            mnuGenerateNewLineBefore.Checked = !mnuGenerateNewLineBefore.Checked;
        }

        private void mnuGenerateNewLineAfter_Click(object sender, EventArgs e)
        {
            mnuGenerateNewLineAfter.Checked = !mnuGenerateNewLineAfter.Checked;
        }

        private void mnuTrimText_Click(object sender, EventArgs e)
        {
            mnuTrimText.Checked = !mnuTrimText.Checked;
        }
    }
}
