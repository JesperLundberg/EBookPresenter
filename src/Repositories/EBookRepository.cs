using System.Collections.Generic;
using System.IO;
using System.Linq;
using EBookPresenter.Models;
using Microsoft.Extensions.Configuration;

namespace EBookPresenter.Repositories
{
    public class EBookRepository : IEBookRepository
    {
        private IConfiguration Configuration { get; }

        public EBookRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IEnumerable<EBook> GetAllEbooks()
        {
            var folderToRead = Configuration.GetSection("AppSettings").GetSection("FolderToRead").Value;

            var allFiles = GetEbooksRecursive(folderToRead);
            
            var ebooks = new List<EBook>();
            
            foreach (var file in allFiles)
            {
                var fixedString = string.IsNullOrEmpty(file) ? "" : file.Replace('\\', '/');

                var fileInfo = new FileInfo(fixedString);
                
                ebooks.Add(new EBook{Title = Path.GetFileName(file), Path = fixedString, CreatedDate = fileInfo.CreationTime});
            }
                
            return ebooks.OrderBy(x => x.Title);
        }

        private IEnumerable<string> GetEbooksRecursive(string folder)
        {
            if (string.IsNullOrEmpty(folder))
            {
                return new List<string>();
            }

            var directories = Directory.GetDirectories(folder);

            var files = Directory.GetFiles(folder).Where(x => x.EndsWith(".epub")).ToList();
            
            foreach (var directory in directories)
            {
                files.AddRange(GetEbooksRecursive(directory));
            }
            
            return files;
        }
    }
}