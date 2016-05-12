using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CygSoft.Xess.Infrastructure;
using CygSoft.Xess.App;
using CygSoft.Xess.UI.WinForms.GlobalSettings;

namespace CygSoft.Xess.UI.WinForms.Controls
{
    public enum ItemTypeEnum
    {
        Unknown,
        Template,
        TemplateSection
    }

    public partial class TemplateView : UserControl
    {
        private List<ITemplate> templatesList = null;
        public event EventHandler ItemSelected;

        public TemplateView()
        {
            InitializeComponent();
            btnUp.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.MoveUp);
            btnDown.Image = ResourceHandler.ToolbarIcon(ResourceHandler.ToolbarImages.MoveDown);
            treeView.Nodes.Clear();
        }

        public ItemTypeEnum TypeOfSelectedItem
        {
            get
            {
                if (NodeIsSection(this.treeView.SelectedNode))
                    return ItemTypeEnum.TemplateSection;
                else if (NodeIsTemplate(this.treeView.SelectedNode))
                    return ItemTypeEnum.Template;
                else
                    return ItemTypeEnum.Unknown;
            }
        }

        public bool UserEditable
        {
            get { return toolStrip1.Visible; }
            set
            {
                treeView.AllowDrop = value;
                toolStrip1.Visible = value;
                if (value)
                    treeView.Dock = DockStyle.None;
                else
                    treeView.Dock = DockStyle.Fill;
            }
        }

        public PersistableObject CurrentlySelectedItem
        {
            get
            {
                return this.treeView.SelectedNode.Tag as PersistableObject;
            }
        }

        public void InitializeTemplates(List<ITemplate> templatesList)
        {
            this.templatesList = templatesList;
            treeView.Nodes.Clear();

            foreach (ITemplate template in this.templatesList)
            {
                TreeNode templateNode = NewTemplateNode(template, false);
                RefreshTemplateSections(templateNode, null);
            }
        }

        public void AddTemplate()
        {
            ITemplate newTemplate = XessApplication.NewTemplate();
            templatesList.Add(newTemplate);
            NewTemplateNode(newTemplate, true);
        }

        public void CloneTemplate()
        {
            if (NodeIsTemplate(treeView.SelectedNode))
            {
                ITemplate template = treeView.SelectedNode.Tag as ITemplate;
                ITemplate cloneTemplate = template.Clone();
                templatesList.Add(cloneTemplate);
                TreeNode templateNode = NewTemplateNode(cloneTemplate, true);

                foreach (ITemplateSection templateSection in cloneTemplate.TemplateSectionList)
                    NewTemplateSectionNode(templateNode, templateSection, false);
            }
        }

        public void CloneTemplateSection()
        {
            if (NodeIsSection(treeView.SelectedNode))
            {
                ITemplate parentTemplate = treeView.SelectedNode.Parent.Tag as ITemplate;
                ITemplateSection templateSection = treeView.SelectedNode.Tag as ITemplateSection;
                ITemplateSection clonedSection = templateSection.Clone(parentTemplate, false);
                parentTemplate.AddSection(clonedSection);
                NewTemplateSectionNode(treeView.SelectedNode.Parent, clonedSection, true);
            }
        }


        public void MoveSectionUp()
        {
            if (NodeIsSection(treeView.SelectedNode))
            {
                TreeNode templateNode = treeView.SelectedNode.Parent;
                ITemplate parentTemplate = treeView.SelectedNode.Parent.Tag as ITemplate;
                ITemplateSection selectedSection = treeView.SelectedNode.Tag as ITemplateSection;

                if (parentTemplate.CanMoveSectionUp(selectedSection))
                {
                    parentTemplate.MoveSectionUp(selectedSection.Id);
                    RefreshTemplateSections(templateNode, selectedSection);
                }
            }
        }

        public void MoveSectionDown()
        {
            if (NodeIsSection(treeView.SelectedNode))
            {
                TreeNode templateNode = treeView.SelectedNode.Parent;
                ITemplate parentTemplate = treeView.SelectedNode.Parent.Tag as ITemplate;
                ITemplateSection selectedSection = treeView.SelectedNode.Tag as ITemplateSection;

                if (parentTemplate.CanMoveSectionDown(selectedSection))
                {
                    parentTemplate.MoveSectionDown(selectedSection.Id);
                    RefreshTemplateSections(templateNode, selectedSection);
                }
            }
        }

        public void RefreshSelectedTitle()
        {
            treeView.Refresh();

            if (treeView.SelectedNode.Tag is ITemplateSection)
                treeView.SelectedNode.Text = (treeView.SelectedNode.Tag as ITemplateSection).Title;
            else if (treeView.SelectedNode.Tag is ITemplate)
                treeView.SelectedNode.Text = (treeView.SelectedNode.Tag as ITemplate).Title;
        }

        public void AddTemplateSection()
        {
            TreeNode selectedNode = treeView.SelectedNode;

            if (selectedNode != null)
            {
                if (selectedNode.Tag is ITemplate)
                {
                    ITemplateSection templateSection = (selectedNode.Tag as ITemplate).AddSection("New Section");
                    NewTemplateSectionNode(selectedNode, templateSection, true);
                }
                else if (selectedNode.Tag is ITemplateSection)
                {
                    TreeNode parentNode = selectedNode.Parent;
                    if (parentNode != null)
                    {
                        if (parentNode.Tag is ITemplate)
                        {
                            ITemplateSection templateSection = (parentNode.Tag as ITemplate).AddSection("New Section");
                            NewTemplateSectionNode(parentNode, templateSection, true);
                        }
                    }
                }
            }
        }

        public void DeleteFocusedItem()
        {
            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode != null)
            {
                if (selectedNode.Tag is ITemplate)
                {
                    ITemplate template = selectedNode.Tag as ITemplate;
                    DialogResult result = MessageBox.Show(this, CommonConstants.DialogMessages.QueryDeletingTemplate(template.Title),
                        ConfigSettings.ApplicationTitle, MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.templatesList.Remove(this.templatesList.Where(t => t.Id == template.Id).SingleOrDefault());
                        treeView.Nodes.Remove(selectedNode);
                        treeView.Focus();
                    }
                }
                else if (selectedNode.Tag is ITemplateSection)
                {
                    ITemplateSection section = selectedNode.Tag as ITemplateSection;
                    DialogResult result = MessageBox.Show(this, CommonConstants.DialogMessages.QueryDeletingTemplateSection(section.Title),
                        ConfigSettings.ApplicationTitle, MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        TreeNode parentNode = selectedNode.Parent;
                        if (parentNode != null)
                        {
                            if (parentNode.Tag is ITemplate)
                            {
                                ITemplate parentTemplate = parentNode.Tag as ITemplate;
                                parentTemplate.DeleteSection(section.Id);
                                treeView.Nodes.Remove(selectedNode);
                                treeView.Focus();
                            }
                        }
                    }
                }
            }
        }

        private TreeNode NewTemplateNode(ITemplate template, bool select)
        {
            TreeNode treeNode = treeView.Nodes.Add(template.Id, template.Title);
            treeNode.Tag = template;
            treeNode.ImageKey = "Template";
            treeNode.SelectedImageKey = "Template";
            treeNode.StateImageKey = "Template";
            if (select)
                SelectNode(treeNode, null);
            return treeNode;
        }


        private void SelectNode(TreeNode node, TreeNode parentNode)
        {
            if (parentNode != null)
                parentNode.Expand();
            treeView.SelectedNode = node;
            node.EnsureVisible();
        }

        private TreeNode NewTemplateSectionNode(TreeNode parentTemplateNode, ITemplateSection templateSection, bool select)
        {
            TreeNode treeNode = parentTemplateNode.Nodes.Add(templateSection.Id, templateSection.Title);
            treeNode.Tag = templateSection;
            treeNode.ImageKey = "Section";
            treeNode.SelectedImageKey = "Section";
            treeNode.StateImageKey = "Section";
            if (select)
                SelectNode(treeNode, parentTemplateNode);
            return treeNode;
        }

        private void RefreshTemplateSections(TreeNode templateNode, ITemplateSection focusedSection)
        {
            if (NodeIsTemplate(templateNode))
            {
                ITemplate template = templateNode.Tag as ITemplate;

                if (templateNode.Nodes.Count > 0)
                    templateNode.Nodes.Clear();

                TreeNode templateSectionNode;

                foreach (ITemplateSection templateSection in template.TemplateSectionList)
                    templateSectionNode = NewTemplateSectionNode(templateNode, templateSection, false);

                if (treeView.Nodes.Count > 0)
                    SelectNode(treeView.Nodes[0], treeView.Nodes[0].Parent);


                if (focusedSection != null)
                {
                    foreach (TreeNode treeNode in templateNode.Nodes)
                    {
                        if ((treeNode.Tag as ITemplateSection).Id == focusedSection.Id)
                        {
                            templateNode.Expand();
                            treeView.SelectedNode = treeNode;
                            treeNode.EnsureVisible();
                            break;
                        }
                    }
                }
            }
        }

        private bool NodeIsTemplate(TreeNode treeNode)
        {
            if (treeNode != null)
            {
                if (treeNode.Tag is ITemplate)
                    return true;
            }
            return false;
        }

        private bool NodeIsSection(TreeNode treeNode)
        {
            if (treeNode != null)
            {
                if (treeNode.Tag is ITemplateSection)
                    return true;
            }
            return false;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (NodeIsSection(treeView.SelectedNode))
            {
                ITemplate parentTemplate = treeView.SelectedNode.Parent.Tag as ITemplate;
                ITemplateSection selectedSection = treeView.SelectedNode.Tag as ITemplateSection;

                btnUp.Enabled = parentTemplate.CanMoveSectionUp(selectedSection);
                btnDown.Enabled = parentTemplate.CanMoveSectionDown(selectedSection);
            }
            else
            {
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            }
            if (ItemSelected != null)
                ItemSelected(this, new EventArgs());
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveSectionUp();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveSectionDown();
        }

        #region Drag and Drop Operations

        private TreeNode sourceNode = null;

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.sourceNode = (TreeNode)e.Item;
            string strItem = e.Item.ToString();
            DoDragDrop(strItem, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Point position = treeView.PointToClient(new Point(e.X, e.Y)); // new Point(e.X, e.Y);
            TreeNode dropNode = treeView.GetNodeAt(position);

            if (NodeIsSection(sourceNode) && NodeIsTemplate(dropNode) && dropNode != null && dropNode != sourceNode && sourceNode.Parent != dropNode)
            {
                ITemplateSection templateSection = sourceNode.Tag as ITemplateSection;
                ITemplate destinationTemplate = dropNode.Tag as ITemplate;

                DialogResult result = MessageBox.Show(this.ParentForm, 
                    string.Format("Template section ({0}) will be cloned to the template ({1}). Would you like to proceed?", 
                    templateSection.Title, destinationTemplate.Title), ConfigSettings.ApplicationTitle, 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    ITemplateSection clonedSection = templateSection.Clone(destinationTemplate, true);
                    destinationTemplate.AddSection(clonedSection);
                    NewTemplateSectionNode(dropNode, clonedSection, true);
                }
            }
        }

        #endregion

    //    private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    //    {
    //        if (e.Button == System.Windows.Forms.MouseButtons.Right)
    //        {
    //            treeView.SelectedNode = e.Node;
    //            //if (NodeIsTemplate(e.Node))
    //            //    MessageBox.Show("Template: " + (e.Node.Tag as ITemplate).Id);
    //            //else if (NodeIsSection(e.Node))
    //            //    MessageBox.Show("Section: " + (e.Node.Tag as ITemplateSection).Id);

    //            contextMenu.Show(this, new Point(e.X, e.Y));
    //        }
    //    }

    //    private void menuEdit_Click(object sender, EventArgs e)
    //    {
    //        //WizardHost wizardHost = new WizardHost();
    //        //wizardHost.Text = "Edit Template Section";
    //        //wizardHost.WizardCompleted += wizardHost_WizardCompleted;
    //        //wizardHost.WizardPages.Add(1, new SectionProperties());
    //        //wizardHost.WizardPages.Add(2, new DataSourceAction());
    //        //wizardHost.WizardPages.Add(3, new DataSourceEdit());
    //        //wizardHost.WizardPages.Add(4, new BlueprintEdit());

    //        //wizardHost.LoadWizard();
    //        //wizardHost.ShowDialog();
    //    }
    }

}
