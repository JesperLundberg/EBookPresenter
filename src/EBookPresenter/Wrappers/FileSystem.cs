namespace EBookPresenter.Wrappers;

public class FileSystem : IFileSystem
{
    public IEnumerable<string> GetDirectories(string path)
    {
        if (Directory.Exists(path))
        {
            return Directory.GetDirectories(path);
        }

        throw new DirectoryNotFoundException($"No directory found at {path}!");
    }

    public IEnumerable<string> GetFiles(string path)
    {
        if (Directory.Exists(path))
        {
            return Directory.GetFiles(path);
        }

        throw new DirectoryNotFoundException($"No directory found at {path}!");
    }
}
