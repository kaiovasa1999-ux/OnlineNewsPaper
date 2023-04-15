using OnlineNewsPaper.Data;

namespace OnlineNewsPaper.Services.Images
{
    public class ImagesService : IImagesService
    {
        private readonly ApplicationDbContext db;
        
        public ImagesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddImgToNewsAd(Guid id)
        {
            //this.db.Images.add
            //throw new NotImplementedException();
        }
    }
}
