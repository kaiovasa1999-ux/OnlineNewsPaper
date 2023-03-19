using Microsoft.AspNetCore.Mvc;
using OnlineNewsPaper.Data;
using OnlineNewsPaper.Data.Models;

namespace OnlineNewsPaper.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewAdApiController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public NewAdApiController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<NewsAd> GetNewsAd()
        {
            var newsAd = new NewsAd
            {
                Title = "kaivoasa",
                Dislike = 3,
                Likes = 4,
            };

            return newsAd;
        }
    }
}
