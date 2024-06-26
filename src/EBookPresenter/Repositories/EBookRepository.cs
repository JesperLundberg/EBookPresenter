using EBookPresenter.Factories;
using EBookPresenter.Wrappers;

namespace EBookPresenter.Repositories;

public class EBookRepository(IFileSystem fileSystem, IFileInfoFactory fileInfoFactory)
    : IEBookRepository
{
    private IFileSystem FileSystem { get; } = fileSystem;
    private IFileInfoFactory FileInfoFactory { get; } = fileInfoFactory;

    public IEnumerable<EBook> GetAllEbooks(string folderToRead, string sortOrder)
    {
        var allFiles = GetEbooksRecursive(folderToRead);

        var ebooks = new List<EBook>();

        foreach (var file in allFiles)
        {
            // Change from back slash to front slash as Linux uses the latter and Windows is agnostic
            var fixedString = string.IsNullOrEmpty(file) ? string.Empty : file.Replace('\\', '/');

            var fileInfo = FileInfoFactory.Create(fixedString);

            ebooks.Add(
                new()
                {
                    Title = Path.GetFileName(file),
                    Path = fixedString,
                    CreatedDate = fileInfo.CreationTime
                }
            );
        }

        return OrderBooks(ebooks, sortOrder);
    }

    public IEnumerable<EBook> OrderBooks(IEnumerable<EBook> ebooks, string sortOrder)
    {
        return sortOrder switch
        {
            "creation" => ebooks.OrderByDescending(x => x.CreatedDate),
            "alphabetic" => ebooks.OrderBy(x => x.Title),
            _ => ebooks.OrderBy(x => x.Title)
        };
    }

    public IEnumerable<string> GetEbooksRecursive(string folder)
    {
        if (string.IsNullOrEmpty(folder))
        {
            return new List<string>();
        }

        var directories = FileSystem.GetDirectories(folder);

        var files = FileSystem
            .GetFiles(folder)
            .Where(x => x.EndsWith(".epub") || x.EndsWith(".cbz"))
            .ToList();

        foreach (var directory in directories)
        {
            files.AddRange(GetEbooksRecursive(directory));
        }

        return files;
    }
}
