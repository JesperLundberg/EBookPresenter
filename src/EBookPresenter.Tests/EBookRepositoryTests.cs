using System.Linq;
using EBookPresenter.Repositories;
using EBookPresenter.Tests.Fakes;
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
        public void GetAllEBooksRecursive_Returns_All_Ebooks_In_The_Given_Path()
        {
            var ebookRepository = new EBookRepository(new FileSystemFake(), new FileInfoFactoryFake());

            var result = ebookRepository.GetEbooksRecursive("folderDoesntMatter/");
            
            Assert.AreEqual(8, result.Count());
        }
    }
}