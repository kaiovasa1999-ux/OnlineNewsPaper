using OnlineNewsPaper.Data.Models;
using OnlineNewsPaper.Models.Home;
using OnlineNewsPaper.Models.News;

namespace OnlineNewsPaper.Services.News
{
    public interface INewsAdService
    {
        public Task<CreateNewsAdInputModel> GetNewsCategories();

        public ICollection<SpecificCategory> RetunSpecificCategoriesJSON(int mainCategoryId);
        
        public Task<ICollection<SpecificCategory>> GetSpecificCategories(int mainCategoryId);

        public Task<ICollection<NewsCategory>> GetMainCategories(int id);

        public void CretaeAsync(CreateNewsAdInputModel inputModel);
        
    }
}
