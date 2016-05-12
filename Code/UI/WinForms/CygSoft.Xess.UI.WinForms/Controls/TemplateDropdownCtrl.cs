using CygSoft.Xess.App;
using CygSoft.Xess.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CygSoft.Xess.UI.WinForms.Controls
{
    public partial class TemplateDropdownCtrl : ToolStripComboBox
    {
        public event EventHandler<BeforeRefreshEventArgs> BeforeRefresh;
        public event EventHandler<AfterRefreshEventArgs> AfterRefresh;
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

        public TemplateDropdownCtrl()
        {
            InitializeComponent();
        }

        public TemplateDropdownCtrl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public string SelectedTemplateId
        {
            get { return GetSelectedTemplateID(); }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);

            TemplateListItem templateListItem = this.SelectedItem as TemplateListItem;
            ITemplate template = XessApplication.GetTemplate(templateListItem.ID);

            if (SelectionChanged != null)
                SelectionChanged(this, new SelectionChangedEventArgs(templateListItem, template));
        }

        public void RefreshTemplateList()
        {
            if (BeforeRefresh != null)
            {
                BeforeRefreshEventArgs args = new BeforeRefreshEventArgs(GetSelectedTemplate());
                BeforeRefresh(this, args);
                if (args.Cancel)
                    return;
            }

            // populate the items...
            this.Items.Clear();
            this.Items.AddRange(XessApplication.GetTemplateList().ToArray());
            string id = GetSelectedTemplateID();

            // attempt to select one at index 0...
            if (id != string.Empty)
            {
                SelectTemplateById(id);
                TemplateListItem templateListItem = GetSelectedTemplate();

                if (AfterRefresh != null)
                    AfterRefresh(this, new AfterRefreshEventArgs(templateListItem));
            }
            if (id == string.Empty && this.Items.Count == 0)
            {
                if (AfterRefresh != null)
                    AfterRefresh(this, new AfterRefreshEventArgs(null));
            }
            else
            {
                this.SelectedIndex = 0;
                id = GetSelectedTemplateID();
                SelectTemplateById(id);
                TemplateListItem templateListItem = GetSelectedTemplate();

                if (AfterRefresh != null)
                    AfterRefresh(this, new AfterRefreshEventArgs(templateListItem));
            }
        }

        private void SelectTemplateById(string id)
        {
            if (id != string.Empty)
            {
                foreach (TemplateListItem template in this.Items)
                {
                    if (template.ID == id)
                        this.SelectedItem = template;
                }
            }

        }
        private TemplateListItem GetSelectedTemplate()
        {
            if (TemplateSelected())
                return this.SelectedItem as TemplateListItem;

            return null;
        }

        private string GetSelectedTemplateID()
        {
            string id = string.Empty;
            if (TemplateSelected())
            {
                TemplateListItem selectedTemplate = this.SelectedItem as TemplateListItem;
                id = selectedTemplate.ID;
            }
            return id;
        }

        private bool TemplateSelected()
        {
            if (this.Items.Count > 0)
            {
                if (this.SelectedItem != null)
                    return true;
            }
            return false;
        }
    }

    public class SelectionChangedEventArgs : EventArgs
    {
        public TemplateListItem TemplateListItem { get; private set; }
        public ITemplate Template { get; private set; }

        public SelectionChangedEventArgs(TemplateListItem templateListItem, ITemplate template)
        {
            this.Template = template;
            this.TemplateListItem = templateListItem;
        }
    }

    public class BeforeRefreshEventArgs : EventArgs
    {
        public TemplateListItem Template { get; private set; }
        public bool Cancel { get; set; }

        public BeforeRefreshEventArgs(TemplateListItem template)
        {
            this.Template = template;
            this.Cancel = false;
        }
    }

    public class AfterRefreshEventArgs : EventArgs
    {
        public TemplateListItem Template { get; private set; }

        public AfterRefreshEventArgs(TemplateListItem template)
        {
            this.Template = template;
        }
    }
}
