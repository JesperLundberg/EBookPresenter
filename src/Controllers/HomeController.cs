using System.Diagnostics;
using EBookPresenter.Models;
using EBookPresenter.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EBookPresenter.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> Logger { get; }
        private IEBookRepository EBookRepository { get; }

        public HomeController(ILogger<HomeController> logger, IEBookRepository eBookRepository)
        {
            Logger = logger;
            EBookRepository = eBookRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new EBookViewModel {EBooks = EBookRepository.GetAllEbooks()};

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}