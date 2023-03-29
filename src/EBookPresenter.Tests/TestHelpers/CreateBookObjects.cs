using System;
using System.Collections.Generic;

using EBookPresenter.Models;

namespace EBookPresenter.Tests.TestHelpers;

public static class CreateBookObjects
{
    public static IEnumerable<EBook> GetUnorderedEBookList()
    {
        return new List<EBook>
        {
            new ()
            {
                Title = "Title4",
                Path = "/some/path/",
                CreatedDate = DateTime.Now.AddDays(-1)
            },
            new ()
            {
                Title = "Title2",
                Path = "/some/path/1",
                CreatedDate = DateTime.Now.AddDays(-111)
            },
            new ()
            {
                Title = "Title1",
                Path = "/some/path/1",
                CreatedDate = DateTime.Now.AddDays(-10)
            },
            new ()
            {
                Title = "Title3",
                Path = "/some/path/2/3",
                CreatedDate = DateTime.Now
            }
        };
    }
}
