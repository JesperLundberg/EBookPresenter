using System;

namespace EBookPresenter.Wrappers
{
    public class FileInfoWrapper : IFileInfoWrapper
    {
        private System.IO.FileInfo FInfo { get; }
        
        public FileInfoWrapper(string path)
        {
            FInfo = new System.IO.FileInfo(path);
        }

        public DateTime CreationTime => FInfo.CreationTime;
    }
}