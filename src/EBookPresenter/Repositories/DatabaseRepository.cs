using System.Collections.Generic;
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
        }
    }
}