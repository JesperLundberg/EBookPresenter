using System;
using System.Diagnostics;
using EBookPresenter.Models;
using EBookPresenter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventSource;
using Microsoft.Net.Http.Headers;

namespace EBookPresenter.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> Logger { get; }
        private IEBookRepository EBookRepository { get; }
        private IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration ,ILogger<HomeController> logger, IEBookRepository eBookRepository)
        {
            Configuration = configuration;
            Logger = logger;
            EBookRepository = eBookRepository;
        }

        public IActionResult Index()
        {
            //read cookie from Request object  
            var sortOrder = Request.Cookies["SortOrder"];

            var folderToRead = Configuration.GetSection("AppSettings").GetSection("FolderToRead").Value;

            var viewModel = new EBookViewModel
                {EBooks = EBookRepository.GetAllEbooks(folderToRead, sortOrder), SortOrder = sortOrder};

            return View(viewModel);
        }

        public RedirectToActionResult ToggleSortOrder()
        {
            var sortOrder = Request.Cookies["SortOrder"];

            if (string.IsNullOrEmpty(sortOrder) || sortOrder.Equals("alphabetic"))
            {
                SetCookie("SortOrder", "creation", 365);
            }
            else
            {
                SetCookie("SortOrder", "alphabetic", 365);
            }

            return RedirectToAction("Index");
        }

        private void SetCookie(string key, string value, int? expireTimeDays)
        {
            var option = new CookieOptions();

            if (expireTimeDays.HasValue)
            {
                option.Expires = DateTime.Now.AddDays(expireTimeDays.Value);
            }
            else
            {
                option.Expires = DateTime.Now.AddDays(10);
            }

            Response.Cookies.Append(key, value, option);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}