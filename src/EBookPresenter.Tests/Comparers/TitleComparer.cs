#nullable enable
using System;
using System.Collections;

using EBookPresenter.Models;

namespace EBookPresenter.Tests.Comparers;

public class TitleComparer : IComparer
{
    public int Compare(object? x,
        object? y)
    {
        if (!(x is EBook book1) || !(y is EBook book2))
        {
            throw new ArgumentException("Both values must be of type EBook");
        }

        if (book1.Title == book2.Title)
        {
            return 0;
        }

        return -1;
    }
}