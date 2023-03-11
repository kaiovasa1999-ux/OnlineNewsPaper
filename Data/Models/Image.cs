namespace OnlineNewsPaper.Data.Models
{
    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public int ApplicationUserID { get; set; }

        public ApplicationUser User { get; set; }

        public string Extension { get; set; }

        public int NewsAdId { get; set; }
        
        public NewsAd NewsAd { get; set; }
    }
}
