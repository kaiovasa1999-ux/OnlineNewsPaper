﻿using Microsoft.EntityFrameworkCore;
using OnlineNewsPaper.Data;
using OnlineNewsPaper.Data.Models;
using OnlineNewsPaper.Models.Home;
using OnlineNewsPaper.Models.News;

namespace OnlineNewsPaper.Services.News
{
    public class NewsAdService : INewsAdService
    {
        private readonly ApplicationDbContext db;

        public NewsAdService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<CreateNewsAdInputModel> GetNewsCategories()
        {
            CreateNewsAdInputModel inputModel = new CreateNewsAdInputModel();
            var categories = await db.NewsCategories.ToListAsync();
            inputModel.NewsCategories = categories;
            inputModel.Title = "";
            inputModel.Description = "";

            return inputModel;
        }

        public ICollection<SpecificCategory> GetSpecficCategoires(int mainCategoryId)
        {
           return  db.SpecificCategories.Where(c => c.NewsCategoryId == mainCategoryId).Select(x => new SpecificCategory
           {
               Id = x.Id,
               Name = x.Name,
           }).ToList();
        }

    }
}