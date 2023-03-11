using Humanizer;

namespace OnlineNewsPaper.Data.Models
{
    public class NewsCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<NewsAd> NewsAds { get; set; } = new List<NewsAd>();

        public IEnumerable<SpecificCategory> SpecificCategories { get; set; } = new List<SpecificCategory>();
    }
}