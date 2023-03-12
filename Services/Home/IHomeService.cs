using OnlineNewsPaper.Models.Home;
using OnlineNewsPaper.Services.DTOs;

namespace OnlineNewsPaper.Services.Home
{
    public interface IHomeService
    {
        public Task<IndexViewModelDTO> GetStatisticsData();
    }
}
