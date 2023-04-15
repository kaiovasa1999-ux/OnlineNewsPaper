using Microsoft.EntityFrameworkCore;
using OnlineNewsPaper.Data;
using OnlineNewsPaper.Data.Models;
using OnlineNewsPaper.Models.Home;
using OnlineNewsPaper.Models.News;
using OnlineNewsPaper.Services.Images;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineNewsPaper.Services.News
{
    public class NewsAdService : INewsAdService
    {
        private readonly ApplicationDbContext db;
        private readonly IImagesService imagesService;

        public NewsAdService(ApplicationDbContext db, IImagesService imagesService)
        {
            this.db = db;
            this.imagesService = imagesService;
        }

        public async Task<CreateNewsAdInputModel> GetNewsCategories()
        {
            CreateNewsAdInputModel inputModel = new CreateNewsAdInputModel();
            var categories = await db.NewsCategories.ToListAsync();
            inputModel.NewsCategories = categories;

            return inputModel;
        }

        public ICollection<SpecificCategory> RetunSpecificCategoriesJSON(int mainCategoryId)
        {
           return  db.SpecificCategories.Where(c => c.NewsCategoryId == mainCategoryId).Select(x => new SpecificCategory
           {
               Id = x.Id,
               NewsCategoryId = mainCategoryId,
               Name = x.Name,
           }).ToList();
        }

        public async Task<ICollection<SpecificCategory>> GetSpecificCategories(int mainCategoryId)
        {
            return await this.db.SpecificCategories.Where(c => c.NewsCategoryId == mainCategoryId).Select(x => new SpecificCategory()
            {
                Id= x.Id,
                Name = x.Name,
                NewsCategoryId = mainCategoryId
            }).ToListAsync();
        }

        public async Task<ICollection<NewsCategory>> GetMainCategories(int id)
        {
            return await this.db.NewsCategories.Where(c => c.Id == id).ToListAsync();
        }

        public async Task SaveToDatabaseAsync(CreateNewsAdInputModel inputModel)
        {
            var adImage = new OnlineNewsPaper.Data.Models.Image();
            var ad = new NewsAd();

            ad.CDate = DateTime.Now;
            ad.Title = inputModel.Title;
            ad.Description = inputModel.Description;
            ad.NewsCategoryId = inputModel.NewsCategoryId;
            ad.SpecificCategoryId = inputModel.SpecificCategoryId;
            ad.Comments = new List<Comment>();
            foreach (var img in inputModel.Images)
            {
                var fileIdAndName = Guid.NewGuid().ToString() + '/' + Path.GetExtension(img.FileName);
                adImage.Id = fileIdAndName;
                adImage.NewsAdId = ad.Id;
                ad.Images.Add(adImage);
                await imagesService.SaveCreatedImageAsync(adImage);
            }

            await this.db.NewsAd.AddAsync(ad);
            await this.db.SaveChangesAsync();
        }
    }
}
