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
            var view = new CreateNewsAdInputModel()
            {
                Title = data.Title,
                Description = data.Description,
                NewsCategories = data.NewsCategories,
                NewsCategoryId = DefaultCategoryId,
                SpecificCategories = service.GetSpecificCategories(DefaultCategoryId),
            };

            return this.View(view);
        }

        [HttpPost]
        public IActionResult Create(CreateNewsAdInputModel inputModel)
        {
            inputModel.NewsCategories = service.GetMainCategories(inputModel.NewsCategoryId);
            inputModel.SpecificCategories = service.GetSpecificCategories(inputModel.NewsCategoryId);

            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }
            
            //add via service method (crete service)
            //TODO: Save data
            return this.RedirectToAction("/");
        }


        [Route("/News/Create/RetunSpecificCategoriesAsJSON/{mainCategorId}")]
        public JsonResult RetunSpecificCategoriesAsJSON(int mainCategorId)
        {
            
            var items = service.RetunSpecificCategoriesJSON(mainCategorId);
            var res = JsonConvert.SerializeObject(items);
            return Json(res);
        }
    }
}
