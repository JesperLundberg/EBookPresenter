using System;
using EBookPresenter.Wrappers;

namespace EBookPresenter.Tests.Fakes
{
    public class FileSystemFake : IFileSystem
    {
        private static int folderCount;

        public string[] GetDirectories(string path)
        {
            string[] directoriesToReturn;

            switch (folderCount)
            {
                case 0:
                    directoriesToReturn = new[] {"folder1", "folder2", "folder3"};
                    break;
                case 1:
                    directoriesToReturn = new[] {"folder4"};
                    break;
                default:
                    directoriesToReturn = Array.Empty<string>();
                    break;
            }

            folderCount += 1;
            
            return directoriesToReturn;
        }

        public string[] GetFiles(string path)
        {
            string[] filesToReturn;

            switch (folderCount)
            {
                case 1:
                    filesToReturn = new[] {"file1.epub", "file2.epub", "file3.epub"};
                    break;
                case 2:
                    filesToReturn = new[] {"file4.epub"};
                    break;
                case 3:
                    filesToReturn = new[] {"file5.epub", "file6.epub"};
                    break;
                case 4:
                    filesToReturn = new[] {"file7.epub", "file8.epub"};
                    break;
                default:
                    filesToReturn = Array.Empty<string>();
                    break;
            }
            
            return filesToReturn;
        }
    }
}