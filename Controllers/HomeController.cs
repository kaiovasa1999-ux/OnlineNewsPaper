using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OnlineNewsPaper.Data;
using OnlineNewsPaper.Models;
using OnlineNewsPaper.Models.Home;
using OnlineNewsPaper.Services.Home;
using System.Diagnostics;

namespace OnlineNewsPaper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var statisticsData = await this.homeService.GetStatisticsData();

            var viewModel = new IndexViewModel()
            {
                TotalComments = statisticsData.TotalComments,
                TotalViews = statisticsData.TotalViews,
                NewsAdCount = statisticsData.NewsAdCount,
                CategoriesCount = statisticsData.CategoriesCount,
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