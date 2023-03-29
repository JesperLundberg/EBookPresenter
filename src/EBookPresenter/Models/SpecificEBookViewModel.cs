namespace EBookPresenter.Models;

public class SpecificEBookViewModel
{
    public string Title => System.IO.Path.GetFileName(Path);
    public string Path { get; set; }
}
