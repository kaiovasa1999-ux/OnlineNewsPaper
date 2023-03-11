using Microsoft.AspNetCore.Identity;

namespace OnlineNewsPaper.Data.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<NewsAd> NewsAds { get; set; } = new List<NewsAd>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}