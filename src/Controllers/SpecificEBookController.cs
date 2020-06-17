using System.IO;
using EBookPresenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookPresenter.Controllers
{
    public class SpecificEBookController : Controller
    {
        // GET
        public IActionResult Index(string path)
        {
            var viewModel = new SpecificEBookViewModel {EBook = new EBook
            {
                Title = Path.GetFileName(path),
                Path = path
            }};
            
            return View(viewModel);
        }
    }
}