using EBookPresenter.Wrappers;

namespace EBookPresenter.Factories;

public interface IFileInfoFactory
{
    IFileInfoWrapper Create(string path);
}
