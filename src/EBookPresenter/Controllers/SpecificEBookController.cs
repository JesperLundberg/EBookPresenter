using Microsoft.AspNetCore.Mvc;

namespace EBookPresenter.Controllers;

public class SpecificEBookController(IConfiguration configuration) : Controller
{
    private readonly IConfiguration _configuration = configuration;

    public IActionResult Index(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return BadRequest("No path specified.");
        }

        var viewModel = new SpecificEBookViewModel { Path = path };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult GetBook(SpecificEBookViewModel eBookViewModel)
    {
        var folderToRead = _configuration
            .GetSection("AppSettings")
            .GetSection("FolderToRead")
            .Value;

        if (string.IsNullOrEmpty(folderToRead))
        {
            return Problem("EBook folder is not configured.");
        }

        var fullBookPath = Path.GetFullPath(eBookViewModel.Path);
        var fullFolderPath = Path.GetFullPath(folderToRead);

        if (!fullBookPath.StartsWith(fullFolderPath, StringComparison.Ordinal))
        {
            return Forbid();
        }

        if (!System.IO.File.Exists(fullBookPath))
        {
            return NotFound();
        }

        var fileToReturn = new PhysicalFileResult(fullBookPath, "application/epub+zip")
        {
            FileDownloadName = string.IsNullOrEmpty(eBookViewModel.Title)
                ? Path.GetFileName(fullBookPath)
                : eBookViewModel.Title,
        };

        return fileToReturn;
    }
}
