namespace XMerge
{
    partial class Results
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            lnkNonIdenticalFiles = new LinkLabel();
            lnkIdenticalFiles = new LinkLabel();
            lnkAppFiles = new LinkLabel();
            lnkAppBaseFiles = new LinkLabel();
            lnkTotalFiles = new LinkLabel();
            lblNonIdenticalFiles = new Label();
            lblIdenticalFiles = new Label();
            lblAppFiles = new Label();
            lblAppBaseFiles = new Label();
            lblTotalFiles = new Label();
            splitContainer2 = new SplitContainer();
            btnExportAll = new Button();
            btnExportFile = new Button();
            lblHeading = new Label();
            lstResults = new ListBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lnkNonIdenticalFiles);
            splitContainer1.Panel1.Controls.Add(lnkIdenticalFiles);
            splitContainer1.Panel1.Controls.Add(lnkAppFiles);
            splitContainer1.Panel1.Controls.Add(lnkAppBaseFiles);
            splitContainer1.Panel1.Controls.Add(lnkTotalFiles);
            splitContainer1.Panel1.Controls.Add(lblNonIdenticalFiles);
            splitContainer1.Panel1.Controls.Add(lblIdenticalFiles);
            splitContainer1.Panel1.Controls.Add(lblAppFiles);
            splitContainer1.Panel1.Controls.Add(lblAppBaseFiles);
            splitContainer1.Panel1.Controls.Add(lblTotalFiles);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1810, 742);
            splitContainer1.SplitterDistance = 468;
            splitContainer1.TabIndex = 0;
            // 
            // lnkNonIdenticalFiles
            // 
            lnkNonIdenticalFiles.AutoSize = true;
            lnkNonIdenticalFiles.Font = new Font("Segoe UI", 11F);
            lnkNonIdenticalFiles.Location = new Point(309, 199);
            lnkNonIdenticalFiles.Name = "lnkNonIdenticalFiles";
            lnkNonIdenticalFiles.Size = new Size(22, 25);
            lnkNonIdenticalFiles.TabIndex = 9;
            lnkNonIdenticalFiles.TabStop = true;
            lnkNonIdenticalFiles.Text = "0";
            lnkNonIdenticalFiles.LinkClicked += lnkNonIdenticalFiles_LinkClicked;
            // 
            // lnkIdenticalFiles
            // 
            lnkIdenticalFiles.AutoSize = true;
            lnkIdenticalFiles.Font = new Font("Segoe UI", 11F);
            lnkIdenticalFiles.Location = new Point(309, 156);
            lnkIdenticalFiles.Name = "lnkIdenticalFiles";
            lnkIdenticalFiles.Size = new Size(22, 25);
            lnkIdenticalFiles.TabIndex = 8;
            lnkIdenticalFiles.TabStop = true;
            lnkIdenticalFiles.Text = "0";
            lnkIdenticalFiles.LinkClicked += lnkIdenticalFiles_LinkClicked;
            // 
            // lnkAppFiles
            // 
            lnkAppFiles.AutoSize = true;
            lnkAppFiles.Font = new Font("Segoe UI", 11F);
            lnkAppFiles.Location = new Point(309, 110);
            lnkAppFiles.Name = "lnkAppFiles";
            lnkAppFiles.Size = new Size(22, 25);
            lnkAppFiles.TabIndex = 7;
            lnkAppFiles.TabStop = true;
            lnkAppFiles.Text = "0";
            lnkAppFiles.LinkClicked += lnkAppFiles_LinkClicked;
            // 
            // lnkAppBaseFiles
            // 
            lnkAppBaseFiles.AutoSize = true;
            lnkAppBaseFiles.Font = new Font("Segoe UI", 11F);
            lnkAppBaseFiles.Location = new Point(309, 68);
            lnkAppBaseFiles.Name = "lnkAppBaseFiles";
            lnkAppBaseFiles.Size = new Size(22, 25);
            lnkAppBaseFiles.TabIndex = 6;
            lnkAppBaseFiles.TabStop = true;
            lnkAppBaseFiles.Text = "0";
            lnkAppBaseFiles.LinkClicked += lnkAppBaseFiles_LinkClicked;
            // 
            // lnkTotalFiles
            // 
            lnkTotalFiles.AutoSize = true;
            lnkTotalFiles.Font = new Font("Segoe UI", 11F);
            lnkTotalFiles.Location = new Point(309, 26);
            lnkTotalFiles.Name = "lnkTotalFiles";
            lnkTotalFiles.Size = new Size(22, 25);
            lnkTotalFiles.TabIndex = 5;
            lnkTotalFiles.TabStop = true;
            lnkTotalFiles.Text = "0";
            lnkTotalFiles.LinkClicked += lnkTotalFiles_LinkClicked;
            // 
            // lblNonIdenticalFiles
            // 
            lblNonIdenticalFiles.AutoSize = true;
            lblNonIdenticalFiles.Font = new Font("Segoe UI", 11F);
            lblNonIdenticalFiles.Location = new Point(37, 199);
            lblNonIdenticalFiles.Name = "lblNonIdenticalFiles";
            lblNonIdenticalFiles.Size = new Size(170, 25);
            lblNonIdenticalFiles.TabIndex = 4;
            lblNonIdenticalFiles.Text = "Non-identical Files";
            // 
            // lblIdenticalFiles
            // 
            lblIdenticalFiles.AutoSize = true;
            lblIdenticalFiles.Font = new Font("Segoe UI", 11F);
            lblIdenticalFiles.Location = new Point(37, 156);
            lblIdenticalFiles.Name = "lblIdenticalFiles";
            lblIdenticalFiles.Size = new Size(126, 25);
            lblIdenticalFiles.TabIndex = 3;
            lblIdenticalFiles.Text = "Identical Files";
            // 
            // lblAppFiles
            // 
            lblAppFiles.AutoSize = true;
            lblAppFiles.Font = new Font("Segoe UI", 11F);
            lblAppFiles.Location = new Point(37, 110);
            lblAppFiles.Name = "lblAppFiles";
            lblAppFiles.Size = new Size(150, 25);
            lblAppFiles.TabIndex = 2;
            lblAppFiles.Text = "Files in App only";
            // 
            // lblAppBaseFiles
            // 
            lblAppBaseFiles.AutoSize = true;
            lblAppBaseFiles.Font = new Font("Segoe UI", 11F);
            lblAppBaseFiles.Location = new Point(37, 68);
            lblAppBaseFiles.Name = "lblAppBaseFiles";
            lblAppBaseFiles.Size = new Size(189, 25);
            lblAppBaseFiles.TabIndex = 1;
            lblAppBaseFiles.Text = "Files in AppBase only";
            // 
            // lblTotalFiles
            // 
            lblTotalFiles.AutoSize = true;
            lblTotalFiles.Font = new Font("Segoe UI", 11F);
            lblTotalFiles.Location = new Point(37, 26);
            lblTotalFiles.Name = "lblTotalFiles";
            lblTotalFiles.Size = new Size(147, 25);
            lblTotalFiles.TabIndex = 0;
            lblTotalFiles.Text = "Total no. of Files";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(btnExportAll);
            splitContainer2.Panel1.Controls.Add(btnExportFile);
            splitContainer2.Panel1.Controls.Add(lblHeading);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(lstResults);
            splitContainer2.Size = new Size(1338, 742);
            splitContainer2.SplitterDistance = 59;
            splitContainer2.TabIndex = 0;
            // 
            // btnExportAll
            // 
            btnExportAll.Location = new Point(791, 22);
            btnExportAll.Name = "btnExportAll";
            btnExportAll.Size = new Size(94, 29);
            btnExportAll.TabIndex = 2;
            btnExportAll.Text = "Export All";
            btnExportAll.UseVisualStyleBackColor = true;
            btnExportAll.Visible = false;
            btnExportAll.Click += btnExportAll_Click;
            // 
            // btnExportFile
            // 
            btnExportFile.Location = new Point(645, 22);
            btnExportFile.Name = "btnExportFile";
            btnExportFile.Size = new Size(94, 29);
            btnExportFile.TabIndex = 1;
            btnExportFile.Text = "Export File";
            btnExportFile.UseVisualStyleBackColor = true;
            btnExportFile.Visible = false;
            btnExportFile.Click += btnExportFile_Click;
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 11F);
            lblHeading.Location = new Point(16, 26);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(392, 25);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Click the numbers on the left to view their list";
            // 
            // lstResults
            // 
            lstResults.Dock = DockStyle.Fill;
            lstResults.FormattingEnabled = true;
            lstResults.Location = new Point(0, 0);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(1338, 679);
            lstResults.TabIndex = 0;
            // 
            // Results
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1810, 742);
            Controls.Add(splitContainer1);
            Name = "Results";
            Text = "Results";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private LinkLabel lnkNonIdenticalFiles;
        private LinkLabel lnkIdenticalFiles;
        private LinkLabel lnkAppFiles;
        private LinkLabel lnkAppBaseFiles;
        private LinkLabel lnkTotalFiles;
        private Label lblNonIdenticalFiles;
        private Label lblIdenticalFiles;
        private Label lblAppFiles;
        private Label lblAppBaseFiles;
        private Label lblTotalFiles;
        private SplitContainer splitContainer2;
        private Label lblHeading;
        private Button btnExportFile;
        private Button btnExportAll;
        private ListBox lstResults;
    }
}