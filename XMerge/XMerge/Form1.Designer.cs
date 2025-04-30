namespace XMerge
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            chkNS = new CheckBox();
            chkBPMN = new CheckBox();
            chkSQL = new CheckBox();
            chkXML = new CheckBox();
            chkHTML = new CheckBox();
            chkAllFiles = new CheckBox();
            label1 = new Label();
            lblComparisonName = new Label();
            txtComparisonName = new TextBox();
            btnCompare = new Button();
            tvApp = new TreeView();
            tvAppBase = new TreeView();
            btnAppPath = new Button();
            btnAppBasePath = new Button();
            txtAppPath = new TextBox();
            txtAppBasePath = new TextBox();
            lblAppPath = new Label();
            lblAppBasePath = new Label();
            splitContainer2 = new SplitContainer();
            btnDeleteComparison = new Button();
            lblComparisonList = new Label();
            btnViewComparison = new Button();
            lstboxComparisons = new ListBox();
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
            splitContainer1.Panel1.Controls.Add(chkNS);
            splitContainer1.Panel1.Controls.Add(chkBPMN);
            splitContainer1.Panel1.Controls.Add(chkSQL);
            splitContainer1.Panel1.Controls.Add(chkXML);
            splitContainer1.Panel1.Controls.Add(chkHTML);
            splitContainer1.Panel1.Controls.Add(chkAllFiles);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(lblComparisonName);
            splitContainer1.Panel1.Controls.Add(txtComparisonName);
            splitContainer1.Panel1.Controls.Add(btnCompare);
            splitContainer1.Panel1.Controls.Add(tvApp);
            splitContainer1.Panel1.Controls.Add(tvAppBase);
            splitContainer1.Panel1.Controls.Add(btnAppPath);
            splitContainer1.Panel1.Controls.Add(btnAppBasePath);
            splitContainer1.Panel1.Controls.Add(txtAppPath);
            splitContainer1.Panel1.Controls.Add(txtAppBasePath);
            splitContainer1.Panel1.Controls.Add(lblAppPath);
            splitContainer1.Panel1.Controls.Add(lblAppBasePath);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1778, 752);
            splitContainer1.SplitterDistance = 1083;
            splitContainer1.TabIndex = 11;
            // 
            // chkNS
            // 
            chkNS.AutoSize = true;
            chkNS.Checked = true;
            chkNS.CheckState = CheckState.Checked;
            chkNS.Location = new Point(115, 327);
            chkNS.Name = "chkNS";
            chkNS.Size = new Size(48, 24);
            chkNS.TabIndex = 29;
            chkNS.Text = ".ns";
            chkNS.UseVisualStyleBackColor = true;
            // 
            // chkBPMN
            // 
            chkBPMN.AutoSize = true;
            chkBPMN.Checked = true;
            chkBPMN.CheckState = CheckState.Checked;
            chkBPMN.Location = new Point(115, 297);
            chkBPMN.Name = "chkBPMN";
            chkBPMN.Size = new Size(73, 24);
            chkBPMN.TabIndex = 28;
            chkBPMN.Text = ".bpmn";
            chkBPMN.UseVisualStyleBackColor = true;
            // 
            // chkSQL
            // 
            chkSQL.AutoSize = true;
            chkSQL.Checked = true;
            chkSQL.CheckState = CheckState.Checked;
            chkSQL.Location = new Point(115, 267);
            chkSQL.Name = "chkSQL";
            chkSQL.Size = new Size(53, 24);
            chkSQL.TabIndex = 27;
            chkSQL.Text = ".sql";
            chkSQL.UseVisualStyleBackColor = true;
            // 
            // chkXML
            // 
            chkXML.AutoSize = true;
            chkXML.Checked = true;
            chkXML.CheckState = CheckState.Checked;
            chkXML.Location = new Point(115, 237);
            chkXML.Name = "chkXML";
            chkXML.Size = new Size(58, 24);
            chkXML.TabIndex = 26;
            chkXML.Text = ".xml";
            chkXML.UseVisualStyleBackColor = true;
            // 
            // chkHTML
            // 
            chkHTML.AutoSize = true;
            chkHTML.Checked = true;
            chkHTML.CheckState = CheckState.Checked;
            chkHTML.Location = new Point(115, 207);
            chkHTML.Name = "chkHTML";
            chkHTML.Size = new Size(64, 24);
            chkHTML.TabIndex = 25;
            chkHTML.Text = ".html";
            chkHTML.UseVisualStyleBackColor = true;
            // 
            // chkAllFiles
            // 
            chkAllFiles.AutoSize = true;
            chkAllFiles.Checked = true;
            chkAllFiles.CheckState = CheckState.Checked;
            chkAllFiles.Location = new Point(115, 177);
            chkAllFiles.Name = "chkAllFiles";
            chkAllFiles.Size = new Size(82, 24);
            chkAllFiles.TabIndex = 24;
            chkAllFiles.Text = "All Files";
            chkAllFiles.UseVisualStyleBackColor = true;
            chkAllFiles.CheckedChanged += chkAllFiles_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(115, 132);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 23;
            label1.Text = "Filters";
            // 
            // lblComparisonName
            // 
            lblComparisonName.AutoSize = true;
            lblComparisonName.Font = new Font("Segoe UI", 11F);
            lblComparisonName.Location = new Point(270, 675);
            lblComparisonName.Name = "lblComparisonName";
            lblComparisonName.Size = new Size(173, 25);
            lblComparisonName.TabIndex = 22;
            lblComparisonName.Text = "Comparison Name:";
            // 
            // txtComparisonName
            // 
            txtComparisonName.Location = new Point(443, 676);
            txtComparisonName.Name = "txtComparisonName";
            txtComparisonName.Size = new Size(424, 27);
            txtComparisonName.TabIndex = 21;
            // 
            // btnCompare
            // 
            btnCompare.Anchor = AnchorStyles.Top;
            btnCompare.Location = new Point(873, 676);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(94, 29);
            btnCompare.TabIndex = 19;
            btnCompare.Text = "Compare";
            btnCompare.UseVisualStyleBackColor = true;
            btnCompare.Click += btnCompare_Click;
            // 
            // tvApp
            // 
            tvApp.Anchor = AnchorStyles.Top;
            tvApp.Location = new Point(670, 132);
            tvApp.Name = "tvApp";
            tvApp.Size = new Size(297, 507);
            tvApp.TabIndex = 18;
            // 
            // tvAppBase
            // 
            tvAppBase.Anchor = AnchorStyles.Top;
            tvAppBase.Location = new Point(270, 132);
            tvAppBase.Name = "tvAppBase";
            tvAppBase.Size = new Size(297, 507);
            tvAppBase.TabIndex = 17;
            // 
            // btnAppPath
            // 
            btnAppPath.Anchor = AnchorStyles.Top;
            btnAppPath.Location = new Point(873, 67);
            btnAppPath.Name = "btnAppPath";
            btnAppPath.Size = new Size(94, 29);
            btnAppPath.TabIndex = 16;
            btnAppPath.Text = "Browse...";
            btnAppPath.UseVisualStyleBackColor = true;
            btnAppPath.Click += btnAppPath_Click;
            // 
            // btnAppBasePath
            // 
            btnAppBasePath.Anchor = AnchorStyles.Top;
            btnAppBasePath.Location = new Point(873, 11);
            btnAppBasePath.Name = "btnAppBasePath";
            btnAppBasePath.Size = new Size(94, 29);
            btnAppBasePath.TabIndex = 15;
            btnAppBasePath.Text = "Browse...";
            btnAppBasePath.UseVisualStyleBackColor = true;
            btnAppBasePath.Click += btnAppBasePath_Click;
            // 
            // txtAppPath
            // 
            txtAppPath.Anchor = AnchorStyles.Top;
            txtAppPath.BackColor = SystemColors.InactiveBorder;
            txtAppPath.Location = new Point(270, 67);
            txtAppPath.Name = "txtAppPath";
            txtAppPath.ReadOnly = true;
            txtAppPath.Size = new Size(570, 27);
            txtAppPath.TabIndex = 14;
            // 
            // txtAppBasePath
            // 
            txtAppBasePath.Anchor = AnchorStyles.Top;
            txtAppBasePath.BackColor = SystemColors.InactiveBorder;
            txtAppBasePath.Location = new Point(270, 11);
            txtAppBasePath.Name = "txtAppBasePath";
            txtAppBasePath.ReadOnly = true;
            txtAppBasePath.Size = new Size(570, 27);
            txtAppBasePath.TabIndex = 13;
            // 
            // lblAppPath
            // 
            lblAppPath.Anchor = AnchorStyles.Top;
            lblAppPath.AutoSize = true;
            lblAppPath.Font = new Font("Segoe UI", 11F);
            lblAppPath.Location = new Point(154, 65);
            lblAppPath.Name = "lblAppPath";
            lblAppPath.Size = new Size(92, 25);
            lblAppPath.TabIndex = 12;
            lblAppPath.Text = "App Path:";
            // 
            // lblAppBasePath
            // 
            lblAppBasePath.Anchor = AnchorStyles.Top;
            lblAppBasePath.AutoSize = true;
            lblAppBasePath.Font = new Font("Segoe UI", 11F);
            lblAppBasePath.Location = new Point(115, 10);
            lblAppBasePath.Name = "lblAppBasePath";
            lblAppBasePath.Size = new Size(131, 25);
            lblAppBasePath.TabIndex = 11;
            lblAppBasePath.Text = "AppBase Path:";
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
            splitContainer2.Panel1.Controls.Add(btnDeleteComparison);
            splitContainer2.Panel1.Controls.Add(lblComparisonList);
            splitContainer2.Panel1.Controls.Add(btnViewComparison);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(lstboxComparisons);
            splitContainer2.Size = new Size(691, 752);
            splitContainer2.SplitterDistance = 72;
            splitContainer2.TabIndex = 0;
            // 
            // btnDeleteComparison
            // 
            btnDeleteComparison.Location = new Point(585, 23);
            btnDeleteComparison.Name = "btnDeleteComparison";
            btnDeleteComparison.Size = new Size(94, 29);
            btnDeleteComparison.TabIndex = 2;
            btnDeleteComparison.Text = "Delete";
            btnDeleteComparison.UseVisualStyleBackColor = true;
            btnDeleteComparison.Click += btnDeleteComparison_Click;
            // 
            // lblComparisonList
            // 
            lblComparisonList.AutoSize = true;
            lblComparisonList.Font = new Font("Segoe UI", 11F);
            lblComparisonList.Location = new Point(41, 27);
            lblComparisonList.Name = "lblComparisonList";
            lblComparisonList.Size = new Size(147, 25);
            lblComparisonList.TabIndex = 1;
            lblComparisonList.Text = "Comparison List";
            // 
            // btnViewComparison
            // 
            btnViewComparison.Location = new Point(498, 23);
            btnViewComparison.Name = "btnViewComparison";
            btnViewComparison.Size = new Size(81, 29);
            btnViewComparison.TabIndex = 0;
            btnViewComparison.Text = "View";
            btnViewComparison.UseVisualStyleBackColor = true;
            btnViewComparison.Click += btnViewComparison_Click;
            // 
            // lstboxComparisons
            // 
            lstboxComparisons.Dock = DockStyle.Fill;
            lstboxComparisons.FormattingEnabled = true;
            lstboxComparisons.Location = new Point(0, 0);
            lstboxComparisons.Name = "lstboxComparisons";
            lstboxComparisons.Size = new Size(691, 676);
            lstboxComparisons.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1778, 752);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "XMerge";
            WindowState = FormWindowState.Maximized;
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

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private SplitContainer splitContainer1;
        private TextBox txtComparisonName;
        private Button btnCompare;
        private TreeView tvApp;
        private TreeView tvAppBase;
        private Button btnAppPath;
        private Button btnAppBasePath;
        private TextBox txtAppPath;
        private TextBox txtAppBasePath;
        private Label lblAppPath;
        private Label lblAppBasePath;
        private SplitContainer splitContainer2;
        private Button btnViewComparison;
        private Label lblComparisonList;
        private ListBox lstboxComparisons;
        private Button btnDeleteComparison;
        private Label lblComparisonName;
        private Label label1;
        private CheckBox chkHTML;
        private CheckBox chkAllFiles;
        private CheckBox chkNS;
        private CheckBox chkBPMN;
        private CheckBox chkSQL;
        private CheckBox chkXML;
    }
}
