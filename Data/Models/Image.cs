namespace OnlineNewsPaper.Data.Models
{
    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public int NewsAdId { get; set; }
    }
}
