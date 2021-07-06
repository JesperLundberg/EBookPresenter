using System;
using System.Collections.Generic;
using EBookPresenter.Models;

namespace EBookPresenter.Tests.TestHelpers
{
    public class CreateBookObjects
    {
        public static IEnumerable<EBook> GetUnorderedEBookList()
        {
            return new List<EBook>
            {
                new EBook {Title = "Title4", Path = "/some/path/", CreatedDate = DateTime.Now.AddDays(-1)},
                new EBook {Title = "Title2", Path = "/some/path/1", CreatedDate = DateTime.Now.AddDays(-111)},
                new EBook {Title = "Title1", Path = "/some/path/1", CreatedDate = DateTime.Now.AddDays(-10)},
                new EBook {Title = "Title3", Path = "/some/path/2/3", CreatedDate = DateTime.Now},
            };
        }
    }
}