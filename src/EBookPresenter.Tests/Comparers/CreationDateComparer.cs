#nullable enable
using System;
using System.Collections;
using EBookPresenter.Models;

namespace EBookPresenter.Tests.Comparers;

public class CreationDateComparer : IComparer
{
    public int Compare(object? x, object? y)
    {
        if (x is not EBook book1 || y is not EBook book2)
        {
            throw new ArgumentException("Both values must be of type EBook");
        }

        if (book1.CreatedDate == book2.CreatedDate)
        {
            return 0;
        }

        if (book1.CreatedDate < book2.CreatedDate)
        {
            return -1;
        }

        return 1;
    }
}
