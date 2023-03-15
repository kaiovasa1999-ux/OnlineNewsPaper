using OnlineNewsPaper.Data.Models;
using OnlineNewsPaper.Models.Home;
using OnlineNewsPaper.Models.News;

namespace OnlineNewsPaper.Services.News
{
    public interface INewsAdService
    {
        public Task<CreateNewsAdInputModel> GetNewsCategories();

        public Task<ICollection<SpecificCategory>> GetSpecficCategoires(int mainCategoryId);
        
    }
}
