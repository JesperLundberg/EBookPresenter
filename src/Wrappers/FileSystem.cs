using System.IO;

namespace EBookPresenter.Wrappers
{
    public class FileSystem : IFileSystem
    {
        public string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }

        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}