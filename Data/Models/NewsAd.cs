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

        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public DateTime CDate { get; set; }

        public int Likes { get; set; }

        public int Dislike { get; set; }

        public int Views { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public string Description { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
