using System.Collections.Generic;
using System.IO;
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
            var ebooks = new List<EBook>();
            
            var folderToRead = Configuration.GetSection("AppSettings").GetSection("FolderToRead").Value;

            var files = Directory.GetFiles(folderToRead);

            foreach (var file in files)
            {
                ebooks.Add(new EBook{Title = Path.GetFileName(file), Path = file});
            }
            
            return ebooks;
        }
    }
}