using OnlineNewsPaper.Models.Home;

namespace OnlineNewsPaper.Services.Home
{
    public interface IHomeService
    {
        public Task<IndexViewModel> GetStatisticsData(IndexViewModel indexViewModel);
    }
}
