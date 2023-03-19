using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineNewsPaper.Data;
using OnlineNewsPaper.Data.Models;

namespace OnlineNewsPaper.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public CategoriesApiController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet] 
        public ActionResult<IEnumerable<NewsCategory>> Get()
        {
            return this.db.NewsCategories.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<NewsCategory> Get(int id)
        {
            var newsCategory =this.db.NewsCategories.SingleOrDefault(c => c.Id == id);
            if(newsCategory == null)
            {
                return NotFound();
            }
            return newsCategory;
        }
        [HttpPost]
        public async Task<ActionResult> Post(NewsCategory newsCategory)
        {
            await this.db.NewsCategories.AddAsync(newsCategory);
            await this.db.SaveChangesAsync();

            return this.CreatedAtAction("Get", new { newsCategory.Id }, newsCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await this.db.NewsCategories.FirstOrDefaultAsync(c => c.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            this.db.Remove(category); 
            await this.db.SaveChangesAsync();
            return NoContent();
        }
    }
}
