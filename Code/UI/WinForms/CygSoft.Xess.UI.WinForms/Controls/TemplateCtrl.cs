using System;
using System.Windows.Forms;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.App;


namespace CygSoft.Xess.UI.WinForms.Controls
{
    public enum TemplateEditMode
    {
        Template,
        Section
    }

    public enum TemplateEditorStateEnum
    {
        Disabled,
        Editing,
        ReadOnly
    }

    public partial class TemplateCtrl : UserControl
    {
        public event EventHandler TemplateSaved;
        public event EventHandler StateChanged;

        private PersistableObject currentItem;

        public TemplateCtrl()
        {
            InitializeComponent();
            sectionEdit.Dock = DockStyle.Fill;
            templateEdit.Dock = DockStyle.Fill;

            tabControl1.TabPages.Clear();

            sectionEdit.SectionSaved += sectionEdit_SectionSaved;
            templateEdit.TemplateSaved += templateEdit_TemplateSaved;
            templateEdit.StateChanged += templateEdit_StateChanged;
            sectionEdit.StateChanged += templateEdit_StateChanged;
        }

        private void templateEdit_StateChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        public bool Editing
        {
            get
            {
                if (sectionEdit.Visible && sectionEdit.CurrentState == TemplateEditorStateEnum.Editing)
                    return true;
                else if (templateEdit.Visible && templateEdit.CurrentState == TemplateEditorStateEnum.Editing)
                    return true;
                else
                    return false;
            }
        }

        private void templateEdit_TemplateSaved(object sender, EventArgs e)
        {
            if (TemplateSaved != null)
                TemplateSaved(this, new EventArgs());
        }

        private void sectionEdit_SectionSaved(object sender, EventArgs e)
        {
            if (TemplateSaved != null)
                TemplateSaved(this, new EventArgs());
        }

        public void LoadData(PersistableObject item)
        {
            this.currentItem = item;

            if (item is ITemplate)
            {
                PopulateEditor(item);
                ShowEditor(TemplateEditMode.Template);
            }
            else if (item is ITemplateSection)
            {
                PopulateEditor(item);
                ShowEditor(TemplateEditMode.Section);
            }
            else
                throw new ApplicationException("bad object type");
        }

        private void ShowEditor(TemplateEditMode mode)
        {
            DisplayEditorTab(mode);
        }

        private void DisplayEditorTab(TemplateEditMode mode)
        {
            switch (mode)
            {
                case TemplateEditMode.Section:
                    if (tabControl1.SelectedTab != tabPageSection)
                    {
                        tabControl1.TabPages.Clear();
                        tabControl1.TabPages.Add(tabPageSection);
                    }
                    tabControl1.SelectedTab = tabPageSection;
                    break;
                case TemplateEditMode.Template:
                    if (tabControl1.SelectedTab != tabPageTemplate)
                    {
                        tabControl1.TabPages.Clear();
                        tabControl1.TabPages.Add(tabPageTemplate);
                    }
                    tabControl1.SelectedTab = tabPageTemplate;
                    break;
            }
        }

        private void PopulateEditor(PersistableObject item)
        {
            if (item is ITemplateSection)
            {
                sectionEdit.CurrentSection = item as ITemplateSection;
            }
            else if (item is ITemplate)
            {
                templateEdit.CurrentTemplate = item as ITemplate;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
