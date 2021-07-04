namespace EBookPresenter.Wrappers
{
    public interface IFileSystem
    {
        string[] GetDirectories(string path);
        string[] GetFiles(string path);
    }
}