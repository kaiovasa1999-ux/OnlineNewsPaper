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

        [HttpGet]
        public async Task<IActionResult> Index(IndexViewModel view)
        {
            var result = await _homeService.GetStatisticsData(view);
            return View(result);
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