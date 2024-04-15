namespace EBookPresenter.Wrappers;

public class FileInfoWrapper(string path) : IFileInfoWrapper
{
    private FileInfo FileInfo { get; } = new(path);

    public DateTime CreationTime => FileInfo.CreationTime;
}
