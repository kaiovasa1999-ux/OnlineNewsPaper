using Humanizer;

namespace OnlineNewsPaper.Data.Models
{
    public class NewsAd
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int NewsCategoryId { get; set; }

        public NewsCategory NewsCategory { get; set; }

        public int SpecificCategoryId { get; set; }

        public SpecificCategory SpecificCategory { get; set; }

        public string ClientId { get; set; }

        public ApplicationUser Client { get; set; }

        public DateTime CDate { get; set; }

        public int Likes { get; set; }

        public int Dislike { get; set; }

        public int Views { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public string Description { get; set; }

        public string ImageURL { get; set; }
    }
}
