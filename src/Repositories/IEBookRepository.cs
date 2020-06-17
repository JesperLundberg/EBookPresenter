using System.Collections.Generic;
using EBookPresenter.Models;

namespace EBookPresenter.Repositories
{
    public interface IEBookRepository
    {
        IEnumerable<EBook> GetAllEbooks();
    }
}