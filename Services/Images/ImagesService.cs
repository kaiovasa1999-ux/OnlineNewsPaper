using OnlineNewsPaper.Data;
using OnlineNewsPaper.Data.Models;

namespace OnlineNewsPaper.Services.Images
{
    public class ImagesService : IImagesService
    {
        private readonly ApplicationDbContext db;
        
        public ImagesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task SaveCreatedImageAsync(Image input)
        {
            Image image = new Image();
            image.Id = input.Id.ToString();
            image.NewsAdId = input.NewsAdId;
            db.Images.Add(image);
            await db.SaveChangesAsync();
        }
    }
}
