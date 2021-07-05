using EBookPresenter.Factories;
using EBookPresenter.Wrappers;

namespace EBookPresenter.Tests.Fakes
{
    public class FileInfoFactoryFake : IFileInfoFactory
    {
        public IFileInfoWrapper Create(string path)
        {
            return new FileInfoWrapperFake();
        }
    }
}