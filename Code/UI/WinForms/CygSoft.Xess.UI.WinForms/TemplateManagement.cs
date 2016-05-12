using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CygX1.XessGenerator.ProjectFileManager;
using CygX1.XessGenerator.Common.RegSettings;
using CygX1.XessGenerator.Domain;
using CygX1.XessGenerator.GUI.Views;


// Property Grid resource List
// http://www.propertygridresourcelist.com/treeNodes[0].Text = (treeNodes[0].Tag as Template).Title;
namespace CygX1.XessGenerator.GUI
{
    public partial class TemplateManagement : Form
    {
        private FileManager fileManager = null;
        private RegistrySettings registrySettings = null;
        private List<ITemplate> templatesList = null;
        
        public TemplateManagement(FileManager fileManager, RegistrySettings registrySettings)
        {
            InitializeComponent();
            this.fileManager = fileManager;
            this.registrySettings = registrySettings;
            

            RefreshTemplates();
        }

        #region Form Events

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void mnuAddTemplate_Click(object sender, EventArgs e)
        {
            AddTemplate();
        }

        private void mnuAddTemplateSection_Click(object sender, EventArgs e)
        {
            AddTemplateSection();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (NodeIsSection(treeView.SelectedNode))
            {
                TreeNode templateNode = treeView.SelectedNode.Parent;
                ITemplateView parentTemplate = treeView.SelectedNode.Parent.Tag as ITemplateView;
                ITemplateSectionView selectedSection = treeView.SelectedNode.Tag as ITemplateSectionView;

                if (parentTemplate.CanMoveSectionUp(selectedSection))
                {
                    parentTemplate.MoveSectionUp(selectedSection.Id);
                    RefreshTemplateSections(templateNode, selectedSection);
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //if (NodeIsSection(treeView.SelectedNode))
            //{
            //    TreeNode templateNode = treeView.SelectedNode.Parent;
            //    ITemplateView parentTemplate = treeView.SelectedNode.Parent.Tag as ITemplateView;
            //    //ITemplateSectionView selectedSection = treeView.SelectedNode.Tag as TemplateSectionView;

            //    if (parentTemplate.CanMoveSectionDown(selectedSection))
            //    {
            //        parentTemplate.MoveSectionDown(selectedSection.Id);
            //        RefreshTemplateSections(templateNode, selectedSection);
            //    }
            //}
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (NodeIsSection(treeView.SelectedNode))
            {
                propertyGrid.SelectedObject = e.Node.Tag as ITemplateSectionView;
                btnUp.Enabled = (treeView.SelectedNode.Parent.Tag as ITemplate).CanMoveSectionUp(treeView.SelectedNode.Tag as ITemplateSection);
                btnDown.Enabled = (treeView.SelectedNode.Parent.Tag as ITemplate).CanMoveSectionDown(treeView.SelectedNode.Tag as ITemplateSection);
            }
            else
            {
                propertyGrid.SelectedObject = e.Node.Tag as ITemplateView;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            }
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            bool isSection = false;
            string id = string.Empty;

            if (propertyGrid.SelectedObject is ITemplateSectionView)
            {
                id = (propertyGrid.SelectedObject as ITemplateSectionView).Id;
                isSection = true;
            }
            else
                id = (propertyGrid.SelectedObject as ITemplateView).Id;

            TreeNode[] treeNodes = treeView.Nodes.Find(id, true);
            if (treeNodes.Length == 1)
            {
                if (isSection)
                    treeNodes[0].Text = (treeNodes[0].Tag as ITemplateSectionView).Title;
                else
                    treeNodes[0].Text = (treeNodes[0].Tag as ITemplateView).Title;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            fileManager.UpdateTemplates(this.templatesList);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Private Procedures

        private void AddTemplateSection()
        {
            TreeNode selectedNode = treeView.SelectedNode;

            if (selectedNode != null)
            {
                if (selectedNode.Tag is ITemplateView)
                {
                    ITemplateSection templateSection = (selectedNode.Tag as ITemplate).AddSection("New Section");
                    NewTemplateSectionNode(selectedNode, templateSection);
                }
                else if (selectedNode.Tag is ITemplateSectionView)
                {
                    TreeNode parentNode = selectedNode.Parent;
                    if (parentNode != null)
                    {
                        if (parentNode.Tag is ITemplateView)
                        {
                            ITemplateSection templateSection = (parentNode.Tag as ITemplate).AddSection("New Section");
                            NewTemplateSectionNode(parentNode, templateSection);
                        }
                    }
                }
            }
        }

        private void AddTemplate()
        {
            Template newTemplate = new Template();
            newTemplate.Title = "New Template";
            templatesList.Add(newTemplate);
            NewTemplateNode(newTemplate);
        }

        private void Delete()
        {
            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode != null)
            {
                if (selectedNode.Tag is ITemplateView)
                {
                    ITemplateView template = selectedNode.Tag as ITemplateView;
                    DialogResult result = MessageBox.Show(this, CommonConstants.DialogMessages.QueryDeletingTemplate(template.Title),
                        ConfigSettings.ApplicationTitle, MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.templatesList.Remove(this.templatesList.Where(t => t.Id == template.Id).SingleOrDefault());
                        treeView.Nodes.Remove(selectedNode);
                        treeView.Focus();
                    }
                }
                else if (selectedNode.Tag is ITemplateSectionView)
                {
                    ITemplateSectionView section = selectedNode.Tag as ITemplateSectionView;
                    DialogResult result = MessageBox.Show(this, CommonConstants.DialogMessages.QueryDeletingTemplateSection(section.Title),
                        ConfigSettings.ApplicationTitle, MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        TreeNode parentNode = selectedNode.Parent;
                        if (parentNode != null)
                        {
                            if (parentNode.Tag is ITemplateView)
                            {
                                ITemplateView parentTemplate = parentNode.Tag as ITemplateView;
                                parentTemplate.DeleteSection(section.Id);
                                treeView.Nodes.Remove(selectedNode);
                                treeView.Focus();
                            }
                        }
                    }
                }
            }
        }

        private void RefreshTemplates()
        {
            this.templatesList = fileManager.GetTemplates();
            treeView.Nodes.Clear();

            foreach (Template template in this.templatesList)
            {
                TreeNode templateNode = NewTemplateNode(template);
                RefreshTemplateSections(templateNode, null);
            }

        }

        private void RefreshTemplateSections(TreeNode templateNode, ITemplateSection focusedSection)
        {
            if (NodeIsTemplate(templateNode))
            {
                ITemplateView template = templateNode.Tag as ITemplateView;

                if (templateNode.Nodes.Count > 0)
                    templateNode.Nodes.Clear();

                TreeNode templateSectionNode;

                foreach (ITemplateSection templateSection in template.TemplateSectionList)
                    templateSectionNode = NewTemplateSectionNode(templateNode, templateSection);

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

        private TreeNode NewTemplateNode(ITemplate template)
        {
            TreeNode treeNode = treeView.Nodes.Add(template.Id, template.Title);
            treeNode.Tag = template; // ViewFactory.GetTemplateViewFor(template);
            treeView.SelectedNode = treeNode;
            treeNode.EnsureVisible();

            return treeNode;
        }

        private TreeNode NewTemplateSectionNode(TreeNode parentTemplateNode, ITemplateSection templateSection)
        {
            TreeNode treeNode = parentTemplateNode.Nodes.Add(templateSection.Id, templateSection.Title);
            //treeNode.Tag = ViewFactory.GetTemplateSectionViewFor(templateSection, null);
            parentTemplateNode.Expand();
            treeView.SelectedNode = treeNode;
            treeNode.EnsureVisible();

            return treeNode;
        }

        private bool NodeIsTemplate(TreeNode treeNode)
        {
            if (treeNode != null)
            {
                if (treeNode.Tag is ITemplateView)
                    return true;
            }
            return false;
        }

        private bool NodeIsSection(TreeNode treeNode)
        {
            if (treeNode != null)
            {
                if (treeNode.Tag is ITemplateSectionView)
                    return true;
            }
            return false;
        }

        #endregion
    }
}
