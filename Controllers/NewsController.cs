using Microsoft.AspNetCore.Mvc;
using OnlineNewsPaper.Models.News;
using OnlineNewsPaper.Services.News;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;



namespace OnlineNewsPaper.Controllers
{
    public class NewsController : Controller
    {
        private const int DefaultCategoryId = 1;
        private readonly INewsAdService service;
        public NewsController(INewsAdService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var data = await service.GetNewsCategories();
            var viewModel = new CreateNewsAdInputModel();
            viewModel.NewsCategories = data.NewsCategories;
            viewModel.SpecificCategories = await service.GetSpecificCategories(DefaultCategoryId);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateNewsAdInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.NewsCategories =await this.service.GetMainCategories(inputModel.NewsCategoryId);
                inputModel.SpecificCategories = await this.service.GetSpecificCategories(inputModel.SpecificCategoryId);
                return this.View(inputModel);
            }

            await service.SaveToDatabaseAsync(inputModel);

            return RedirectToAction("Index", "Home");
        }

        [Route("/News/Create/GetSpecificCategoriesJSON/{mainCategorId}")]
        public JsonResult GetSpecificCategoriesJSON(int mainCategorId)
        {
            
            var items = service.RetunSpecificCategoriesJSON(mainCategorId);
            var res = JsonConvert.SerializeObject(items);
            return Json(res);
        }
    }
}
