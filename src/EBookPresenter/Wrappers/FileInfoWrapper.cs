namespace EBookPresenter.Wrappers;

public class FileInfoWrapper : IFileInfoWrapper
{
    public FileInfoWrapper(string path)
    {
        FileInfo = new (path);
    }
    private FileInfo FileInfo { get; }

    public DateTime CreationTime => FileInfo.CreationTime;
}
