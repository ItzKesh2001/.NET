

namespace XMerge
{
    public class FileDetails
    {
        public string FilePath { get; private set; }
        public string FileRelativePath { get; private set; }
        public long FileSize { get; private set; }
        public bool IsMatchingFilePresent { get; private set; }
        public bool IsIdentical { get; private set; }
        public bool IsAppBase { get; private set; }


        public FileDetails(string filePath, string fileRelativePath, long fileSize, bool isAppBase, bool isMatchingFilePresent, bool isIdentical)
        {
            FilePath = filePath;
            FileRelativePath = fileRelativePath;
            FileSize = fileSize;
            IsMatchingFilePresent = isMatchingFilePresent;
            IsIdentical = isIdentical;
            IsAppBase = isAppBase;
        }
    }
}
