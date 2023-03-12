using AutoMapper;
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
        private readonly IMapper mapper;

        public HomeController(IHomeService homeService,IMapper mapper)
        {
            this.homeService = homeService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var viewResult = await this.homeService.GetStatisticsData();

            var viewModel = mapper.Map<IndexViewModel>(viewResult);
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