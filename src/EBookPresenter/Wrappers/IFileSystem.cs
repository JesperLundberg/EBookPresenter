namespace EBookPresenter.Wrappers;

public interface IFileSystem
{
    bool DirectoryExists(string path);

    IEnumerable<string> GetDirectories(string path);

    IEnumerable<string> GetFiles(string path);
}
