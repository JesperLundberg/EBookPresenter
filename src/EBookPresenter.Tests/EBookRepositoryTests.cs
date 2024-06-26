using System.Collections.Generic;
using System.Linq;
using EBookPresenter.Models;
using EBookPresenter.Repositories;
using EBookPresenter.Tests.Comparers;
using EBookPresenter.Tests.Fakes;
using EBookPresenter.Tests.TestHelpers;
using NUnit.Framework;

namespace EBookPresenter.Tests;

public class EBookRepositoryTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void EBookRepository_GetAllEBooksRecursive_Returns_All_Ebooks_In_The_Given_Path()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var result = ebookRepository.GetEbooksRecursive("folderDoesntMatter/");

        Assert.AreEqual(8, result.Count());
    }

    [Test]
    public void EBookRepository_OrderBooks_Alphabetic_Returns_Books_Ordered_By_Alphabetic_Order_Ascending()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var expected = new List<EBook>
        {
            new() { Title = "Title1" },
            new() { Title = "Title2" },
            new() { Title = "Title3" },
            new() { Title = "Title4" }
        };

        var unorderedBookList = CreateBookObjects.GetUnorderedEBookList();
        var result = ebookRepository.OrderBooks(unorderedBookList, "alphabetic");

        CollectionAssert.AreEqual(expected, result, new TitleComparer());
    }

    [Test]
    public void EBookRepository_OrderBooks_Created_Returns_Books_Ordered_By_Creation_Date_Ascending()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var unorderedBookList = CreateBookObjects.GetUnorderedEBookList().ToList();
        var expected = unorderedBookList.OrderByDescending(x => x.CreatedDate);

        var result = ebookRepository.OrderBooks(unorderedBookList, "creation");

        CollectionAssert.AreEqual(expected, result, new CreationDateComparer());
    }
}
