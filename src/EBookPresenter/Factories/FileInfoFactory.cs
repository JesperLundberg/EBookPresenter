using EBookPresenter.Wrappers;

namespace EBookPresenter.Factories
{
    public class FileInfoFactory : IFileInfoFactory
    {
        public FileInfoWrapper Create(string path)
        {
            return new FileInfoWrapper(path);
        }
    }
}