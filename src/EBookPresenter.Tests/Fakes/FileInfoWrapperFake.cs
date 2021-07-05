using System;
using EBookPresenter.Wrappers;

namespace EBookPresenter.Tests.Fakes
{
    public class FileInfoWrapperFake : IFileInfoWrapper
    {
        public DateTime CreationTime => new DateTime();
    }
}