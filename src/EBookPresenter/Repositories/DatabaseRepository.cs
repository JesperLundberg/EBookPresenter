using System.Collections.Generic;
using System.Threading.Tasks;
using EBookPresenter.Context;
using EBookPresenter.Models;

namespace EBookPresenter.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private EBookContext EBookContext { get; }

        public DatabaseRepository(EBookContext eBookContext)
        {
            EBookContext = eBookContext;
        }
        
        public async void AddBooksAsync(IEnumerable<EBook> eBooks)
        {
            // TODO: Verify indata

            await EBookContext.AddAsync(eBooks);
            await EBookContext.SaveChangesAsync();
        }

        public async Task<bool> ClearBooksAsync()
        {
            var allEbooks = EBookContext.EBooks;
            
            EBookContext.RemoveRange(allEbooks);
            var changedRows = await EBookContext.SaveChangesAsync();

            return changedRows != 0;
        }
    }
}