using OnlineNewsPaper.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace OnlineNewsPaper.Models.News
{
    public class CreateNewsAdInputModel
    {
        public string Title { get; set; }

        public int NewsCategoryId { get; set; }

        public ICollection<NewsCategory> NewsCategories { get; set; }

        public string Description { get; set; }

        public ICollection<SpecificCategory> SpecificCategories { get; set; }

        public int SpecificCategoryId { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
