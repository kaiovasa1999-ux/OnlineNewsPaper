using Microsoft.AspNetCore.Mvc;
using OnlineNewsPaper.Data;
using OnlineNewsPaper.Models.News;
using OnlineNewsPaper.Services.News;

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
    }
}
