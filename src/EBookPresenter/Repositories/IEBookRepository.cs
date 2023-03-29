namespace EBookPresenter.Repositories;

public interface IEBookRepository
{
    IEnumerable<EBook> GetAllEbooks(string folderToRead,
        string sortOrder);
}
