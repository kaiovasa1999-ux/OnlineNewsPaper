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
        public async Task<IActionResult> Create()
        {
            var data = await service.GetNewsCategories();
            var viewModel = new CreateNewsAdInputModel();
            viewModel.NewsCategories = data.NewsCategories;
            viewModel.SpecificCategories = service.GetSpecificCategories(DefaultCategoryId);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsAdInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.NewsCategories = this.service.GetMainCategories(inputModel.NewsCategoryId);
                inputModel.SpecificCategories = this.service.GetSpecificCategories(inputModel.SpecificCategoryId);
                return this.View(inputModel);
            }


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
