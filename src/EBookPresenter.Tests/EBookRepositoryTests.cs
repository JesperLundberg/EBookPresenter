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

        Assert.That(result.Count(), Is.EqualTo(8));
    }

    [Test]
    public void EBookRepository_GetEbooksRecursive_Returns_Empty_When_Folder_Is_Null()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var result = ebookRepository.GetEbooksRecursive(null!);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void EBookRepository_GetEbooksRecursive_Returns_Empty_When_Folder_Is_Empty_String()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var result = ebookRepository.GetEbooksRecursive(string.Empty);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void EBookRepository_GetEbooksRecursive_Returns_Empty_When_Folder_Does_Not_Exist()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var result = ebookRepository.GetEbooksRecursive("nonExistentFolder/");

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void EBookRepository_GetAllEbooks_Returns_Ebooks_With_Fixed_Path_Separators()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var result = ebookRepository.GetAllEbooks("folderDoesntMatter/", "alphabetic");

        Assert.That(result, Is.Not.Empty);
        Assert.That(result.All(x => !x.Path.Contains('\\')), Is.True);
    }

    [Test]
    public void EBookRepository_GetAllEbooks_Returns_Ebooks_Ordered_By_Alphabetic_Order()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var result = ebookRepository.GetAllEbooks("folderDoesntMatter/", "alphabetic").ToList();

        var orderedTitles = result.Select(x => x.Title).ToList();
        var expectedTitles = orderedTitles.OrderBy(x => x).ToList();

        Assert.That(orderedTitles, Is.EqualTo(expectedTitles));
    }

    [Test]
    public void EBookRepository_GetAllEbooks_Returns_Ebooks_Ordered_By_Creation_Date_When_Sort_Order_Is_Creation()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var result = ebookRepository.GetAllEbooks("folderDoesntMatter/", "creation").ToList();

        var orderedDates = result.Select(x => x.CreatedDate).ToList();
        var expectedDates = orderedDates.OrderByDescending(x => x).ToList();

        Assert.That(orderedDates, Is.EqualTo(expectedDates));
    }

    [Test]
    public void EBookRepository_GetAllEbooks_Returns_Title_As_File_Name()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var result = ebookRepository.GetAllEbooks("folderDoesntMatter/", "alphabetic");

        Assert.That(result.All(x => !string.IsNullOrEmpty(x.Title)), Is.True);
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
            new() { Title = "Title4" },
        };

        var unorderedBookList = CreateBookObjects.GetUnorderedEBookList();
        var result = ebookRepository.OrderBooks(unorderedBookList, "alphabetic");

        Assert.That(result, Is.EqualTo(expected).Using(new TitleComparer()));
    }

    [Test]
    public void EBookRepository_OrderBooks_Created_Returns_Books_Ordered_By_Creation_Date_Ascending()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var unorderedBookList = CreateBookObjects.GetUnorderedEBookList().ToList();
        var expected = unorderedBookList.OrderByDescending(x => x.CreatedDate);

        var result = ebookRepository.OrderBooks(unorderedBookList, "creation");

        Assert.That(result, Is.EqualTo(expected).Using(new CreationDateComparer()));
    }

    [Test]
    public void EBookRepository_OrderBooks_Returns_Alphabetic_Order_As_Default_When_Sort_Order_Is_Unrecognized()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var expected = new List<EBook>
        {
            new() { Title = "Title1" },
            new() { Title = "Title2" },
            new() { Title = "Title3" },
            new() { Title = "Title4" },
        };

        var unorderedBookList = CreateBookObjects.GetUnorderedEBookList();
        var result = ebookRepository.OrderBooks(unorderedBookList, "unrecognizedSortOrder");

        Assert.That(result, Is.EqualTo(expected).Using(new TitleComparer()));
    }

    [Test]
    public void EBookRepository_OrderBooks_Returns_Empty_When_Input_Is_Empty()
    {
        var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

        var result = ebookRepository.OrderBooks([], "alphabetic");

        Assert.That(result, Is.Empty);
    }
}
