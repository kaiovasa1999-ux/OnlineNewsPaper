using Microsoft.EntityFrameworkCore;
using OnlineNewsPaper.Data;
using OnlineNewsPaper.Models.Home;
using OnlineNewsPaper.Services.DTOs;

namespace OnlineNewsPaper.Services.Home
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _db;
        public HomeService(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<IndexViewModelDTO> GetStatisticsData()
        {
            var indexViewModel = new IndexViewModelDTO();
            int totalviews = 0;
            int totalComments = 0;
            var newsAds = await _db.NewsAd.ToListAsync();
          
            foreach (var item in newsAds)
            {
                totalviews += item.Views;
                totalComments += item.Comments.Count();
            }

            indexViewModel.CategoriesCount = _db.NewsCategories.Count() + _db.SpecificCategories.Count();
            indexViewModel.TotalViews = totalviews;
            indexViewModel.NewsAdCount = _db.NewsAd.Count();
            indexViewModel.TotalComments = totalComments;

            return indexViewModel;
        }
    }
}
