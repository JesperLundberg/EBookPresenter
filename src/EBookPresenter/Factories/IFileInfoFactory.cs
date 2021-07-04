using EBookPresenter.Wrappers;

namespace EBookPresenter.Factories
{
    public interface IFileInfoFactory
    {
        FileInfoWrapper Create(string path);
    }
}