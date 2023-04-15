using OnlineNewsPaper.Data.Models;
using OnlineNewsPaper.Models.Home;
using OnlineNewsPaper.Models.News;

namespace OnlineNewsPaper.Services.News
{
    public interface INewsAdService
    {
        public Task<CreateNewsAdInputModel> GetNewsCategories();

        public ICollection<SpecificCategoryiesAJAXModel> RetunSpecificCategoriesJSON(int mainCategoryId);
        
        public ICollection<SpecificCategoryiesAJAXModel> GetSpecificCategories(int mainCategoryId);

        public ICollection<NewsCategory> GetMainCategories(int id);
        
    }
}
