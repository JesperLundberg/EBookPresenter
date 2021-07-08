using System.Collections.Generic;
using EBookPresenter.Models;

namespace EBookPresenter.Repositories
{
    public interface IDatabaseRepository
    {
        void AddBooksAsync(IEnumerable<EBook> eBooks);
    }
}