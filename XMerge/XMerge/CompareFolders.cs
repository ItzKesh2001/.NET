using System.Text;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Diagnostics;

namespace XMerge
{
    public class CompareFolders
    {
        public string? ComparisonName {  get; set; }
        public string? appBasePath { get; set; }
        public string? appPath { get; set; }
        List<CheckBox>? Filters { get; set; }
        public CompareFolders(string ComparisonName, string appBasePath, string appPath, List<CheckBox> Filters) 
        { 
            this.ComparisonName = ComparisonName;
            this.appBasePath = appBasePath;
            this.appPath = appPath;
            this.Filters = Filters;
        }

        public string exportFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ComparisonResults.txt");

        Collection<FileDetails>? clnFileDetails;
        

        // paths of the parent folders
        

        // Hashsets for using Contains
        HashSet<string>? appBaseFolders;
        HashSet<string>? appBaseFiles;
        HashSet<string>? commonFiles;

        // bools for file differentiation
        bool IsAppBase, IsMatchingPresent, IsIdentical;

        // arrays for storing file information
        public string[]? arrTotalFiles { get; set; }
        public string[]? arrAppBaseFiles { get; set; }
        public string[]? arrAppFiles { get; set; }
        public string[]? arrIdenticalFiles { get; set; }
        public string[]? arrNonIdenticalFiles { get; set; }




        /// <summary>
        /// Method to compare 2 folders
        /// </summary>
        /// <param name="tvAppBase"></param>
        /// <param name="tvApp"></param>
        public bool ComparingFolders(TreeView tvAppBase, TreeView tvApp)
        {
            clnFileDetails = new Collection<FileDetails>(); //New Comparison
            
            CompareSelectedFolders(tvAppBase, true); // IsAppBase = true
            CompareSelectedFolders(tvApp, false); // IsAppBase = false

            if (clnFileDetails.Count > 0)
            {
                AssignArrays();
                return true;
            }
            else
            {
                return false;
            }

        }

        private void CompareSelectedFolders(TreeView tvTree, bool IsAppBase)
        {
            if (IsAppBase)
            {
                appBaseFolders = new HashSet<string>();
            }
            // checking each node if it's checked or not
            foreach (TreeNode trnNode in tvTree.Nodes)
            {
                GetCheckedNodes(trnNode, IsAppBase);
            }
        }

        string? relativeFolderPath;
        private void GetCheckedNodes(TreeNode trnNode, bool IsAppBase)
        {
            if (trnNode.Checked)
            {
                relativeFolderPath = trnNode.Tag.ToString()!;

                // IsAppBase = true -> retrieving checked folders in AppBase
                if (IsAppBase)
                {
                    relativeFolderPath = relativeFolderPath.Substring(appBasePath!.Length);

                    appBaseFolders!.Add(relativeFolderPath);

                }

                else // is App -> comparing checked folders in App with AppBase 
                {
                    relativeFolderPath = relativeFolderPath.Substring(appPath!.Length);
                    if (appBaseFolders!.Contains(relativeFolderPath))
                    {
                        ComparingCheckedFolders(relativeFolderPath); // Compare both folders if match is found
                    }
                }
            }
            // recursive method for checking subfolders of the current folder
            foreach (TreeNode trnChild in trnNode.Nodes)
            {
                GetCheckedNodes(trnChild, IsAppBase);
            }
        }

        string? appBaseFolder = null;
        string? appFolder = null;
        private void ComparingCheckedFolders(string CommonFolderPath)
        {
            // if "" is passed, then parent folders are selected
            if (CommonFolderPath.Length == 0)
            {
                appBaseFolder = appBasePath;
                appFolder = appPath;
            }

            else // retrieve full paths of the folders in their respective folders
            {
                appBaseFolder = appBasePath + CommonFolderPath;
                appFolder = appPath + CommonFolderPath;
            }

            appBaseFiles = new HashSet<string>();
            commonFiles = new HashSet<string>();

                foreach(CheckBox checkBox in Filters!)
                {
                    if(checkBox.Checked)
                    {
                        ComparingFolderFiles(appBaseFolder!, appFolder!, checkBox.Text);

                    }
                }        
        }

        private void ComparingFolderFiles(string appBaseFolder, string appFolder, string Filter)
        {
            foreach (string fileA in Directory.GetFiles(appBaseFolder!, "*" + Filter, SearchOption.AllDirectories))
            {
                appBaseFiles!.Add(fileA.Substring(appBasePath!.Length)); // relative paths
            }

            string? RelativePathB = null;

            foreach (string fileB in Directory.GetFiles(appFolder!, "*" + Filter, SearchOption.AllDirectories))
            {
                RelativePathB = fileB.Substring(appPath!.Length);
                // common files
                if (appBaseFiles!.Contains(RelativePathB))
                {
                    CompareFiles(RelativePathB);

                    commonFiles!.Add(RelativePathB); // required for getting files in AppBase only
                }
                // not in AppBase -> in App only
                else
                {
                    FileInfo file = new FileInfo(fileB);

                    IsAppBase = false;
                    IsMatchingPresent = false;
                    IsIdentical = false;

                    FileDetails NewFile = new FileDetails(fileB, RelativePathB, file.Length, IsAppBase, IsMatchingPresent, IsIdentical);
                    clnFileDetails!.Add(NewFile);
                }
            }


            // All AppBase files - common files = AppBase only files
            foreach (string RelativePathA in appBaseFiles!)
            {
                if (!commonFiles!.Contains(RelativePathA))
                {

                    FileInfo file = new FileInfo(appBasePath + RelativePathA);

                    IsAppBase = true;
                    IsMatchingPresent = false;
                    IsIdentical = false;

                    FileDetails NewFile = new FileDetails(appBasePath + RelativePathA, RelativePathA, file.Length, IsAppBase, IsMatchingPresent, IsIdentical);
                    clnFileDetails!.Add(NewFile);
                }
            }
        }


        bool blnIsDifferent;
        private void CompareFiles(string relativePath)
        {
            blnIsDifferent = false;

            // File Size comparison
            // retrieving file info

            string fullPathA = appBasePath + relativePath;
            string fullPathB = appPath + relativePath;

            FileInfo FileA = new FileInfo(fullPathA);
            FileInfo FileB = new FileInfo(fullPathB);

            // check if files are equal in size
            if (FileA.Length != FileB.Length)
            {
                blnIsDifferent = true;
            }

            // if they're equal in size, check if they're different
            //Byte by Byte comparison
            else
            {
                blnIsDifferent = Compare_BytebyByte(fullPathA, fullPathB);
            }


            IsMatchingPresent = true;

            if (blnIsDifferent) // Files are not identical
            {
                IsIdentical = false;

                // appbase file
                IsAppBase = true;

                FileDetails appBaseFile = new FileDetails(fullPathA, relativePath, FileA.Length, IsAppBase, IsMatchingPresent, IsIdentical);
                clnFileDetails!.Add(appBaseFile);

                // app file 
                IsAppBase = false;

                FileDetails appFile = new FileDetails(fullPathB, relativePath, FileB.Length, IsAppBase, IsMatchingPresent, IsIdentical);
                clnFileDetails.Add(appFile);
            }

            else // Files are identical
            {
                IsIdentical = true;

                // appbase 
                IsAppBase = true;

                FileDetails appBaseFile = new FileDetails(fullPathA, relativePath, FileA.Length, IsAppBase, IsMatchingPresent, IsIdentical);
                clnFileDetails!.Add(appBaseFile);

                // app file
                IsAppBase = false;

                FileDetails appFile = new FileDetails(fullPathB, relativePath, FileB.Length, IsAppBase, IsMatchingPresent, IsIdentical);
                clnFileDetails.Add(appFile);
            }
        }

        private bool Compare_BytebyByte(string fileA, string fileB)
        {
            bool blnIsDifferent = false;

            int intByteA, intByteB;

            using (FileStream fsA = new FileStream(fileA, FileMode.Open, FileAccess.Read))
            using (FileStream fsB = new FileStream(fileB, FileMode.Open, FileAccess.Read))
            {
                // read first byte to enter the loop
                intByteA = fsA.ReadByte();
                intByteB = fsB.ReadByte();

                while (intByteA != -1 && intByteB != -1)
                {

                    // Compare ByteA and ByteB
                    if (intByteA != intByteB)
                    {
                        blnIsDifferent = true;
                        break;
                    }

                    // Read next bytes
                    intByteA = fsA.ReadByte();
                    intByteB = fsB.ReadByte();
                }

            }

            return blnIsDifferent;
        }

        private void AssignArrays()
        {
            arrTotalFiles = clnFileDetails!
                .Select(f => f.FilePath!)
                .ToArray();

            arrAppBaseFiles = clnFileDetails!
                .Where(f => f.IsAppBase == true && f.IsMatchingFilePresent == false)
                .Select(f => f.FilePath!)
                .ToArray();

            arrAppFiles = clnFileDetails!
                .Where(f => f.IsAppBase == false && f.IsMatchingFilePresent == false)
                .Select(f => f.FilePath!)
                .ToArray();

            arrIdenticalFiles = clnFileDetails!
                .Where(f => f.IsAppBase == false && f.IsMatchingFilePresent == true && f.IsIdentical == true)
                .Select(f => f.FilePath!)
                .ToArray();

            arrNonIdenticalFiles = clnFileDetails!
                .Where(f => f.IsAppBase == false && f.IsMatchingFilePresent == true && f.IsIdentical == false)
                .Select(f => f.FilePath!)
                .ToArray();
        }

        public void ExportResults()
        {
            Results results = new Results(this);
            results.Show();
        }

        public void LineDifferences_ExportAllToTextFile()
        {
            using (FileStream fs = new FileStream(exportFilePath, FileMode.Truncate)) { }

            foreach (string appBaseFile in arrNonIdenticalFiles!)
            {
                LineDifferences_ExportToTextFile(appBaseFile);
            }

            MessageBox.Show($"Differences of all files have been exported to:\n{exportFilePath}", "Export complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        string? RelativePath;
        public void LineDifferences_ExportToTextFile(string FullPath)
        {
            RelativePath = FullPath.Substring(appPath!.Length);
            using (StreamWriter writer = new StreamWriter(exportFilePath, append: true))
            {
                StringBuilder sbRemovedLines = new StringBuilder();
                StringBuilder sbAddedLines = new StringBuilder();

                string? lineA, lineB;

                using (StreamReader fileA = new StreamReader(appBasePath + RelativePath))
                using (StreamReader fileB = new StreamReader(appPath + RelativePath))
                {
                    lineA = fileA.ReadLine();
                    lineB = fileB.ReadLine();
                    while (lineA != null || lineB != null)
                    {
                        // stop if both files have reached the end
                        if (lineA == null && lineB == null) break;


                        // lines are equal, skip to next line
                        if (lineA == lineB)
                        {
                            lineA = fileA.ReadLine();
                            lineB = fileB.ReadLine();
                            continue;
                        }

                        // lines are not equal, add to removedlines/addedlines
                        if (lineB == null)
                            sbRemovedLines.Append("  - " + lineA + "\n");
                        else if (lineA == null)
                            sbAddedLines.Append("  + " + lineB + "\n");
                        else
                        {
                            sbRemovedLines.Append("  - " + lineA + "\n");
                            sbAddedLines.Append("  + " + lineB + "\n");
                        }

                        // read next lines
                        lineA = fileA.ReadLine();
                        lineB = fileB.ReadLine();
                    }
                }

                writer.WriteLine(appPath + RelativePath);
                writer.WriteLine("\nRemoved lines:");
                writer.WriteLine(sbRemovedLines + "\n");
                writer.WriteLine("Added lines:");
                writer.WriteLine(sbAddedLines + "\n\n");
            }
        }

        ///// <summary>
        ///// Exporting differences in content of both folders
        ///// </summary>
        //public void LineDifferences_ExportToExcel()
        //{

        //    string strExcelPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        //                                        ConfigurationManager.AppSettings["ExcelFileName"] ?? "ComparisonResults.xlsx");
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    // Creating an Excel package
        //    if(strNonIdenticalFiles != null)
        //    using (ExcelPackage exlpExcel = new ExcelPackage())
        //    {
        //        // Creating a worksheet and setting headers
        //        var varWS = exlpExcel.Workbook.Worksheets.Add("Comparison Results");
        //        varWS.Cells[1, 1].Value = "File Path";
        //        varWS.Cells[1, 2].Value = "Removed Lines";
        //        varWS.Cells[1, 3].Value = "Added Lines";
        //        varWS.Row(1).Style.Font.Bold = true;

        //        int intRow = 2;

        //        foreach (string file in strNonIdenticalFiles.ToString().Split(new[] { '\n' }))
        //        {
        //            StringBuilder sbRemovedLines = new StringBuilder();
        //            StringBuilder sbAddedLines = new StringBuilder();

        //            string? strLineA, strLineB;

        //            using (StreamReader fileA = new StreamReader((appBasePath + file.Substring(appPath.Length)).Trim()))
        //            using (StreamReader fileB = new StreamReader(file.Trim()))
        //            {
        //                strLineA = fileA.ReadLine();
        //                strLineB = fileB.ReadLine();
        //                while (strLineA != null || strLineB != null)
        //                {
        //                    // stop if both files have reached the end
        //                    if (strLineA == null && strLineB == null) break;

        //                    // lines are equal, skip to next line
        //                    if (strLineA == strLineB)
        //                    {
        //                        strLineA = fileA.ReadLine();
        //                        strLineB = fileB.ReadLine();
        //                        continue;
        //                    }

        //                    // lines are not equal, add to removedlines/addedlines
        //                    if (strLineB == null)
        //                        sbRemovedLines.AppendLine("  - " + strLineA);
        //                    else if (strLineA == null)
        //                        sbAddedLines.AppendLine("  + " + strLineB);
        //                    else
        //                    {
        //                        sbRemovedLines.AppendLine("  - " + strLineA);
        //                        sbAddedLines.AppendLine("  + " + strLineB);
        //                    }

        //                    // read next lines
        //                    strLineA = fileA.ReadLine();
        //                    strLineB = fileB.ReadLine();
        //                }
        //            }

        //            varWS.Cells[intRow, 1].Value = file;
        //            varWS.Cells[intRow, 2].Value = sbRemovedLines.ToString();
        //            varWS.Cells[intRow, 3].Value = sbAddedLines.ToString();

        //            intRow++;

        //        }
        //        // Saving the Excel file
        //        File.WriteAllBytes(strExcelPath, exlpExcel.GetAsByteArray());
        //    }
        //    MessageBox.Show($"Results exported to:\n{strExcelPath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
    }
}
