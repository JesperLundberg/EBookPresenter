using System.Collections.Generic;
using System.IO;
using System.Linq;
using EBookPresenter.Factories;
using EBookPresenter.Models;
using EBookPresenter.Wrappers;
using Microsoft.Extensions.Configuration;

namespace EBookPresenter.Repositories
{
    public class EBookRepository : IEBookRepository
    {
        private IConfiguration Configuration { get; }
        private IFileSystem FileSystem { get; }
        private IFileInfoFactory FileInfoFactory { get; }

        public EBookRepository(IConfiguration configuration, IFileSystem fileSystem, IFileInfoFactory fileInfoFactory)
        {
            Configuration = configuration;
            FileSystem = fileSystem;
            FileInfoFactory = fileInfoFactory;
        }

        public IEnumerable<EBook> GetAllEbooks(string sortOrder)
        {
            var folderToRead = Configuration.GetSection("AppSettings").GetSection("FolderToRead").Value;

            var allFiles = GetEbooksRecursive(folderToRead);

            var ebooks = new List<EBook>();

            foreach (var file in allFiles)
            {
                // Change from back slash to front slash as Linux uses the latter and Windows is agnostic
                var fixedString = string.IsNullOrEmpty(file) ? "" : file.Replace('\\', '/');

                var fileInfo = FileInfoFactory.Create(fixedString);

                ebooks.Add(new EBook
                    {Title = Path.GetFileName(file), Path = fixedString, CreatedDate = fileInfo.CreationTime});
            }

            return OrderBooks(ebooks, sortOrder);
        }

        private static IEnumerable<EBook> OrderBooks(IEnumerable<EBook> ebooks, string sortOrder)
        {
            return sortOrder switch
            {
                "creation" => ebooks.OrderByDescending(x => x.CreatedDate),
                "alphabetic" => ebooks.OrderBy(x => x.Title),
                _ => ebooks.OrderBy(x => x.Title)
            };
        }

        private IEnumerable<string> GetEbooksRecursive(string folder)
        {
            if (string.IsNullOrEmpty(folder))
            {
                return new List<string>();
            }

            var directories = FileSystem.GetDirectories(folder);

            var files = FileSystem.GetFiles(folder).Where(x => x.EndsWith(".epub")).ToList();

            foreach (var directory in directories)
            {
                files.AddRange(GetEbooksRecursive(directory));
            }

            return files;
        }
    }
}