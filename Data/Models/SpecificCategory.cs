namespace OnlineNewsPaper.Data.Models
{
    public class SpecificCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NewsCategoryId { get; set; }

        public NewsCategory NewsCategory { get; set; }

        public IEnumerable<NewsAd> NewsAds { get; set; } = new List<NewsAd>();
    }
}