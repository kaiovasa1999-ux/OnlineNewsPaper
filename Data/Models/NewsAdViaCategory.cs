namespace OnlineNewsPaper.Data.Models
{
    public class NewsAdViaCategory
    {
        public int Id { get; set; }

        public int NewsAdID { get; set; }

        public NewsAd NewsAd { get; set; }

        public int CategoryId { get; set; }

        public NewsCategory Category { get; set; }
    }
}
