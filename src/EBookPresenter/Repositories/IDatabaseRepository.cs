using System.Collections.Generic;
using System.Threading.Tasks;
using EBookPresenter.Models;

namespace EBookPresenter.Repositories
{
    public interface IDatabaseRepository
    {
        void AddBooksAsync(IEnumerable<EBook> eBooks);
        Task<bool> ClearBooksAsync();
    }
}