using System.Collections.Generic;
using System.Linq;
using EBookPresenter.Models;
using EBookPresenter.Repositories;
using EBookPresenter.Tests.Comparers;
using EBookPresenter.Tests.Fakes;
using EBookPresenter.Tests.TestHelpers;
using NUnit.Framework;

namespace EBookPresenter.Tests
{
    public class EBookRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EBookRepository_GetAllEBooksRecursive_Returns_All_Ebooks_In_The_Given_Path()
        {
            var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

            var result = ebookRepository.GetEbooksRecursive("folderDoesntMatter/");
            
            Assert.AreEqual(8, result.Count());
        }

        [Test]
        public void EBookRepository_OrderBooks_Alphabetic_Returns_Books_Ordered_By_Alphabetic_Order()
        {
            var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

            var unorderedBookList = CreateBookObjects.GetUnorderedEBookList();

            var expected = new List<EBook>
            {
                new EBook {Title = "Title1"},
                new EBook {Title = "Title2"},
                new EBook {Title = "Title3"},
                new EBook {Title = "Title4"}
            };
            
            var result = ebookRepository.OrderBooks(unorderedBookList, "alphabetic");
            
            CollectionAssert.AreEqual(expected, result, new TitleComparer());
        }
    }
}