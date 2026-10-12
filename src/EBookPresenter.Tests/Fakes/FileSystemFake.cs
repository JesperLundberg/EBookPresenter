using EBookPresenter.Wrappers;

namespace EBookPresenter.Tests.Fakes;

public class FileSystemFake : IFileSystem
{
    private static readonly Dictionary<string, string[]> _directories = new()
    {
        ["folderDoesntMatter/"] = ["folder1", "folder2", "folder3"],
        ["folderDoesntMatter/folder1"] = ["folder4"],
        ["folderDoesntMatter/folder2"] = [],
        ["folderDoesntMatter/folder3"] = [],
        ["folderDoesntMatter/folder1/folder4"] = [],
    };

    private static readonly Dictionary<string, string[]> _files = new()
    {
        ["folderDoesntMatter/"] = [],
        ["folderDoesntMatter/folder1"] = ["file1.epub", "file2.epub", "file3.epub"],
        ["folderDoesntMatter/folder2"] = ["file4.epub"],
        ["folderDoesntMatter/folder3"] = ["file5.epub", "file6.epub"],
        ["folderDoesntMatter/folder1/folder4"] = ["file7.epub", "file8.epub"],
    };

    public bool DirectoryExists(string path)
    {
        return true;
    }

    public IEnumerable<string> GetDirectories(string path)
    {
        return _directories.TryGetValue(path, out var directories)
            ? directories.Select(d => Path.Combine(path, d))
            : [];
    }

    public IEnumerable<string> GetFiles(string path)
    {
        return _files.TryGetValue(path, out var files) ? files : [];
    }
}
