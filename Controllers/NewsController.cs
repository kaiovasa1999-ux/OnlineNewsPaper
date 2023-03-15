using Microsoft.AspNetCore.Mvc;
using OnlineNewsPaper.Models.News;
using OnlineNewsPaper.Services.News;
using System.Web;
using Newtonsoft.Json;

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


        public async Task<JsonResult> GetSpecificCategories(int mainCategorId)
        {
            var ListCategories = await service.GetSpecficCategoires(mainCategorId);
            var json = JsonConvert.SerializeObject(ListCategories);
            return Json(json);
        }
    }
}
