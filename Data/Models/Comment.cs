namespace OnlineNewsPaper.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string Description { get; set; }

        public int Likes { get; set; }

        public int NewsAdId { get; set; }

        public NewsAd NewsAd { get; set; }

        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}