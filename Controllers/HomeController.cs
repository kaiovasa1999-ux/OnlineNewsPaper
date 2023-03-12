using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineNewsPaper.Data;
using OnlineNewsPaper.Models;
using OnlineNewsPaper.Models.Home;
using System.Diagnostics;

namespace OnlineNewsPaper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            var newsAds = _db.NewsAd.ToList();
            int totalviews = 0;

            foreach (var item in newsAds)
            {
                totalviews += item.Views;
            }

            var viewModel = new IndexViewModel
            {
                CategoriesCount = _db.NewsCategories.Count() + _db.SpecificCategories.Count(),
                TotalViews = totalviews,
                NewsAdCount = _db.NewsAd.Count(),
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