using System.Diagnostics;
using System.Text;

namespace XMerge
{
    public partial class Results : Form
    {
        CompareFolders compareFolders;

        // arrays for storing file information
        public string[]? arrTotalFiles { get; set; }
        public string[]? arrAppBaseFiles { get; set; }
        public string[]? arrAppFiles { get; set; }
        public string[]? arrIdenticalFiles { get; set; }
        public string[]? arrNonIdenticalFiles { get; set; }

        public Results(CompareFolders compareFolders)
        {
            InitializeComponent();
            this.compareFolders = compareFolders;
            AssignArrays();
            AssignFormComponents();
            
        }

        private void AssignFormComponents()
        {
            lnkTotalFiles.Text = arrTotalFiles!.Length.ToString();
            lnkAppBaseFiles.Text = arrAppBaseFiles!.Length.ToString();
            lnkAppFiles.Text = arrAppFiles!.Length.ToString();
            lnkIdenticalFiles.Text = arrIdenticalFiles!.Length.ToString();
            lnkNonIdenticalFiles.Text = arrNonIdenticalFiles!.Length.ToString();
        }

        private void AssignArrays()
        {
            arrTotalFiles = compareFolders.clnFileDetails!
                .Select(f => f.FilePath!)
                .ToArray();

            arrAppBaseFiles = compareFolders.clnFileDetails!
                .Where(f => f.IsAppBase == true && f.IsMatchingFilePresent == false)
                .Select(f => f.FilePath!)
                .ToArray();

            arrAppFiles = compareFolders.clnFileDetails!
                .Where(f => f.IsAppBase == false && f.IsMatchingFilePresent == false)
                .Select(f => f.FilePath!)
                .ToArray();

            arrIdenticalFiles = compareFolders.clnFileDetails!
                .Where(f => f.IsAppBase == false && f.IsMatchingFilePresent == true && f.IsIdentical == true)
                .Select(f => f.FilePath!)
                .ToArray();

            arrNonIdenticalFiles = compareFolders.clnFileDetails!
                .Where(f => f.IsAppBase == false && f.IsMatchingFilePresent == true && f.IsIdentical == false)
                .Select(f => f.FilePath!)
                .ToArray();
        }
        private void lnkTotalFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblHeading.Text = lblTotalFiles.Text;

            lstResults.Items.Clear();
            lstResults.Items.AddRange(arrTotalFiles!);

            btnExportFile.Visible = false;
            btnExportAll.Visible = false;

            lblCount.Visible = false;
            btnExportSearchResults.Visible = false;
        }

        private void lnkAppBaseFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblHeading.Text = lblAppBaseFiles.Text;

            lstResults.Items.Clear();
            lstResults.Items.AddRange(arrAppBaseFiles!);

            btnExportFile.Visible = false;
            btnExportAll.Visible = false;

            lblCount.Visible = false;
            btnExportSearchResults.Visible = false;
        }

        private void lnkAppFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblHeading.Text = lblAppFiles.Text;

            lstResults.Items.Clear();
            lstResults.Items.AddRange(arrAppFiles!);

            btnExportFile.Visible = false;
            btnExportAll.Visible = false;

            lblCount.Visible = false;
            btnExportSearchResults.Visible = false;
        }

        private void lnkIdenticalFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblHeading.Text = lblIdenticalFiles.Text;

            lstResults.Items.Clear();
            lstResults.Items.AddRange(arrIdenticalFiles!);

            btnExportFile.Visible = false;
            btnExportAll.Visible = false;

            lblCount.Visible = false;
            btnExportSearchResults.Visible = false;
        }

        private void lnkNonIdenticalFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblHeading.Text = lblNonIdenticalFiles.Text;

            lstResults.Items.Clear();
            lstResults.Items.AddRange(arrNonIdenticalFiles!);

            if (arrNonIdenticalFiles!.Length > 0)
            {
                btnExportFile.Visible = true;
                btnExportAll.Visible = true;
            }

            lblCount.Visible = false;
            btnExportSearchResults.Visible = false;
        }

        FileDetails? FileDetail;
        private void btnExportFile_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedItem != null)
            {
                using (FileStream fs = new FileStream(compareFolders.exportFilePath, FileMode.Truncate)) { }

                FileDetail = compareFolders.clnFileDetails!.First(f => f.FilePath == lstResults.SelectedItem.ToString());

                compareFolders.LineDifferences_ExportToTextFile(FileDetail.FileRelativePath!);

                MessageBox.Show($"File:\n{FileDetail.FilePath}\n\nResults exported to:\n{compareFolders.exportFilePath}", "Export complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select the folder you'd like to export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(compareFolders.exportFilePath, FileMode.Truncate)) { }
            compareFolders.LineDifferences_ExportAllToTextFile();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                lstResults.Items.Clear();

                if (lblHeading.Text == lblTotalFiles.Text)
                {
                    lstResults.Items.AddRange(arrTotalFiles!.Where(f => f.Contains(txtSearch.Text)).ToArray());
                }

                if (lblHeading.Text == lblAppBaseFiles.Text)
                {
                    lstResults.Items.AddRange(arrAppBaseFiles!.Where(f => f.Contains(txtSearch.Text)).ToArray());
                }

                if (lblHeading.Text == lblAppFiles.Text)
                {
                    lstResults.Items.AddRange(arrAppFiles!.Where(f => f.Contains(txtSearch.Text)).ToArray());
                }

                if (lblHeading.Text == lblIdenticalFiles.Text)
                {
                    lstResults.Items.AddRange(arrIdenticalFiles!.Where(f => f.Contains(txtSearch.Text)).ToArray());
                }

                if (lblHeading.Text == lblNonIdenticalFiles.Text)
                {
                    lstResults.Items.AddRange(arrNonIdenticalFiles!.Where(f => f.Contains(txtSearch.Text)).ToArray());
                    btnExportSearchResults.Visible = true;
                }

                lblCount.Visible = true;
                lblCount.Text = $"({lstResults.Items.Count})";
                
            }
            else
            {
                MessageBox.Show("Please enter the file name or path you'd like to search for.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportSearchResults_Click(object sender, EventArgs e)
        {
            if (lstResults.Items.Count > 0)
            {
                using (FileStream fs = new FileStream(compareFolders.exportFilePath, FileMode.Truncate)) { }

                foreach (string ResultsFile in lstResults.Items)
                {
                    FileDetail = compareFolders.clnFileDetails!.First(f => f.FilePath == ResultsFile);

                    compareFolders.LineDifferences_ExportToTextFile(FileDetail.FileRelativePath!);
                }

                //foreach(string ResultsFile in lstResults.Items)
                //{
                //    compareFolders.LineDifferences_ExportToTextFile(ResultsFile.Substring(compareFolders.appPath!.Length));
                //}

                MessageBox.Show($"File differences of the Search \"{txtSearch.Text}\" have been exported to:\n{compareFolders.exportFilePath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("There are no file differences to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
