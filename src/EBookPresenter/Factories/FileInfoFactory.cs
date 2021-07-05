using EBookPresenter.Wrappers;

namespace EBookPresenter.Factories
{
    public class FileInfoFactory : IFileInfoFactory
    {
        public IFileInfoWrapper Create(string path)
        {
            return new FileInfoWrapper(path);
        }
    }
}