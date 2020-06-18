using EBookPresenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookPresenter.Controllers
{
    public class SpecificEBookController : Controller
    {
        public IActionResult Index(string path)
        {
            var viewModel = new SpecificEBookViewModel
            {
                Path = path
            };

            return View(viewModel);
        }

        [HttpPost]
        public PhysicalFileResult GetBook(SpecificEBookViewModel eBookViewModel)
        {
             var fileToReturn = new PhysicalFileResult(eBookViewModel.Path, "application/text")
            {
                FileDownloadName = eBookViewModel.Title
            };

            return fileToReturn;
        }
    }
}