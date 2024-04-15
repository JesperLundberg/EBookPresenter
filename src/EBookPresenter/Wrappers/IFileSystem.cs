namespace EBookPresenter.Wrappers;

public interface IFileSystem
{
    IEnumerable<string> GetDirectories(string path);

    IEnumerable<string> GetFiles(string path);
}
