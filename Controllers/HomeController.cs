using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineNewsPaper.Data;
using OnlineNewsPaper.Models;
using OnlineNewsPaper.Models.Home;
using OnlineNewsPaper.Services.Home;
using System.Diagnostics;

namespace OnlineNewsPaper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            this._homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var viewResult = await _homeService.GetStatisticsData();

            var viewModel = new IndexViewModel
            {
                CategoriesCount = viewResult.CategoriesCount,
                TotalComments = viewResult.TotalComments,
                TotalViews = viewResult.TotalViews,
                NewsAdCount = viewResult.NewsAdCount,
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}