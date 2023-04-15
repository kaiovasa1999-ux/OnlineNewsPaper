using OnlineNewsPaper.Data.Models;

namespace OnlineNewsPaper.Services.Images
{
    public interface IImagesService
    {
        public Task SaveCreatedImageAsync(Image input);
    }
}
