using Microsoft.AspNetCore.Mvc;
using OnlineNewsPaper.Models.News;
using OnlineNewsPaper.Services.News;
using System.Web;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using OnlineNewsPaper.Data.Models;

namespace OnlineNewsPaper.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsAdService service;
        public NewsController(INewsAdService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var data = await service.GetNewsCategories();
            var view = new CreateNewsAdInputModel()
            {
                Title = data.Title,
                Description = data.Description,
                NewsCategories = data.NewsCategories,
            };

            return this.View(view);
        }

        [HttpPost]
        public IActionResult Create(CreateNewsAdInputModel inputModel)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }
            //add via service method (crete service)
            //TODO: Save data
            return this.RedirectToAction("/");
        }

        [Route("/News/Create/GetSpecificCategories/{mainCategorId}")]
        public JsonResult GetSpecificCategories(int mainCategorId)
        {
            var items = service.GetSpecficCategoires(mainCategorId);
            var res = JsonConvert.SerializeObject(items);
            return Json(res);
        }
    }
}
