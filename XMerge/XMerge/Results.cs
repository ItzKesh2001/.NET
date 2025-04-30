using System.Diagnostics;
using System.Text;

namespace XMerge
{
    public partial class Results : Form
    {
        CompareFolders compareFolders;

        public Results(CompareFolders compareFolders)
        {
            InitializeComponent();
            this.compareFolders = compareFolders;
            AssignFormComponents();
        }

        private void AssignFormComponents()
        {
            lnkTotalFiles.Text = compareFolders.arrTotalFiles!.Length.ToString();
            lnkAppBaseFiles.Text = compareFolders.arrAppBaseFiles!.Length.ToString();
            lnkAppFiles.Text = compareFolders.arrAppFiles!.Length.ToString();
            lnkIdenticalFiles.Text = compareFolders.arrIdenticalFiles!.Length.ToString();
            lnkNonIdenticalFiles.Text = compareFolders.arrNonIdenticalFiles!.Length.ToString();
        }

        private void lnkTotalFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblHeading.Text = lblTotalFiles.Text;
            lstResults.Items.Clear();
            lstResults.Items.AddRange(compareFolders.arrTotalFiles!);
            btnExportFile.Visible = false;
            btnExportAll.Visible = false;
        }

        private void lnkAppBaseFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblHeading.Text = lblAppBaseFiles.Text;
            lstResults.Items.Clear();
            lstResults.Items.AddRange(compareFolders.arrAppBaseFiles!);
            btnExportFile.Visible = false;
            btnExportAll.Visible = false;
        }

        private void lnkAppFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblHeading.Text = lblAppFiles.Text;
            lstResults.Items.Clear();
            lstResults.Items.AddRange(compareFolders.arrAppFiles!);
            btnExportFile.Visible = false;
            btnExportAll.Visible = false;
        }

        private void lnkIdenticalFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblHeading.Text = lblIdenticalFiles.Text;
            lstResults.Items.Clear();
            lstResults.Items.AddRange(compareFolders.arrIdenticalFiles!);
            btnExportFile.Visible = false;
            btnExportAll.Visible = false;
        }

        private void lnkNonIdenticalFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblHeading.Text = lblNonIdenticalFiles.Text;
            lstResults.Items.Clear();
            lstResults.Items.AddRange(compareFolders.arrNonIdenticalFiles!);
            if (lnkNonIdenticalFiles.Text != "0") //compareFolders.arrNonIdenticalFiles!.Length > 0 ?
            {
                btnExportFile.Visible = true;
                btnExportAll.Visible = true;
            }
        }

        string? appBaseFile = null;
        private void btnExportFile_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedItem != null)
            {
                using (FileStream fs = new FileStream(compareFolders.exportFilePath, FileMode.Truncate)) { }

                appBaseFile = lstResults.SelectedItem.ToString();
                compareFolders.LineDifferences_ExportToTextFile(appBaseFile!);
                MessageBox.Show($"File:\n{appBaseFile}\n\nResults exported to:\n{compareFolders.exportFilePath}", "Export complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kindly select the folder you'd like to export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            compareFolders.LineDifferences_ExportAllToTextFile();
        }
    }
}
