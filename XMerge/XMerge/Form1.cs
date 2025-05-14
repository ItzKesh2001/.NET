using System.Collections.ObjectModel;
using System.Diagnostics;

namespace XMerge
{
    public partial class Form1 : Form
    {
        private string strDefaultFolderPath = "D:\\Training\\C#\\Tools\\Tools\\AppBase";

        List<CompareFolders> lstCompareFolders = new List<CompareFolders>();

        List<string> ComparisonNames = new List<string>();


        List<CheckBox> lstFilters;
        public Form1()
        {
            InitializeComponent();
            tvAppBase.CheckBoxes = true;
            tvApp.CheckBoxes = true;
            lstFilters = new List<CheckBox> { chkHTML, chkXML, chkSQL, chkBPMN, chkNS, chkJS, chkSCSS, chkTS};
        }

        private void btnAppBasePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbdDialog = new FolderBrowserDialog())
            {
                // setting Folder A path
                fbdDialog.SelectedPath = strDefaultFolderPath;

                if (fbdDialog.ShowDialog() == DialogResult.OK)
                {
                    // populating folder path
                    txtAppBasePath.Text = fbdDialog.SelectedPath;
                    tvAppBase.Nodes.Clear();
                    // loading the folder structure into the textbox
                    LoadFolderStructure(txtAppBasePath.Text, tvAppBase);
                }
            }
        }

        private void btnAppPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbdDialog = new FolderBrowserDialog())
            {
                // setting Folder A path
                fbdDialog.SelectedPath = strDefaultFolderPath;

                if (fbdDialog.ShowDialog() == DialogResult.OK)
                {
                    // populating folder path
                    txtAppPath.Text = fbdDialog.SelectedPath;
                    tvApp.Nodes.Clear();
                    // loading the folder structure into the textbox
                    LoadFolderStructure(txtAppPath.Text, tvApp);
                }
            }
        }

        public void LoadFolderStructure(string strRootPath, TreeView tvTree)
        {
            DirectoryInfo dirRootDir = new DirectoryInfo(strRootPath);

            if (dirRootDir.Exists)
            {
                // adding parent folder as a node
                TreeNode trnRootNode = new TreeNode(dirRootDir.Name) { Tag = dirRootDir.FullName };

                tvTree.Nodes.Add(trnRootNode);

                LoadSubDirectories(dirRootDir, trnRootNode); // calling the method to load sub directories

                trnRootNode.Expand();
            }
        }

        private void LoadSubDirectories(DirectoryInfo dirSubDir, TreeNode trnParentNode)
        {
            foreach (var subDir in dirSubDir.GetDirectories())
            {
                /// adding child folder as Parent node
                TreeNode trnChildNode = new TreeNode(subDir.Name) { Tag = subDir.FullName };

                trnParentNode.Nodes.Add(trnChildNode);

                LoadSubDirectories(subDir, trnChildNode); // recursive method for loading all sub directories
            }
        }
        
        private void chkAllFiles_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = chkAllFiles.Checked;

            chkHTML.Checked = isChecked;
            chkXML.Checked = isChecked;
            chkSQL.Checked = isChecked;
            chkBPMN.Checked = isChecked;
            chkNS.Checked = isChecked;
            chkJS.Checked = isChecked;
            chkSCSS.Checked = isChecked;
            chkTS.Checked = isChecked;
        }

        private void UncheckAllFiles(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if(!checkBox.Checked)
            {
                chkAllFiles.CheckedChanged -= chkAllFiles_CheckedChanged!;
                chkAllFiles.Checked = false;
                chkAllFiles.CheckedChanged += chkAllFiles_CheckedChanged!;

            }
        }

        int ComparisonIndex = 1;
        string? ComparisonName;
        bool IsFilterSelected;
        private void btnCompare_Click(object sender, EventArgs e)
        {

            if (txtAppBasePath.Text.Length == 0 || txtAppPath.Text.Length == 0)
            {
                MessageBox.Show("Please select 2 Folders before comparing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IsFilterSelected = false;

            foreach(CheckBox checkBox in lstFilters)
            {
                if (checkBox.Checked)
                {
                    IsFilterSelected = true;
                }
            }

           if(!IsFilterSelected)
            {
                MessageBox.Show("Please select the Filters before comparing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            ComparisonName = txtComparisonName.Text.Length == 0 ? $"Comparison {ComparisonIndex}" : txtComparisonName.Text;

            CompareFolders NewComparison = new CompareFolders(ComparisonName, txtAppBasePath.Text, txtAppPath.Text, lstFilters);

            bool filesCompared = NewComparison.ComparingFolders(tvAppBase, tvApp);

            if (filesCompared)
            {
                if (!ComparisonNames.Contains(ComparisonName))
                {
                    lstCompareFolders.Add(NewComparison);

                    ComparisonNames.Add(ComparisonName);
                    
                    lstboxComparisons.Items.Clear();
                    lstboxComparisons.Items.AddRange(ComparisonNames.ToArray());

                    ComparisonIndex++;

                    txtComparisonName.Text = "";

                    MessageBox.Show("Folders have been compared and results have been stored.", "Comparison Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please pick a name which is not already in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please select matching folders for comparison.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string? SelectedComparison;
        private void btnViewComparison_Click(object sender, EventArgs e)
        {
            if (lstboxComparisons.SelectedItem != null)
            {
                SelectedComparison = lstboxComparisons.SelectedItem.ToString();
                lstCompareFolders.First(f => f.ComparisonName == SelectedComparison).ExportResults();
            }
            else
            {
                MessageBox.Show("Please select the comparison for which you'd like to see the summary.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDeleteComparison_Click(object sender, EventArgs e)
        {
            if (lstboxComparisons.SelectedItem != null)
            {
                SelectedComparison = lstboxComparisons.SelectedItem.ToString();

                // remove comparison object
                lstCompareFolders.RemoveAll(f => f.ComparisonName == SelectedComparison);

                // remove comparison from listBox
                ComparisonNames.Remove(SelectedComparison!);

                lstboxComparisons.Items.Clear();
                lstboxComparisons.Items.AddRange(ComparisonNames.ToArray());
            }
            else
            {
                MessageBox.Show("Please select the comparison you'd like to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
